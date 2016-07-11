using System.Collections.Generic;

namespace ProblemDevelopmentKit.Result
{
    /// <summary>
    /// Stores result as the list of TableResultItems.
    /// </summary>
    public class TableResult : IResult
    {
        /// <summary>
        /// Title for table result.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// List of result items.
        /// </summary>
        public List<TableResultItem> ResultItems { get; private set; }

        public TableResult() : this(string.Empty) { }

        public TableResult(string title)
        {
            Title = title;
            ResultItems = new List<TableResultItem>();
        }
    }
}