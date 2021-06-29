using System;
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

        public VmControlTemplate(VirtualMachine _vm) : this()
        {
            vm = _vm;

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
            string cmd = VAGRANT_UP.Replace("@path", vm.VagrantFilePath);
            BtUp.Enabled = false;
            //TODO: Validar 
            ((VmControl)Parent.Parent).ExecuteCommand(cmd);
        }

        private void BtDown_Click(object sender, EventArgs e)
        {
            string cmd = VAGRANT_HALT.Replace("@path", vm.VagrantFilePath);
            BtDown.Enabled = false;
            //TODO: Validar 
            ((VmControl)Parent.Parent).ExecuteCommand(cmd);
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

            string cmd = VAGRANT_DESTROY.Replace("@path", vm.VagrantFilePath);
            BtDestroy.Enabled = false;
            //TODO: Validar 
            ((VmControl)Parent.Parent).ExecuteCommand(cmd);
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
