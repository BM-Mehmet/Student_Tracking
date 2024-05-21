using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Student.Course
{
    public partial class CourseAdd : System.Web.UI.Page
    {
        StudentTrackingEntitiesDB db = new StudentTrackingEntitiesDB();

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            // Yeni öğrenci eklemek için kullanılan metot
            string CourseName = txtNewcourse_name.Text;
            bool IsGroupEnabled = chkIsGroupEnabled.Checked;
            bool IsAloneEnabled = chkIsAloneEnabled.Checked;
            int SemesterId = Convert.ToInt32(txtNewsemester_id.Text);

            using (var db = new StudentTrackingEntitiesDB()) // Veritabanı bağlantısı
            {
                // Yeni öğrenci oluştur
                var newCourses = new courses
                {
                    course_name = CourseName,
                    is_group_enabled = IsGroupEnabled,
                    is_alone_enabled = IsAloneEnabled,
                    semester_id = SemesterId,
                    is_visible = true
                };

                db.courses.Add(newCourses); 
                db.SaveChanges(); 

            }

            txtNewcourse_name.Text = ""; // TextBox'ları temizle
            txtNewsemester_id.Text = "";

            Response.Redirect(Page.ResolveClientUrl("CourseSign.aspx"));
        }
    }
}