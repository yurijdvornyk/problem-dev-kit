using System.Collections.Generic;

namespace ProblemDevelopmentKit.Result
{
    /// <summary>
    /// Stores table result item.
    /// </summary>
    public class TableResultItem : IResultItem
    {
        /// <summary>
        /// Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// List of column titles.
        /// </summary>
        public List<string> ColumnTitles { get; private set; }

        /// <summary>
        /// TableResultItem's value: matrix of objects, saved as List of Lists.
        /// </summary>
        public List<List<object>> Value { get; set; }

        public TableResultItem() : this(string.Empty) { }

        /// <summary>
        /// TableResultItem constructor.
        /// </summary>
        /// <param name="title">Item's title.</param>
        public TableResultItem(string title)
        {
            Title = title;
            ColumnTitles = new List<string>();
            Value = new List<List<object>>();
        }

        /// <summary>
        /// Converts given object matrix and sets the result.
        /// </summary>
        /// <param name="result">Given object matrix.</param>
        public void SetResult(object[,] result)
        {
            Value = convertMatrixToLists(result);
        }

        /// <summary>
        /// Converts TableResultItem value to object matrix.
        /// </summary>
        /// <returns>Object matrix.</returns>
        public object[,] GetValueAsMatrix()
        {
            return convertListsToMatrix(Value);
        }

        #region Convertors

        private static object[,] convertListsToMatrix(List<List<object>> value)
        {
            int rows = value.Count;
            int columns = 0;
            if (rows > 0)
            {
                columns = value[0].Count;
            }

            object[,] result = new object[rows, columns];

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    result[i, j] = value[i][j];
                }
            }
            return result;
        }

        private static List<List<object>> convertMatrixToLists(object[,] objectMatrix)
        {
            List<List<object>> result = new List<List<object>>();
            for (int i = 0; i < objectMatrix.GetLength(0); ++i)
            {
                List<object> row = new List<object>();
                for (int j = 0; j < objectMatrix.GetLength(1); ++j)
                {
                    row.Add(objectMatrix[i, j]);
                }
                result.Add(row);
            }
            return result;
        }

        #endregion
    }
}