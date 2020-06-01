using System.Collections.Generic;

namespace Library
{
    public interface IPrintFormatter
    {
        string FormatMessage(List<IProperty> data);
    }
}