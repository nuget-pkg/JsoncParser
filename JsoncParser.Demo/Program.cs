using Global;
using System;
using System.IO;
using static Global.EasyObject;
namespace Main;


static class Program {
    static void TestStrinct() {
        ShowDetail = true;
        var o1 = Global.StrictJsonParser.Parse("""
            { "a": 123 }
            """);
        Echo(o1, "o1");
    }
    static void TestJsonc() {
        ShowDetail = true;
        var o3 = Global.JsoncParser.Parse("""
            { 'a': 123 }
            """);
        Echo(o3, "o3");
        var o4 = Global.JsoncParser.Parse("""
            { a: 123 }
            """);
        Echo(o4, "o4");
        var o5 = Global.JsoncParser.Parse("""
            { "a": /*comment*/123 }
            """);
        Echo(o5, "o5");
        var o6 = Global.JsoncParser.Parse("""
            { "a": //line comment
              123 }
            """);
    }
    [STAThread]
    static void Main(string[] originalArgs) {
        TestStrinct();
        TestJsonc();
        var parser = new LispLanguageParser(numberAsDecimal: true, removeSurrogatePair: true);
        var result1 = parser.ParseJson("'🔥引火★★帝国🔥'");
        Echo(result1, "result1");
        var parser2 = new LispLanguageParser(numberAsDecimal: true, removeSurrogatePair: false);
        var result2 = parser2.ParseJson("'🔥引火★★帝国🔥'");
        Echo(result2, "result2");

        string cljureCode01 = File.ReadAllText("assets/cljure_code01.clj");
        Echo(cljureCode01, "cljureCode01");
        Echo(parser2.ParseJsonSequence(cljureCode01), "cljureCode01(parsed)");
        string cljureCode02 = File.ReadAllText("assets/cljure_code02.clj");
        Echo(parser2.ParseJsonSequence(cljureCode02), "cljureCode02(parsed)");

        string json = """'abc'""";

        Global.Parser.JsonC.ParserContext context = new Global.Parser.JsonC.ParserContext(json, false);
        Global.Parser.JsonC.Rule_json_text rule = Global.Parser.JsonC.Rule_json_text.Parse(context);
        Global.Parser.JsonC.XmlDisplayer displayer = new Global.Parser.JsonC.XmlDisplayer();
        rule.Accept(displayer);
    }
}