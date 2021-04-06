using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trimailov;

namespace Test_Trimailov
{
    [TestClass]
    public class MyLogTest
    {
        [TestMethod]
        public void LogTest()
        {
            MyLog.Log("Test log");
            Assert.AreEqual("Test log", MyLog.GetLog().Last());
        }
        [TestMethod]
        public void InstanceTest()
        {
            Assert.IsInstanceOfType(MyLog.Instance(), typeof(MyLog));
        }
        [TestMethod]
        public void writeTest()
        {
            MyLog.Write();
            string path = @"./Log/" +  FindLastFile();
 
            var logFile = File.ReadAllLines(path);
            var logList = new List<string>(logFile);
            CollectionAssert.AreEqual(logList, MyLog.GetLog());
        }
        public string FindLastFile()
        {
            var directory = new DirectoryInfo(@"./Log/");
            return (from f in directory.GetFiles()
                          orderby f.LastWriteTime descending
                          select f).First().Name;
        }

    }
}
