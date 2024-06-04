using System;
using System.Web.UI;

namespace StudentTracking.Program
{
    public partial class ProgramAdd : System.Web.UI.Page
    {
        protected void btnAddProgram_Click(object sender, EventArgs e)
        {
            // Yeni öğrenci eklemek için kullanılan metot
            int CourseId = Convert.ToInt32( txtNewcourse_id.Text);
            int TeacherId = Convert.ToInt32(txtNewteacher_id.Text);
            int SemesterId = Convert.ToInt32( txtNewsemester_id.Text);

            using (var db = new StudentTrackingEntitiesDb()) // Veritabanı bağlantısı
            {
                // Yeni öğrenci oluştur
                var newProgram = new program
                {
                    course_id = CourseId,
                    teachers_id = TeacherId,
                    semester_id = SemesterId,
                    is_visible = true
                };

                db.program.Add(newProgram); // Öğrenciyi veritabanına ekle
                db.SaveChanges(); // Değişiklikleri kaydet

            }

            txtNewcourse_id.Text = ""; // TextBox'ları temizle
            txtNewsemester_id.Text = "";
            txtNewteacher_id.Text = "";

            Response.Redirect(Page.ResolveClientUrl("ProgramAdd.aspx"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}