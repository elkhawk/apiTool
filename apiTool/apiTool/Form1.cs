using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apiTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileWindow = new OpenFileDialog();
            fileWindow.InitialDirectory = Application.ExecutablePath;
            fileWindow.Filter = " 头文件(*.h)";
            fileWindow.FilterIndex = 1;
            fileWindow.RestoreDirectory = true;

            if(fileWindow.ShowDialog() == DialogResult.OK)
            {
                string[] filePaths = fileWindow.FileNames;

            }

        }
    }
}
