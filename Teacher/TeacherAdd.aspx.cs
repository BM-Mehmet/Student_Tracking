using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Teacher
{
    public partial class TeacherAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Oturum kontrolü - öğretmen olarak giriş yapılmış mı kontrol et
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin")
            {
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                // Eksik bilgi var, kırmızı mesajı göster
                lblMessage.Text = "Lütfen tüm alanları doldurunuz!";
                lblMessage.Visible = true;
                return; // Ekleme işleminden çık
            }

            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            using (var db = new StudentTrackingEntitiesDb())
            {
                bool emailExists = db.teachers.Any(t => t.email == email);
                if (emailExists)
                {
                    // E-posta adresi zaten mevcut, kırmızı mesajı göster
                    lblMessage.Text = "Aynı e-postaya sahip bir öğretmen zaten var!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                    return; // Ekleme işleminden çık
                }
            }

            // Yeni bir Teacher nesnesi oluştur
            teachers newTeacher = new teachers()
            {
                name = name,
                surname = surname,
                email = email,
                password = password,
                is_visible = true
            };

            // Veritabanına yeni öğretmeni ekle
            using (var db = new StudentTrackingEntitiesDb())
            {
                db.teachers.Add(newTeacher);
                db.SaveChanges();
            }

            // İşlem başarıyla tamamlandı, kullanıcıya mesajı göster ve yönlendir
            lblMessage.Text = "Öğretmen ekleme işlemi başarıyla sonuçlandı!";
            lblMessage.ForeColor = System.Drawing.Color.Green; // Yeşil renk kullanabilirsiniz
            lblMessage.Visible = true;

            // Diğer işlemleri yapmak için buraya kod ekleyebilirsiniz
            txtName.Text = "";
            txtSurname.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

    }
}