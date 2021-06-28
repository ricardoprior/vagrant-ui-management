
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
            this.label1 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblState = new System.Windows.Forms.Label();
            this.BtUp = new System.Windows.Forms.Button();
            this.BtDown = new System.Windows.Forms.Button();
            this.BtRefresh = new System.Windows.Forms.Button();
            this.BgkUp = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(16, 19);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(25, 15);
            this.LblName.TabIndex = 1;
            this.LblName.Text = "xxx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "State";
            // 
            // LblState
            // 
            this.LblState.AutoSize = true;
            this.LblState.Location = new System.Drawing.Point(16, 49);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(25, 15);
            this.LblState.TabIndex = 3;
            this.LblState.Text = "xxx";
            // 
            // BtUp
            // 
            this.BtUp.Location = new System.Drawing.Point(3, 67);
            this.BtUp.Name = "BtUp";
            this.BtUp.Size = new System.Drawing.Size(144, 23);
            this.BtUp.TabIndex = 4;
            this.BtUp.Text = "Up";
            this.BtUp.UseVisualStyleBackColor = true;
            this.BtUp.Click += new System.EventHandler(this.BtUp_Click);
            // 
            // BtDown
            // 
            this.BtDown.Location = new System.Drawing.Point(3, 96);
            this.BtDown.Name = "BtDown";
            this.BtDown.Size = new System.Drawing.Size(144, 23);
            this.BtDown.TabIndex = 5;
            this.BtDown.Text = "Down";
            this.BtDown.UseVisualStyleBackColor = true;
            this.BtDown.Click += new System.EventHandler(this.BtDown_Click);
            // 
            // BtRefresh
            // 
            this.BtRefresh.Enabled = false;
            this.BtRefresh.Location = new System.Drawing.Point(3, 125);
            this.BtRefresh.Name = "BtRefresh";
            this.BtRefresh.Size = new System.Drawing.Size(144, 23);
            this.BtRefresh.TabIndex = 6;
            this.BtRefresh.Text = "Refresh";
            this.BtRefresh.UseVisualStyleBackColor = true;
            this.BtRefresh.Click += new System.EventHandler(this.BtRefresh_Click);
            // 
            // BgkUp
            // 
            this.BgkUp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgkUp_DoWork);
            // 
            // VmControlTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtRefresh);
            this.Controls.Add(this.BtDown);
            this.Controls.Add(this.BtUp);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.label1);
            this.Name = "VmControlTemplate";
            this.Size = new System.Drawing.Size(150, 154);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.Button BtUp;
        private System.Windows.Forms.Button BtDown;
        private System.Windows.Forms.Button BtRefresh;
        private System.ComponentModel.BackgroundWorker BgkUp;
    }
}
