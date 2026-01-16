// ReSharper disable once CheckNamespace
namespace Global;

public interface IObjectConverter
{
    public object ConvertResult(object x, string origTypeName);
}
