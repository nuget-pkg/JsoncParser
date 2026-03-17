namespace Global;

public class CSharpEasyLanguageHandler : IParseJson {
    private readonly EasyLanguageParser jsonParser;
    public CSharpEasyLanguageHandler(bool numberAsDecimal, bool removeSurrogatePair = false) {
        jsonParser = new EasyLanguageParser(numberAsDecimal, removeSurrogatePair);
    }
    public object ParseJson(string json) {
        return jsonParser.ParseJson(json);
    }
    public object[] ParseJsonSequence(string jsonSequenceString) {
        object result = jsonParser.ParseJsonSequence(jsonSequenceString);
        if (result == null) { return null; }
        return new object[] { result };
    }
}
