﻿
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HydroNumerics.HydroNet.Core;
using HydroNumerics.Geometry;

namespace HydroNumerics.HydroNet.OpenMI.UnitTest
{
    /// <summary>
    /// Summary description for Demo
    /// </summary>
    [TestClass]
    public class Demo
    {
        public Demo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {


        }

        private Model CreateHydroNetModel()
        {
            
            DateTime startTime = new DateTime(2000, 1, 1);
          

            // -------------------- Polygons --------------------------------------
            HydroNumerics.Geometry.XYPolygon contactPolygonUpperLake = new HydroNumerics.Geometry.XYPolygon();
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(535.836, 2269.625));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(675.768, 2187.713));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(771.331, 2177.474));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(887.372, 2184.300));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(935.154, 2255.973));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(945.392, 2385.666));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(931.741, 2505.119));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(877.133, 2546.075));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(812.287, 2638.225));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(696.246, 2675.768));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(638.225, 2627.986));
            contactPolygonUpperLake.Points.Add(new HydroNumerics.Geometry.XYPoint(573.379, 2587.031));

            HydroNumerics.Geometry.XYPolygon contactPolygonLowerLake = new HydroNumerics.Geometry.XYPolygon();
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(1935.154, 1150.171));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(1901.024, 1058.020));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(1877.133, 965.870));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(1894.198, 897.611));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(1938.567, 808.874));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(2023.891, 761.092));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(2116.041, 740.614));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(2232.082, 747.440));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(2327.645, 808.874));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(2389.078, 969.283));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(2372.014, 1109.215));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(2262.799, 1218.430));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(2105.802, 1235.495));
            contactPolygonLowerLake.Points.Add(new HydroNumerics.Geometry.XYPoint(1982.935, 1225.256));

            HydroNumerics.Geometry.XYPolygon contactPolygonUpperStream = new HydroNumerics.Geometry.XYPolygon();
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(863.481, 2177.474));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(914.676, 2129.693));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(965.870, 2071.672));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(976.109, 2027.304));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(976.109, 1989.761));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1006.826, 1959.044));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1051.195, 1918.089));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1095.563, 1877.133));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1126.280, 1808.874));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1187.713, 1781.570));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1228.669, 1730.375));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1262.799, 1665.529));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1283.276, 1597.270));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1317.406, 1535.836));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1341.297, 1484.642));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1389.078, 1457.338));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1423.208, 1440.273));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1477.816, 1402.730));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1511.945, 1358.362));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1539.249, 1327.645));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1566.553, 1354.949));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1535.836, 1406.143));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1508.532, 1457.338));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1440.273, 1522.184));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1368.601, 1580.205));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1327.645, 1631.399));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1307.167, 1696.246));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1269.625, 1767.918));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1221.843, 1819.113));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1191.126, 1843.003));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1136.519, 1894.198));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1088.737, 1935.154));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1061.433, 1976.109));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1030.717, 2040.956));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1013.652, 2105.802));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(972.696, 2177.474));
            contactPolygonUpperStream.Points.Add(new HydroNumerics.Geometry.XYPoint(918.089, 2228.669));

            HydroNumerics.Geometry.XYPolygon contactPolygonLowerStream = new HydroNumerics.Geometry.XYPolygon();
            contactPolygonLowerStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1904.437, 1081.911));
            contactPolygonLowerStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1921.502, 1153.584));
            contactPolygonLowerStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1771.331, 1255.973));
            contactPolygonLowerStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1573.379, 1354.949));
            contactPolygonLowerStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1542.662, 1324.232));
            contactPolygonLowerStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1597.270, 1273.038));
            contactPolygonLowerStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1709.898, 1215.017));
            contactPolygonLowerStream.Points.Add(new HydroNumerics.Geometry.XYPoint(1839.590, 1143.345));

            // --- precipitation --------------------------------------------------

            const int numberOfTimesteps = 1095;
            double[] precipitation = new double[numberOfTimesteps] { 0.0000, 0.0000, 2.3000, 0.2000, 0.0000, 0.1000, 0.1000, 0.0000, 0.3000, 0.4000, 0.1000, 0.1000, 1.0000, 0.0000, 0.5000, 5.3000, 1.9000, 0.1000, 0.0000, 0.4000, 1.1000, 1.2000, 2.6000, 0.0000, 1.5000, 3.4000, 6.0000, 0.7000, 4.0000, 0.1000, 0.6000, 2.0000, 0.4000, 0.1000, 0.0000, 0.0000, 0.0000, 4.1000, 0.2000, 4.0000, 0.3000, 0.6000, 3.1000, 14.1000, 3.9000, 0.1000, 3.7000, 2.4000, 4.3000, 0.0000, 0.0000, 0.0000, 0.0000, 2.7000, 1.0000, 0.1000, 0.3000, 0.2000, 0.0000, 0.2000, 8.7000, 2.0000, 1.8000, 0.9000, 0.1000, 0.2000, 0.1000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.6000, 1.8000, 0.0000, 1.1000, 4.7000, 2.4000, 0.0000, 0.1000, 8.2000, 4.6000, 1.0000, 0.1000, 0.0000, 0.0000, 7.8000, 2.0000, 0.3000, 0.0000, 0.1000, 0.1000, 0.0000, 0.0000, 0.3000, 0.1000, 2.2000, 2.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 6.7000, 0.0000, 0.0000, 0.0000, 5.4000, 2.2000, 1.0000, 10.8000, 3.6000, 3.1000, 10.1000, 0.0000, 0.3000, 2.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 1.3000, 0.0000, 0.0000, 7.6000, 3.6000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 4.5000, 0.0000, 12.8000, 0.0000, 4.4000, 0.0000, 0.0000, 0.0000, 0.0000, 4.9000, 0.0000, 0.8000, 0.0000, 2.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 7.1000, 0.2000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 4.4000, 1.5000, 4.6000, 1.4000, 0.8000, 0.0000, 0.0000, 0.0000, 0.0000, 5.5000, 4.6000, 1.3000, 0.1000, 2.8000, 2.6000, 0.0000, 0.1000, 3.5000, 1.0000, 8.7000, 0.5000, 0.0000, 0.4000, 0.0000, 0.0000, 0.0000, 0.0000, 3.8000, 4.9000, 4.6000, 2.5000, 7.9000, 0.1000, 4.7000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.6000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.2000, 14.4000, 2.0000, 6.2000, 0.5000, 0.3000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 3.2000, 8.1000, 1.3000, 20.2000, 13.5000, 1.1000, 1.3000, 0.0000, 0.0000, 2.1000, 13.7000, 3.9000, 0.5000, 0.1000, 0.0000, 0.0000, 0.1000, 0.0000, 0.0000, 0.2000, 4.8000, 7.2000, 0.4000, 0.0000, 4.6000, 0.2000, 0.0000, 0.0000, 0.5000, 4.8000, 9.8000, 0.6000, 0.0000, 0.0000, 0.0000, 0.0000, 3.2000, 0.0000, 0.0000, 0.0000, 0.0000, 0.4000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.5000, 8.5000, 0.5000, 1.9000, 1.2000, 0.0000, 3.2000, 1.7000, 12.3000, 1.9000, 0.0000, 4.3000, 3.6000, 1.1000, 6.7000, 5.4000, 0.0000, 0.0000, 0.9000, 10.0000, 7.8000, 0.1000, 1.3000, 0.5000, 0.1000, 0.2000, 0.5000, 0.0000, 7.2000, 0.0000, 0.0000, 10.2000, 9.7000, 0.2000, 0.1000, 0.9000, 3.5000, 1.2000, 4.9000, 4.6000, 3.5000, 1.1000, 5.8000, 0.4000, 0.0000, 0.0000, 0.6000, 0.1000, 1.2000, 0.8000, 9.4000, 1.5000, 0.1000, 0.1000, 0.2000, 0.9000, 4.8000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 0.0000, 0.1000, 1.9000, 0.8000, 0.9000, 2.1000, 7.9000, 3.8000, 3.8000, 9.6000, 1.4000, 7.9000, 0.4000, 0.6000, 0.7000, 0.0000, 0.0000, 0.0000, 7.0000, 0.1000, 0.1000, 0.1000, 5.3000, 1.0000, 4.3000, 0.2000, 0.0000, 1.8000, 0.1000, 0.6000, 0.0000, 1.5000, 3.2000, 0.1000, 4.1000, 5.5000, 10.6000, 9.0000, 0.9000, 0.8000, 2.7000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.4000, 0.6000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 0.1000, 2.5000, 5.7000, 2.3000, 2.0000, 0.6000, 0.8000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 4.2000, 9.6000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.7000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 9.3000, 0.0000, 0.0000, 0.0000, 0.0000, 5.3000, 0.0000, 0.0000, 0.7000, 9.0000, 0.2000, 0.0000, 0.0000, 2.8000, 2.4000, 1.5000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 6.4000, 0.0000, 0.0000, 0.8000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 1.0000, 0.0000, 7.1000, 0.1000, 0.0000, 0.2000, 0.0000, 0.0000, 0.2000, 0.0000, 0.6000, 0.9000, 10.0000, 5.1000, 4.1000, 10.3000, 1.9000, 0.0000, 0.0000, 0.0000, 0.2000, 4.2000, 0.4000, 5.8000, 0.5000, 0.1000, 3.3000, 4.9000, 1.4000, 0.5000, 0.0000, 1.8000, 2.5000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 1.4000, 0.0000, 2.4000, 7.6000, 5.2000, 11.4000, 0.1000, 1.1000, 0.7000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.8000, 0.0000, 2.3000, 0.4000, 0.0000, 0.0000, 0.0000, 0.0000, 5.2000, 2.2000, 0.0000, 10.0000, 5.3000, 1.2000, 8.0000, 30.7000, 2.9000, 0.0000, 0.0000, 0.0000, 6.8000, 0.0000, 0.0000, 0.0000, 1.4000, 0.5000, 4.1000, 0.1000, 10.6000, 11.2000, 2.5000, 6.2000, 5.3000, 4.5000, 12.8000, 0.1000, 1.0000, 0.0000, 0.0000, 22.7000, 2.5000, 5.5000, 3.7000, 0.8000, 0.0000, 1.6000, 1.7000, 3.8000, 0.2000, 0.3000, 0.0000, 0.4000, 0.0000, 0.2000, 0.5000, 1.0000, 16.3000, 0.3000, 4.3000, 14.8000, 0.0000, 2.7000, 0.0000, 2.8000, 3.2000, 5.3000, 2.1000, 0.0000, 2.2000, 0.4000, 0.3000, 0.1000, 0.0000, 0.0000, 1.8000, 0.5000, 9.4000, 11.4000, 2.4000, 9.2000, 1.1000, 11.1000, 6.4000, 8.3000, 15.3000, 0.1000, 6.8000, 2.9000, 0.0000, 0.3000, 0.4000, 0.2000, 3.3000, 6.2000, 1.0000, 9.0000, 5.5000, 0.0000, 0.0000, 3.0000, 1.1000, 0.0000, 10.8000, 0.0000, 7.1000, 2.0000, 1.6000, 7.2000, 9.4000, 0.9000, 6.1000, 1.4000, 2.5000, 0.6000, 8.1000, 0.9000, 2.8000, 5.0000, 3.3000, 2.1000, 9.5000, 0.0000, 6.0000, 7.0000, 0.0000, 2.2000, 1.8000, 0.2000, 1.1000, 5.2000, 0.0000, 0.3000, 1.6000, 0.8000, 0.4000, 0.0000, 0.2000, 1.4000, 5.9000, 7.1000, 7.0000, 1.9000, 1.5000, 0.1000, 0.3000, 5.6000, 4.1000, 4.8000, 1.5000, 1.5000, 2.7000, 11.4000, 8.6000, 3.7000, 5.7000, 1.3000, 13.4000, 5.6000, 5.9000, 5.4000, 5.3000, 0.1000, 0.1000, 0.2000, 0.0000, 0.5000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 4.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 0.0000, 2.9000, 3.0000, 1.0000, 14.6000, 0.6000, 5.0000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 1.6000, 2.2000, 0.0000, 0.0000, 0.6000, 0.0000, 0.2000, 2.4000, 0.3000, 0.0000, 0.3000, 5.8000, 1.6000, 1.6000, 5.7000, 2.8000, 1.9000, 0.6000, 2.8000, 0.0000, 8.8000, 2.5000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 3.1000, 0.0000, 0.0000, 0.0000, 0.2000, 0.5000, 0.0000, 3.7000, 5.0000, 10.2000, 1.2000, 0.4000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.6000, 0.3000, 0.0000, 0.0000, 2.2000, 8.4000, 11.5000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.8000, 12.4000, 2.8000, 3.9000, 10.1000, 4.5000, 6.6000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.5000, 0.5000, 0.0000, 0.7000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.3000, 0.7000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 3.2000, 1.4000, 7.3000, 0.0000, 3.7000, 11.1000, 1.2000, 0.0000, 0.0000, 0.0000, 0.0000, 0.1000, 8.3000, 2.2000, 6.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.2000, 0.0000, 0.0000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 11.6000, 5.9000, 0.0000, 0.0000, 8.9000, 17.1000, 0.1000, 4.9000, 2.3000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 14.5000, 2.7000, 1.9000, 3.3000, 0.0000, 0.0000, 19.9000, 2.4000, 4.1000, 2.0000, 4.2000, 0.9000, 0.3000, 0.0000, 0.1000, 0.3000, 0.0000, 3.1000, 2.5000, 0.0000, 1.6000, 3.8000, 8.2000, 5.7000, 7.7000, 0.3000, 0.0000, 5.4000, 7.9000, 1.3000, 10.0000, 0.6000, 0.7000, 0.0000, 0.0000, 0.0000, 0.9000, 0.0000, 0.0000, 0.1000, 2.6000, 6.3000, 4.7000, 0.7000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.2000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 2.3000, 2.0000, 0.0000, 3.1000, 0.9000, 0.1000, 0.0000, 0.0000, 0.0000, 0.0000, 0.0000, 0.3000, 0.4000, 7.5000, 12.4000, 2.9000, 0.5000, 7.6000, 1.6000, 2.3000, 0.0000, 0.0000, 2.1000, 2.3000, 8.0000, 2.1000, 1.7000, 0.0000, 0.0000, 17.9000, 4.5000, 0.5000, 0.7000, 0.3000, 0.0000, 1.1000, 0.1000, 0.0000, 0.0000, 1.1000, 0.1000, 0.0000, 1.2000, 0.0000, 1.2000, 0.8000, 0.7000, 0.0000, 0.1000, 0.2000, 0.2000, 0.0000, 0.4000, 1.3000, 0.0000, 0.0000, 0.0000, 0.1000, 1.4000 };
            HydroNumerics.Time.Core.TimestampSeries precipitationTs = new HydroNumerics.Time.Core.TimestampSeries("PrecipitationTS", startTime, numberOfTimesteps, 1, HydroNumerics.Time.Core.TimestepUnit.Days, -99999, new HydroNumerics.Core.Unit("m3PrSec", 1, 0));
            for (int i = 0; i < numberOfTimesteps; i++)
            {
                precipitationTs.Items[i].Value = precipitation[i] * contactPolygonUpperLake.GetArea() / (24 * 3600 * 1000);
            }
            // --------------------------------------------------------------------


            // Upper Lake configuration
            Lake upperLake = new Lake("Upper Lake", 2 * contactPolygonUpperLake.GetArea());
            upperLake.WaterLevel = 6.1;
            upperLake.Output.LogAllChemicals = true;

            Lake lowerLake = new Lake("lower Lake", 2 * contactPolygonLowerLake.GetArea());
            lowerLake.WaterLevel = 6.0;
            lowerLake.Output.LogAllChemicals = true;

            HydroNet.Core.Stream upperStream = new HydroNet.Core.Stream("The stream", 2000, 2, 1);
            upperStream.WaterLevel = 6.0;
            upperStream.Output.LogAllChemicals = true;

            HydroNet.Core.Stream lowerStream = new HydroNet.Core.Stream("Lower Stream", 1000, 2, 1);
            lowerStream.WaterLevel = 6.0;
            lowerStream.Output.LogAllChemicals = true;

            //SinkSourceBoundary upperLakePrecipitation = new SinkSourceBoundary(0.002 * contactPolygonUpperLake.GetArea() / (24 * 3600));
            SinkSourceBoundary upperLakePrecipitation = new SinkSourceBoundary(precipitationTs);
            
            upperLakePrecipitation.Name = "Inflow to upperlake";


            //SinkSourceBoundary lowerLakePrecipitation = new SinkSourceBoundary(0.002 * contactPolygonLowerLake.GetArea()/ (24 * 3600));
            SinkSourceBoundary lowerLakePrecipitation = new SinkSourceBoundary(precipitationTs);
            upperLakePrecipitation.Name = "Inflow to lowerlake";

            // -------- Groundwater boundary under upper lake ----------
            GroundWaterBoundary groundWaterBoundaryUpperLake = new GroundWaterBoundary();
            groundWaterBoundaryUpperLake.Connection = upperLake;
            groundWaterBoundaryUpperLake.ContactGeometry = contactPolygonUpperLake;
            groundWaterBoundaryUpperLake.Distance = 2.3;
            groundWaterBoundaryUpperLake.HydraulicConductivity = 1e-9;
            groundWaterBoundaryUpperLake.GroundwaterHead = 5.0;
            groundWaterBoundaryUpperLake.Name = "Groundwater boundary under UpperLake";
            groundWaterBoundaryUpperLake.Name = "UpperGWBoundary";
            ((WaterPacket)groundWaterBoundaryUpperLake.WaterSample).AddChemical(ChemicalFactory.Instance.GetChemical(ChemicalNames.Radon), 2.3);
            ((WaterPacket)groundWaterBoundaryUpperLake.WaterSample).AddChemical(ChemicalFactory.Instance.GetChemical(ChemicalNames.Cl), 2.3);

            // -------- Groundwater boundary under lower lake ----------
            GroundWaterBoundary groundWaterBoundaryLowerLake = new GroundWaterBoundary();
            groundWaterBoundaryLowerLake.Connection = lowerLake;
            groundWaterBoundaryLowerLake.ContactGeometry = contactPolygonLowerLake;
            groundWaterBoundaryLowerLake.Distance = 2.3;
            groundWaterBoundaryLowerLake.HydraulicConductivity = 1e-9;
            groundWaterBoundaryLowerLake.GroundwaterHead = 5.0;
            groundWaterBoundaryLowerLake.Name = "Groundwater boundary under LowerLake";
            groundWaterBoundaryLowerLake.Name = "LowerGWBoundary";

            //--- Ground water boundary upper Stream ------
            GroundWaterBoundary groundWaterBoundaryUpperStream = new GroundWaterBoundary();
            groundWaterBoundaryUpperStream.Connection = upperStream;
            groundWaterBoundaryUpperStream.ContactGeometry = contactPolygonUpperStream;
            groundWaterBoundaryUpperStream.Distance = 2.3;
            groundWaterBoundaryUpperStream.HydraulicConductivity = 1e-9;
            groundWaterBoundaryUpperStream.GroundwaterHead = 5.0;
            groundWaterBoundaryUpperStream.Name = "Groundwater boundary Upper Stream";
            groundWaterBoundaryUpperStream.Name = "UpperStreamGWBoundary";
            
            // ---------  Ground water boundary lower stream ------------------------------------------
            GroundWaterBoundary groundWaterBoundaryLowerStream = new GroundWaterBoundary();
            groundWaterBoundaryLowerStream.Connection = lowerStream;
            groundWaterBoundaryLowerStream.ContactGeometry = contactPolygonLowerStream;
            groundWaterBoundaryLowerStream.Distance = 2.3;
            groundWaterBoundaryLowerStream.HydraulicConductivity = 1e-9;
            groundWaterBoundaryLowerStream.GroundwaterHead = 5.0;
            groundWaterBoundaryLowerStream.Name = "Groundwater boundary Lower Stream";
            groundWaterBoundaryLowerStream.Name = "LowerStreamGWBoundary";
            // ------------------------------------------------------------------------------

            upperLake.SurfaceArea = contactPolygonUpperLake;
            lowerLake.SurfaceArea = contactPolygonLowerLake;
            upperLake.Precipitation.Add(upperLakePrecipitation);
            lowerLake.Precipitation.Add(lowerLakePrecipitation);

            upperLake.GroundwaterBoundaries.Add(groundWaterBoundaryUpperLake);
            upperStream.GroundwaterBoundaries.Add(groundWaterBoundaryUpperStream);
            lowerStream.GroundwaterBoundaries.Add(groundWaterBoundaryLowerStream);
            lowerLake.GroundwaterBoundaries.Add(groundWaterBoundaryLowerLake);

 
            upperLake.DownStreamConnections.Add(upperStream);
            upperStream.DownStreamConnections.Add(lowerStream);
            lowerStream.DownStreamConnections.Add(lowerLake);

            //Creating the model
            Model model = new Model();
            model._waterBodies.Add(upperLake);
            model._waterBodies.Add(upperStream);
            model._waterBodies.Add(lowerStream);
            model._waterBodies.Add(lowerLake);
            

            

            WaterPacket waterPacket = new WaterPacket(1000);
            waterPacket.AddChemical(ChemicalFactory.Instance.GetChemical(ChemicalNames.Cl), 9.2);

            model.SetState("MyState", startTime, waterPacket);
            
            //model.SetState("kkk", startTime, new 
            //upperLake.SetState("MyState", startTime, new WaterPacket(2));
            model.Name = "Lake model";
            model.Initialize();
            //model.Update(new DateTime(2001, 1, 1));
            return model;
        }

        [TestMethod]
        public void CreateHydroNetInputfile()
        {

            //string filename = "DemoHydroNet";
            string filename = @"c:\Users\Gregersen\Documents\MyDocs\HydroInform\Projects\1011.Soemod\MikeSheCoupling\HydroNumericsData\DemoHydroNet";
            Model model = CreateHydroNetModel();
            model.Save(filename + ".xml");

            Model modela = ModelFactory.GetModel(filename +".xml"); 

            LinkableComponent linkableHydroNet = new LinkableComponent();
            linkableHydroNet.WriteOmiFile(filename + ".xml", 86400);

        }

        [TestMethod]
        public void AnalyseResults()
        {
            //string filename = "DemoHydroNet.xml";
            string filename = @"c:\Users\Gregersen\Documents\MyDocs\HydroInform\Projects\1011.Soemod\MikeSheCoupling\HydroNumericsData\DemoHydroNet.xml";
            Model model = ModelFactory.GetModel(filename);

            System.Diagnostics.Debug.WriteLine("===============================================================");
            
            DateTime time = new DateTime(2003,06,12);
            TimeSpan timespan = new TimeSpan(1,0,0,0);
            System.Diagnostics.Debug.WriteLine("Time: " + time.ToString());
            System.Diagnostics.Debug.WriteLine("Timespan: " + timespan.ToString());

            foreach (IWaterBody waterBody in model._waterBodies)
            {
                string name = waterBody.Name;
                double groundWaterBoundaryArea = ((XYPolygon)waterBody.GroundwaterBoundaries[0].ContactGeometry).GetArea();
                double groundWaterLeakage = waterBody.GroundwaterBoundaries[0].GetSinkVolume(time, timespan);

                System.Diagnostics.Debug.WriteLine(" -----------------------------------------------------");
                System.Diagnostics.Debug.WriteLine("Name: " + name);
                System.Diagnostics.Debug.WriteLine("Groundwaterboundary area: " + groundWaterBoundaryArea.ToString());
                System.Diagnostics.Debug.WriteLine("Groundwater leakage: " + groundWaterLeakage.ToString());
                System.Diagnostics.Debug.WriteLine("Specific leakage: " + (1000 * groundWaterLeakage / groundWaterBoundaryArea).ToString());

                System.Diagnostics.Debug.WriteLine("WaterVolume: " + waterBody.CurrentStoredWater.ToString());
                if (waterBody is Lake)
                {
                    double outflow = (((Lake)waterBody).Output.Outflow.GetSiValue(time, time + timespan) * timespan.TotalSeconds);
                    System.Diagnostics.Debug.WriteLine("Outflow: " + outflow.ToString());
                    System.Diagnostics.Debug.WriteLine("Specific Outflow [mm]: " + (1000 * outflow / groundWaterBoundaryArea).ToString());
                    foreach (KeyValuePair<Chemical, HydroNumerics.Time.Core.TimestampSeries> ct in ((Lake)waterBody).Output.ChemicalsToLog)
                    {
                        System.Diagnostics.Debug.WriteLine("Chemical name: " + ct.Key.Name + " concentration: " + ct.Value.GetSiValue(time).ToString());
                    }
                    //double cloride = ((Lake)waterBody).Output.ChemicalsToLog[].GetSiValue(time + timespan);
                }

                foreach (ISource source in waterBody.Precipitation)
                {
                    double precipitationVolume = source.GetSourceWater(time, timespan).Volume;
                    System.Diagnostics.Debug.WriteLine("Precipitation: " + precipitationVolume.ToString());
                    System.Diagnostics.Debug.WriteLine("Specific precipitation [mm]: " + (1000 * precipitationVolume / groundWaterBoundaryArea).ToString());
                }

                foreach (ISource source in waterBody.Sources)
                {
                    
                    System.Diagnostics.Debug.WriteLine("SourceWater: " + source.GetSourceWater(time, timespan).Volume.ToString());
                }

                foreach (ISink sink in waterBody.Sinks)
                {
                    System.Diagnostics.Debug.WriteLine("SinkWater: " + sink.GetSinkVolume(time, timespan).ToString());
                }

                

                

                
            }

     
            //Lake upperLake =( Lake)  model._waterBodies[0];
            //System.Diagnostics.Debug.WriteLine("Lake name: " + upperLake.Name);
            //System.Diagnostics.Debug.WriteLine("Boundary area: " + ((XYPolygon)upperLake.GroundwaterBoundaries[0].ContactGeometry).GetArea());
            //System.Diagnostics.Debug.WriteLine("SinkVolume " + upperLake.GroundwaterBoundaries[0].GetSinkVolume(time, timespan).ToString());
            
        
            
            System.Diagnostics.Debug.WriteLine("================================================================");
            
            
        }
        
    }
}
