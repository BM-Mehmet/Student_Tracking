using System;
using System.Net.Mail;

namespace StudentTracking.Student
{
    public partial class StudentRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendEmailButton_Click(object sender, EventArgs e)
        {
            try
            {
                string email = EmailTextBox.Text;

                // Gmail SMTP sunucusuna bağlanma
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("your-email@gmail.com", "your-password");
                smtpClient.EnableSsl = true;

                // E-posta oluşturma
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("your-email@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Gmail API Sample";
                mail.Body = "Bu e-posta, Gmail API kullanılarak gönderilmiştir.";

                // E-postayı gönderme
                smtpClient.Send(mail);

                InfoLabel.Text = "E-posta başarıyla gönderildi.";
                InfoLabel.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                InfoLabel.Text = "E-posta gönderilirken bir hata oluştu: " + ex.Message;
                InfoLabel.CssClass = "text-danger";
            }
        }
    }
}
