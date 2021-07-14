using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ui4Vagrant.Support;

namespace Ui4Vagrant.UI
{
    public partial class VmControl : Form
    {
        private readonly string UserHome;
        private MachinesIndex list;
        private readonly List<string> WorkList = new List<string>();

        public VmControl()
        {
            InitializeComponent();

            UserHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        private void VmControl_Load(object sender, EventArgs e)
        {
            BkgLoadMachines.RunWorkerAsync(argument: false);
        }

        private void BkgLoadMachines_DoWork(object sender, DoWorkEventArgs e)
        {
            bool wait = (bool)e.Argument;

            if (wait)
            {
                while (BkgExecuteCommands.IsBusy || consoleControl1.IsProcessRunning)
                {

                }
            }

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

            if (list.Machines.Count > 10)
            {
                flowLayoutPanel1.AutoScroll = true;
                Size = new Size(859, 566);
            }

            foreach (VirtualMachine vm in list.Machines.Values)
            {
                VmControlTemplate machineControls = new VmControlTemplate(vm);
                flowLayoutPanel1.Controls.Add(machineControls);
                machineControls.Show();
            }
        }

        private void BtRefresh_Click(object sender, EventArgs e)
        {
            if (!BkgLoadMachines.IsBusy)
            {
                BkgLoadMachines.RunWorkerAsync(argument: false);
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

        private void BkgExecuteCommands_DoWork(object sender, DoWorkEventArgs e)
        {
            string cmd = (string)e.Argument;
            if (consoleControl1.IsProcessRunning)
            {
                while (consoleControl1.IsProcessRunning)
                {

                }

                System.Threading.Thread.Sleep(1000);
            }

            e.Result = cmd;
        }

        private void BkgExecuteCommands_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string cmd = (string)e.Result;
            consoleControl1.StartProcess("cmd.exe", cmd);

            WorkList.Remove(cmd);

            BtQueue.Text = "Work List: " + WorkList.Count.ToString();

            if (WorkList.Count > 0)
            {
                BkgExecuteCommands.RunWorkerAsync(argument: WorkList[0]);
                return;
            }

            BkgLoadMachines.RunWorkerAsync(argument: true);
        }

        public void ExecuteCommand(string cmd)
        {
            if (!WorkList.Contains(cmd))
            {
                WorkList.Add(cmd);
            }

            BtQueue.Text = "Work List: " + WorkList.Count.ToString();

            if (WorkList.Count > 0 && !BkgExecuteCommands.IsBusy)
            {
                BkgExecuteCommands.RunWorkerAsync(argument: WorkList[0]);
                return;
            }
        }
    }
}
