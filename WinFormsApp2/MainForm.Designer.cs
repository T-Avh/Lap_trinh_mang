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
            btnLoadEmails = new Button();
            listViewEmails = new ListView();
            columnSubject = new ColumnHeader();
            columnFrom = new ColumnHeader();
            columnDate = new ColumnHeader();
            textBoxBody = new TextBox();
            SuspendLayout();
            // 
            // btnLoadEmails
            // 
            btnLoadEmails.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnLoadEmails.Location = new Point(20, 20);
            btnLoadEmails.Name = "btnLoadEmails";
            btnLoadEmails.Size = new Size(150, 40);
            btnLoadEmails.TabIndex = 0;
            btnLoadEmails.Text = "Tải Email";
            btnLoadEmails.Click += btnLoadEmails_Click;
            // 
            // listViewEmails
            // 
            listViewEmails.Columns.AddRange(new ColumnHeader[] { columnSubject, columnFrom, columnDate });
            listViewEmails.FullRowSelect = true;
            listViewEmails.GridLines = true;
            listViewEmails.Location = new Point(20, 70);
            listViewEmails.Name = "listViewEmails";
            listViewEmails.Size = new Size(600, 300);
            listViewEmails.TabIndex = 1;
            listViewEmails.UseCompatibleStateImageBehavior = false;
            listViewEmails.View = View.Details;
            listViewEmails.SelectedIndexChanged += listViewEmails_SelectedIndexChanged;
            // 
            // columnSubject
            // 
            columnSubject.Text = "Chủ đề";
            columnSubject.Width = 250;
            // 
            // columnFrom
            // 
            columnFrom.Text = "Người gửi";
            columnFrom.Width = 200;
            // 
            // columnDate
            // 
            columnDate.Text = "Ngày";
            columnDate.Width = 150;
            // 
            // textBoxBody
            // 
            textBoxBody.Location = new Point(20, 380);
            textBoxBody.Multiline = true;
            textBoxBody.Name = "textBoxBody";
            textBoxBody.ScrollBars = ScrollBars.Vertical;
            textBoxBody.Size = new Size(600, 150);
            textBoxBody.TabIndex = 2;
            // 
            // MainForm
            // 
            ClientSize = new Size(650, 550);
            Controls.Add(btnLoadEmails);
            Controls.Add(listViewEmails);
            Controls.Add(textBoxBody);
            Name = "MainForm";
            Text = "Trình Nhận Email";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
