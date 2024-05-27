using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace StudentTracking
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void btnSendEmail_Click(object sender, EventArgs e)
        //{
        //    string emailPassword = ConfigurationManager.AppSettings["EmailPassword"];

        //    try
        //    {
        //        // SMTP sunucusu ve kimlik bilgilerini kullanarak SmtpClient oluşturma
        //        SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
        //        smtpClient.EnableSsl = true;
        //        smtpClient.Credentials = new NetworkCredential("studenttracking@outlook.com", emailPassword); // Outlook adresiniz ve şifreniz

        //        // E-posta mesajını oluşturma
        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.From = new MailAddress("studenttracking@outlook.com"); // Gönderen e-posta adresi
        //        mailMessage.To.Add(txtRecipient.Text); // Alıcı e-posta adresi (kullanıcının girdiği adres)
        //                                               // Rastgele 6 haneli bir sayı oluşturma
        //        Random random = new Random();
        //        int randomNumber = random.Next(100000, 999999); // 100000 ile 999999 arasında rastgele bir sayı oluşturur
        //        string messageBody = "Şifreniz: " + randomNumber.ToString();
        //        mailMessage.Body = messageBody; // E-posta içeriği

        //        // E-postayı gönderme
        //        smtpClient.Send(mailMessage);

        //        // Başarılı bir şekilde gönderildiğinde kullanıcıya bilgi verme
        //        lblMessage.Text = "E-posta başarıyla gönderildi!";
        //        lblMessage.ForeColor = System.Drawing.Color.Green;
        //        string recipient = txtRecipient.Text;

        //        using (var db = new StudentTrackingDBEntities()) // Veritabanı bağlantısı
        //        {
        //            // Yeni öğrenci oluştur
        //            var newStudent = new students
        //            {
        //                password = emailPassword,  
        //            };

        //            db.students.Add(newStudent); // Öğrenciyi veritabanına ekle
        //            db.SaveChanges(); // Değişiklikleri kaydet

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        // Hata durumunda kullanıcıya bilgi verme
        //        lblMessage.Text = "E-posta gönderirken bir hata oluştu: " + ex.Message;
        //        lblMessage.ForeColor = System.Drawing.Color.Red;
        //    }
        //}

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            string emailPassword = ConfigurationManager.AppSettings["EmailPassword"];

            try
            {
                // SMTP sunucusu ve kimlik bilgilerini kullanarak SmtpClient oluşturma
                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("studenttracking@outlook.com", emailPassword); // Outlook adresiniz ve şifreniz

                // E-posta mesajını oluşturma
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("studenttracking@outlook.com"); // Gönderen e-posta adresi
                mailMessage.To.Add(txtRecipient.Text); // Alıcı e-posta adresi (kullanıcının girdiği adres)

                // Rastgele 6 haneli bir sayı oluşturma
                Random random = new Random();
                int randomNumber = random.Next(100000, 999999); // 100000 ile 999999 arasında rastgele bir sayı oluşturur
                string messageBody = "Şifreniz: " + randomNumber.ToString();
                mailMessage.Body = messageBody; // E-posta içeriği

                // E-postayı gönderme
                smtpClient.Send(mailMessage);

                // Başarılı bir şekilde gönderildiğinde kullanıcıya bilgi verme
                lblMessage.Text = "E-posta başarıyla gönderildi!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                string recipient = txtRecipient.Text;

                using (var db = new StudentTrackingDBEntities()) // Veritabanı bağlantısı
                {
                    // Veritabanında belirli bir e-posta adresine sahip kullanıcıyı bul
                    var existingStudent = db.students.FirstOrDefault(s => s.email == recipient);

                    if (existingStudent == null) // Kullanıcı bulunduysa
                    {
                        var newStudent = new students
                        {
                            email = recipient,
                            password = randomNumber.ToString(),
                            is_visible = true,
                        };

                        db.students.Add(newStudent); // Öğrenciyi veritabanına ekle
                        db.SaveChanges(); // Değişiklikleri kaydet
                       
                    }
    
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi verme
                lblMessage.Text = "E-posta gönderirken bir hata oluştu: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


    }
}
