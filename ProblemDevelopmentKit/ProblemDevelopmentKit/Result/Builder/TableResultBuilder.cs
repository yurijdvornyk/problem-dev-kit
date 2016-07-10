using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemDevelopmentKit.Result.Builder
{
    /// <summary>
    /// Table result builder.
    /// </summary>
    public class TableResultBuilder : IResultBuilder
    {
        private TableResult tableResult;
        private TableResultItem currentTable;

        private TableResultBuilder()
        {
            tableResult = new TableResult();
        }

        /// <summary>
        /// Creates new TableResultBuilder instance.
        /// </summary>
        /// <returns></returns>
        public static TableResultBuilder Create()
        {
            return new TableResultBuilder();
        }

        /// <summary>
        /// Sets table result.
        /// </summary>
        /// <param name="tableResult">Given TableResult.</param>
        /// <returns></returns>
        public TableResultBuilder SetTableResult(TableResult tableResult)
        {
            this.tableResult = tableResult;
            return this;
        }

        /// <summary>
        /// Builds Table result.
        /// </summary>
        /// <returns>Table result.</returns>
        public TableResult Build()
        {
            return tableResult;
        }

        /// <summary>
        /// Adds new table to the end of table list.
        /// </summary>
        /// <param name="title">Table's title (optional, "" by default).</param>
        /// <returns></returns>
        public TableResultBuilder NewTable(string title = "")
        {
            currentTable = new TableResultItem(title);
            return this;
        }

        /// <summary>
        /// Sets title to current table
        /// </summary>
        /// <param name="title">Table's title</param>
        /// <returns></returns>
        public TableResultBuilder SetTitle(string title)
        {
            currentTable.Title = title;
            return this;
        }

        /// <summary>
        /// Adds new row to current table's matrix.
        /// </summary>
        /// <returns></returns>
        public TableResultBuilder NewRow()
        {
            currentTable.Value.Add(new List<object>());
            return this;
        }

        /// <summary>
        /// Adds new value after the last one in the current row.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns></returns>
        public TableResultBuilder AddValue(object value)
        {
            currentTable.Value.Last().Add(value);
            return this;
        }

        /// <summary>
        /// Adds current table to TableResult. If currentTable == null, throws ArgumentNullException.
        /// </summary>
        /// <returns></returns>
        public TableResultBuilder AddTableToResult()
        {
            if (currentTable == null)
            {
                throw new ArgumentNullException("Table is not initialized. Cannot add null value as table.");
            }
            else
            {
                tableResult.ResultItems.Add(currentTable);
                return this;
            }
        }
    }
}