using ProblemDevelopmentKit.ProblemData;
using ProblemDevelopmentKit.Result;
using System;
using System.Collections.Generic;

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

        public bool IsInputDataSet { get; protected set; }

        public bool IsExecuted { get; protected set; }

        public Problem()
        {
            IsInputDataSet = false;
            IsExecuted = false;
            InputData = new List<DataItem>();
        }

        public void SetInputData(List<object> inputData)
        {
            for (int i = 0; i < inputData.Count; ++i)
            {
                InputData[i].Value = inputData[i];
            }
            ParseData();
            IsInputDataSet = true;
        }

        public void ResetInputData()
        {
            foreach (var dataItem in InputData)
            {
                dataItem.Value = null;
            }
            IsInputDataSet = false;
        }

        public abstract void ParseData();

        public abstract ProblemResult Execute();

        public ProblemResult Solve()
        {
            if (!IsInputDataSet)
            {
                throw new ArgumentException("Input data not set.");
            }

            Result = Execute();
            IsExecuted = true;
            return Result;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}