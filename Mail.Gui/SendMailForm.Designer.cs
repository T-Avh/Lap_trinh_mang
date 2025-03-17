namespace EmailSender
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRecipient;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox txtAttachment;
        private System.Windows.Forms.Label lblAttachment;

        private void InitializeComponent()
        {
            lblRecipient = new Label();
            txtRecipient = new TextBox();
            lblSubject = new Label();
            txtSubject = new TextBox();
            lblBody = new Label();
            txtBody = new TextBox();
            btnSendEmail = new Button();
            btnChooseFile = new Button();
            txtAttachment = new TextBox();
            lblAttachment = new Label();
            SuspendLayout();
            // 
            // lblRecipient
            // 
            lblRecipient.Location = new Point(20, 20);
            lblRecipient.Name = "lblRecipient";
            lblRecipient.Size = new Size(74, 23);
            lblRecipient.TabIndex = 0;
            lblRecipient.Text = "📩 Đến:";
            // 
            // txtRecipient
            // 
            txtRecipient.Location = new Point(100, 20);
            txtRecipient.Name = "txtRecipient";
            txtRecipient.Size = new Size(400, 23);
            txtRecipient.TabIndex = 1;
            // 
            // lblSubject
            // 
            lblSubject.Location = new Point(20, 60);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(74, 23);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "📌 Tiêu đề:";
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(100, 60);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(400, 23);
            txtSubject.TabIndex = 3;
            // 
            // lblBody
            // 
            lblBody.Location = new Point(20, 100);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(80, 23);
            lblBody.TabIndex = 4;
            lblBody.Text = "📄 Nội dung:";
            // 
            // txtBody
            // 
            txtBody.Location = new Point(100, 100);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.ScrollBars = ScrollBars.Vertical;
            txtBody.Size = new Size(400, 150);
            txtBody.TabIndex = 5;
            // 
            // btnSendEmail
            // 
            btnSendEmail.BackColor = Color.LightGreen;
            btnSendEmail.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnSendEmail.Location = new Point(200, 320);
            btnSendEmail.Name = "btnSendEmail";
            btnSendEmail.Size = new Size(150, 40);
            btnSendEmail.TabIndex = 9;
            btnSendEmail.Text = "📤 Gửi Email";
            btnSendEmail.UseVisualStyleBackColor = false;
            btnSendEmail.Click += btnSendEmail_Click;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(410, 270);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(75, 23);
            btnChooseFile.TabIndex = 8;
            btnChooseFile.Text = "Chọn File";
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // txtAttachment
            // 
            txtAttachment.Location = new Point(126, 270);
            txtAttachment.Name = "txtAttachment";
            txtAttachment.ReadOnly = true;
            txtAttachment.Size = new Size(274, 23);
            txtAttachment.TabIndex = 7;
            // 
            // lblAttachment
            // 
            lblAttachment.Location = new Point(20, 270);
            lblAttachment.Name = "lblAttachment";
            lblAttachment.Size = new Size(100, 23);
            lblAttachment.TabIndex = 6;
            lblAttachment.Text = "📎 File đính kèm:";
            // 
            // MainForm
            // 
            ClientSize = new Size(550, 400);
            Controls.Add(lblRecipient);
            Controls.Add(txtRecipient);
            Controls.Add(lblSubject);
            Controls.Add(txtSubject);
            Controls.Add(lblBody);
            Controls.Add(txtBody);
            Controls.Add(lblAttachment);
            Controls.Add(txtAttachment);
            Controls.Add(btnChooseFile);
            Controls.Add(btnSendEmail);
            Name = "MainForm";
            Text = "📧 Gửi Email - Gmail Client";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
