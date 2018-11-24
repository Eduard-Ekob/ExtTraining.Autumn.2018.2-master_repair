using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class No8SolutionTests
    {       
        [Test]
        public void PrinterBaseTests()
        {
            var pm = new PrinterManager();
            pm.AddPrinter("HP", "FX15");
            pm.AddPrinter("Samsung", "5815");

            Printer printerHP = new Printer("HP", "FX15");
            Printer printerSams = new Printer("Samsung", "5815");

            var outpPm = new Dictionary<int, Printer>();
            outpPm.Add(0, printerHP);
            outpPm.Add(1, printerSams);

            string expectedHP = printerHP.ToString();
            string expectedSams = printerSams.ToString();

            Assert.AreEqual(expectedHP, pm.Printers[0].ToString());
            Assert.AreEqual(expectedSams, pm.Printers[1].ToString());
        }
        
        PrinterManager pm = new PrinterManager();
        [Test]
        public void PrinterBaseTestsPrintOnWrongPrinterNumber_throwsArgumentException() =>
            Assert.Throws<ArgumentException>(() => pm.Print(-1, "Hello World"));

        [Test]
        public void PrinterBaseTestsPrintEmptyText_throwsArgumentException() =>
            Assert.Throws<ArgumentException>(() => pm.Print(1, ""));

    }
}