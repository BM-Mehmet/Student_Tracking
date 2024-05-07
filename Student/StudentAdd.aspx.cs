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
            string name = txtNewName.Text;
            string surname = txtNewSurname.Text;
            string email = txtNewEmail.Text;

            using (var db = new StudentTrackingDB()) // Veritabanı bağlantısı
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