using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace StudentTracking.Student
{
    public partial class StudentRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            string emailPassword = ConfigurationManager.AppSettings["EmailPassword"];
            string recipient = txtRecipient.Text;
            // E-posta adresinin @ksu.edu.tr ile bitip bitmediğini kontrol et
            if (!recipient.EndsWith("@ogr.ksu.edu.tr"))
            {
                lblMessage.Text = "Lütfen geçerli bir KSU e-posta adresi giriniz.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return; // Eğer geçerli değilse, işlemi sonlandır
            }

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
                string messageBody = "Şifreniz: " + randomNumber;
                mailMessage.Body = messageBody; // E-posta içeriği

                // E-postayı gönderme
                smtpClient.Send(mailMessage);

                string name = txtNewName.Text;
                string surname = txtNewSurname.Text;

                using (var db = new StudentTrackingEntitiesDb()) // Veritabanı bağlantısı
                {
                    // Veritabanında belirli bir e-posta adresine sahip kullanıcıyı bul
                    var existingStudent = db.students.FirstOrDefault(s => s.email == recipient);

                    if (existingStudent == null) // Kullanıcı bulunduysa
                    {
                        var newStudent = new students
                        {
                            name = name,
                            surname = surname,
                            email = recipient,
                            password = randomNumber.ToString(),
                            is_visible = true,
                        };

                        db.students.Add(newStudent); // Öğrenciyi veritabanına ekle
                        db.SaveChanges(); // Değişiklikleri kaydet

                    }
                    else // Kullanıcı zaten kayıtlıysa
                    {
                        // Kullanıcı zaten kayıtlı olduğu için tekrar şifre gönderilmez, kullanıcıya bilgi ver
                        lblMessage.Text = "Bu e-posta adresi zaten kayıtlı.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return; // İşlemi sonlandır
                    }
                    txtNewName.Text = ""; // TextBox'ları temizle
                    txtNewSurname.Text = "";
                    txtRecipient.Text = "";
                    // Başarılı bir şekilde gönderildiğinde kullanıcıya bilgi verme

                }
                Response.Redirect("~/Student/StudentLogin.aspx");
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
