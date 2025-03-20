using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Search;

namespace EmailClient
{
    public partial class MainForm : Form
    {
        private string email;
        private string password;
        private List<MimeMessage> emailMessages = new List<MimeMessage>();

        public MainForm(string email, string password)
        {
            InitializeComponent();
            this.email = email;
            this.password = password;
        }

        private void btnLoadEmails_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate(email, password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    emailMessages.Clear();
                    listViewEmails.Items.Clear();

                    var uids = inbox.Search(SearchQuery.All);
                    foreach (var uid in uids)
                    {
                        emailMessages.Add(inbox.GetMessage(uid));
                    }

                    emailMessages.Sort((x, y) => y.Date.CompareTo(x.Date)); // Sắp xếp từ mới nhất

                    foreach (var message in emailMessages)
                    {
                        var item = new ListViewItem(new[] { message.Subject, message.From.ToString(), message.Date.ToString() });
                        listViewEmails.Items.Add(item);
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            SendEmailForm sendForm = new SendEmailForm(email, password);
            sendForm.ShowDialog();
        }

        private void listViewEmails_DoubleClick(object sender, EventArgs e)
        {
            if (listViewEmails.SelectedIndices.Count > 0)
            {
                int index = listViewEmails.SelectedIndices[0];
                var selectedEmail = emailMessages[index];

                EmailDetailForm detailForm = new EmailDetailForm(selectedEmail);
                detailForm.ShowDialog();
            }
        }
    }
}
