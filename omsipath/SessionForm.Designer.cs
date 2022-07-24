namespace Omsipath
{
    partial class SessionForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionForm));
            this.sessionList = new System.Windows.Forms.ListBox();
            this.saveCurrentSessionButton = new System.Windows.Forms.Button();
            this.deleteSessionButton = new System.Windows.Forms.Button();
            this.loadSessionButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sessionList
            // 
            this.sessionList.FormattingEnabled = true;
            resources.ApplyResources(this.sessionList, "sessionList");
            this.sessionList.Name = "sessionList";
            this.toolTip.SetToolTip(this.sessionList, resources.GetString("sessionList.ToolTip"));
            // 
            // saveCurrentSessionButton
            // 
            resources.ApplyResources(this.saveCurrentSessionButton, "saveCurrentSessionButton");
            this.saveCurrentSessionButton.Name = "saveCurrentSessionButton";
            this.toolTip.SetToolTip(this.saveCurrentSessionButton, resources.GetString("saveCurrentSessionButton.ToolTip"));
            this.saveCurrentSessionButton.Click += new System.EventHandler(this.SaveCurrentSessionButton_Click);
            // 
            // deleteSessionButton
            // 
            resources.ApplyResources(this.deleteSessionButton, "deleteSessionButton");
            this.deleteSessionButton.Name = "deleteSessionButton";
            this.toolTip.SetToolTip(this.deleteSessionButton, resources.GetString("deleteSessionButton.ToolTip"));
            this.deleteSessionButton.Click += new System.EventHandler(this.DeleteSessionButton_Click);
            // 
            // loadSessionButton
            // 
            resources.ApplyResources(this.loadSessionButton, "loadSessionButton");
            this.loadSessionButton.Name = "loadSessionButton";
            this.toolTip.SetToolTip(this.loadSessionButton, resources.GetString("loadSessionButton.ToolTip"));
            this.loadSessionButton.Click += new System.EventHandler(this.LoadSessionButton_Click);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.saveCurrentSessionButton);
            this.flowLayoutPanel1.Controls.Add(this.deleteSessionButton);
            this.flowLayoutPanel1.Controls.Add(this.loadSessionButton);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // SessionForm
            // 
            this.AcceptButton = this.loadSessionButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.sessionList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SessionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SessionForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListBox sessionList;
        private Button saveCurrentSessionButton;
        private Button deleteSessionButton;
        private Button loadSessionButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private ToolTip toolTip;
    }
}