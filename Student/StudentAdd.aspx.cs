using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Student
{
    public partial class StudentAdd : System.Web.UI.Page
    {


        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Yeni öğrenci eklemek için kullanılan metot
            string name = txtNewName.Text.Trim();
            string surname = txtNewSurname.Text.Trim();
            string email = txtNewEmail.Text.Trim();
            // Gerekli girdilerin boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(email))
            {
                // Hata mesajını göster
                lblMessage.Text = "Lütfen tüm alanları doldurun.";
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return; // Metodu sonlandır
            }

            using (var db = new StudentTrackingEntitiesDb()) // Veritabanı bağlantısı
            {
                // Yeni öğrenci oluştur
                var newStudent = new students
                {
                    name = name,
                    surname = surname,
                    email = email,
                    is_visible = true
                };

                db.students.Add(newStudent); // Öğrenciyi veritabanına ekle
                db.SaveChanges(); // Değişiklikleri kaydet

            }

            txtNewName.Text = ""; // TextBox'ları temizle
            txtNewSurname.Text = "";
            txtNewEmail.Text = "";

            Response.Redirect(Page.ResolveClientUrl("StudentList.aspx"));
        }
    }
}