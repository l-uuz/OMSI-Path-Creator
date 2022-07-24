using Omsipath.Properties;

namespace Omsipath
{
    internal partial class SessionForm : Form
    {
        private Session CurrentSession { get; }
        public Session? SessionToLoad { get; private set; }

        public SessionForm(Session currentSession)
        {
            InitializeComponent();
            CurrentSession = currentSession;
        }

        private void SessionForm_Load(object sender, EventArgs e)
        {
            RefreshSessionList();
        }

        private void SaveCurrentSessionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentSession.ProjectName))
            {
                MessageBox.Show(i18n.msg_noSubDirectory, i18n.msg_error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SessionManager.WriteSession(CurrentSession);
            RefreshSessionList();
        }

        private void DeleteSessionButton_Click(object sender, EventArgs e)
        {
            if (sessionList.SelectedItem is not string item)
            {
                Utils.Beep();
                return;
            }
            SessionManager.DeleteSession(item);
        }

        private void LoadSessionButton_Click(object sender, EventArgs e)
        {
            if (sessionList.SelectedItem is not string item)
            {
                Utils.Beep();
                return;
            }

            SessionToLoad = SessionManager.ReadSession(item);
            if (SessionToLoad == null) Utils.Beep();
            DialogResult = DialogResult.OK;
        }

        private void RefreshSessionList()
        {
            sessionList.Items.Clear();
            foreach (var foundSession in SessionManager.FindSessions())
            {
                sessionList.Items.Add(foundSession);
            }
        }
    }
}
