using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Fakes;
using System.IO.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using EnterpriseLogger;

namespace EnterpriseLogger.Tests.Unit
{
    [TestClass]
    public class LogAggregatorTests
    {
        [TestMethod]
        public void AggregateLogs_PastThreeDays_ReturnsAllLinesFromPastThreeDays()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                var sut = new LogAggregator();
                ShimDirectory.GetFilesStringString = (dir, pattern) => new[]
                {
                    @"C:\someLogDir\Log_20121001.log",
                    @"C:\someLogDir\Log_20121002.log",
                    @"C:\someLogDir\Log_20121005.log"
                };
                ShimFile.ReadAllLinesString = path =>
                {
                    switch (path)
                    {
                        case @"C:\someLogDir\Log_20121001.log":
                            return new[] { "OctFirstLine1", "OctFirstLine2" };
                        case @"C:\someLogDir\Log_20121002.log":
                            return new[] { "ThreeDaysAgoFirstLine", "OctSecondLine2" };
                        case @"C:\someLogDir\Log_20121005.log":
                            return new[] { "OctFifthLine1", "TodayLastLine" };
                    }

                    return new string[] { };
                };
                ShimDateTime.TodayGet = () => new DateTime(2012, 10, 05);

                // Act
                var result = sut.AggregateLogs(@"C:\SomeLogDir", daysInPast: 3);

                // Assert
                Assert.AreEqual(4, result.Length, "Number of aggregated lines incorrect.");
                CollectionAssert.Contains(result, "ThreeDaysAgoFirstLine", "Expected line missing from aggregated log.");
                CollectionAssert.Contains(result, "TodayLastLine", "Expected line missing from aggregated log.");
            }
        }
    }
}
