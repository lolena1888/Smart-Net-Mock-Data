﻿namespace Smart.Mock.Services
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Smart.Mock.Data;
    using Smart.Mock.Infrastructure;

    /// <summary>
    ///
    /// </summary>
    [TestClass]
    public class EmployeeServiceTest
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:スコープを失う前にオブジェクトを破棄", Justification = "Ignore")]
        [TestMethod]
        public void TestQueryEmployeeList()
        {
            var columns = new[]
            {
                new MockColumn(typeof(int), "Id"),
                new MockColumn(typeof(string), "Name")
            };
            var rows = new List<object[]>
            {
                new object[] { 1, "従業員1" },
                new object[] { 2, "従業員2" },
                new object[] { 3, "従業員3" }
            };

            var connection = new MockDbConnection();
            connection.SetupCommand(cmd => cmd.SetupResult(new MockDataReader(columns, rows)));

            var service = new EmployeeService(new MockConnectionFactory(connection));

            // Test
            var list = service.QueryEmployeeList();

            // Assert
            Assert.AreEqual(3, list.Count);
        }
    }
}