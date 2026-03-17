using Global;
using System;
using System.IO;
//using System.Web.UI.WebControls;
using Xunit;
//using static MyJson.MyData;
using static Global.EasyObjectClassic;
namespace Main;


static class Program {
    static void TestStrinct() {
        ShowDetail = true;
        var o1 = Global.StrictJsonParser.Parse("""
            { "a": 123 }
            """);
        Echo(o1, "o1");
        var exception1 = Assert.Throws<ArgumentException>(() => {
            Global.StrictJsonParser.Parse("""
            { a: 123 }
            """);
        });
        exception1 = Assert.Throws<ArgumentException>(() => {
            Global.StrictJsonParser.Parse("""
            { "a": /*comment*/123 }
            """);
        });
        Assert.Equal("Illegal JSON: `{ \"a\": /*comment*/123 }`", exception1.Message);
        exception1 = Assert.Throws<ArgumentException>(() => {
            Global.StrictJsonParser.Parse("""
            { "a": //line comment
              123 }
            """);
        });
        Assert.Equal("""
                     Illegal JSON: `{ "a": //line comment
                       123 }`
                     """.Replace("\r\n", "\n"), exception1.Message.Replace("\r\n", "\n"));
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
        var parser = new EasyLanguageParser(numberAsDecimal: true, removeSurrogatePair: true);
        var result1 = parser.ParseJson("'🔥引火★★帝国🔥'");
        Echo(result1, "result1");
        var parser2 = new EasyLanguageParser(numberAsDecimal: true, removeSurrogatePair: false);
        var result2 = parser2.ParseJson("'🔥引火★★帝国🔥'");
        Echo(result2, "result2");

        string cljureCode01 = File.ReadAllText("assets/cljure_code01.clj");
        Echo(cljureCode01, "cljureCode01");
        Echo(parser2.ParseMulti(cljureCode01), "cljureCode01(parsed)");
        string cljureCode02 = File.ReadAllText("assets/cljure_code02.clj");
        Echo(parser2.ParseMulti(cljureCode02), "cljureCode02(parsed)");
    }
}