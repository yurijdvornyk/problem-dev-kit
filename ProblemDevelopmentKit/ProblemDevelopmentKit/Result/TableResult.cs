using System.Collections.Generic;

namespace ProblemDevelopmentKit.Result
{
    /// <summary>
    /// Stores result as the list of TableResultItems.
    /// </summary>
    public class TableResult : IResult
    {
        /// <summary>
        /// List of result items.
        /// </summary>
        public List<TableResultItem> ResultItems { get; private set; }

        public TableResult()
        {
            ResultItems = new List<TableResultItem>();
        }
    }
}