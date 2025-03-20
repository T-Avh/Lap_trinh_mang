using System.Windows.Forms;

namespace EmailClient
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControl;
        private TabPage tabInbox;
        private TabPage tabSend;

        private ListView listViewEmails;
        private ColumnHeader columnSubject;
        private ColumnHeader columnFrom;
        private ColumnHeader columnDate;
        private TextBox textBoxEmailBody;
        private Button btnLoadEmails;

        private Label lblTo;
        private TextBox txtTo;
        private Label lblSubject;
        private TextBox txtSubject;
        private Label lblBody;
        private TextBox txtBody;
        private Button btnSendEmail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new TabControl();
            this.tabInbox = new TabPage("📩 Hộp thư đến");
            this.tabSend = new TabPage("📨 Gửi Email");

            // ==========================
            // Hộp thư đến
            // ==========================
            this.listViewEmails = new ListView();
            this.columnSubject = new ColumnHeader() { Text = "Chủ đề", Width = 250 };
            this.columnFrom = new ColumnHeader() { Text = "Người gửi", Width = 200 };
            this.columnDate = new ColumnHeader() { Text = "Ngày", Width = 150 };

            this.listViewEmails.Columns.AddRange(new ColumnHeader[] { columnSubject, columnFrom, columnDate });
            this.listViewEmails.View = View.Details;
            this.listViewEmails.FullRowSelect = true;
            this.listViewEmails.Location = new System.Drawing.Point(20, 20);
            this.listViewEmails.Size = new System.Drawing.Size(600, 300);
            this.listViewEmails.SelectedIndexChanged += new System.EventHandler(this.listViewEmails_SelectedIndexChanged);

            this.textBoxEmailBody = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new System.Drawing.Point(20, 340),
                Size = new System.Drawing.Size(600, 150),
                ReadOnly = true
            };

            this.btnLoadEmails = new Button
            {
                Text = "📥 Tải Email",
                Location = new System.Drawing.Point(650, 20),
                Size = new System.Drawing.Size(100, 40)
            };
            this.btnLoadEmails.Click += new System.EventHandler(this.btnLoadEmails_Click);

            this.tabInbox.Controls.Add(this.btnLoadEmails);
            this.tabInbox.Controls.Add(this.listViewEmails);
            this.tabInbox.Controls.Add(this.textBoxEmailBody);

            // ==========================
            // Gửi Email
            // ==========================
            this.lblTo = new Label
            {
                Text = "Người nhận:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            this.txtTo = new TextBox
            {
                Location = new System.Drawing.Point(120, 20),
                Size = new System.Drawing.Size(400, 25)
            };

            this.lblSubject = new Label
            {
                Text = "Chủ đề:",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(100, 20)
            };

            this.txtSubject = new TextBox
            {
                Location = new System.Drawing.Point(120, 60),
                Size = new System.Drawing.Size(400, 25)
            };

            this.lblBody = new Label
            {
                Text = "Nội dung:",
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(100, 20)
            };

            this.txtBody = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new System.Drawing.Point(120, 100),
                Size = new System.Drawing.Size(600, 250)
            };

            this.btnSendEmail = new Button
            {
                Text = "📨 Gửi Email",
                Location = new System.Drawing.Point(650, 360),
                Size = new System.Drawing.Size(100, 40)
            };
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);

            this.tabSend.Controls.Add(this.lblTo);
            this.tabSend.Controls.Add(this.txtTo);
            this.tabSend.Controls.Add(this.lblSubject);
            this.tabSend.Controls.Add(this.txtSubject);
            this.tabSend.Controls.Add(this.lblBody);
            this.tabSend.Controls.Add(this.txtBody);
            this.tabSend.Controls.Add(this.btnSendEmail);

            // ==========================
            // Tab Control
            // ==========================
            this.tabControl.Controls.Add(this.tabInbox);
            this.tabControl.Controls.Add(this.tabSend);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Size = new System.Drawing.Size(780, 550);

            // ==========================
            // Main Form
            // ==========================
            this.Controls.Add(this.tabControl);
            this.Text = "📧 Email Client - Gmail";
            this.Size = new System.Drawing.Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
    }
}
