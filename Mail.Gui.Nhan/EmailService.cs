using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

public class EmailMessage
{
    public string Subject { get; set; }
    public string From { get; set; }
    public string Date { get; set; }
    public string Body { get; set; }
}

public class EmailService
{
    private string email;
    private string password;
    private List<EmailMessage> emailMessages = new List<EmailMessage>();

    public EmailService(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public async Task<List<EmailMessage>> FetchEmailsAsync()
    {
        List<EmailMessage> emails = new List<EmailMessage>();

        using (var client = new ImapClient())
        {
            await client.ConnectAsync("imap.gmail.com", 993, true);
            await client.AuthenticateAsync(email, password);
            var inbox = client.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadOnly);

            for (int i = inbox.Count - 1; i >= Math.Max(inbox.Count - 10, 0); i--)
            {
                var message = await inbox.GetMessageAsync(i);
                emails.Add(new EmailMessage
                {
                    Subject = message.Subject,
                    From = message.From.ToString(),
                    Date = message.Date.ToString("dd/MM/yyyy HH:mm"),
                    Body = message.TextBody
                });
            }
            await client.DisconnectAsync(true);
        }

        emailMessages = emails;
        return emails;
    }

    public async Task<bool> SendEmailAsync(string to, string subject, string body)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(email, email));
            message.To.Add(new MailboxAddress(to, to));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync(email, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GetEmailDetail(int index)
    {
        return emailMessages.Count > index ? emailMessages[index].Body : "Không có nội dung.";
    }
}
