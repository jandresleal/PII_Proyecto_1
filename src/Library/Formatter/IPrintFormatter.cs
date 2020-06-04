using System.Collections.Generic;

namespace Library
{
    public interface IPrintFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string FormatMessage(List<IProperty> data);
    }
}