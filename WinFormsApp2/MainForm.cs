using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.Threading.Tasks;

namespace EmailClient
{
    public partial class MainForm : Form
    {
        private List<MimeMessage> emailMessages = new List<MimeMessage>();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnLoadEmails_Click(object sender, EventArgs e)
        {
            btnLoadEmails.Enabled = false;
            await Task.Run(() => LoadEmails());
            btnLoadEmails.Enabled = true;
        }

        private void LoadEmails()
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate("tuananh12603@gmail.com", "uxxe jxlp rrhj dnkg");

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    var uids = inbox.Search(SearchQuery.All);
                    uids.Reverse(); // Hiển thị email mới nhất trước

                    emailMessages.Clear();
                    Invoke(new Action(() => listViewEmails.Items.Clear()));

                    foreach (var uid in uids)
                    {
                        var message = inbox.GetMessage(uid);
                        emailMessages.Insert(0, message);

                        Invoke(new Action(() =>
                        {
                            ListViewItem item = new ListViewItem(new[]
                            {
                                message.Subject,
                                message.From.ToString(),
                                message.Date.ToString("dd/MM/yyyy HH:mm")
                            });
                            listViewEmails.Items.Insert(0, item);
                        }));
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => MessageBox.Show("Lỗi khi tải email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)));
            }
        }

        private void listViewEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEmails.SelectedIndices.Count > 0)
            {
                int index = listViewEmails.SelectedIndices[0];
                textBoxBody.Text = emailMessages[index].TextBody;
            }
        }
    }
}
