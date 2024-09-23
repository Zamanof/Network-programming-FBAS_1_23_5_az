using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System.Net;
using System.Net.Mail;
// Mail protocols - SMTP, POP3, IMAP


//SMTP();
IMAP();
void SMTP()
{
    var client = new SmtpClient("smtp.gmail.com", 587);
    client.Credentials = new NetworkCredential(
        "fbms.1223@gmail.com", 
        "aehkecjulvhxuqco");
    client.EnableSsl = true;
    var message = new MailMessage()
    {
        Subject = "Ibrahim",
        Body = "42 butun suallara cavab. Hakuna Matata!!!"
    };
    message.From = new MailAddress("fbms.1223@gmail.com", "Açma virusdu");
    message.To.Add(new MailAddress("zamanov@itstep.org"));
    message.To.Add(new MailAddress("huseyn200825@gmail.com"));
    message.To.Add(new MailAddress("talibliibrahim28@gmail.com"));
    message.To.Add(new MailAddress("fatullyev.m@gmail.com"));
    message.To.Add(new MailAddress("samedyolchuyev08@gmail.com"));
    client.Send(message);
}

void IMAP()
{
    var imapClient = new ImapClient();
    imapClient.Connect("imap.gmail.com", 993, true);
    imapClient.Authenticate(
        "fbms.1223@gmail.com",
        "aehkecjulvhxuqco");
    var inbox = imapClient.GetFolder("Inbox");
    inbox.Open(FolderAccess.ReadWrite);

    //var ids = inbox.Search(SearchQuery.All);

    //foreach (var id in ids)
    //{
    //    Console.WriteLine($"{id} {inbox.GetMessage(id).TextBody}");
    //}

    inbox.SetFlags([1, 2, 3], MessageFlags.Deleted, true);
    inbox.Expunge();
    inbox.Close();
}

