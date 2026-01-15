using Xunit;
using Xunit.Abstractions;
//using MyJson;
//using static MyJson.MyData;
using static Global.SharpJson;
using System;
using Global;

public class ExceptionTest
{
    private readonly ITestOutputHelper Out;
    public ExceptionTest(ITestOutputHelper testOutputHelper)
    {
        Out = testOutputHelper;
        SharpJson.ClearAllSettings();
        Print("Setup() called");
    }
    private void Print(object x, string title = null)
    {
        Out.WriteLine(SharpJson.ToPrintable(x, title));
    }
    [Fact]
    public void Test01()
    {
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
                     """, exception1.Message);
    }
}
