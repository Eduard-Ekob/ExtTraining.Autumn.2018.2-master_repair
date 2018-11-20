using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace No8.Solution
{
    public class PrinterManager  /*IEnumerable<Printer>*/
    {
        private Dictionary<int, Printer> printers;
        private int numberOfPrinter;

        public PrinterManager()
        {
            printers = new Dictionary<int, Printer>();
        }


        public void AddPrinter(PrinterSpecs printerSpecs)
        {
            Printer printer = new Printer(printerSpecs);
            printers.Add(numberOfPrinter, printer);            
            numberOfPrinter++;
        }

        public void Print(int numberOfPrinter)
        {
            var currentPrinter = printers[numberOfPrinter];
            currentPrinter.Print();
            
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return printers.GetEnumerator();
        //}

        //IEnumerator<Printer> IEnumerable<Printer>.GetEnumerator()
        //{
        //    return printers.GetEnumerator();
        //}
        

    }
}