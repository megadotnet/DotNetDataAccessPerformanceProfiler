using System;
using System.Collections.Generic;
using DG.Common;
using NUnit.Framework;

namespace DataGeneratorTest1
{
    [TestFixture]
    public class DataGeneratorTest
    {
        [Test]
        public void JoinFormatTest()
        {
            var columnsList = new string[]{};
            string joinFormat = columnsList.JoinFormat(",", c => string.Format("{0}=@{0}", c));
            Assert.IsFalse(string.IsNullOrEmpty(joinFormat));
        }

        [Test]
        public void JoinFormatForList()
        {
            var columnList = new List<int> { 1, 2, 3 };
            string joinFormat = columnList.JoinFormat(",", c => string.Format("{0}=@{0}", c));
            Assert.IsFalse(string.IsNullOrEmpty(joinFormat));
        }

        [Test]
        public void JoinFormatForCustomClass()
        {
            var countryList = new List<Country>
                                  {
                                      new Country {Name = "United State", ISO = "US"},
                                      new Country {Name = "United Kingdom", ISO = "GB"},
                                      new Country {Name = "Bangladesh", ISO = "BD"}
                                  };

            string joinFormat = countryList.JoinFormat("", country =>
                                                                    string.Format(@"<Country Name=""{0}"" ISO=""{1}""></Country>",
                                                                                  country.Name, country.ISO)
                                                                );
            Assert.IsFalse(string.IsNullOrEmpty(joinFormat));
        }

        public class Country
        {
            public string Name { get; set; }
            public string ISO { get; set; }
        }

    }
}
