// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPerformanceTest.cs" company="Megadotnet">
//   IPerformanceTest
// </copyright>
// <summary>
//   IPerformanceTest
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DBPerformanceTest.Core
{
    /// <summary>
    /// IPerformanceTest
    /// </summary>
    public interface IPerformanceTest
    {
        #region Public Methods

        /// <summary>
        /// Fetches all test.
        /// </summary>
        /// <param name="repeatTime">
        /// The repeat time.
        /// </param>
        /// <returns>
        /// The fetch all test.
        /// </returns>
        long FetchAllTest(int repeatTime);

        /// <summary>
        /// Fetches the single test.
        /// </summary>
        /// <param name="repeatTime">
        /// The repeat time.
        /// </param>
        /// <returns>
        /// The fetch single test.
        /// </returns>
        long FetchSingleTest(int repeatTime);

        /// <summary>
        /// Writes the test.
        /// </summary>
        /// <param name="repeatTime">
        /// The repeat time.
        /// </param>
        /// <returns>
        /// The write test.
        /// </returns>
        long WriteTest(int repeatTime);

        #endregion
    }
}