using System;
using System.Windows.Forms;

namespace EmailClient
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                Text = caption
            };

            Label lbl = new Label() { Left = 20, Top = 20, Text = text };
            TextBox txtInput = new TextBox() { Left = 20, Top = 50, Width = 350 };
            Button btnOk = new Button() { Text = "OK", Left = 150, Top = 80 };

            btnOk.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; prompt.Close(); };

            prompt.Controls.Add(lbl);
            prompt.Controls.Add(txtInput);
            prompt.Controls.Add(btnOk);
            prompt.AcceptButton = btnOk;

            return prompt.ShowDialog() == DialogResult.OK ? txtInput.Text : "";
        }
    }
}
