namespace Omsipath
{
    partial class InfoForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.applicationName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.licenses = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sourceCodeButton = new System.Windows.Forms.Button();
            this.supportButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.applicationName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.licenses, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.OKButton, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // applicationName
            // 
            resources.ApplyResources(this.applicationName, "applicationName");
            this.applicationName.Name = "applicationName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Omsipath.Properties.Resources.preview;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // licenses
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.licenses, 2);
            resources.ApplyResources(this.licenses, "licenses");
            this.licenses.Name = "licenses";
            this.licenses.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.sourceCodeButton);
            this.flowLayoutPanel1.Controls.Add(this.supportButton);
            this.flowLayoutPanel1.Controls.Add(this.updateButton);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // sourceCodeButton
            // 
            resources.ApplyResources(this.sourceCodeButton, "sourceCodeButton");
            this.sourceCodeButton.Name = "sourceCodeButton";
            this.sourceCodeButton.Click += new System.EventHandler(this.sourceCodeButton_Click);
            // 
            // supportButton
            // 
            resources.ApplyResources(this.supportButton, "supportButton");
            this.supportButton.Name = "supportButton";
            this.supportButton.Click += new System.EventHandler(this.supportButton_Click);
            // 
            // updateButton
            // 
            resources.ApplyResources(this.updateButton, "updateButton");
            this.updateButton.Name = "updateButton";
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // OKButton
            // 
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Name = "OKButton";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // InfoForm
            // 
            this.AcceptButton = this.OKButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OKButton;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.InfoForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label applicationName;
        private PictureBox pictureBox1;
        private TextBox licenses;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button sourceCodeButton;
        private Button supportButton;
        private Button updateButton;
        private Button OKButton;
    }
}