using System.IO;
using System.Windows.Forms;

namespace No8.Solution
{
    /// <summary>
    /// Base abstract class whch describes printer
    /// </summary>
    public abstract class PrinterBase
    {
        public abstract string Name { get; set; }
        public abstract string Model { get; set; }

        /// <summary>
        /// For print document
        /// </summary>
        virtual public void Print()
        {
            string inputText = string.Empty;
            var openWind = new OpenFileDialog();
            openWind.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openWind.ShowDialog();
            using (StreamReader sReader = new StreamReader(openWind.FileName, System.Text.Encoding.Default))
            {
                inputText = sReader.ReadToEnd();
            }
            var saveWind = new SaveFileDialog();
            saveWind.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveWind.ShowDialog();
            using (StreamWriter sWriter = new StreamWriter(saveWind.FileName, false, System.Text.Encoding.Default))
            {
                sWriter.WriteLine(inputText);
            }
        }

        /// <summary>
        /// Override ToString method for display name and model together
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name + " " + Model;
    }
}
