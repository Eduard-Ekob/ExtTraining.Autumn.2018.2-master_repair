using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
            const int defaultmenustartingpoint = 2;
            var pm = new PrinterManager(defaultmenustartingpoint);
            var logger = new Logging();
            pm.LoggingEvent += logger.Log;

            // Add default printer
            pm.AddPrinter("Canon", "FX15");
            pm.AddPrinter("Epson", "E-1181");

            // Menu logic
            while (true)
            {
                const int defaultmenupoints = 2;
                int PointsInMenu = defaultmenupoints;
                System.Console.WriteLine("Select your choice:");
                System.Console.WriteLine();
                System.Console.WriteLine("1:Add new printer");
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
                    string inputText = string.Empty;
                    var openWind = new OpenFileDialog();
                    openWind.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                    openWind.ShowDialog();
                    using (StreamReader sReader = new StreamReader(openWind.FileName, System.Text.Encoding.Default))
                    {
                        inputText = sReader.ReadToEnd();
                        pm.Print(printerNumber, inputText);
                    }
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
