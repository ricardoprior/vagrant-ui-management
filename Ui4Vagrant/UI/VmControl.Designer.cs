
namespace Ui4Vagrant.UI
{
    partial class VmControl
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BkgLoadMachines = new System.ComponentModel.BackgroundWorker();
            this.consoleControl1 = new ConsoleControl.ConsoleControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // BkgLoadMachines
            // 
            this.BkgLoadMachines.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgLoadMachines_DoWork);
            this.BkgLoadMachines.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgLoadMachines_RunWorkerCompleted);
            // 
            // consoleControl1
            // 
            this.consoleControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.consoleControl1.IsInputEnabled = true;
            this.consoleControl1.Location = new System.Drawing.Point(0, 277);
            this.consoleControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.consoleControl1.Name = "consoleControl1";
            this.consoleControl1.SendKeyboardCommandsToProcess = false;
            this.consoleControl1.ShowDiagnostics = false;
            this.consoleControl1.Size = new System.Drawing.Size(800, 173);
            this.consoleControl1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 277);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // VmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.consoleControl1);
            this.Name = "VmControl";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.VmControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BkgLoadMachines;
        private ConsoleControl.ConsoleControl consoleControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

