using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class Printer : PrinterBase
    {
        public PrinterSpecs printerSpecs;
        public Printer(PrinterSpecs printerSpecs)
        {
            this.printerSpecs = printerSpecs;
        }
    }
}
