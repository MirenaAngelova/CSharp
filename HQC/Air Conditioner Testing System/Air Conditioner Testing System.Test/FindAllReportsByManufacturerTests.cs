using System;
using System.Linq;
using Air_Conditioner_Testing_System.Databases;
using Air_Conditioner_Testing_System.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Air_Conditioner_Testing_System.Test
{
    [TestClass]
    public class FindAllReportsByManufacturerTests
    {
        private IController controller;

        [TestInitialize]
        public void Initialize()
        {
            this.controller = new Controller();
        }

        [TestMethod]
        public void FindAllReports_WithIncorrectInput_ShoudReturnAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            for (int i = 0; i < 3; i++)
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba" + i, "EX1000" + i, "B", 1000);
            }

            var actual = this.controller.FindAllReportsByManufacturer("Toshiba");

            var expected = "No reports.";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FindAllReports_WithCorrectInput_ShoudReturnAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            for (int i = 0; i < 3; i++)
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000" + i, "B", 1000);
                this.controller.TestAirConditioner("Toshiba", "EX1000" + i);
            }
            
            var actual = this.controller.FindAllReportsByManufacturer("Toshiba");

            var expected = "Reports from Toshiba:" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Toshiba" +
                           "\r\nModel: EX10000" +
                           "\r\nMark: Passed" +
                           "\r\n====================" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Toshiba" +
                           "\r\nModel: EX10001" +
                           "\r\nMark: Passed" +
                           "\r\n====================" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Toshiba" +
                           "\r\nModel: EX10002" +
                           "\r\nMark: Passed" +
                           "\r\n====================";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FindAllReports_WithCorrectInput2_ShoudReturnAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            for (int i = 0; i < 3; i++)
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000" + i, "B", 1000);
                this.controller.TestAirConditioner("Toshiba", "EX1000" + i);
            }
            this.controller.RegisterStationaryAirConditioner("Hitachi", "E1000", "B", 1000);
            this.controller.TestAirConditioner("Hitachi", "E1000");

            var actual = this.controller.FindAllReportsByManufacturer("Toshiba");

            var expected = "Reports from Toshiba:" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Toshiba" +
                           "\r\nModel: EX10000" +
                           "\r\nMark: Passed" +
                           "\r\n====================" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Toshiba" +
                           "\r\nModel: EX10001" +
                           "\r\nMark: Passed" +
                           "\r\n====================" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Toshiba" +
                           "\r\nModel: EX10002" +
                           "\r\nMark: Passed" +
                           "\r\n====================";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FindAllReports_WithCorrectInput3_ShoudReturnAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            for (int i = 0; i < 3; i++)
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000" + i, "B", 1000);
                this.controller.TestAirConditioner("Toshiba", "EX1000" + i);
            }
            this.controller.RegisterStationaryAirConditioner("Hitachi", "E1000", "B", 1000);
            this.controller.TestAirConditioner("Hitachi", "E1000");

            var actual = this.controller.FindAllReportsByManufacturer("Hitachi");

            var expected = "Reports from Hitachi:" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Hitachi" +
                           "\r\nModel: E1000" +
                           "\r\nMark: Passed" +
                           "\r\n====================";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FindAllReports_WithCorrectInput4_ShoudReturnAppropriateMessage()
        {//RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)
            for (int i = 0; i < 3; i++)
            {
                this.controller.RegisterStationaryAirConditioner("Toshiba", "EX1000" + i, "A", 999 + i);
                this.controller.TestAirConditioner("Toshiba", "EX1000" + i);
            }
            this.controller.RegisterStationaryAirConditioner("Hitachi", "E1000", "B", 1000);
            this.controller.TestAirConditioner("Hitachi", "E1000");

            var actual = this.controller.FindAllReportsByManufacturer("Toshiba");

            var expected = "Reports from Toshiba:" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Toshiba" +
                           "\r\nModel: EX10000" +
                           "\r\nMark: Passed" +
                           "\r\n====================" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Toshiba" +
                           "\r\nModel: EX10001" +
                           "\r\nMark: Failed" +
                           "\r\n====================" +
                           "\r\nReport" +
                           "\r\n====================" +
                           "\r\nManufacturer: Toshiba" +
                           "\r\nModel: EX10002" +
                           "\r\nMark: Failed" +
                           "\r\n====================";

            Assert.AreEqual(actual, expected);
        }
    }
}
