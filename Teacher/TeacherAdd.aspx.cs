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

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            using (var db = new StudentTrackingDB())
            {
                bool emailExists = db.teachers.Any(t => t.email == email);
                if (emailExists)
                {
                    // E-posta adresi zaten mevcut, kullanıcıya hata mesajı göster
                    Response.Write("<script>alert('Aynı e-postaya sahip bir öğretmen zaten var!');</script>");
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
            using (var db = new StudentTrackingDB())
            {
                db.teachers.Add(newTeacher);
                db.SaveChanges();
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
         "alert('Öğretmen ekleme işlemi başarıyla sonuçlandı!'); window.location='" +
         Request.ApplicationPath + "Teacher/TeacherManagement.aspx';", true);
        }
    }
}