using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    /// <summary>
    /// Create printer
    /// </summary>
    public class Printer : PrinterBase
    {
        public override string Name { get; set; }
        public override string Model { get; set; }

        /// <summary>
        /// Constructor for create Printer
        /// </summary>
        /// <param name="name">Printer name</param>
        /// <param name="model">Printer model</param>
        public Printer(string name, string model)
        {
            Name = name;
            Model = model;
        }
        
    }
}
