using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ui4Vagrant.Support;

namespace Ui4Vagrant.UI
{
    public partial class VmControlTemplate : UserControl
    {
        private readonly VirtualMachine vm;
        private readonly ConsoleControl.ConsoleControl mainConsole;
        private readonly BackgroundWorker BkgLoadMachines;
        private List<string> WorkList = new List<string>();

        private const string VAGRANT_UP = @"/C cd @path & cls & vagrant up";
        private const string VAGRANT_HALT = @"/C cd @path & cls & vagrant halt";
        private const string VAGRANT_CMD = @"/K cd @path & cls";
        private const string VAGRANT_SSH = @"/K cd @path & cls & vagrant ssh";
        private const string VAGRANT_DESTROY = @"/C cd @path & cls & vagrant destroy";

        private const string VM_STATE_RUNNING = "running";
        private const string VM_STATE_POWERED_OFF = "poweroff";
        private const string VM_STATE_ABORTED = "aborted";

        private VmControlTemplate()
        {
            InitializeComponent();
        }

        public VmControlTemplate(VirtualMachine _vm, ConsoleControl.ConsoleControl _console, BackgroundWorker _bkgLoadMachines, List<string> _workList) : this()
        {
            vm = _vm;
            mainConsole = _console;
            BkgLoadMachines = _bkgLoadMachines;

            LblName.Text = vm.Name;
            UpdateButtonState(vm.State);

            if (!Directory.Exists(vm.VagrantFilePath))
            {
                BtOpenOnExplorer.Enabled = false;
                BtOpenOnCMD.Enabled = false;
            }

            //TODO: Remover qsuando funcionar
            BtOpenOnExplorer.Enabled = false;
        }

        private void BtUp_Click(object sender, EventArgs e)
        {
            mainConsole.StartProcess("cmd.exe", VAGRANT_UP.Replace("@path", vm.VagrantFilePath));

            if (!BkgLoadMachines.IsBusy)
            {
                BkgLoadMachines.RunWorkerAsync();
            }
        }

        private void BtDown_Click(object sender, EventArgs e)
        {
            mainConsole.StartProcess("cmd.exe", VAGRANT_HALT.Replace("@path", vm.VagrantFilePath));

            if (!BkgLoadMachines.IsBusy)
            {
                BkgLoadMachines.RunWorkerAsync();
            }
        }

        private void BtAdvancedOptions_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(MousePosition);
        }

        private void BtOpenOnExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(vm.VagrantFilePath);
        }

        private void BtOpenOnCMD_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", VAGRANT_CMD.Replace("@path", vm.VagrantFilePath));
        }

        private void BtSSH_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", VAGRANT_SSH.Replace("@path", vm.VagrantFilePath));
        }

        private void BtDestroy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to delete \"{vm.Name}\"?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.No)
            {
                return;
            }

            Process.Start("cmd.exe", VAGRANT_DESTROY.Replace("@path", vm.VagrantFilePath));

            if (!BkgLoadMachines.IsBusy)
            {
                BkgLoadMachines.RunWorkerAsync();
            }
        }

        public void UpdateButtonState(string state)
        {
            LblState.Text = state;

            switch (state)
            {
                case VM_STATE_RUNNING:
                    LblState.ForeColor = Color.Green;
                    BtUp.Enabled = false;
                    BtDown.Enabled = true;
                    BtSSH.Enabled = true;
                    BtDestroy.Enabled = true;
                    break;

                case VM_STATE_POWERED_OFF:
                    LblState.ForeColor = Color.Black;
                    BtUp.Enabled = true;
                    BtDown.Enabled = false;
                    BtSSH.Enabled = false;
                    BtDestroy.Enabled = true;

                    break;

                default:
                    LblState.ForeColor = Color.Red;
                    BtUp.Enabled = true;
                    BtDown.Enabled = true;
                    BtSSH.Enabled = true;
                    BtDestroy.Enabled = true;
                    break;
            }
        }
    }
}

/* para ref

int exitCode;
ProcessStartInfo processInfo;
Process process;
processInfo = new ProcessStartInfo(""cmd.exe".exe", VAGRANT_UP.Replace("@path", vm.VagrantFilePath));
processInfo.CreateNoWindow = true;
processInfo.UseShellExecute = false;
 *** Redirect the output ***
processInfo.RedirectStandardError = true;
processInfo.RedirectStandardOutput = true;

process = Process.Start(processInfo);
process.WaitForExit();

 *** Read the streams ***
 Warning: This approach can lead to deadlocks, see Edit #2
string output = process.StandardOutput.ReadToEnd();
string error = process.StandardError.ReadToEnd();

exitCode = process.ExitCode;

Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
process.Close();
*/
