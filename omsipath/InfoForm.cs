using Omsipath.Properties;

namespace Omsipath
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            applicationName.Text = Utils.GetNameAndVersion();
            licenses.Text = Resources.LICENSE;
        }

        private void sourceCodeButton_Click(object sender, EventArgs e)
        {
            Utils.OpenUrl(Settings.Default.urlSourceCode);
        }

        private void supportButton_Click(object sender, EventArgs e)
        {
            Utils.OpenUrl(Settings.Default.urlSupport);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Utils.OpenUrl(Settings.Default.urlUpdates);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
