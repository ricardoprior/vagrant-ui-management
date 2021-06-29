using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Ui4Vagrant.Support;

namespace Ui4Vagrant.UI
{
    public partial class VmControl : Form
    {
        private readonly string UserHome;
        private MachinesIndex list;
        private List<string> workList = new List<string>();

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
            string path = @$"{UserHome}\.vagrant.d\data\machine-index\index";
            if (File.Exists(path))
            {
                list = JsonConvert.DeserializeObject<MachinesIndex>(File.ReadAllText(path));
            }
        }

        private void BkgLoadMachines_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            if (list.Machines.Values.Count == 0)
            {
                flowLayoutPanel1.Controls.Add(new Label()
                {
                    Text = "No vms found."
                });
                return;
            }

            foreach (VirtualMachine vm in list.Machines.Values)
            {
                VmControlTemplate machineControls = new VmControlTemplate(vm, consoleControl1, BkgLoadMachines);
                flowLayoutPanel1.Controls.Add(machineControls);
                machineControls.Show();
            }
        }

        private void BtRefresh_Click(object sender, EventArgs e)
        {
            if (!BkgLoadMachines.IsBusy)
            {
                BkgLoadMachines.RunWorkerAsync();
            }
        }

        private void BtClearConsoleOutput_Click(object sender, EventArgs e)
        {
            if (!consoleControl1.IsProcessRunning)
            {
                consoleControl1.ClearOutput();
            }
        }

        private void BtOnlyFavourites_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
