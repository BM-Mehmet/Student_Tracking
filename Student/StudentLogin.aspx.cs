using System;
using System.Linq;
using System.Web.UI;


namespace StudentTracking.Student
{ 
public partial class StudentLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Sayfa yüklendiğinde yapılacak işlemler buraya yazılabilir
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        // Kullanıcı giriş bilgilerini kontrol etmek için buraya kod ekleyebilirsiniz
        string studentMail = TextBox1.Text;
        string password = TextBox2.Text;

        // Örneğin, giriş bilgilerini kontrol etmek için bir fonksiyon çağırabilirsiniz
        if (ValidateLogin(studentMail, password))
        {
                // Giriş başarılı ise yönlendirme yapabilirsiniz
                Response.Redirect(Page.ResolveClientUrl("Course/CourseList.aspx"));
            
        }
        else
        {
            Response.Write("<script>alert('Giriş başarısız. Lütfen geçerli bir e-posta ve şifre girin.');</script>");
        }
    }
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("StudentRegister.aspx"));
        }
            // Kullanıcı giriş bilgilerini kontrol etmek için bir fonksiyon
            private bool ValidateLogin(string studentMail, string password)
        {
            // Eğer kullanıcı e-posta veya şifre alanlarını doldurmadıysa doğrulama başarısız olur
            if (string.IsNullOrEmpty(studentMail) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            using (var db = new StudentTrackingEntitiesDB())
            {
                // Kullanıcıyı veritabanından e-posta adresine göre bul
                var user = db.students.SingleOrDefault(s => s.email == studentMail);

                // Kullanıcı bulunamadıysa veya şifre uyuşmuyorsa doğrulama başarısız olur
                if (user == null || user.password != password)
                {
                    return false;
                }

                // Eğer herhangi bir hata yoksa, doğrulama başarılı olur
                Session["UserRole"] = "öğrenci";
                Session["UserId"] = user.id;
                return true;
            }
        }

    }
}