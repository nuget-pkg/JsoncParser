namespace Global;

public class CSharpJsonHandler : IParseJson {
    private readonly JsoncParser jsonParser;
    public CSharpJsonHandler(bool numberAsDecimal) {
        jsonParser = new JsoncParser(numberAsDecimal);
    }
    public object ParseJson(string json) {
        return jsonParser.ParseJson(json);
    }
    public object[] ParseJsonSequence(string jsonSequenceString) {
        object result = ParseJson(jsonSequenceString);
        if (result == null) { return null; }
        return new object[] { result };
    }
}
