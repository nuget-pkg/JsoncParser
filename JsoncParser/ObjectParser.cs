using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Global;

public interface IObjectWrapper
{
    public object UnWrap();
}

public class RedundantObject
{
}

internal static class ObjectParserUtil
{
    public static string GetMemberName(MemberInfo member)
    {
        if (member.IsDefined(typeof(DataMemberAttribute), true))
        {
            var dataMemberAttribute = (DataMemberAttribute)Attribute.GetCustomAttribute(member, typeof(DataMemberAttribute), true);
            if (!string.IsNullOrEmpty(dataMemberAttribute!.Name))
                return dataMemberAttribute.Name;
        }

        return member.Name;
    }

}
public class ObjectParser: IObjectConverter
{
    public object ConvertResult(object x, string origTypeName) // IObjectConverter
    {
        return x;
    }

    private readonly bool forceAscii;
    IObjectConverter oc;
    public ObjectParser(bool forceAscii = false, IObjectConverter oc = null)
    {
        this.forceAscii = forceAscii;
        if (oc == null) oc = this;
        this.oc = oc;
    }
    public static string ToPrintable(bool showDetail, object x, string title = null)
    {
        ObjectParser op = new ObjectParser(false);
        if (x is IObjectWrapper)
        {
            x = ((IObjectWrapper)x).UnWrap();
        }
        string s = "";
        if (title != null) s = title + ": ";
        if (x is null) return s + "null";
        if (x is string)
        {
            if (!showDetail) return s + (string)x;
            return s + "`" + (string)x + "`";
        }
        string output = null;
        try
        {
            output = op.Stringify(x, true);
        }
        catch (Exception)
        {
            output = x.ToString();
        }
        if (!showDetail) return s + output;
        return s + $"<{FullName(x)}> {output}";
    }
    // ReSharper disable once MemberCanBePrivate.Global
    public static string FullName(dynamic x)
    {
        if (x is null) return "null";
        string fullName = ((object)x).GetType().FullName;
        return fullName!.Split('`')[0];
    }
    public object Parse(object x, bool numberAsDecimal = false)
    {
        string origTypeName = FullName(x);
        if (x is IObjectWrapper)
        {
            x = ((IObjectWrapper)x).UnWrap();
        }

        if (x == null)
        {
            return oc.ConvertResult(null, origTypeName);
        }

        if (x is IObjectWrapper)
        {
            x = ((IObjectWrapper)x).UnWrap();
        }

        Type type = x.GetType();
        if (type == typeof(string) || type == typeof(char))
        {
            return oc.ConvertResult(x.ToString(), origTypeName);
        }
        else if (type == typeof(byte) || type == typeof(sbyte)
            || type == typeof(short) || type == typeof(ushort)
            || type == typeof(int) || type == typeof(uint)
            || type == typeof(long) || type == typeof(ulong)
            || type == typeof(float)
            || type == typeof(double)
            || type == typeof(decimal))
        {
            if (numberAsDecimal)
                return oc.ConvertResult(Convert.ToDecimal(x), origTypeName);
            return oc.ConvertResult(Convert.ToDouble(x), origTypeName);
        }
        else if (type == typeof(bool))
        {
            return oc.ConvertResult(x, origTypeName);
        }
        else if (type == typeof(DateTime))
        {
            DateTime dt = (DateTime)x;
            switch (dt.Kind)
            {
                case DateTimeKind.Local:
                    return oc.ConvertResult(dt.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"), origTypeName);
                case DateTimeKind.Utc:
                    return oc.ConvertResult(dt.ToString("o"), origTypeName);
                default:
                    return oc.ConvertResult(dt.ToString("o").Replace("Z", ""), origTypeName);
            }
        }
        else if (type == typeof(TimeSpan))
        {
            return oc.ConvertResult(x.ToString(), origTypeName);
        }
        else if (type == typeof(Guid))
        {
            return oc.ConvertResult(x.ToString(), origTypeName);
        }
        else if (type.IsEnum)
        {
            return oc.ConvertResult(x.ToString(), origTypeName);
        }
        else if (x is ExpandoObject)
        {
            var dic = x as IDictionary<string, object>;
            var result = new Dictionary<string, object>();
            foreach (var key in dic.Keys)
            {
                result[key] = Parse(dic[key], numberAsDecimal);
            }
            return oc.ConvertResult(result, origTypeName);
        }
        else if (x is IList)
        {
            IList list = x as IList;
            var result = new List<object>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(Parse(list[i], numberAsDecimal));
            }
            return oc.ConvertResult(result, origTypeName);
        }
        else if (x is Hashtable)
        {
            Hashtable ht = x as Hashtable;
            var result = new Dictionary<string, object>();
            foreach (object key in ht.Keys)
            {
                if (!(key is string)) continue;
                result.Add((string)key, Parse(ht[key], numberAsDecimal));
            }
            return oc.ConvertResult(result, origTypeName);
        }
        else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            Type keyType = type.GetGenericArguments()[0];
            var result = new Dictionary<string, object>();
            //Refuse to output dictionary keys that aren't of type string
            if (keyType != typeof(string))
            {
                return oc.ConvertResult(result, origTypeName);
            }
            IDictionary dict = x as IDictionary;
            foreach (object key in dict.Keys)
            {
                result[(string)key] = Parse(dict[key], numberAsDecimal);
            }
            return oc.ConvertResult(result, origTypeName);
        }
        else if (x is IEnumerable)
        {
            IEnumerable enumerable = (IEnumerable)x;
            var result = new List<object>();
            IEnumerator e = enumerable.GetEnumerator();
            while (e.MoveNext())
            {
                object o = e.Current;
                result.Add(Parse(o, numberAsDecimal));
            }
            return oc.ConvertResult(result, origTypeName);
        }
        else
        {
            var result = new Dictionary<string, object>();
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                if (fieldInfos[i].IsDefined(typeof(IgnoreDataMemberAttribute), true))
                    continue;
                object value = fieldInfos[i].GetValue(x);
                result[ObjectParserUtil.GetMemberName(fieldInfos[i])] = Parse(value);
            }
            PropertyInfo[] propertyInfo = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (!propertyInfo[i].CanRead || propertyInfo[i].IsDefined(typeof(IgnoreDataMemberAttribute), true))
                    continue;
                object value = propertyInfo[i].GetValue(x, null);
                result[ObjectParserUtil.GetMemberName(propertyInfo[i])] = Parse(value);
            }
            return oc.ConvertResult(result, origTypeName);
        }
    }
    public string Stringify(object x, bool indent, bool sort_keys = false)
    {
        StringBuilder sb = new StringBuilder();
        new _JsonStringBuilder(this.forceAscii, indent, sort_keys).WriteToSb(sb, x, 0);
        string json = sb.ToString();
        return json;
    }
}

internal class _JsonStringBuilder
{
    private readonly bool forceAscii = false;
    private readonly bool indentJson = false;
    private readonly bool sortKeys = false;
    public _JsonStringBuilder(bool forceAscii, bool indentJson, bool sortKeys)
    {
        this.forceAscii = forceAscii;
        this.indentJson = indentJson;
        this.sortKeys = sortKeys;
    }

    private void Indent(StringBuilder sb/*, bool indent*/, int level)
    {
        if (this.indentJson)
        {
            for (int i = 0; i < level; i++)
            {
                sb.Append("  ");
            }
        }
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public static Type GetGenericIDictionaryType(Type type)
    {
        if (type == null) return null;
        var ifs = type.GetInterfaces();
        foreach (var i in ifs)
        {
            if (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(System.Collections.Generic.IDictionary<,>))
            {
                return i;
            }
        }
        return null;
    }

    private void WriteProcessGenericIDictionaryToSb<T>(StringBuilder sb, System.Collections.Generic.IDictionary<string, T> dict/*, bool indent*/, int level)
    {
        sb.Append("{");
        int count = 0;
#if false
        var keys = from a in dict.Keys
                       orderby a
                       select a;
#else
        var keys = from a in dict.Keys select a;
        if (this.sortKeys)
            keys = from a in dict.Keys orderby a select a;
#endif
        foreach (string key in keys/*dict.Keys*/)
        {
            if (count == 0 && this.indentJson) sb.Append('\n');
            if (count > 0)
            {
                sb.Append(",");
                if (this.indentJson) sb.Append('\n');
            }
            WriteToSb(sb, (string)key, level + 1);
            sb.Append(this.indentJson ? ": " : ":");
            WriteToSb(sb, dict[key], level + 1, true);
            count++;
        }
        if (count > 0 && this.indentJson)
        {
            sb.Append('\n');
            Indent(sb, level);
        }
        sb.Append("}");
    }
    public void WriteToSb(StringBuilder sb, object x/*, bool indent*/, int level, bool cancelIndent = false)
    {
        if (!cancelIndent) Indent(sb, level);

        if (x is IObjectWrapper)
        {
            x = ((IObjectWrapper)x).UnWrap();
        }

        if (x == null)
        {
            sb.Append("null");
            return;
        }

        Type type = x.GetType();
        if (type == typeof(string) || type == typeof(char))
        {
            string str = x.ToString();
            sb.Append('"');
            sb.Append(Escape(str));
            sb.Append('"');
            return;
        }
        if (type == typeof(byte) || type == typeof(sbyte)
            || type == typeof(short) || type == typeof(ushort)
            || type == typeof(int) || type == typeof(uint)
            || type == typeof(long) || type == typeof(ulong)
            || type == typeof(float)
            || type == typeof(double)
            || type == typeof(decimal))
        {
            sb.Append(x.ToString());
            return;
        }
        else if (type == typeof(bool))
        {
            sb.Append(x.ToString().ToLower());
            return;
        }
        else if (type == typeof(DateTime))
        {
            DateTime dt = (DateTime)x;
            switch(dt.Kind)
            {
                case DateTimeKind.Local:
                    WriteToSb(sb, dt.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz"), level, cancelIndent);
                    break;
                case DateTimeKind.Utc:
                    WriteToSb(sb, dt.ToString("o"), level, cancelIndent);
                    break;
                default: //case DateTimeKind.Unspecified:
                    WriteToSb(sb, dt.ToString("o").Replace("Z", ""), level, cancelIndent);
                    break;
            }
            return;
        }
        else if (type == typeof(TimeSpan))
        {
            WriteToSb(sb, x.ToString(), level, cancelIndent);
            return;
        }
        else if (type == typeof(Guid))
        {
            WriteToSb(sb, x.ToString(), level, cancelIndent);
            return;
        }
        else if (type.IsEnum)
        {
            WriteToSb(sb, x.ToString(), level, cancelIndent);
            return;
        }
        else if (x is ExpandoObject)
        {
            var dic = x as IDictionary<string, object>;
            var result = new Dictionary<string, object>();
            foreach (var key in dic.Keys)
            {
                result[key] = dic[key];
            }
            WriteToSb(sb, result, level, cancelIndent);
            return;
        }
        else if (x is IList)
        {
            IList list = x as IList;
            if (list.Count == 0)
            {
                sb.Append("[]");
                return;
            }
            sb.Append('[');
            if (this.indentJson) sb.Append('\n');
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                    if (this.indentJson) sb.Append('\n');
                }
                WriteToSb(sb, list[i], level + 1);
            }
            if (this.indentJson) sb.Append('\n');
            Indent(sb, level);
            sb.Append(']');
            return;
        }
        else if (x is Hashtable)
        {
            Hashtable ht = x as Hashtable;
            sb.Append("{");
            int count = 0;
            var keys = new List<object>();
            foreach (object key in ht.Keys)
            {
                keys.Add(key);
            }
#if false
            keys = keys.Where(x => x is string).OrderBy(x => x as string).ToList();
#else
            keys = keys.Where(x => x is string).ToList();
            if (this.sortKeys)
                keys = keys.OrderBy(x => x as string).ToList();
#endif
            foreach (object key in keys/*ht.Keys*/)
            {
                //if (!(key is string)) continue;
                if (count == 0 && this.indentJson) sb.Append('\n');
                if (count > 0)
                {
                    sb.Append(",");
                    if (this.indentJson) sb.Append('\n');
                }
                WriteToSb(sb, (string)key, level + 1);
                sb.Append(this.indentJson ? ": " : ":");
                WriteToSb(sb, ht[key], level + 1, true);
                count++;
            }
            if (count > 0 && this.indentJson)
            {
                sb.Append('\n');
                Indent(sb, level);
            }
            sb.Append("}");
        }
        else if (GetGenericIDictionaryType(type) != null)
        {
            type = GetGenericIDictionaryType(type);
            Type keyType = type.GetGenericArguments()[0];
            //Refuse to output dictionary keys that aren't of type string
            if (keyType != typeof(string))
            {
                sb.Append("{}");
                return;
            }
            WriteProcessGenericIDictionaryToSb(sb, (dynamic)x, level);

            return;
        }
        else if (x is IEnumerable)
        {
            IEnumerable enumerable = (IEnumerable)x;
            var result = new List<object>();
            IEnumerator e = enumerable.GetEnumerator();
            while (e.MoveNext())
            {
                object o = e.Current;
                result.Add(o);
            }
            WriteToSb(sb, result, level, cancelIndent);
        }
        else
        {
            int count = 0;
            sb.Append('{');
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                if (fieldInfos[i].IsDefined(typeof(IgnoreDataMemberAttribute), true))
                    continue;
                object value = fieldInfos[i].GetValue(x);
                if (x is RedundantObject)
                {
                    if (value == null) continue;
                }
                if (count == 0 && this.indentJson) sb.Append('\n');
                if (count > 0)
                {
                    sb.Append(",");
                    if (this.indentJson) sb.Append('\n');
                }
                WriteToSb(sb, ObjectParserUtil.GetMemberName(fieldInfos[i]), level + 1);
                sb.Append(this.indentJson ? ": " : ":");
                WriteToSb(sb, value, level + 1, true);
                count++;
            }
            PropertyInfo[] propertyInfo = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (!propertyInfo[i].CanRead || propertyInfo[i].IsDefined(typeof(IgnoreDataMemberAttribute), true))
                    continue;
                object value = propertyInfo[i].GetValue(x, null);
                if (x is RedundantObject)
                {
                    if (value == null) continue;
                }
                if (count == 0 && this.indentJson) sb.Append('\n');
                if (count > 0)
                {
                    sb.Append(",");
                    if (this.indentJson) sb.Append('\n');
                }
                WriteToSb(sb, ObjectParserUtil.GetMemberName(propertyInfo[i]), level + 1);
                sb.Append(this.indentJson ? ": " : ":");
                WriteToSb(sb, value, level + 1, true);
                count++;
            }
            if (count > 0 && this.indentJson)
            {
                sb.Append('\n');
                Indent(sb, level);
            }
            sb.Append('}');
            return;
        }
    }

    private string Escape(string aText /*, bool ForceASCII*/)
    {
        var sb = new StringBuilder();
        sb.Length = 0;
        if (sb.Capacity < aText.Length + aText.Length / 10)
            sb.Capacity = aText.Length + aText.Length / 10;
        foreach (char c in aText)
        {
            switch (c)
            {
                case '\\':
                    sb.Append("\\\\");
                    break;
                case '\"':
                    sb.Append("\\\"");
                    break;
                case '\n':
                    sb.Append("\\n");
                    break;
                case '\r':
                    sb.Append("\\r");
                    break;
                case '\t':
                    sb.Append("\\t");
                    break;
                case '\b':
                    sb.Append("\\b");
                    break;
                case '\f':
                    sb.Append("\\f");
                    break;
                default:
                    if (c < ' ' || (forceAscii && c > 127))
                    {
                        ushort val = c;
                        sb.Append("\\u").Append(val.ToString("X4"));
                    }
                    else
                        sb.Append(c);
                    break;
            }
        }
        string result = sb.ToString();
        sb.Length = 0;
        return result;
    }
}