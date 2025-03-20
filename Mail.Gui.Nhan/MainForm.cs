using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailClient
{
    public partial class MainForm : Form
    {
        private string email;
        private string password;
        private List<MimeMessage> emailMessages = new List<MimeMessage>();

        public MainForm(string email, string password)
        {
            this.email = email;
            this.password = password;
            InitializeComponent();
        }

        private void btnLoadEmails_Click(object sender, EventArgs e)
        {
            emailMessages.Clear();
            listViewEmails.Items.Clear();

            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate(email, password);

                var inbox = client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);

                var uids = inbox.Search(SearchQuery.All);
                uids.Reverse(); // Lấy email mới nhất trước

                foreach (var uid in uids)
                {
                    var message = inbox.GetMessage(uid);
                    emailMessages.Add(message);

                    ListViewItem item = new ListViewItem(new[]
                    {
                        message.Subject,
                        message.From.ToString(),
                        message.Date.ToString()
                    });

                    listViewEmails.Items.Add(item);
                }

                client.Disconnect(true);
            }
        }

        private void listViewEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEmails.SelectedIndices.Count == 0) return;

            int index = listViewEmails.SelectedIndices[0];
            MimeMessage message = emailMessages[index];

            textBoxEmailBody.Text = message.TextBody;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("", email));
                message.To.Add(new MailboxAddress("", txtTo.Text));
                message.Subject = txtSubject.Text;
                message.Body = new TextPart("plain") { Text = txtBody.Text };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate(email, password);
                    client.Send(message);
                    client.Disconnect(true);
                }

                MessageBox.Show("Email đã gửi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
