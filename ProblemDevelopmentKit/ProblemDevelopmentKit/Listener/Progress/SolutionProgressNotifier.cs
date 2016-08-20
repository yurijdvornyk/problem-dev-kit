using System;

namespace ProblemDevelopmentKit.Listener.Progress
{
    /// <summary>
    /// Manages the behavior of ISolutionProgressListener listeners.
    /// </summary>
    public class SolutionProgressNotifier : Notifier<ISolutionProgressListener>
    {
        /// <summary>
        /// "false" if solution progress is indeterminate, otherwise "true".
        /// </summary>
        public static bool IsProgressModeEnabled { get; private set; }

        /// <summary>
        /// Set progress mode.
        /// </summary>
        /// <param name="isEnabled">If "true" then display the progress in percent, otherwise just show that solving is in progress.</param>
        public static void SetProgressModeEnabled(bool isEnabled)
        {
            IsProgressModeEnabled = isEnabled;
            GetListeners().ForEach(listener => listener.SetProgressModeEnabled(IsProgressModeEnabled));
        }

        /// <summary>
        /// If progress mode is enabled, show the progress of problem solving.
        /// </summary>
        /// <param name="percent">Problem solving progress in percent.</param>
        public static void SetProgress(double percent)
        {
            GetListeners().ForEach(listener => listener.SetProgress(percent));
        }

        /// <summary>
        /// Notify listeners that solution progress started.
        /// </summary>
        public static void StartSolution()
        {
            GetListeners().ForEach(listener => listener.OnSolutionStarted());
        }

        /// <summary>
        /// Notify listeners that solution progress completed.
        /// </summary>
        public static void CompleteSolution()
        {
            GetListeners().ForEach(listener => listener.OnSolutionCompleted());
        }

        /// <summary>
        /// Notify listeners that solution progress was cancelled.
        /// </summary>
        public static void CancelSolution()
        {
            GetListeners().ForEach(listener => listener.OnSolutionCancelled());
        }

        /// <summary>
        /// Notify listeners when solution was interrupted with an exception.
        /// </summary>
        /// <param name="e">Exception.</param>
        public static void SolutionError(Exception e)
        {
            GetListeners().ForEach(listener => listener.OnSolutionError(e));
        }
    }
}
