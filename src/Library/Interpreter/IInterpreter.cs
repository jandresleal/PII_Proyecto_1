using System.Collections.Generic;
using System;

namespace Library
{
    public interface IInterpreter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        void AddFilter(IFilter filter);

        void RemoveFilter(IFilter filter);

        string AskQuestion();

        bool CheckForEmptyFilters();

        List<IFilter> ParseInput(string input);

        List<IFilter> CreateExtendedList(string input);
    }
}