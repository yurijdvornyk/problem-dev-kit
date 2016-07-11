using System.Collections.Generic;

namespace ProblemDevelopmentKit.Result
{
    /// <summary>
    /// Stores visual result as the list of graphs.
    /// </summary>
    public class VisualResult : IResult
    {
        /// <summary>
        /// Title for visual result.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Title for the horizontal axis.
        /// </summary>
        public string KeyTitle { get; set; }

        /// <summary>
        /// Title for the vertical axis.
        /// </summary>
        public string ValueTitle { get; set; }

        /// <summary>
        /// List of graphs.
        /// </summary>
        public List<VisualResultItem> Graphs { get; private set; }

        public VisualResult() : this(string.Empty, string.Empty, string.Empty) { }

        public VisualResult(string title, string keyTitle, string valueTitle)
        {
            Title = title;
            KeyTitle = keyTitle;
            ValueTitle = valueTitle;
            Graphs = new List<VisualResultItem>();
        }
    }
}