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
            foreach (VirtualMachine vm in list.Machines.Values)
            {
                VmControlTemplate machineControls = new VmControlTemplate(vm, consoleControl1);
                flowLayoutPanel1.Controls.Add(machineControls);
                machineControls.Show();
            }
        }

        private void apenasFavoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (apenasFavoritosToolStripMenuItem.Checked)
            {

            }
        }

        private void refreshToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void apenasFavoritosToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
