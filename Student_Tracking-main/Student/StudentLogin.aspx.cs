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
        string studentMail = TextBox1.Text;
        string password = TextBox2.Text;

        if (ValidateLogin(studentMail, password))
        {
                Response.Redirect(Page.ResolveClientUrl("~/CourseOGR/CourseListOgr.aspx"));

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
            private bool ValidateLogin(string studentMail, string password)
            {
            if (string.IsNullOrEmpty(studentMail) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            using (var db = new StudentTrackingEntitiesDb())
            {
                var user = db.students.SingleOrDefault(s => s.email == studentMail);

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