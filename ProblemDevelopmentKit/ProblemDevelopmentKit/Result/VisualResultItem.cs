using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemDevelopmentKit.Result
{
    /// <summary>
    /// Stores visual result item.
    /// </summary>
    public class VisualResultItem : IResultItem
    {
        /// <summary>
        /// Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// List of keys (horizontal axis values).
        /// </summary>
        public List<double> Keys { get; private set; }

        /// <summary>
        /// List of values (vertical axis values).
        /// </summary>
        public List<double> Values { get; private set; }

        public VisualResultItem() : this(string.Empty, new List<double>(), new List<double>()) { }

        public VisualResultItem(string title, IEnumerable<double> keys, IEnumerable<double> values)
        {
            Title = title;

            if (keys != null && values != null)
            {
                if (isKeysAndValuesTheSameLength(keys, values))
                {
                    Keys = new List<double>(keys);
                    Values = new List<double>(values);
                }
                else
                {
                    throw new ArgumentException("Keys and values must have the same length!");
                }
            }
            else
            {
                Keys = new List<double>();
                Values = new List<double>();
            }
        }

        /// <summary>
        /// Adds new point to the graph.
        /// </summary>
        /// <param name="key">Point's horizontal value.</param>
        /// <param name="value">Point's vertical value.</param>
        public void AddPoint(double key, double value)
        {
            Keys.Add(key);
            Values.Add(value);
        }

        /// <summary>
        /// Removes point from the graph.
        /// </summary>
        /// <param name="index">Point's index.</param>
        public void RemoveItem(int index)
        {
            Keys.RemoveAt(index);
            Values.RemoveAt(index);
        }

        /// <summary>
        /// Returns graph values as matrix.
        /// </summary>
        /// <returns>Graph values as numeric matrix.</returns>
        public double[,] GetValue()
        {
            double[,] result = new double[Keys.Count, 2];
            for (int i = 0; i < Keys.Count; ++i)
            {
                result[i, 0] = Keys[i];
                result[i, 1] = Values[i];
            }
            return result;
        }

        /// <summary>
        /// Checks if graph contains given point.
        /// </summary>
        /// <param name="key">Horizontal axis value.</param>
        /// <param name="value">Vertical axis value.</param>
        /// <returns></returns>
        public bool ContainsPoint(double key, double value)
        {
            return Keys.Contains(key) && Values.Contains(value);
        }

        private bool isKeysAndValuesTheSameLength(IEnumerable<double> keys, IEnumerable<double> values)
        {
            return keys.Count() == values.Count();
        }
    }
}
