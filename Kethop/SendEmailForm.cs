using System;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailClient
{
    public partial class SendEmailForm : Form
    {
        private string email;
        private string password;

        public SendEmailForm(string email, string password)
        {
            InitializeComponent();
            this.email = email;
            this.password = password;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Me", email));
                message.To.Add(new MailboxAddress("", txtTo.Text));
                message.Subject = txtSubject.Text;

                var bodyBuilder = new BodyBuilder { TextBody = txtBody.Text };
                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate(email, password);
                    client.Send(message);
                    client.Disconnect(true);
                }

                MessageBox.Show("Gửi email thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
