using Global.Parser.ELang;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Global;

public class EasyLanguageParser {
    private readonly bool numberAsDecimal = false;
    private readonly bool removeSurrogatePair = false;

    public EasyLanguageParser(bool numberAsDecimal, bool removeSurrogatePair) {
        this.numberAsDecimal = numberAsDecimal;
        this.removeSurrogatePair = removeSurrogatePair;
    }

    public object ParseJson(string json) {
        return ParseFirst(json, numberAsDecimal, removeSurrogatePair);
    }

    public object ParseMulti(string json) {
        return ParseMulti(json, numberAsDecimal, removeSurrogatePair);
    }

    public static object ParseFirst(string json, bool numberAsDecimal = false, bool removeSurrogatePair = false) {
        if (String.IsNullOrEmpty(json)) {
            return null;
        }
        var context = new ParserContext(json, false);
        var rule = Rule_elang_text.Parse(context);
        return rule == null ? throw new ArgumentException($"Illegal JSONC: `{json}`") : RuleToObject(rule, numberAsDecimal, removeSurrogatePair);
    }
    public static object ParseMulti(string json, bool numberAsDecimal = false, bool removeSurrogatePair = false) {
        if (String.IsNullOrEmpty(json)) {
            return null;
        }
        var context = new ParserContext(json, false);
        var rule = Rule_elang_multi.Parse(context);
        return rule == null ? throw new ArgumentException($"Illegal JSONC: `{json}`") : RuleToObject(rule, numberAsDecimal, removeSurrogatePair);
    }
    public static string FullName(dynamic x) {
        if (x is null) {
            return "null";
        }

        string fullName = ((object)x).GetType().FullName;
        return fullName!.Split('`')[0];
    }

    public static string ParseJsonString(string aJson, bool removeSurrogatePair) {
#if false
        if (aJson.StartsWith("\"")) return ParseJsonStringDouble(aJson);
        return aJson.StartsWith("'") ? ParseJsonStringSingle(aJson) :
            aJson;
#else
        string result = "?";
        if (aJson.StartsWith("\"")) {
            result = ParseJsonStringDouble(aJson);
        } else if (aJson.StartsWith("'")) {
            result = ParseJsonStringSingle(aJson);

        }
        if (removeSurrogatePair) {
            result = Regex.Replace(result, @"[\uD800-\uDFFF]", "{ddbea68e-d93f-4e85-92b5-83b1ace6d50f}");
            result = result.Replace("{ddbea68e-d93f-4e85-92b5-83b1ace6d50f}{ddbea68e-d93f-4e85-92b5-83b1ace6d50f}", "★");
            result = result.Replace("{ddbea68e-d93f-4e85-92b5-83b1ace6d50f}", "★");
        }
        return result;
#endif
    }
    public static string ParseJsonStringSingle(string aJson) {
        int i = 0;
        StringBuilder token = new StringBuilder();
        bool quoteMode = false;
        while (i < aJson.Length) {
            switch (aJson[i]) {

                case '\'':
                    quoteMode ^= true;
                    break;

                case '\r':
                case '\n':
                    break;

                case ' ':
                case '\t':
                    if (quoteMode) {
                        token.Append(aJson[i]);
                    }

                    break;

                case '\\':
                    ++i;
                    if (quoteMode) {
                        char c = aJson[i];
                        switch (c) {
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
                            case 'u': {
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
        if (quoteMode) {
            throw new Exception("My Parse: Quotation marks seems to be messed up.");
        }
        return token.ToString();
    }
    public static string ParseJsonStringDouble(string aJson) {
        var i = 0;
        var token = new StringBuilder();
        var quoteMode = false;
        while (i < aJson.Length) {
            switch (aJson[i]) {

                case '"':
                    quoteMode ^= true;
                    break;

                case '\r':
                case '\n':
                    break;

                case ' ':
                case '\t':
                    if (quoteMode) {
                        token.Append(aJson[i]);
                    }

                    break;

                case '\\':
                    ++i;
                    if (quoteMode) {
                        char c = aJson[i];
                        switch (c) {
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
                            case 'u': {
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
        return quoteMode ? throw new Exception("My Parse: Quotation marks seems to be messed up.") : token.ToString();
    }

    private static List<Rule> SkipUseless(List<Rule> rules) {
        var result = new List<Rule>();
        if (rules != null) {
            foreach (var rule in rules) {
                if (rule is Rule_ws) {
                    continue;
                }

                if (rule is Rule_begin_object) {
                    continue;
                }

                if (rule is Rule_end_object) {
                    continue;
                }

                if (rule is Rule_name_separator) {
                    continue;
                }

                if (rule is Rule_value_separator) {
                    continue;
                }

                if (rule is Rule_begin_array) {
                    continue;
                }

                if (rule is Rule_end_array) {
                    continue;
                }

                if (rule is Rule_begin_vector) {
                    continue;
                }

                if (rule is Rule_end_vector) {
                    continue;
                }
                //if (rule is Terminal_StringValue) continue;
                result.Add(rule);
            }
        }
        return result;
    }
    public static object RuleToObject(Rule rule, bool numberAsDecimal, bool removeSurrogatePair) {
        var rules = SkipUseless(rule.rules);
        if (rule is Rule_elang_text) {
            return RuleToObject(rules[0], numberAsDecimal, removeSurrogatePair);
        } else if (rule is Rule_elang_multi) {
            var result = new List<object>();
            Console.Error.WriteLine($"Rule_elang_multi: {rules.Count} rules");
            foreach (var r in rules) {
                result.Add(RuleToObject(r, numberAsDecimal, removeSurrogatePair));
            }
            return result;
        } else if (rule is Rule_value) {
            return RuleToObject(rules[0], numberAsDecimal, removeSurrogatePair);
        } else if (rule is Rule_quote) {
            var value = RuleToObject(rules[1], numberAsDecimal, removeSurrogatePair);
            var result = new Dictionary<string, object>();
            if (rule.spelling.StartsWith("'")) {
                result["!"] = "quote";
            } else {
                result["!"] = "quasi-quote";
            }
            result["?"] = value;
            return result;
        } else if (rule is Rule_unquote) {
            var result = new Dictionary<string, object>();
            if (rule.spelling.StartsWith("~@")) {
                result["!"] = "splice-unquote";
            } else {
                result["!"] = "unquote";
            }
            result["?"] = RuleToObject(rules[1], numberAsDecimal, removeSurrogatePair);
            return result;
        } else if (rule is Rule_deref) {
            var result = new Dictionary<string, object>();
            result["!"] = "deref";
            result["?"] = RuleToObject(rules[1], numberAsDecimal, removeSurrogatePair);
            return result;
        } else if (rule is Rule_metadata) {
            var result = new Dictionary<string, object>();
            result["!"] = "metadata";
            result["?meta"] = RuleToObject(rules[1], numberAsDecimal, removeSurrogatePair);
            result["?data"] = RuleToObject(rules[2], numberAsDecimal, removeSurrogatePair);
            return result;
        } else if (rule is Rule_as_is) {
            var result = new Dictionary<string, object>();
            result["!"] = "as-is";
            result["?"] = rule.spelling.Substring(2, rule.spelling.Length - 3).Replace("@@", "@");
            return result;
        } else if (rule is Rule_lisp_symbol) {
            var result = new Dictionary<string, object>();
            if (rule.spelling == ".") {
                result["!"] = "dot";
                return result;
            }
            string spelling = rule.spelling;
            if (spelling.StartsWith("\\")) {
                spelling = spelling.Substring(1);
            }
            result["!"] = "symbol";
            result["?"] = spelling;
            return result;
        } else if (rule is Rule_array) {
            var result = new List<object>();
            foreach (var r in rules) {
                result.Add(RuleToObject(r, numberAsDecimal, removeSurrogatePair));
            }
            return result;
        } else if (rule is Rule_vector) {
            var vec = new List<object>();
            foreach (var r in rules) {
                vec.Add(RuleToObject(r, numberAsDecimal, removeSurrogatePair));
            }
            var result = new Dictionary<string, object>();
            result["!"] = "vector";
            result["?"] = vec;
            return result;
        } else if (rule is Rule_object) {
            var result = new Dictionary<string, object>();
            foreach (var r in rules) {
                var pair = (KeyValuePair<string, object>)RuleToObject(r, numberAsDecimal, removeSurrogatePair);
                result[pair.Key] = pair.Value;
            }
            return result;
        } else if (rule is Rule_member) {
            string name = null;
            foreach (var r in rules) {
                if (r is Rule_member_name) {
                    name = (string)RuleToObject(r, numberAsDecimal, removeSurrogatePair);
                }

                if (r is Rule_value) {
                    return new KeyValuePair<string, object>(name, RuleToObject(r, numberAsDecimal, removeSurrogatePair));
                }
            }
        } else if (rule is Rule_member_name) {
            foreach (var r in rules) {
                object result = RuleToObject(r, numberAsDecimal, removeSurrogatePair);
                if (result is string) {
                    return result;
                }

                if (result is Dictionary<string, object>) {
                    return (result as Dictionary<string, object>)["?"];
                }
            }
        } else if (rule is Rule_string) {
            if (rule.spelling == ".") {
                var result = new Dictionary<string, object>();
                result["!"] = "dot";
                return result;
            }
            if (rule.spelling.StartsWith("\\")) {
                return rule.spelling.Substring(1);
            }
            return ParseJsonString(rule.spelling, removeSurrogatePair);
        } else if (rule is Rule_number) {
            if (numberAsDecimal) {
                return decimal.Parse(rule.spelling);
            }
            return double.Parse(rule.spelling);
        } else if (rule is Rule_true) {
            return true;
        } else if (rule is Rule_false) {
            return false;
        } else if (rule is Rule_null) {
            return null;
        } else if (rule is Rule_nil) {
            return null;
        } else {
            throw new Exception($"{FullName(rule)} is not supported");
        }
        throw new Exception($"{FullName(rule)} did not return result");
    }
}
