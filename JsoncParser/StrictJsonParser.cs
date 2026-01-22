using Global.Parser.StrictJson;
using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Global;

public class StrictJsonParser
{
    private readonly bool numberAsDecimal /*= false*/;
    public StrictJsonParser(bool numberAsDecimal)
    {
        this.numberAsDecimal = numberAsDecimal;
    }

    public object ParseJson(string json)
    {
        return Parse(json, this.numberAsDecimal);
    }

    public static object Parse(string json, bool numberAsDecimal = false)
    {
        if (String.IsNullOrEmpty(json)) return null;
        ParserContext context = new ParserContext(json, false);
        Rule_json_text rule = Rule_json_text.Parse(context);
        if (rule == null) throw new ArgumentException($"Illegal JSON: `{json}`");
        return RuleToObject(rule, numberAsDecimal);
    }

    private static List<Rule> SkipUseless(List<Rule> rules)
    {
        var result = new List<Rule>();
        foreach (var rule in rules)
        {
            if (rule is Rule_ws) continue;
            if (rule is Rule_begin_object) continue;
            if (rule is Rule_end_object) continue;
            if (rule is Rule_name_separator) continue;
            if (rule is Rule_value_separator) continue;
            if (rule is Rule_begin_array) continue;
            if (rule is Rule_end_array) continue;
            result.Add(rule);
        }
        return result;
    }
    // ReSharper disable once MemberCanBePrivate.Global
    public static object RuleToObject(Rule rule, bool numberAsDecimal)
    {
        var rules = SkipUseless(rule.rules);
        if (rule is Rule_json_text)
        {
            return RuleToObject(rules[0], numberAsDecimal);
        }
        else if (rule is Rule_value)
        {
            return RuleToObject(rules[0], numberAsDecimal);
        }
        else if (rule is Rule_array)
        {
            var result = new List<object>();
            foreach (var r in rules)
            {
                result.Add(RuleToObject(r, numberAsDecimal));
            }
            return result;
        }
        else if (rule is Rule_object)
        {
            var result = new Dictionary<string, object>();
            foreach (var r in rules)
            {
                var pair = (KeyValuePair<string, object>)RuleToObject(r, numberAsDecimal);
                result[pair.Key] = pair.Value;
            }
            return result;
        }
        else if (rule is Rule_member)
        {
            string name = null;
            foreach (var r in rules)
            {
                if (r is Rule_string) name = (string)RuleToObject(r, numberAsDecimal);
                //if (r is Rule_member_name) name = (string)RuleToObject(r, NumberAsDecimal);
                if (r is Rule_value) return new KeyValuePair<string, object>(name, RuleToObject(r, numberAsDecimal));
            }
        }
#if false
        else if (rule is Rule_member_name)
        {
            foreach (var r in rules)
            {
                if (r is Rule_string) return (string)RuleToObject(r, NumberAsDecimal);
                if (r is Rule_symbol) return (string)RuleToObject(r, NumberAsDecimal);
            }
        }
#endif
        else if (rule is Rule_string)
        {
            return ParseJsonString(rule.spelling);
        }
#if false
        else if (rule is Rule_symbol)
        {
            return rule.spelling;
        }
#endif
        else if (rule is Rule_number)
        {
            if (numberAsDecimal)
                return decimal.Parse(rule.spelling);
            return double.Parse(rule.spelling);
        }
        else if (rule is Rule_true)
        {
            return true;
        }
        else if (rule is Rule_false)
        {
            return false;
        }
        else if (rule is Rule_null)
        {
            return null;
        }
        else
        {
            throw new Exception($"{FullName(rule)} is not supported");
        }
        throw new Exception($"{FullName(rule)} did not return result");
    }
    // ReSharper disable once MemberCanBePrivate.Global
    public static string FullName(dynamic x)
    {
        if (x is null) return "null";
        string fullName = ((object)x).GetType().FullName;
        return fullName!.Split('`')[0];
    }
    // ReSharper disable once MemberCanBePrivate.Global
    public static string ParseJsonString(string aJson)
    {
        int i = 0;
        StringBuilder token = new StringBuilder();
        bool quoteMode = false;
        while (i < aJson.Length)
        {
            switch (aJson[i])
            {

                case '"':
                    quoteMode ^= true;
                    break;

                case '\r':
                case '\n':
                    break;

                case ' ':
                case '\t':
                    if (quoteMode)
                        token.Append(aJson[i]);
                    break;

                case '\\':
                    ++i;
                    if (quoteMode)
                    {
                        char c = aJson[i];
                        switch (c)
                        {
                            case 't':
                                token.Append('\t');
                                break;
                            case 'r':
                                token.Append('\r');
                                break;
                            case 'n':
                                token.Append('\n');
                                break;
                            case 'b':
                                token.Append('\b');
                                break;
                            case 'f':
                                token.Append('\f');
                                break;
                            case 'u':
                                {
                                    string s = aJson.Substring(i + 1, 4);
                                    token.Append((char)int.Parse(
                                        s,
                                        System.Globalization.NumberStyles.AllowHexSpecifier));
                                    i += 4;
                                    break;
                                }
                            default:
                                token.Append(c);
                                break;
                        }
                    }
                    break;

                case '\uFEFF': // remove / ignore BOM (Byte Order Mark)
                    break;

                default:
                    token.Append(aJson[i]);
                    break;
            }
            ++i;
        }
        if (quoteMode)
        {
            throw new Exception("My Parse: Quotation marks seems to be messed up.");
        }
        return token.ToString();
    }

}
