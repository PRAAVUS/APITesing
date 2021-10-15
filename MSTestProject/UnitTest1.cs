using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, TestCategory("Smoke")]
        public void TestMethod1()
        {
            Console.WriteLine("Test Method 1");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("Test Method 2");
        }

        [TestInitialize]
         public void Setup()
        {
            Console.WriteLine("This is setup");
        }

        [TestCleanup]
         public void TearDown()
        {
            Console.WriteLine("This is test cleanup");
        }

        [ClassInitialize]
        public static void classsetup(TestContext testContext)
        {
            Console.WriteLine("Class setup");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("Class Cleanup");
        }
       
        [AssemblyInitialize]
        public static void AssemblySetup(TestContext testContext)
        {
            Console.WriteLine("Assembly setup");
        }

        [AssemblyCleanup]
        public static void AssemblyTeardown()
        { 
            Console.WriteLine("AssemblyTeardown"); 
        
        }







    }
}
