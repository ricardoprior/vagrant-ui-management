using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ui4Vagrant.Support;

namespace Ui4Vagrant.UI;

public partial class VmControlTemplate : UserControl
{
    private readonly VirtualMachine _vm;

    private const string VagrantUp = @"/C cd @path & cls & vagrant up";
    private const string VagrantHalt = @"/C cd @path & cls & vagrant halt";
    private const string VagrantCmd = @"/K cd @path & cls";
    private const string VagrantSsh = @"/K cd @path & cls & vagrant ssh";
    private const string VagrantDestroy = @"/C cd @path & cls & vagrant destroy";

    private const string VmStateRunning = "running";
    private const string VmStatePoweredOff = "poweroff";
    private const string VmStateAborted = "aborted";

    private VmControlTemplate()
    {
        InitializeComponent();
    }

    public VmControlTemplate(VirtualMachine vm) : this()
    {
        _vm = vm;

        LblName.Text = _vm.Name;
        UpdateButtonState(_vm.State);

        if (!Directory.Exists(_vm.VagrantFilePath))
        {
            BtOpenOnExplorer.Enabled = false;
            BtOpenOnCMD.Enabled = false;
        }

        //TODO: Remover quando funcionar
        BtOpenOnExplorer.Enabled = false;
    }

    private void BtUp_Click(object sender, EventArgs e)
    {
        var cmd = VagrantUp.Replace("@path", _vm.VagrantFilePath);
        BtUp.Enabled = false;
        //TODO: Validar
        ((VmControl)Parent.Parent).ExecuteCommand(cmd);
    }

    private void BtDown_Click(object sender, EventArgs e)
    {
        var cmd = VagrantHalt.Replace("@path", _vm.VagrantFilePath);
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
        Process.Start(_vm.VagrantFilePath);
    }

    private void BtOpenOnCMD_Click(object sender, EventArgs e)
    {
        Process.Start("cmd.exe", VagrantCmd.Replace("@path", _vm.VagrantFilePath));
    }

    private void BtSSH_Click(object sender, EventArgs e)
    {
        Process.Start("cmd.exe", VagrantSsh.Replace("@path", _vm.VagrantFilePath));
    }

    private void BtDestroy_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show($@"Are you sure you want to delete ""{_vm.Name}""?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        if (result == DialogResult.No)
        {
            return;
        }

        var cmd = VagrantDestroy.Replace("@path", _vm.VagrantFilePath);
        BtDestroy.Enabled = false;
        //TODO: Validar
        ((VmControl)Parent.Parent).ExecuteCommand(cmd);
    }

    private void UpdateButtonState(string state)
    {
        LblState.Text = state;

        switch (state)
        {
            case VmStateRunning:
                LblState.ForeColor = Color.Green;
                BtUp.Enabled = false;
                BtDown.Enabled = true;
                BtSSH.Enabled = true;
                BtDestroy.Enabled = true;
                break;

            case VmStatePoweredOff:
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
