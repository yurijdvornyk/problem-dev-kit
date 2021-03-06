﻿namespace ProblemDevelopmentKit.Result
{
    /// <summary>
    /// Stores the result of problem solution.
    /// </summary>
    public class ProblemResult
    {
        /// <summary>
        /// Name for keys axis in visual representation.
        /// </summary>
        public string VisualTitleKey { get; private set; }

        /// <summary>
        /// Name for values axis in visual representation.
        /// </summary>
        public string VisualTitleValue { get; private set; }

        /// <summary>
        /// Some comments to solution. Use HTML markup to improve readibility.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Collection of result tables.
        /// </summary>
        public TableResult TableResult { get; private set; }

        /// <summary>
        /// Collection of data for plots.
        /// </summary>
        public VisualResult VisualResult { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProblemResult() :
            this(string.Empty, string.Empty, new TableResult(), new VisualResult())
        { }

        /// <summary>
        /// Construct ProblemResult instance from given tableValues and visualValues.
        /// </summary>
        /// <param name="tableValues">TableResult.</param>
        /// <param name="visualValues">VisualResult.</param>
        public ProblemResult(TableResult tableValues, VisualResult visualValues) :
            this(string.Empty, string.Empty, tableValues, visualValues)
        { }

        /// <summary>
        /// Construct ProblemResult instance from given visualTableKey, visualTitleValue, visualValues, visualValues and comments.
        /// </summary>
        /// <param name="visualTitleKey">VisualTitleKey.</param>
        /// <param name="visualTitleValue">VisualTitleValue.</param>
        /// <param name="tableValues">TableResult.</param>
        /// <param name="visualValues">VisualResult.</param>
        /// <param name="comments">Commenyts.</param>
        public ProblemResult(
            string visualTitleKey,
            string visualTitleValue,
            TableResult tableValues,
            VisualResult visualValues,
            string comments = "")
        {
            TableResult = tableValues;
            VisualResult = visualValues;
            VisualTitleKey = visualTitleKey;
            VisualTitleValue = visualTitleValue;
            Comments = comments;
        }
    }
}