using ProblemDevelopmentKit.Listener.Progress;
using ProblemDevelopmentKit.ProblemData;
using ProblemDevelopmentKit.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProblemDevelopmentKit
{
    /// <summary>
    /// Partial implementation of IProblem interface for easier usage.
    /// </summary>
    public abstract class Problem : IProblem
    {
        public abstract string Name { get; }

        public virtual string Equation { get; }

        public virtual string Comments { get; }

        public List<DataItem> InputData { get; set; }

        public ProblemResult Result { get; protected set; }

        public bool IsInputDataSet
        {
            get
            {
                foreach (DataItem item in InputData)
                {
                    if (item.IsRequired && item.Value == null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool IsCancellationPending { get; private set; }

        private BackgroundWorker backgroundWorker;

        public Problem()
        {
            InputData = new List<DataItem>();
        }

        public abstract void ParseData();

        public abstract ProblemResult Execute();

        public void SetInputData(List<object> inputData)
        {
            for (int i = 0; i < inputData.Count; ++i)
            {
                InputData[i].Value = inputData[i];
            }
            ParseData();
        }

        public void ResetInputData()
        {
            foreach (var dataItem in InputData)
            {
                dataItem.Value = null;
            }
        }

        public ProblemResult Solve()
        {
            if (IsInputDataSet)
            {
                Result = Execute();
                return Result;
            }
            else
            {
                throw new ArgumentException("Input data not set.");
            }
        }

        public void SolveAsync()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            IsCancellationPending = false;
            backgroundWorker.RunWorkerAsync();
        }

        public void CancelAsyncSolution()
        {
            IsCancellationPending = true;
            if (backgroundWorker != null)
            {
                backgroundWorker.CancelAsync();
            }
            else
            {
                throw new NullReferenceException("BackgroundWorker is not initialized.");
            }
        }

        public override string ToString()
        {
            return Name;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Solve();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                SolutionProgressNotifier.CancelSolution();
            }
            else if (e.Error != null)
            {
                SolutionProgressNotifier.SolutionError(e.Error);
            }
            else
            {
                SolutionProgressNotifier.CompleteSolution();
            }
        }
    }
}