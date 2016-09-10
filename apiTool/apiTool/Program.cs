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
            //form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // get tradeapi Name
            StreamReader file = new StreamReader(@"..\..\..\apis\USTPFtdcTraderApi.h", Encoding.Default, true);
            List<string> tradeapi = new List<string>();

            //找到  apiName
            string funcNamePattern = @"\s*(\S*)\(";
            string varNamePattern = @"\((\w*)\s";
            string commentPattern = @"^\s*//";
            Regex funcNameRe = new Regex(funcNamePattern);
            Regex varNameRe = new Regex(varNamePattern);
            Regex commentRe = new Regex(commentPattern);
            List<apiFunc> funcList= new List<apiFunc>();
            
            string line = file.ReadLine();
            while (!file.EndOfStream)
            {
                //MatchCollection comments = commentRe.Matches(line);
                Match comments = commentRe.Match(line);
                StringBuilder sb = new StringBuilder();
                
                while(comments.Success)
                {
                    sb.AppendLine(line);
                    line = file.ReadLine();
                    comments = commentRe.Match(line);
                }

                Match funcs = funcNameRe.Match(line);
                if(funcs.Success)
                {
                    Match vars = varNameRe.Match(line);
                    if(vars.Success)
                    {
                        apiFunc one = new apiFunc(funcs.Result("$1"), vars.Result("$1"), line, sb.ToString());
                        funcList.Add(one);
                    }
                }
                
                //MatchCollection funcs = funcRe.Matches(line);
                //foreach (Match m in funcs)
                //{
                //    string s = m.Result("$1");
                //    tradeapi.Add(s);
                //}
                line = file.ReadLine();
            }

            // get tradeapi‘s input struct &  comments;

            Console.WriteLine(funcList.Count);
            foreach (apiFunc a in funcList)
            {
                Console.Write(a.FuncName);
                Console.Write("-" + a.FuncVar);
                Console.WriteLine(a.FuncComment);                
            }
            //Console.WriteLine(tradeapi.Count);
            Console.ReadLine();
            file.Close();
        }
    }
}
