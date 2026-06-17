namespace Global;

public class CSharpLispLanguageHandler : IParseJson {
    private readonly LispLanguageParser jsonParser;
    public CSharpLispLanguageHandler(bool numberAsDecimal, bool removeSurrogatePair = false) {
        jsonParser = new LispLanguageParser(numberAsDecimal, removeSurrogatePair);
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
