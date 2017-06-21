// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utility.cs" company="Megadotnet">
//   Utility
// </copyright>
// <summary>
//   Utility
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DBPerformanceTest.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Utility
    /// </summary>
    public static class Utility
    {
        #region Public Methods

        /// <summary>
        /// Foreaches the specified input.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        public static void Foreach<T>(this IEnumerable<T> input, Action<T> action)
        {
            foreach (T item in input)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performances the watch.
        /// </summary>
        /// <param name="targetaction">
        /// The targetaction.
        /// </param>
        /// <returns>
        /// The performance watch.
        /// </returns>
        public static long PerformanceWatch(Action targetaction)
        {
            var sw = new Stopwatch();
            sw.Reset();
            sw.Start();

            targetaction();

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// PerformanceWatchWithTimes
        /// </summary>
        /// <param name="targetaction"></param>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public static long PerformanceWatchWithTimes(Action targetaction,int repeatTime)
        {
            return Utility.PerformanceWatch(
   () =>
   {
       for (int i = 0; i < repeatTime; i++)
       {
           targetaction();
       }
   });
        }

        #endregion
    }
}