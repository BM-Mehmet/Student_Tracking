using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Student.Course
{
    public partial class SemesterAdd : System.Web.UI.Page
    {
        StudentTrackingEntitiesDb db = new StudentTrackingEntitiesDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin")
            {
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni kurs eklemek için kullanılan metot
                DateTime StartDate = DateTime.ParseExact(txtStartDate.Text, "dd-MM-yyyy", null);
                DateTime EndDate = DateTime.ParseExact(txtEndDate.Text, "dd-MM-yyyy", null);
                using (var db = new StudentTrackingEntitiesDb()) // Veritabanı bağlantısı
                {

                    // Yeni semester oluştur
                    var newSemester = new semesters
                    {
                        academic_year = txtNewDonem.Text,
                        is_visible = true,
                        start_date = StartDate,
                        end_date = EndDate,


                    };
                    db.semesters.Add(newSemester);
                    db.SaveChanges();
                }

                // TextBox'ları temizle
                txtNewDonem.Text = "";
                txtStartDate.Text = "";
                txtEndDate.Text = "";
                lblError.Text = "Kurs başarıyla eklendi.";
                lblError.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                // Hata işleme burada yapılabilir
                lblError.Text = "Hata: " + ex.Message;
            }
        }
    }
}