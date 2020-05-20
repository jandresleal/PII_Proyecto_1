using System.Collections.Generic;

namespace Library
{
    public interface IPrintFormatter
    {
        List<IProperty> FormatMessage(string data);
    }
}