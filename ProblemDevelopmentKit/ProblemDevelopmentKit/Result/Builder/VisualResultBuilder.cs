using System;

namespace ProblemDevelopmentKit.Result.Builder
{
    /// <summary>
    /// Visual result builder.
    /// </summary>
    public class VisualResultBuilder : IResultBuilder
    {
        private VisualResult visualResult;
        private VisualResultItem currentResult;

        private VisualResultBuilder() : this(string.Empty, string.Empty, string.Empty) { }

        private VisualResultBuilder(string title, string keyTitle, string valueTitle)
        {
            visualResult = new VisualResult(title, keyTitle, valueTitle);
        }

        /// <summary>
        /// Creates new VisualResultBuilder instance.
        /// </summary>
        /// <param name="title">Graph title</param>
        /// <param name="keyTitle">Key axis title</param>
        /// <param name="valueTitle">Value axis title</param>
        /// <returns></returns>
        public static VisualResultBuilder Create(string title = "", string keyTitle = "", string valueTitle = "")
        {
            return new VisualResultBuilder(title, keyTitle, valueTitle);
        }

        /// <summary>
        /// Sets visual result.
        /// </summary>
        /// <param name="visualResult">Given VisualResult.</param>
        /// <returns></returns>
        public VisualResultBuilder SetTableResult(VisualResult visualResult)
        {
            this.visualResult = visualResult;
            return this;
        }

        /// <summary>
        /// Builds Visual result.
        /// </summary>
        /// <returns>Visual result.</returns>
        public VisualResult Build()
        {
            return visualResult;
        }

        /// <summary>
        /// Adds new graph to the end of graph list.
        /// </summary>
        /// <param name="title">Graph title (optional, "" by default).</param>
        /// <returns></returns>
        public VisualResultBuilder NewGraph(string title = "")
        {
            currentResult = new VisualResultItem();
            currentResult.Title = title;
            return this;
        }

        /// <summary>
        /// Sets title to current graph
        /// </summary>
        /// <param name="title">Graph's title</param>
        /// <returns></returns>
        public VisualResultBuilder SetGraphTitle(string title)
        {
            currentResult.Title = title;
            return this;
        }

        /// <summary>
        /// Adds new value to the end of value list in current graph.
        /// </summary>
        /// <param name="key">Key axis value.</param>
        /// <param name="value">Value axis value.</param>
        /// <returns></returns>
        public VisualResultBuilder AddValue(double key, double value)
        {
            currentResult.AddPoint(key, value);
            return this;
        }

        /// <summary>
        /// Adds current graph to VisualResult. If currentResult == null, throws ArgumentNullException.
        /// </summary>
        /// <returns></returns>
        public VisualResultBuilder AddGraphToResult()
        {
            if (currentResult == null)
            {
                throw new ArgumentNullException("Graph is not initialized. Cannot add null value as visual result.");
            }
            else
            {
                visualResult.Graphs.Add(currentResult);
                return this;
            }
        }
    }
}