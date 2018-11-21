using System;
using System.Collections.Generic;

namespace No8.Solution.Console
{
    class Program
    {
        /// <summary>
        /// Add printer
        /// </summary>
        /// <param name="pm">printer manager reference</param>        
        public static void AddCustomPrinter(PrinterManager pm)
        {
            System.Console.WriteLine("Enter printer name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Enter printer model");
            string model = System.Console.ReadLine();
            pm.AddPrinter(name, model);
        }

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            // Add default printer
            var pm = new PrinterManager(2);
            pm.AddPrinter("Canon", "FX15");
            pm.AddPrinter("Epson", "E-1181");

            // Menu logic
            while (true)
            {
                int PointsInMenu = 0;
                System.Console.WriteLine("Select your choice:");
                PointsInMenu++;
                System.Console.WriteLine();
                System.Console.WriteLine("1:Add new printer");
                PointsInMenu++;
                foreach (KeyValuePair<int, Printer> kv in pm.Printers)
                {
                    System.Console.WriteLine("{0}:Print on {1}", kv.Key, kv.Value.ToString());
                }

                PointsInMenu += pm.Printers.Count;
                System.Console.WriteLine("{0}:Exit", PointsInMenu);
                System.Console.WriteLine();
                System.Console.WriteLine("Choose menu point");
                string point = System.Console.ReadLine();
                int printerNumber;
                int.TryParse(point, out printerNumber);

                if (point == "1")
                {
                    AddCustomPrinter(pm);
                }
                else if (pm.Printers.ContainsKey(printerNumber))
                {
                    pm.Print(printerNumber);
                }
                else if (point == PointsInMenu.ToString())
                {
                    return;
                }
                else
                {
                    System.Console.WriteLine("Wrong menu point");
                    System.Console.WriteLine();
                }
            }
        }
    }
}
