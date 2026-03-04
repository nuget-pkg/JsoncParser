// ReSharper disable once CheckNamespace
namespace Global;

public class CSharpEasyLanguageHandler: IParseJson
{
    private readonly EasyLanguageParser jsonParser;
    public CSharpEasyLanguageHandler(bool numberAsDecimal, bool removeSurrogatePair = false)
    {
        this.jsonParser = new EasyLanguageParser(numberAsDecimal, removeSurrogatePair);
    }
    public object ParseJson(string json)
    {
        return this.jsonParser.ParseJson(json);
    }
}
