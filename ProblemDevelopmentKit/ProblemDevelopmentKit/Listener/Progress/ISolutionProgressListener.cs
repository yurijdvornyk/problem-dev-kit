using System;

namespace ProblemDevelopmentKit.Listener.Progress
{
    /// <summary>
    /// Implement this interface to listen to problem solving progress.
    /// </summary>
    public interface ISolutionProgressListener : IListener
    {
        /// <summary>
        /// Enable or disable progress show.
        /// </summary>
        /// <param name="isEnabled">"true" if progress mode should be enabled, "false" - if not.</param>
        void SetProgressModeEnabled(bool isEnabled);

        /// <summary>
        /// Set value to progress indicator if progress mode is enabled.
        /// </summary>
        /// <param name="percent">Progress value in percent (between 0 and 100).</param>
        void SetProgress(double percent);

        /// <summary>
        /// Called when the solution is started.
        /// </summary>
        void OnSolutionStarted();

        /// <summary>
        /// Called when the solution error appears.
        /// </summary>
        /// <param name="e">Error.</param>
        void OnSolutionError(Exception e);

        /// <summary>
        /// Called when the solution is cancelled.
        /// </summary>
        void OnSolutionCancelled();

        /// <summary>
        /// Called when the solution is completed successfully.
        /// </summary>
        void OnSolutionCompleted();        
    }
}
