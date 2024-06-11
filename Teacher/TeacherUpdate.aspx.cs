using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Teacher
{
    public partial class TeacherUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Oturum kontrolü - öğretmen olarak giriş yapılmış mı kontrol et
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin")
            {
                if (!IsPostBack)
                {
                    // Sayfa yüklendiğinde, öğretmenin bilgilerini göster
                    string teacherId = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(teacherId))
                    {
                        using (var db = new StudentTrackingEntitiesDb())
                        {
                            int id = int.Parse(teacherId);
                            var teacher = db.teachers.FirstOrDefault(t => t.id == id);
                            if (teacher != null)
                            {
                                txtName.Text = teacher.name;
                                txtSurname.Text = teacher.surname;
                                txtEmail.Text = teacher.email;
                                // Şifre alanını boş bırak
                                txtPassword.Text = "";
                            }
                        }
                    }
                }
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string teacherId = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(teacherId))
            {
                using (var db = new StudentTrackingEntitiesDb())
                {
                    int id = int.Parse(teacherId);
                    var teacher = db.teachers.FirstOrDefault(t => t.id == id);
                    if (teacher != null)
                    {
                        // Öğretmen bilgilerini güncelle
                        teacher.name = txtName.Text;
                        teacher.surname = txtSurname.Text;
                        teacher.email = txtEmail.Text;

                        // Şifre güncellenmişse
                        if (!string.IsNullOrEmpty(txtPassword.Text))
                        {
                            // Yeni şifreyi hashleyerek kaydetmek gerekebilir, bu sadece bir örnektir
                            teacher.password = ComputeSHA256Hash(txtPassword.Text); 
                        }
                        db.SaveChanges();

                        // Sayfayı yeniden yönlendir
                        Response.Redirect("TeacherList.aspx");
                    }
                }
            }
        }

    }
}