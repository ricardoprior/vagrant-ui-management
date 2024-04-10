using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Ui4Vagrant.Support;

namespace Ui4Vagrant.UI;

public partial class VmControl : Form
{
    private readonly string _userHome;
    private MachinesIndex _list;
    private readonly List<string> _workList = [];

    public VmControl()
    {
        InitializeComponent();

        _userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }

    private void VmControl_Load(object sender, EventArgs e)
    {
        BkgLoadMachines.RunWorkerAsync(argument: false);
    }

    private void BkgLoadMachines_DoWork(object sender, DoWorkEventArgs e)
    {
        var wait = e.Argument != null && (bool)e.Argument;

        if (wait)
        {
            while (BkgExecuteCommands.IsBusy || consoleControl1.IsProcessRunning)
            {
            }
        }

        var path = @$"{_userHome}\.vagrant.d\data\machine-index\index";
        if (File.Exists(path))
        {
            _list = JsonConvert.DeserializeObject<MachinesIndex>(File.ReadAllText(path));
        }
    }

    private void BkgLoadMachines_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        flowLayoutPanel1.Controls.Clear();

        if (_list.Machines.Values.Count == 0)
        {
            flowLayoutPanel1.Controls.Add(new Label
            {
                Text = @"No vms found."
            });
            return;
        }

        if (_list.Machines.Count > 10)
        {
            flowLayoutPanel1.AutoScroll = true;
            Size = new Size(859, 566);
        }

        foreach (var machineControls in _list.Machines.Values.Select(vm => new VmControlTemplate(vm)))
        {
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
        var cmd = (string)e.Argument;
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
        var cmd = (string)e.Result;
        consoleControl1.StartProcess("cmd.exe", cmd);

        _workList.Remove(cmd);

        BtQueue.Text = $@"Work List: {_workList.Count}";

        if (_workList.Count > 0)
        {
            BkgExecuteCommands.RunWorkerAsync(argument: _workList[0]);
            return;
        }

        if (!BkgLoadMachines.IsBusy)
        {
            BkgLoadMachines.RunWorkerAsync(argument: true);
        }
    }

    public void ExecuteCommand(string cmd)
    {
        if (!_workList.Contains(cmd))
        {
            _workList.Add(cmd);
        }

        BtQueue.Text = $@"Work List: {_workList.Count}";

        if (_workList.Count <= 0 || BkgExecuteCommands.IsBusy)
        {
            return;
        }

        BkgExecuteCommands.RunWorkerAsync(argument: _workList[0]);
    }
}
