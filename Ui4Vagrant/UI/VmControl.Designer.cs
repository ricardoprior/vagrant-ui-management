
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BtGeral = new System.Windows.Forms.ToolStripMenuItem();
            this.BtClearConsoleOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.BtRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.BtOnlyFavourites = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BkgLoadMachines
            // 
            this.BkgLoadMachines.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgLoadMachines_DoWork);
            this.BkgLoadMachines.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgLoadMachines_RunWorkerCompleted);
            // 
            // consoleControl1
            // 
            this.consoleControl1.AutoScroll = true;
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 253);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtGeral});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BtGeral
            // 
            this.BtGeral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtRefresh,
            this.BtClearConsoleOutput,
            this.BtOnlyFavourites});
            this.BtGeral.Name = "BtGeral";
            this.BtGeral.Size = new System.Drawing.Size(46, 20);
            this.BtGeral.Text = "Geral";
            // 
            // BtClearConsoleOutput
            // 
            this.BtClearConsoleOutput.Name = "BtClearConsoleOutput";
            this.BtClearConsoleOutput.Size = new System.Drawing.Size(188, 22);
            this.BtClearConsoleOutput.Text = "Clear Console Output";
            this.BtClearConsoleOutput.Click += new System.EventHandler(this.BtClearConsoleOutput_Click);
            // 
            // BtRefresh
            // 
            this.BtRefresh.Name = "BtRefresh";
            this.BtRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.BtRefresh.Size = new System.Drawing.Size(180, 22);
            this.BtRefresh.Text = "Refresh";
            this.BtRefresh.Click += new System.EventHandler(this.BtRefresh_Click);
            // 
            // BtOnlyFavourites
            // 
            this.BtOnlyFavourites.CheckOnClick = true;
            this.BtOnlyFavourites.Enabled = false;
            this.BtOnlyFavourites.Name = "BtOnlyFavourites";
            this.BtOnlyFavourites.Size = new System.Drawing.Size(188, 22);
            this.BtOnlyFavourites.Text = "Only Favourites";
            this.BtOnlyFavourites.CheckedChanged += new System.EventHandler(this.BtOnlyFavourites_CheckedChanged);
            // 
            // VmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.consoleControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "VmControl";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.VmControl_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ConsoleControl.ConsoleControl consoleControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BtGeral;
        private System.Windows.Forms.ToolStripMenuItem BtOnlyFavourites;
        private System.Windows.Forms.ToolStripMenuItem BtRefresh;
        private System.ComponentModel.BackgroundWorker BkgLoadMachines;
        private System.Windows.Forms.ToolStripMenuItem BtClearConsoleOutput;
    }
}

