using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Task_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Process[] locallAll = Process.GetProcesses();
            foreach (Process process in locallAll)
            {
                listView1.Items.Add(process.ProcessName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string processSelected = listView1.SelectedItems[0].Text.ToString();
            Process[] localByName = Process.GetProcessesByName(processSelected);
            localByName.First().Kill();
        }
    }
}