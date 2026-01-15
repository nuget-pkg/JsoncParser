using System;
using System.Collections.Generic;
using System.Text;

namespace Global;

public class CSharpJsonHandler: IJsonHandler
{
    JsoncParser jsonParser;
    ObjectParser objParser;
    public CSharpJsonHandler(bool NumberAsDecimal, bool ForceASCII)
    {
        this.jsonParser = new JsoncParser(NumberAsDecimal);
        this.objParser = new ObjectParser(ForceASCII);
    }
    public object Parse(string json)
    {
        return this.jsonParser.ParseJson(json);
    }
    public string Stringify(object x, bool indent, bool sort_keys = false)
    {
        return this.objParser.Stringify(x, indent, sort_keys);
    }
}
