using NLog;
using System;
using System.Collections.Generic;

namespace No8.Solution
{
    public class LoggingEventArgs : System.EventArgs
    {
        public string message;
        public LoggingEventArgs(string message)
        {
            this.message = message;
        }
    }

    /// <summary>
    /// The Printers Manager, which manage printers like add printer, print on printer
    /// </summary>
    public class PrinterManager
    {
        public Dictionary<int, Printer> Printers { get; private set; }
        private int numberOfPrinter;
        public event EventHandler<LoggingEventArgs> LoggingEvent;
        protected virtual void OnLogging(LoggingEventArgs e)
        {
            if (LoggingEvent != null) LoggingEvent(this, e);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrinterManager() : this(0)
        {            
        }

        /// <summary>
        /// Constructor of fields init
        /// </summary>
        /// <param name="beginPrinterNumeration"></param>
        public PrinterManager(int beginPrinterNumeration)
        {
            if (beginPrinterNumeration < 0)
            {
                throw new ArgumentException("Wrong printer numeration");
            }

            Printers = new Dictionary<int, Printer>();
            numberOfPrinter = beginPrinterNumeration;
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
                string errormessage = "The same printer " + name + " " + model + " " + "is exist";
                OnLogging(new LoggingEventArgs(errormessage));
                throw new ArgumentException(errormessage);
            }

            var printer = new Printer(name, model);
            Printers.Add(numberOfPrinter, printer);
            OnLogging(new LoggingEventArgs("Printer is added" + " " + Printers[numberOfPrinter].ToString()));
            numberOfPrinter++;
        }

        /// <summary>
        /// Check if printer exist
        /// </summary>
        /// <param name="name">printer name</param>
        /// <param name="model">printer model</param>
        /// <returns></returns>
        private bool CheckIfPrinterIsExist(string name, string model)
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
        /// Check if printer is not exist
        /// </summary>
        /// <param name="name">printer name</param>
        /// <param name="model">printer model</param>
        /// <returns></returns>
        private bool CheckIfPrinterIsNotExist(string name, string model)
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
        public void Print(int numberOfPrinter, string inputText)
        {
            if (inputText == null)
            {
                throw new ArgumentNullException(nameof(inputText));
            }

            if (!Printers.ContainsKey(numberOfPrinter))
            {
                string errormessage = "Printer does not exist";
                OnLogging(new LoggingEventArgs(errormessage));
                throw new ArgumentException(errormessage);
            }

            var currentPrinter = Printers[numberOfPrinter];
            OnLogging(new LoggingEventArgs("Start print on printer" + " " + currentPrinter.ToString()));
            currentPrinter.Print(inputText);            
            OnLogging(new LoggingEventArgs("End print on printer" + " " + currentPrinter.ToString()));
        }
    }
}