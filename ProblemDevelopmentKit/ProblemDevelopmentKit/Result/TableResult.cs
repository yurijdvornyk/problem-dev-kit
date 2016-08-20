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

        /// <summary>
        /// Create new TableResult.
        /// </summary>
        public TableResult() : this(string.Empty) { }

        /// <summary>
        /// Create new TableResult with given title.
        /// </summary>
        /// <param name="title">TableResult title.</param>
        public TableResult(string title)
        {
            Title = title;
            ResultItems = new List<TableResultItem>();
        }
    }
}