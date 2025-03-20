using System;
using System.Windows.Forms;

namespace EmailClient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string email = Prompt.ShowDialog("Nhập địa chỉ Gmail:", "Đăng nhập");
            string password = Prompt.ShowDialog("Nhập mật khẩu ứng dụng:", "Đăng nhập");

            Application.Run(new MainForm(email, password));
        }
    }
}
