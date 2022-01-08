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

            listView1.Columns.Add("Name", 193, HorizontalAlignment.Left);
            listView1.Columns.Add("Id", 50, HorizontalAlignment.Left);
        }

        public void ProcessesList()
        {
            listView1.Items.Clear();
            Process[] locallAll = Process.GetProcesses();
            int i = 0;
            foreach (Process process in locallAll)
            {
                listView1.Items.Add(process.ProcessName);
                listView1.Items[i].SubItems.Add(Convert.ToString(process.Id));
                i++;
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
                int pId = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text);
                Process processSelected = Process.GetProcessById(pId);
                processSelected.Kill();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}