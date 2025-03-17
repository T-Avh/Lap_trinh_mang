using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string senderEmail = "nguyentuananh1262003@gmail.com";  // Thay bằng email thật
            string appPassword = "asix iwju ghkl ggcf";    // Thay bằng mật khẩu ứng dụng

            string recipientEmail = txtRecipient.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string body = txtBody.Text;

            if (string.IsNullOrEmpty(recipientEmail) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MailMessage mail = new MailMessage())
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    if (!string.IsNullOrEmpty(txtAttachment.Text))
                        mail.Attachments.Add(new Attachment(txtAttachment.Text));

                    smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    MessageBox.Show("Email đã được gửi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtAttachment.Text = openFileDialog.FileName;
            }
        }
    }
}
