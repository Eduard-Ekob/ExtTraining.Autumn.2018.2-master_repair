using System.Collections.Specialized;

namespace No8.Solution
{
    public class PrinterSpecs
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public PrinterSpecs(string name, string model)
        {
            Name = name;
            Model = model;
        }
    }
}