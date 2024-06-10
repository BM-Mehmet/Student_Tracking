using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace StudentTracking.Teacher
{
    public partial class TeacherLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Giriş dizesini SHA256 hash'e dönüştür
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Diziyi bir string olarak formatla
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // x2, her byte'ı iki haneli onaltılık formata dönüştürür
                }
                return builder.ToString();
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string teacherEmail = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            string sifreliIfade = ComputeSHA256Hash(password);
            var loginResult = ValidateLogin(teacherEmail, sifreliIfade);
            if (loginResult.Item1)  // Eğer giriş başarılı ise
            {
                Session["UserRole"] = loginResult.Item3.is_admin == true ? "admin" : "teacher";
                Session["UserId"] = loginResult.Item3.id;
                if (loginResult.Item3.is_admin == true)
                {
                Response.Redirect(Page.ResolveClientUrl("~/Teacher/ManageTeacherRequest.aspx"));
                }
                else
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Teacher/Teacher.aspx"));
                }
            }
            else
            {
                Response.Write("<script>alert('Giriş başarısız. Lütfen geçerli bir e-posta ve şifre girin.');</script>");
            }
        }

        private Tuple<bool, bool?, teachers> ValidateLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return Tuple.Create(false, (bool?)null, (teachers)null);
            }

            using (var db = new StudentTrackingEntitiesDb())
            {
                var teacher = db.teachers.SingleOrDefault(t => t.email == email);

                if (teacher == null || teacher.password != password)
                {
                    return Tuple.Create(false, (bool?)null, (teachers)null);
                }

                // Kullanıcı bulundu ve şifre doğru ise, admin olup olmadığını ve kullanıcıyı döndür
                return Tuple.Create(true, teacher.is_admin, teacher);
            }
        }
    }
}
