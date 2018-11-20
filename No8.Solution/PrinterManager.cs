using System.Collections;
using System.Collections.Generic;

namespace No8.Solution
{
    public class PrinterManager : PrinterBase, IEnumerable<PrinterBase>
    {
        public List<PrinterBase> printers;

        public PrinterManager()
        {
            printers = new List<PrinterBase>();
        }

        

        public void AddPrinter(PrinterSpecs printerSpecs)
        {
            Printer printer = new Printer(printerSpecs);
            printers.Add(printer);
        }

        public IEnumerator GetEnumerator()
        {
            return this.printers.GetEnumerator();
        }

        IEnumerator<PrinterBase> IEnumerable<PrinterBase>.GetEnumerator()
        {
            return printers.GetEnumerator();
        }
        

    }
}