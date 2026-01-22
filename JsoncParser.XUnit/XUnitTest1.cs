//using MyJson;
//using static MyJson.MyData;
using static Global.EasyObjectClassic;
using Xunit;
using Xunit.Abstractions;
using Global;
using System;
using System.Collections;
using Microsoft.SqlServer.Server;

public class XUnitTest1
{
    private readonly ITestOutputHelper Out;
    public XUnitTest1(ITestOutputHelper testOutputHelper)
    {
        Out = testOutputHelper;
        EasyObjectClassic.ClearSettings();
        Print("Setup() called");
    }
    private void Print(object x, string title = null)
    {
        Out.WriteLine(EasyObjectClassic.ToPrintable(x, title));
    }
    private string ToJson(object x, bool indent = false)
    {
        return EasyObjectClassic.FromObject(x).ToJson(indent: indent);
    }
    [Fact]
    public void Test01()
    {
        ShowDetail = true;
        var o1 = Global.StrictJsonParser.Parse("""
            { "a": 123 }
            """);
        Echo(o1, "o1");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o1));
    }
    [Fact]
    public void Test02()
    {
        ShowDetail = true;
        var o3 = Global.JsoncParser.Parse("""
            { "a": 123 }
            """);
        Echo(o3, "o3");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o3));
        var o4 = Global.JsoncParser.Parse("""
            { a: 123 }
            """);
        Echo(o4, "o4");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o4));
        var o5 = Global.JsoncParser.Parse("""
            { "a": /*comment*/123 }
            """);
        Echo(o5, "o5");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o5));
        var o6 = Global.JsoncParser.Parse("""
            { "a": //line comment
              123 }
            """);
        Echo(o6, "o6");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o6));
    }
    // [Fact]
    // public void Test03()
    // {
    //     ShowDetail = true;
    //     var o1 = new Global.PlainObjectConverter(false).Parse("helloハロー©");
    //     Echo(o1, "o1");
    //     var json = new Global.PlainObjectConverter(false).Stringify(o1, false);
    //     Assert.Equal("""
    //         "helloハロー©"
    //         """, json);
    //     json = new Global.PlainObjectConverter(true).Stringify(o1, false); // ForceASII
    //     Assert.Equal("""
    //         "hello\u30CF\u30ED\u30FC\u00A9"
    //         """, json);
    // }
    //[Fact]
    //public void Test04()
    //{
    //    ShowDetail = true;
    //    var o1 = new MyRedundant();
    //    Echo(o1, "o1");
    //    var json = new PlainObjectConverter(false).Stringify(o1, false);
    //    Echo(json, "json");
    //    Assert.Equal("""
    //        {"Ok":"ok"}
    //        """, json);
    //}
    // [Fact]
    // public void Test05()
    // {
    //     ShowDetail = true;
    //     object o;
    //     o = JsoncParser.Parse("""
    //         "ab'\"c"
    //         """);
    //     Assert.Equal("""
    //         "ab'\"c"
    //         """, new PlainObjectConverter(false).Stringify(o, false));
    //     o = JsoncParser.Parse("""
    //         'ab\'"c'
    //         """);
    //     Assert.Equal("""
    //         "ab'\"c"
    //         """, new PlainObjectConverter(false).Stringify(o, false));
    //     o = JsoncParser.Parse("""
    //         { a: 'ab\'"c' }
    //         """);
    //     Assert.Equal("""
    //         {"a":"ab'\"c"}
    //         """, new PlainObjectConverter(false).Stringify(o, false));
    // }
    //public class MyRedundant : RedundantObject
    //{
    //    public string Null = null;
    //    public string Ok = "ok";
    //}
}
