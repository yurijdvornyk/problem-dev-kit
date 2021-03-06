﻿using ProblemDevelopmentKit.ProblemData;
using ProblemDevelopmentKit.Result;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProblemDevelopmentKit
{
    public interface IProblem
    {
        /// <summary>
        /// Problem name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Problem equation.
        /// </summary>
        string Equation { get; }

        /// <summary>
        /// Some comments to the problem. HTML tags can be used for text formatting.
        /// </summary>
        string Comments { get; }

        /// <summary>
        /// List of input parameters.
        /// </summary>
        List<DataItem> InputData { get; }

        /// <summary>
        /// Stores information about problem solution.
        /// </summary>
        ProblemResult Result { get; }

        /// <summary>
        /// True if input data is set, otherwise False.
        /// </summary>
        bool IsInputDataSet { get; }

        /// <summary>
        /// True if the solution process must be stopped, otherwise False.
        /// </summary>
        bool IsCancellationPending { get; }

        /// <summary>
        /// Set input argument to the InputData field and parses it using ParseData method.
        /// Then set IsInputDataSet property to True.
        /// </summary>
        /// <param name="inputData">Data to be set to InputData</param>
        void SetInputData(List<object> inputData);

        /// <summary>
        /// Parse InputData to problem parameters.
        /// </summary>
        void ParseData();

        /// <summary>
        /// Reset InputData: all parameters become null. Sets IsInputDataSet to False.
        /// </summary>
        void ResetInputData();

        /// <summary>
        /// Perform solving the problem.
        /// </summary>
        ProblemResult Execute(DoWorkEventArgs args);

        /// <summary>
        /// Wrap Calculate() method and set IsExecuted to True.
        /// </summary>
        ProblemResult Solve(DoWorkEventArgs args);

        /// <summary>
        /// Solve problem asyncronously.
        /// </summary>
        void SolveAsync();

        /// <summary>
        /// Cancel asynchronous problem solving.
        /// </summary>
        void CancelAsyncSolution();

        /// <summary>
        /// Checks if solution process can be continued. Check this before doing some complicated operations.
        /// </summary>
        /// <param name="args">DoWorkEventArgs</param>
        /// <returns>True is the solution progress can be continued, otherwise False.</returns>
        bool CheckSolutionStatus(DoWorkEventArgs args);
    }
}