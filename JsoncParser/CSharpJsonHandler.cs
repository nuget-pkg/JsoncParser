using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Global;

public class CSharpJsonHandler: IJsonHandler
{
    private readonly JsoncParser jsonParser;
    private readonly ObjectParser objParser;
    // ReSharper disable once ConvertToPrimaryConstructor
    public CSharpJsonHandler(bool numberAsDecimal, bool forceAscii)
    {
        this.jsonParser = new JsoncParser(numberAsDecimal);
        this.objParser = new ObjectParser(forceAscii);
    }
    public object Parse(string json)
    {
        return this.jsonParser.ParseJson(json);
    }
    public string Stringify(object x, bool indent, bool sortKeys = false)
    {
        return this.objParser.Stringify(x, indent, sortKeys);
    }
}
