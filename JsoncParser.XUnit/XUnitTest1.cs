using Xunit;
using T = Global.EasyObject;

public class XUnitTest1
{
    private readonly ITestOutputHelper Out;
    public XUnitTest1(ITestOutputHelper testOutputHelper)
    {
        Out = testOutputHelper;
        T.ClearSettings();
        T.ShowDetail = true;
        T.EchoRedirector = Out.WriteLine;
        T.LogRedirector = Out.WriteLine;
        T.Log("Setup() called");
    }
    private string ToJson(object x, bool indent = false)
    {
        return T.FromObject(x).ToJson(indent: indent);
    }
    [Fact]
    public void Test01()
    {
        T.Pass(System.Reflection.MethodBase.GetCurrentMethod().Name);
        var o1 = Global.StrictJsonParser.Parse("""
            { "a": 123 }
            """);
        T.Log(o1, "o1");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o1));
        T.AssertIdentical("""
            {"a":123}
            """, ToJson(o1));
        T.Pass(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    [Fact]
    public void Test02()
    {
        T.Pass(System.Reflection.MethodBase.GetCurrentMethod().Name);
        var o3 = Global.JsoncParser.Parse("""
            { "a": 123 }
            """);
        T.Log(o3, "o3");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o3));
        var o4 = Global.JsoncParser.Parse("""
            { a: 123 }
            """);
        T.Log(o4, "o4");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o4));
        var o5 = Global.JsoncParser.Parse("""
            { "a": /*comment*/123 }
            """);
        T.Log(o5, "o5");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o5));
        var o6 = Global.JsoncParser.Parse("""
            { "a": //line comment
              123 }
            """);
        T.Log(o6, "o6");
        Assert.Equal("""
            {"a":123}
            """, ToJson(o6));
        T.Pass(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    [Fact]
    public void Test03()
    {
        T.Pass(System.Reflection.MethodBase.GetCurrentMethod().Name);
        var o1 = Global.JsoncParser.Parse("""'helloハロー©'""");
        T.Log(o1, "o1");
        var json = new Global.PlainObjectConverter(forceAscii: false).Stringify(o1, false);
        Assert.Equal("""
             "helloハロー©"
             """, json);
        json = new Global.PlainObjectConverter(forceAscii: true).Stringify(o1, false); // ForceASII
        Assert.Equal("""
             "hello\u30CF\u30ED\u30FC\u00A9"
             """, json);
        T.Pass(System.Reflection.MethodBase.GetCurrentMethod().Name);
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
