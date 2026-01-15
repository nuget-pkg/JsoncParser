namespace Global;

public interface IJsonHandler
{
    public object Parse(string json);
    public string Stringify(object x, bool indent, bool sort_keys = false);
}
