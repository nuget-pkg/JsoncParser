// ReSharper disable once CheckNamespace
namespace Global;

public class CSharpEasyLanguageHandler: IParseJson
{
    private readonly EasyLanguageParser jsonParser;
    //private readonly PlainObjectConverter objParser;
    // ReSharper disable once ConvertToPrimaryConstructor
    public CSharpEasyLanguageHandler(bool numberAsDecimal)
    {
        this.jsonParser = new EasyLanguageParser(numberAsDecimal);
        //this.objParser = new PlainObjectConverter(forceAscii);
    }
    public object ParseJson(string json)
    {
        return this.jsonParser.ParseJson(json);
    }
    // public string Stringify(object x, bool indent, bool sortKeys = false)
    // {
    //     return this.objParser.Stringify(x, indent, sortKeys);
    // }
}
