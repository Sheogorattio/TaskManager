using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        void UpdateInfo()
        {
            listView.Items.Clear();
            Process[] processes = Process.GetProcesses();
            for(int i = 0; i< processes.Length; i++)
            {
               listView.Items.Add(processes[i].ProcessName).SubItems.Add(processes[i].Id.ToString());
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void Cancel_click(object sender, EventArgs e)
        {
            string proc = listView.SelectedItems[0].Text;
            Process[] processes = Process.GetProcesses();
            for( int i = 0;i< processes.Length;i++)
            {
                if (processes[i].ProcessName == proc)
                {
                    processes[i].Kill();
                    break;
                }
            }
            UpdateInfo();
        }
    }
}
