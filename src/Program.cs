// ***********************************************************************
// Assembly         : TestMain
// Author           : PeterLiu
// Created          : 07-26-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 07-26-2014
// ***********************************************************************
// <copyright file="Program.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace TestMain
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    using DBPerformanceTest.Core;

    /// <summary>
    /// The DBPerformanceTest program.
    /// </summary>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    internal class Program
    {
        #region Methods

        /// <summary>
        /// The begin test.
        /// </summary>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private static void BeginTest()
        {
            var sb = new StringBuilder();
            var testmodule = new ServiceLocatorConfig();
            List<IPerformanceTest> genericInstances = testmodule.GenericOverload_GetAllInstances();
            //Default dal 
            string testSuitNames = "SqlClient(SN), NHibernateV1(NH), LinqToEntity(LE), LinqToSql(LQ)";

            var namelist = new List<string>();

            // for initial
            if (genericInstances != null)
            {
                genericInstances.ForEach(
                    tp =>
                    {
                        tp.FetchSingleTest(1);
                        tp.FetchAllTest(1);
                        tp.WriteTest(1);
                        namelist.Add(tp.GetType().Name);
                    });
            }

            testSuitNames = string.Join(" , ", namelist.ToArray());

            // repeat times
            var testmoduleconfig = (IDictionary)ConfigurationManager.GetSection("testmodule");
            var repeatTimestr = (string)testmoduleconfig["repeatTimes"];

            int[] repeatTimes = new List<string>(repeatTimestr.Split(',')).ConvertAll(t => int.Parse(t)).ToArray();

            // string blocknames = "ADO.NET   ,     NH,     LE,     LQ    ";

            // sb.AppendLine(testSuitNames);
            // test fetch single performance
            TestFetchSinglePerformance(sb, genericInstances, testSuitNames, repeatTimes);

            sb.AppendLine();

            // test fetch all performance
            TestFetchAllPerformance(sb, genericInstances, repeatTimes);

            // test write performance
            TestWritePerformance(sb, genericInstances, repeatTimes);

            OutputToFile(sb);
        }

        /// <summary>
        /// TestWritePerformance
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="genericInstances"></param>
        /// <param name="repeatTimes"></param>
        private static void TestWritePerformance(StringBuilder sb, List<IPerformanceTest> genericInstances, int[] repeatTimes)
        {
            sb.AppendLine(string.Format("Compare  {0}  performance of {0}", "write"));
            for (int i = 0; i < repeatTimes.Length; ++i)
            {
                sb.AppendLine();
                sb.AppendLine(string.Format("Repeat Time = {0}", repeatTimes[i]));
                genericInstances.ForEach(
                    tp =>
                    {
                        sb.Append(tp.WriteTest(repeatTimes[i]));
                        sb.Append("\t");
                    });
                sb.AppendLine();
            }

            sb.AppendLine();
        }

        /// <summary>
        /// TestFetchAllPerformance
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="genericInstances"></param>
        /// <param name="repeatTimes"></param>
        private static void TestFetchAllPerformance(StringBuilder sb, List<IPerformanceTest> genericInstances, int[] repeatTimes)
        {
            sb.AppendLine(string.Format("Compare  {0} performance of", "fetch all"));
            for (int i = 0; i < repeatTimes.Length; ++i)
            {
                sb.AppendLine();
                sb.AppendLine(string.Format("Repeat Time = {0}", repeatTimes[i]));
                genericInstances.ForEach(
                    tp =>
                    {
                        sb.Append(tp.FetchAllTest(repeatTimes[i]));
                        sb.Append("\t");
                    });

                sb.AppendLine();
            }

            sb.AppendLine();
        }

        /// <summary>
        /// TestFetchSinglePerformance
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="genericInstances"></param>
        /// <param name="testSuitNames"></param>
        /// <param name="repeatTimes"></param>
        private static void TestFetchSinglePerformance(StringBuilder sb, List<IPerformanceTest> genericInstances, string testSuitNames, int[] repeatTimes)
        {
            sb.AppendLine(string.Format("Compare {0} performance", "fetch single"));
            sb.AppendLine(testSuitNames);

            for (int i = 0; i < repeatTimes.Length; ++i)
            {
                sb.AppendLine();
                sb.AppendLine(string.Format("Repeat Time = {0}", repeatTimes[i]));

                genericInstances.ForEach(
                    tp =>
                    {
                        sb.Append(tp.FetchSingleTest(repeatTimes[i]));
                        sb.Append("\t");
                    });
                sb.AppendLine();
            }
        }

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private static void Main(string[] args)
        {
            Console.WriteLine("Testing....Please wait..");
            BeginTest();
        }

        /// <summary>
        /// The output to file.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        private static void OutputToFile(StringBuilder sb)
        {
            string filename = string.Format("TestResult-{0:yyyy-MM-dd_hh-mm-ss-tt}.txt", DateTime.Now);
            string fullpath = Path.Combine(Environment.CurrentDirectory, filename);
            using (var outfile = new StreamWriter(fullpath))
            {
                outfile.Write(sb.ToString());
                outfile.Close();
            }

            Process.Start(fullpath);
        }

        #endregion
    }
}