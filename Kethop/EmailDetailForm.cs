using System;
using System.Windows.Forms;
using MimeKit;

namespace EmailClient
{
    public partial class EmailDetailForm : Form
    {
        public EmailDetailForm(MimeMessage email)
        {
            InitializeComponent();
            lblFrom.Text = "Từ: " + email.From.ToString();
            lblSubject.Text = "Chủ đề: " + email.Subject;
            lblDate.Text = "Ngày gửi: " + email.Date.ToString();
            txtBody.Text = email.TextBody;
        }
    }
}
