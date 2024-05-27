using System;
using System.Linq;
using System.Web.UI;

namespace StudentTracking.Teacher
{
    public partial class TeacherLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sayfa yüklendiğinde yapılacak işlemler buraya yazılabilir
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string teacherEmail = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            var loginResult = ValidateLogin(teacherEmail, password);
            if (loginResult.Item1)  // Eğer giriş başarılı ise
            {
                // isAdmin null ise veya false ise "teacher", true ise "admin" olarak atayın
                Session["UserRole"] = loginResult.Item2 ?? false ? "admin" : "teacher";
                Response.Redirect(Page.ResolveClientUrl("~/Admin/Admin.aspx"));
            }
            else
            {
                Response.Write("<script>alert('Giriş başarısız. Lütfen geçerli bir e-posta ve şifre girin.');</script>");
            }
        }

        // Kullanıcı giriş bilgilerini kontrol etmek için bir fonksiyon
        // Geri dönüş tipi Tuple<bool, bool?>, burada ilk bool giriş başarılı olup olmadığını,
        // ikinci bool? ise kullanıcının admin olup olmadığını (veya bilinmiyor ise null olabileceğini) belirtir
        private Tuple<bool, bool?> ValidateLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return Tuple.Create(false, (bool?)null);
            }

            using (var db = new StudentTrackingDBEntities())
            {
                var teacher = db.teachers.SingleOrDefault(t => t.email == email);

                if (teacher == null || teacher.password != password)
                {
                    return Tuple.Create(false, (bool?)null);
                }

                // Kullanıcı bulundu ve şifre doğru ise, admin olup olmadığını kontrol et
                return Tuple.Create(true, teacher.is_admin);
            }
        }
    }
}
