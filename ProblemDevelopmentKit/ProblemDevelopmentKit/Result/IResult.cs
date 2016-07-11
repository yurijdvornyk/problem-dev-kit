namespace ProblemDevelopmentKit.Result
{
    /// <summary>
    /// Interface that indicates that its descendant describes problem result.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Result title
        /// </summary>
        string Title { get; set; }
    }
}