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

        public bool IsCancellationPending
        {
            get
            {
                if (backgroundWorker != null)
                {
                    return backgroundWorker.CancellationPending;
                }
                else
                {
                    return false;
                }
            }
            private set
            {
                if (backgroundWorker != null && value)
                {
                    backgroundWorker.CancelAsync();
                }
            }
        }

        private BackgroundWorker backgroundWorker;

        public Problem()
        {
            InputData = new List<DataItem>();
        }

        public abstract void ParseData();

        public abstract ProblemResult Execute(DoWorkEventArgs args);

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
                Result = Execute(null);
                return Result;
            }
            else
            {
                throw new ArgumentException("Input data not set.");
            }
        }

        public ProblemResult Solve(DoWorkEventArgs args)
        {
            if (IsInputDataSet)
            {
                Result = Execute(args);
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
            backgroundWorker.RunWorkerAsync();
        }

        public void CancelAsyncSolution()
        {
            IsCancellationPending = true;
        }

        public bool CheckSolutionStatus(DoWorkEventArgs args)
        {
            if (IsCancellationPending)
            {
                args.Cancel = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SolutionProgressNotifier.StartSolution();
            Solve(e);
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