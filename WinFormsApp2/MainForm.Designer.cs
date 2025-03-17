namespace EmailClient
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadEmails;
        private System.Windows.Forms.ListView listViewEmails;
        private System.Windows.Forms.ColumnHeader columnSubject;
        private System.Windows.Forms.ColumnHeader columnFrom;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.TextBox textBoxBody;

        private void InitializeComponent()
        {
            this.btnLoadEmails = new System.Windows.Forms.Button();
            this.listViewEmails = new System.Windows.Forms.ListView();
            this.columnSubject = new System.Windows.Forms.ColumnHeader();
            this.columnFrom = new System.Windows.Forms.ColumnHeader();
            this.columnDate = new System.Windows.Forms.ColumnHeader();
            this.textBoxBody = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            // 
            // btnLoadEmails
            // 
            this.btnLoadEmails.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoadEmails.Location = new System.Drawing.Point(20, 20);
            this.btnLoadEmails.Size = new System.Drawing.Size(150, 40);
            this.btnLoadEmails.Text = "Tải Email";
            this.btnLoadEmails.Click += new System.EventHandler(this.btnLoadEmails_Click);

            // 
            // listViewEmails
            // 
            this.listViewEmails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSubject,
            this.columnFrom,
            this.columnDate});
            this.listViewEmails.FullRowSelect = true;
            this.listViewEmails.GridLines = true;
            this.listViewEmails.Location = new System.Drawing.Point(20, 70);
            this.listViewEmails.Size = new System.Drawing.Size(600, 300);
            this.listViewEmails.View = System.Windows.Forms.View.Details;
            this.listViewEmails.SelectedIndexChanged += new System.EventHandler(this.listViewEmails_SelectedIndexChanged);

            // 
            // columnSubject
            // 
            this.columnSubject.Text = "Chủ đề";
            this.columnSubject.Width = 250;
            // 
            // columnFrom
            // 
            this.columnFrom.Text = "Người gửi";
            this.columnFrom.Width = 200;
            // 
            // columnDate
            // 
            this.columnDate.Text = "Ngày";
            this.columnDate.Width = 150;

            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(20, 380);
            this.textBoxBody.Multiline = true;
            this.textBoxBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBody.Size = new System.Drawing.Size(600, 150);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(650, 550);
            this.Controls.Add(this.btnLoadEmails);
            this.Controls.Add(this.listViewEmails);
            this.Controls.Add(this.textBoxBody);
            this.Text = "Trình Nhận Email";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
