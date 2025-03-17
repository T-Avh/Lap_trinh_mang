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
            btnLoadEmails.Text = "Đang tải...";

            await Task.Run(() => LoadEmails());

            btnLoadEmails.Text = "Tải Email";
            btnLoadEmails.Enabled = true;
        }

        private void LoadEmails()
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate("n.tuananh.mail@gmail.com", "rdlc anei qbkh cgyj");

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    var uids = inbox.Search(SearchQuery.All);
                    emailMessages.Clear();

                    Invoke(new Action(() => listViewEmails.Items.Clear()));

                    foreach (var uid in uids)
                    {
                        var message = inbox.GetMessage(uid);
                        emailMessages.Add(message);

                        Invoke(new Action(() =>
                        {
                            ListViewItem item = new ListViewItem(new[]
                            {
                                message.Subject,
                                message.From.ToString(),
                                message.To.ToString(),
                                message.Date.ToString()
                            });
                            listViewEmails.Items.Add(item);
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
                var email = emailMessages[index];

                txtEmailInfo.Text = $"📌 Tiêu đề: {email.Subject}\r\n" +
                                    $"✉️ Từ: {email.From}\r\n" +
                                    $"📩 Đến: {email.To}\r\n" +
                                    $"🕒 Ngày gửi: {email.Date}\r\n\r\n" +
                                    $"📄 Nội dung:\r\n{email.TextBody}";
            }
        }
    }
}
