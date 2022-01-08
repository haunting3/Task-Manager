using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Task_Manager
{
    public partial class Form1 : Form
    {
        int cont = Process.GetProcesses().Length;
        public Form1()
        {
            InitializeComponent();
            ProcessesList();
        }

        public void ProcessesList()
        {
            listView1.Items.Clear();
            Process[] locallAll = Process.GetProcesses();
            foreach (Process process in locallAll)
            {
                listView1.Items.Add(process.ProcessName);
            }
        }

        public void UpdateList()
        {
            if (cont != Process.GetProcesses().Length)
            {
                cont = Process.GetProcesses().Length;
                toolStripStatusLabel2.Text = Convert.ToString(cont);
                ProcessesList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count != 0) 
            { 
                string processSelected = listView1.SelectedItems[0].Text.ToString();
                Process[] localByName = Process.GetProcessesByName(processSelected);
                localByName.First().Kill();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}