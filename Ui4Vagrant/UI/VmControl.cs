using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Ui4Vagrant.Support;

namespace Ui4Vagrant.UI
{
    public partial class VmControl : Form
    {
        private readonly string UserHome;
        private MachinesIndex list;
        private int MAX_ROW = 4;
        private int MAX_COL = 4;

        public VmControl()
        {
            InitializeComponent();

            UserHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        private void VmControl_Load(object sender, EventArgs e)
        {
            BkgLoadMachines.RunWorkerAsync();
        }

        private void BkgLoadMachines_DoWork(object sender, DoWorkEventArgs e)
        {
            //string path = @$"{UserHome}\.vagrant.d\data\machine-index\index";
            string path = @"_tmp\demo.json";
            if (File.Exists(path))
            {
                list = JsonConvert.DeserializeObject<MachinesIndex>(File.ReadAllText(path));
            }
        }

        private void BkgLoadMachines_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (VirtualMachine vm in list.Machines.Values)
            {
                VmControlTemplate machineControls = new VmControlTemplate(vm);
                flowLayoutPanel1.Controls.Add(machineControls);
                machineControls.Show();
            }

            //string path = @"_tmp\up.bat";
            //consoleControl1.StartProcess(path, @"cd c:\dev\code\devops\postgresql");
        }
    }
}
