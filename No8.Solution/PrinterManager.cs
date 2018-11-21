using NLog;
using System;
using System.Collections.Generic;

namespace No8.Solution
{
    public delegate void Logger(string message);
    /// <summary>
    /// The Printers Manager 
    /// </summary>
    public class PrinterManager
    {
        public event Logger onLog;
        public Dictionary<int, Printer> Printers { get; private set; }
        private int numberOfPrinter;
        private NLog.Logger log;
        /// <summary>
        /// Constructor of fields init
        /// </summary>
        /// <param name="beginPrinterNumeration"></param>
        public PrinterManager(int beginPrinterNumeration)
        {
            Printers = new Dictionary<int, Printer>();
            numberOfPrinter = beginPrinterNumeration;
            log = LogManager.GetCurrentClassLogger();
            this.onLog += this.Logging;
        }

        /// <summary>
        /// Event Handler. Write log file
        /// </summary>
        /// <param name="message">Input message for logging</param>
        public void Logging(string message)
        {
            log.Debug(message);
        }

        /// <summary>
        /// Add printer
        /// </summary>
        /// <param name="name">Name printer</param>
        /// <param name="model">Model printer</param>
        public void AddPrinter(string name, string model)
        {
            if (!CheckIfPrinterIsExist(name, model))
            {
                string message = "The same printer " + name + " " + model + " " + "is exist";
                onLog(message);
                throw new ArgumentException(message);
            }

            var printer = new Printer(name, model);
            Printers.Add(numberOfPrinter, printer);
            onLog("Printer is added" + " " + Printers[numberOfPrinter].ToString());
            numberOfPrinter++;
        }
        /// <summary>
        /// Check if printer exist
        /// </summary>
        /// <param name="name">printer name</param>
        /// <param name="model">printer model</param>
        /// <returns></returns>
        public bool CheckIfPrinterIsExist(string name, string model)
        {
            foreach (KeyValuePair<int, Printer> kv in Printers)
            {
                if (kv.Value.Name.Contains(name) && kv.Value.Model.Contains(model))
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Print document
        /// </summary>
        /// <param name="numberOfPrinter">number printer wich on to print</param>
        public void Print(int numberOfPrinter)
        {
            var currentPrinter = Printers[numberOfPrinter];
            onLog("Start print on printer" + " " + currentPrinter.ToString());
            try
            {
                currentPrinter.Print();
            }
            catch (Exception e)
            {
                log.Debug(e.Message);
                return;
            }

            onLog("End print on printer" + " " + currentPrinter.ToString());
        }
    }
}