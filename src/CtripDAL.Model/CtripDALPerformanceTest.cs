// ***********************************************************************
// Assembly         : CtripDALPerformanceTest.Model
// Author           : PeterLiu
// Created          : 06-05-2017
//
// Last Modified By : PeterLiu
// Last Modified On : 06-05-2017
// ***********************************************************************
// <copyright file="CtripDALPerformanceTest.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CtripDAL.Model
{
    using DBPerformanceTest.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// CtripDALPerformanceTest
    /// </summary>
    public class CtripDALPerformanceTest : IPerformanceTest
    {
        /// <summary>
        /// FetchAllTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long FetchAllTest(int repeatTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FetchSingleTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long FetchSingleTest(int repeatTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// WriteTest
        /// </summary>
        /// <param name="repeatTime"></param>
        /// <returns></returns>
        public long WriteTest(int repeatTime)
        {
            throw new NotImplementedException();
        }
    }
}
