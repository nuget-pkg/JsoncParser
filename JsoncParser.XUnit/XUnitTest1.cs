using Xunit;
using Global;
using T = Global.EasyObject;

public class XUnitTest1
{
    private readonly ITestOutputHelper Out;
    public XUnitTest1(ITestOutputHelper testOutputHelper)
    {
        Out = testOutputHelper;
        EasyObject.ClearSettings();
        EasyObject.ShowDetail = true;
        Print("Setup() called");
    }
    private void Print(object x, string title = null)
    {
        Out.WriteLine(EasyObject.ToPrintable(x, title));
    }
    private string ToJson(object x, bool indent = false)
    {
        return EasyObject.FromObject(x).ToJson(indent: indent);
    }
    [Fact]
    public void Test01()
    {
        var o1 = Global.StrictJsonParser.Parse("""
            { "a": 123 }
            """);
        Print(o1, "o1");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o1));
        T.AssertIdentical("""
            {"a":123}
            """, ToJson(o1));
    }
    [Fact]
    public void Test02()
    {
        var o3 = Global.JsoncParser.Parse("""
            { "a": 123 }
            """);
        Print(o3, "o3");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o3));
        var o4 = Global.JsoncParser.Parse("""
            { a: 123 }
            """);
        Print(o4, "o4");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o4));
        var o5 = Global.JsoncParser.Parse("""
            { "a": /*comment*/123 }
            """);
        Print(o5, "o5");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o5));
        var o6 = Global.JsoncParser.Parse("""
            { "a": //line comment
              123 }
            """);
        Print(o6, "o6");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o6));
    }
    [Fact]
    public void Test03()
    {
        var o1 = Global.JsoncParser.Parse("""'helloハロー©'""");
        Print(o1, "o1");
        var json = new Global.PlainObjectConverter(forceAscii: false).Stringify(o1, false);
        Assert.Equal("""
             "helloハロー©"
             """, json);
        json = new Global.PlainObjectConverter(forceAscii: true).Stringify(o1, false); // ForceASII
        Assert.Equal("""
             "hello\u30CF\u30ED\u30FC\u00A9"
             """, json);
    }
    //[Fact]
    //public void Test04()
    //{
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
