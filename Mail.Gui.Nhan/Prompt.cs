using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 400,
            Height = 200,
            Text = caption
        };

        Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 350 };
        TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
        Button okButton = new Button() { Text = "OK", Left = 250, Width = 100, Top = 90 };
        okButton.Click += (sender, e) => { prompt.Close(); };

        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(inputBox);
        prompt.Controls.Add(okButton);
        prompt.AcceptButton = okButton;

        prompt.ShowDialog();
        return inputBox.Text;
    }
}
