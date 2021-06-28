using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Ui4Vagrant.Support;

namespace Ui4Vagrant.UI
{
    public partial class VmControlTemplate : UserControl
    {
        private VirtualMachine vm;
        private ConsoleControl.ConsoleControl mainConsole;

        private VmControlTemplate()
        {
            InitializeComponent();
        }

        public VmControlTemplate(VirtualMachine _vm, ConsoleControl.ConsoleControl _console) : base()
        {
            InitializeComponent();

            vm = _vm;
            mainConsole = _console;

            LblName.Text = vm.Name;
            LblState.Text = vm.State;
            if (vm.State.ToLower() == "running")
            {
                LblState.ForeColor = Color.Green;
                BtUp.Enabled = false;
                BtDown.Enabled = true;
            }
            else
            {
                LblState.ForeColor = Color.Red;
                BtUp.Enabled = true;
                BtDown.Enabled = false;
            }
        }

        private void BtUp_Click(object sender, EventArgs e)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + path);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }

        private void BtDown_Click(object sender, EventArgs e)
        {


        }

        private void BtRefresh_Click(object sender, EventArgs e)
        {

        }

        private void BgkUp_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }
}
