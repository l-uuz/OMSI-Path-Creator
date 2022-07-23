namespace Omsipath
{
    partial class OverwriteDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverwriteDialog));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.selectDelete = new System.Windows.Forms.RadioButton();
            this.selectCopyOverwrite = new System.Windows.Forms.RadioButton();
            this.selectOnlyOverwrite = new System.Windows.Forms.RadioButton();
            this.selectNotOverwrite = new System.Windows.Forms.RadioButton();
            this.label = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.radioButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.buttonPanel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.radioButtonsPanel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label, 0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // buttonPanel
            // 
            resources.ApplyResources(this.buttonPanel, "buttonPanel");
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Name = "buttonPanel";
            // 
            // radioButtonsPanel
            // 
            resources.ApplyResources(this.radioButtonsPanel, "radioButtonsPanel");
            this.radioButtonsPanel.Controls.Add(this.selectDelete);
            this.radioButtonsPanel.Controls.Add(this.selectCopyOverwrite);
            this.radioButtonsPanel.Controls.Add(this.selectOnlyOverwrite);
            this.radioButtonsPanel.Controls.Add(this.selectNotOverwrite);
            this.radioButtonsPanel.Name = "radioButtonsPanel";
            // 
            // selectDelete
            // 
            resources.ApplyResources(this.selectDelete, "selectDelete");
            this.selectDelete.Name = "selectDelete";
            this.selectDelete.TabStop = true;
            this.selectDelete.UseVisualStyleBackColor = true;
            this.selectDelete.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // selectCopyOverwrite
            // 
            resources.ApplyResources(this.selectCopyOverwrite, "selectCopyOverwrite");
            this.selectCopyOverwrite.Name = "selectCopyOverwrite";
            this.selectCopyOverwrite.TabStop = true;
            this.selectCopyOverwrite.UseVisualStyleBackColor = true;
            this.selectCopyOverwrite.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // selectOnlyOverwrite
            // 
            resources.ApplyResources(this.selectOnlyOverwrite, "selectOnlyOverwrite");
            this.selectOnlyOverwrite.Name = "selectOnlyOverwrite";
            this.selectOnlyOverwrite.TabStop = true;
            this.selectOnlyOverwrite.UseVisualStyleBackColor = true;
            this.selectOnlyOverwrite.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // selectNotOverwrite
            // 
            resources.ApplyResources(this.selectNotOverwrite, "selectNotOverwrite");
            this.selectNotOverwrite.Name = "selectNotOverwrite";
            this.selectNotOverwrite.UseVisualStyleBackColor = true;
            this.selectNotOverwrite.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            // 
            // OverwriteDialog
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverwriteDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.radioButtonsPanel.ResumeLayout(false);
            this.radioButtonsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.FlowLayoutPanel radioButtonsPanel;
        private System.Windows.Forms.RadioButton selectDelete;
        private System.Windows.Forms.RadioButton selectCopyOverwrite;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.RadioButton selectOnlyOverwrite;
        private System.Windows.Forms.RadioButton selectNotOverwrite;
    }
}