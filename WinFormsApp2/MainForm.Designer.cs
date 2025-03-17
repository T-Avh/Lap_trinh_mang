namespace EmailClient
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadEmails;
        private System.Windows.Forms.ListView listViewEmails;
        private System.Windows.Forms.ColumnHeader columnSubject;
        private System.Windows.Forms.ColumnHeader columnFrom;
        private System.Windows.Forms.ColumnHeader columnTo;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.TextBox txtEmailInfo;

        private void InitializeComponent()
        {
            this.btnLoadEmails = new System.Windows.Forms.Button();
            this.listViewEmails = new System.Windows.Forms.ListView();
            this.columnSubject = new System.Windows.Forms.ColumnHeader();
            this.columnFrom = new System.Windows.Forms.ColumnHeader();
            this.columnTo = new System.Windows.Forms.ColumnHeader();
            this.columnDate = new System.Windows.Forms.ColumnHeader();
            this.txtEmailInfo = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            // Nút "Tải Email"
            this.btnLoadEmails.Location = new System.Drawing.Point(20, 15);
            this.btnLoadEmails.Size = new System.Drawing.Size(120, 35);
            this.btnLoadEmails.Text = "Tải Email";
            this.btnLoadEmails.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.btnLoadEmails.BackColor = System.Drawing.Color.LightBlue;
            this.btnLoadEmails.Click += new System.EventHandler(this.btnLoadEmails_Click);

            // ListView - Danh sách Email
            this.listViewEmails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnSubject,
                this.columnFrom,
                this.columnTo,
                this.columnDate});
            this.listViewEmails.FullRowSelect = true;
            this.listViewEmails.Location = new System.Drawing.Point(20, 60);
            this.listViewEmails.Size = new System.Drawing.Size(750, 250);
            this.listViewEmails.View = System.Windows.Forms.View.Details;
            this.listViewEmails.SelectedIndexChanged += new System.EventHandler(this.listViewEmails_SelectedIndexChanged);

            // Tiêu đề cột
            this.columnSubject.Text = "📌 Tiêu đề";
            this.columnSubject.Width = 250;
            this.columnFrom.Text = "✉️ Từ";
            this.columnFrom.Width = 180;
            this.columnTo.Text = "📩 Đến";
            this.columnTo.Width = 180;
            this.columnDate.Text = "🕒 Ngày gửi";
            this.columnDate.Width = 140;

            // TextBox - Hiển thị nội dung email
            this.txtEmailInfo.Location = new System.Drawing.Point(20, 320);
            this.txtEmailInfo.Multiline = true;
            this.txtEmailInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmailInfo.Size = new System.Drawing.Size(750, 250);
            this.txtEmailInfo.Font = new System.Drawing.Font("Arial", 10);
            this.txtEmailInfo.ReadOnly = true;
            this.txtEmailInfo.BackColor = System.Drawing.Color.WhiteSmoke;

            // MainForm - Cấu hình giao diện chính
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnLoadEmails);
            this.Controls.Add(this.listViewEmails);
            this.Controls.Add(this.txtEmailInfo);
            this.Name = "MainForm";
            this.Text = "📧 Trình xem Email - Gmail Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
