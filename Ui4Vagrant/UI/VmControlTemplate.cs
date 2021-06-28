using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ui4Vagrant.Support;

namespace Ui4Vagrant.UI
{
    public partial class VmControlTemplate : UserControl
    {
        private VirtualMachine vm;

        private VmControlTemplate()
        {
            InitializeComponent();
        }

        public VmControlTemplate(VirtualMachine _vm) : base()
        {
            vm = _vm;
        }

        private void VmControlTemplate_Load(object sender, EventArgs e)
        {
            BkgLoadVmInfo.RunWorkerAsync();
        }

        private void BkgLoadVmInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            LblName.Text = vm.Name;
            LblState.Text = vm.State;
        }

        private void BkgLoadVmInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (vm.State.ToLower() == "running")
            {
                BtUp.Enabled = false;
                BtDown.Enabled = true;
            }
            else
            {
                BtUp.Enabled = true;
                BtDown.Enabled = false;
            }
        }

        private void BtUp_Click(object sender, EventArgs e)
        {

        }

        private void BtDown_Click(object sender, EventArgs e)
        {

        }

        private void BtRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
