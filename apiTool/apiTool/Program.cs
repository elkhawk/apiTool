using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace apiTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ////form
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            // get tradeapi Name
            StreamReader file = new StreamReader(@"..\..\..\apis\USTPFtdcTraderApi.h", Encoding.UTF8, true);
            List<string> tradeapi = new List<string>();

            string apiPattern = @"\s*(\S*)\(";
            Regex re = new Regex(apiPattern);
            string line = file.ReadLine();
            while (!file.EndOfStream)
            {
                MatchCollection finds = re.Matches(line);
                foreach (Match m in finds)
                {
                    string s = m.Result("$1");
                    tradeapi.Add(s);
                }
                line = file.ReadLine();
            }

            // get tradeapi‘s input struct &  comments;


            foreach (string a in tradeapi)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine(tradeapi.Count);
            Console.ReadLine();
            file.Close();
        }
    }
}
