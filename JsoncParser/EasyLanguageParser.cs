#if true
using Global.Parser.ELang;
//using Global.Parser.JsonC;
using System;
using System.Collections.Generic;
using System.Text;

namespace Global;

public class EasyLanguageParser
{
    protected bool NumberAsDecimal = false;
    public EasyLanguageParser(bool numberAsDecimal)
    {
        this.NumberAsDecimal = numberAsDecimal;
    }

    public object ParseJson(string json)
    {
        return Parse(json, this.NumberAsDecimal);
    }

    public static object Parse(string json, bool NumberAsDecimal = false)
    {
        if (String.IsNullOrEmpty(json)) return null;
        ParserContext context = new ParserContext(json, false);
        Rule_elang_text rule = Rule_elang_text.Parse(context);
        if (rule == null) throw new ArgumentException($"Illegal JSONC: `{json}`");
        return RuleToObject(rule, NumberAsDecimal);
    }
    public static string FullName(dynamic x)
    {
        if (x is null) return "null";
        string fullName = ((object)x).GetType().FullName;
        return fullName.Split('`')[0];
    }

    public static string ParseJsonString(string aJSON)
    {
        if (aJSON.StartsWith("\"")) return ParseJsonStringDouble(aJSON);
        if (aJSON.StartsWith("'")) return ParseJsonStringSingle(aJSON);
        //if (aJSON.StartsWith("@")) return aJSON.Substring(1);
        return aJSON;
    }
    public static string ParseJsonStringSingle(string aJSON)
    {
        int i = 0;
        StringBuilder Token = new StringBuilder();
        bool QuoteMode = false;
        while (i < aJSON.Length)
        {
            switch (aJSON[i])
            {

                case '\'':
                    QuoteMode ^= true;
                    break;

                case '\r':
                case '\n':
                    break;

                case ' ':
                case '\t':
                    if (QuoteMode)
                        Token.Append(aJSON[i]);
                    break;

                case '\\':
                    ++i;
                    if (QuoteMode)
                    {
                        char C = aJSON[i];
                        switch (C)
                        {
                            case 't':
                                Token.Append('\t');
                                break;
                            case 'r':
                                Token.Append('\r');
                                break;
                            case 'n':
                                Token.Append('\n');
                                break;
                            case 'b':
                                Token.Append('\b');
                                break;
                            case 'f':
                                Token.Append('\f');
                                break;
                            case 'u':
                                {
                                    string s = aJSON.Substring(i + 1, 4);
                                    Token.Append((char)int.Parse(
                                        s,
                                        System.Globalization.NumberStyles.AllowHexSpecifier));
                                    i += 4;
                                    break;
                                }
                            default:
                                Token.Append(C);
                                break;
                        }
                    }
                    break;

                case '\uFEFF': // remove / ignore BOM (Byte Order Mark)
                    break;

                default:
                    Token.Append(aJSON[i]);
                    break;
            }
            ++i;
        }
        if (QuoteMode)
        {
            throw new Exception("My Parse: Quotation marks seems to be messed up.");
        }
        return Token.ToString();
    }
    public static string ParseJsonStringDouble(string aJSON)
    {
        int i = 0;
        StringBuilder Token = new StringBuilder();
        bool QuoteMode = false;
        while (i < aJSON.Length)
        {
            switch (aJSON[i])
            {

                case '"':
                    QuoteMode ^= true;
                    break;

                case '\r':
                case '\n':
                    break;

                case ' ':
                case '\t':
                    if (QuoteMode)
                        Token.Append(aJSON[i]);
                    break;

                case '\\':
                    ++i;
                    if (QuoteMode)
                    {
                        char C = aJSON[i];
                        switch (C)
                        {
                            case 't':
                                Token.Append('\t');
                                break;
                            case 'r':
                                Token.Append('\r');
                                break;
                            case 'n':
                                Token.Append('\n');
                                break;
                            case 'b':
                                Token.Append('\b');
                                break;
                            case 'f':
                                Token.Append('\f');
                                break;
                            case 'u':
                                {
                                    string s = aJSON.Substring(i + 1, 4);
                                    Token.Append((char)int.Parse(
                                        s,
                                        System.Globalization.NumberStyles.AllowHexSpecifier));
                                    i += 4;
                                    break;
                                }
                            default:
                                Token.Append(C);
                                break;
                        }
                    }
                    break;

                case '\uFEFF': // remove / ignore BOM (Byte Order Mark)
                    break;

                default:
                    Token.Append(aJSON[i]);
                    break;
            }
            ++i;
        }
        if (QuoteMode)
        {
            throw new Exception("My Parse: Quotation marks seems to be messed up.");
        }
        return Token.ToString();
    }

    protected static List<Rule> SkipUseless(List<Rule> rules)
    {
        var result = new List<Rule>();
        if (rules != null)
        {
            foreach (var rule in rules)
            {
                if (rule is Rule_ws) continue;
                if (rule is Rule_begin_object) continue;
                if (rule is Rule_end_object) continue;
                if (rule is Rule_name_separator) continue;
                if (rule is Rule_value_separator) continue;
                if (rule is Rule_begin_array) continue;
                if (rule is Rule_end_array) continue;
                if (rule is Rule_begin_vector) continue;
                if (rule is Rule_end_vector) continue;
                //if (rule is Terminal_StringValue) continue;
                result.Add(rule);
            }
        }
        return result;
    }
    public static object RuleToObject(Rule rule, bool NumberAsDecimal)
    {
        var rules = SkipUseless(rule.rules);
        if (rule is Rule_elang_text)
        {
            foreach (var r in rules)
            {
                //Assert.Single(rules);
                return RuleToObject(rules[0], NumberAsDecimal);
            }
        }
        else if (rule is Rule_value)
        {
            //Assert.Single(rules);
            foreach (var r in rules)
            {
                return RuleToObject(rules[0], NumberAsDecimal);
            }
        }
        else if (rule is Rule_quote)
        {
            var value = RuleToObject(rules[1], NumberAsDecimal);
#if false
            if (value is string)
                return "string:" + (string)value;
#endif
            var result = new Dictionary<string, object>();
            if (rule.spelling.StartsWith("'"))
                result["!"] = "quote";
            else
                result["!"] = "quasi-quote";
            result["?"] = value;
            return result;
        }
        else if (rule is Rule_unquote)
        {
            var result = new Dictionary<string, object>();
            if (rule.spelling.StartsWith("~@"))
                result["!"] = "splice-unquote";
            else
                result["!"] = "unquote";
            result["?"] = RuleToObject(rules[1], NumberAsDecimal);
            return result;
        }
        else if (rule is Rule_deref)
        {
            var result = new Dictionary<string, object>();
            result["!"] = "deref";
            result["?"] = RuleToObject(rules[1], NumberAsDecimal);
            return result;
        }
        else if (rule is Rule_metadata)
        {
            var result = new Dictionary<string, object>();
            result["!"] = "metadata";
            result["?meta"] = RuleToObject(rules[1], NumberAsDecimal);
            result["?data"] = RuleToObject(rules[2], NumberAsDecimal);
            return result;
        }
        else if (rule is Rule_as_is)
        {
            var result = new Dictionary<string, object>();
            result["!"] = "as-is";
            result["?"] = rule.spelling.Substring(2, rule.spelling.Length - 3).Replace("@@", "@");
            return result;
        }
        else if (rule is Rule_lisp_symbol)
        {
            var result = new Dictionary<string, object>();
            if (rule.spelling == ".")
            {
                result["!"] = "dot";
                return result;
            }
            string spelling = rule.spelling;
            if (spelling.StartsWith("\\"))
                spelling = spelling.Substring(1);
            result["!"] = "symbol";
            result["?"] = spelling;
            return result;
        }
        else if (rule is Rule_array)
        {
            var result = new List<object>();
            foreach (var r in rules)
            {
                //Assert.True(r is Rule_value);
                result.Add(RuleToObject(r, NumberAsDecimal));
            }
            return result;
        }
        else if (rule is Rule_vector)
        {
            var vec = new List<object>();
            foreach (var r in rules)
            {
                vec.Add(RuleToObject(r, NumberAsDecimal));
            }
            var result = new Dictionary<string, object>();
            result["!"] = "vector";
            result["?"] = vec;
            return result;
        }
        else if (rule is Rule_object)
        {
            var result = new Dictionary<string, object>();
            foreach (var r in rules)
            {
                //Assert.True(r is Rule_member);
                var pair = (KeyValuePair<string, object>)RuleToObject(r, NumberAsDecimal);
                result[pair.Key] = pair.Value;
            }
            return result;
        }
        else if (rule is Rule_member)
        {
            string name = null;
            foreach (var r in rules)
            {
                if (r is Rule_member_name) name = (string)RuleToObject(r, NumberAsDecimal);
                if (r is Rule_value) return new KeyValuePair<string, object>(name, RuleToObject(r, NumberAsDecimal));
            }
        }
        else if (rule is Rule_member_name)
        {
#if true
            foreach (var r in rules)
            {
                object result = RuleToObject(r, NumberAsDecimal);
                if (result is string) return result;
                if (result is Dictionary<string, object>) return (result as Dictionary<string, object>)["?"];
            }
#else
            foreach (var r in rules)
            {
                if (r is Rule_string) return (string)RuleToObject(r, NumberAsDecimal);
                if (r is Rule_lisp_symbol) return (string)RuleToObject(r, NumberAsDecimal);
            }
#endif
        }
        else if (rule is Rule_string)
        {
            if (rule.spelling == ".")
            {
                var result = new Dictionary<string, object>();
                result["!"] = "dot";
                return result;
            }
            if (rule.spelling.StartsWith("\\"))
                return rule.spelling.Substring(1);
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
            if (NumberAsDecimal)
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
        else if (rule is Rule_nil)
        {
            return null;
        }
        else
        {
            throw new Exception($"{FullName(rule)} is not supported");
        }
        throw new Exception($"{FullName(rule)} did not return result");
    }
}
#endif
