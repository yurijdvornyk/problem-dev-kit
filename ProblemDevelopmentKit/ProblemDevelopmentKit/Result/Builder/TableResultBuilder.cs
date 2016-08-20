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
            tableResult.ResultItems.Add(currentTable);
            return this;
        }

        /// <summary>
        /// Sets given table as current table.
        /// </summary>
        /// <param name="table">Given table.</param>
        /// <returns></returns>
        public TableResultBuilder SetCurrentTable(TableResultItem table)
        {
            currentTable = table;
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
            if (currentTable.Value.Count == 0)
            {
                currentTable.Value.Add(new List<object>());
            }
            currentTable.Value.Last().Add(value);
            return this;
        }

        /// <summary>
        /// Adds column titles to current table.
        /// </summary>
        /// <param name="titles">Column titles.</param>
        /// <returns></returns>
        public TableResultBuilder AddColumnTitles(params string[] titles)
        {
            foreach (string column in titles)
            {
                currentTable.ColumnTitles.Add(column);
            }
            return this;
        }
    }
}