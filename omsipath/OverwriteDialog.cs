using Omsipath.Properties;

namespace Omsipath
{
    internal partial class OverwriteDialog : Form
    {

        public OverwriteInstruction OverwriteInstruction { get; private set; }

        public OverwriteDialog()
        {
            InitializeComponent();
        }

        public OverwriteDialog(string target)
        {
            InitializeComponent();
            label.Text = string.Format(i18n.msg_overwriteDialogMessage, target);
            radioButtonsPanel.Controls.OfType<RadioButton>().ToList()[Settings.Default.overwriteSetting].Checked = true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            OverwriteInstruction = (OverwriteInstruction)Settings.Default.overwriteSetting;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RadioButtonChanged(object sender, EventArgs e)
        {
            RadioButton selected = radioButtonsPanel.Controls.OfType<RadioButton>().Single(radio => radio.Checked);
            Settings.Default.overwriteSetting = (byte)radioButtonsPanel.Controls.OfType<RadioButton>().ToList().IndexOf(selected);
            Settings.Default.Save();
            Settings.Default.Reload();
        }
    }


}
