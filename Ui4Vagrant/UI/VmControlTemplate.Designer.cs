
namespace Ui4Vagrant.UI
{
    partial class VmControlTemplate
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.BtUp = new System.Windows.Forms.Button();
            this.BtDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtAdvancedOptions = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BtOpenOnExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.BtOpenOnCMD = new System.Windows.Forms.ToolStripMenuItem();
            this.BtSSH = new System.Windows.Forms.ToolStripMenuItem();
            this.BtDestroy = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(21, 22);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(25, 15);
            this.LblName.TabIndex = 1;
            this.LblName.Text = "xxx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "State";
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Location = new System.Drawing.Point(21, 52);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(25, 15);
            this.LblState.TabIndex = 3;
            this.LblState.Text = "xxx";
            // 
            // BtUp
            // 
            this.BtUp.Location = new System.Drawing.Point(3, 70);
            this.BtUp.Name = "BtUp";
            this.BtUp.Size = new System.Drawing.Size(143, 23);
            this.BtUp.TabIndex = 4;
            this.BtUp.Text = "Up";
            this.BtUp.UseVisualStyleBackColor = true;
            this.BtUp.Click += new System.EventHandler(this.BtUp_Click);
            // 
            // BtDown
            // 
            this.BtDown.Location = new System.Drawing.Point(3, 96);
            this.BtDown.Name = "BtDown";
            this.BtDown.Size = new System.Drawing.Size(143, 23);
            this.BtDown.TabIndex = 5;
            this.BtDown.Text = "Down";
            this.BtDown.UseVisualStyleBackColor = true;
            this.BtDown.Click += new System.EventHandler(this.BtDown_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtAdvancedOptions);
            this.panel1.Controls.Add(this.LblName);
            this.panel1.Controls.Add(this.BtDown);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtUp);
            this.panel1.Controls.Add(this.LblState);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 150);
            this.panel1.TabIndex = 7;
            // 
            // BtAdvancedOptions
            // 
            this.BtAdvancedOptions.Location = new System.Drawing.Point(3, 122);
            this.BtAdvancedOptions.Name = "BtAdvancedOptions";
            this.BtAdvancedOptions.Size = new System.Drawing.Size(143, 23);
            this.BtAdvancedOptions.TabIndex = 6;
            this.BtAdvancedOptions.Text = "Advanced";
            this.BtAdvancedOptions.UseVisualStyleBackColor = true;
            this.BtAdvancedOptions.Click += new System.EventHandler(this.BtAdvancedOptions_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtOpenOnExplorer,
            this.BtOpenOnCMD,
            this.BtSSH,
            this.BtDestroy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 92);
            // 
            // BtOpenOnExplorer
            // 
            this.BtOpenOnExplorer.Name = "BtOpenOnExplorer";
            this.BtOpenOnExplorer.Size = new System.Drawing.Size(168, 22);
            this.BtOpenOnExplorer.Text = "Open on Explorer";
            this.BtOpenOnExplorer.Click += new System.EventHandler(this.BtOpenOnExplorer_Click);
            // 
            // BtOpenOnCMD
            // 
            this.BtOpenOnCMD.Name = "BtOpenOnCMD";
            this.BtOpenOnCMD.Size = new System.Drawing.Size(168, 22);
            this.BtOpenOnCMD.Text = "Open Dir on CMD";
            this.BtOpenOnCMD.Click += new System.EventHandler(this.BtOpenOnCMD_Click);
            // 
            // BtSSH
            // 
            this.BtSSH.Name = "BtSSH";
            this.BtSSH.Size = new System.Drawing.Size(168, 22);
            this.BtSSH.Text = "SSH";
            this.BtSSH.Click += new System.EventHandler(this.BtSSH_Click);
            // 
            // BtDestroy
            // 
            this.BtDestroy.Name = "BtDestroy";
            this.BtDestroy.Size = new System.Drawing.Size(168, 22);
            this.BtDestroy.Text = "Destroy";
            this.BtDestroy.Click += new System.EventHandler(this.BtDestroy_Click);
            // 
            // VmControlTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.Controls.Add(this.panel1);
            this.Name = "VmControlTemplate";
            this.Size = new System.Drawing.Size(159, 160);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.Button BtUp;
        private System.Windows.Forms.Button BtDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtAdvancedOptions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BtOpenOnCMD;
        private System.Windows.Forms.ToolStripMenuItem BtSSH;
        private System.Windows.Forms.ToolStripMenuItem BtDestroy;
        private System.Windows.Forms.ToolStripMenuItem BtOpenOnExplorer;
    }
}
