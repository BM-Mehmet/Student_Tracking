using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Student.Course
{
    public partial class CourseEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int courseId;
                    if (int.TryParse(Request.QueryString["id"], out courseId))
                    {
                        PopulateUpdateData(courseId);
                    }
                    else
                    {
                        // Hata işlemleri buraya eklenebilir
                    }
                }
                else
                {
                    // Hata işlemleri buraya eklenebilir
                }
            }
        }

        private void PopulateUpdateData(int courseId)
        {
            using (var db = new StudentTrackingEntitiesDB())
            {
                var courses = db.courses.FirstOrDefault(s => s.id == courseId);
                if (courses != null)
                {
                    course_name.Text = courses.course_name;
                    semester_id.Text = Convert.ToString(courses.semester_id);
                    is_group_enabled.Checked = Convert.ToBoolean(courses.is_group_enabled); // Email özelliğini ekle
                    is_alone_enabled.Checked = Convert.ToBoolean(courses.is_alone_enabled);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int courseId;
                if (int.TryParse(Request.QueryString["id"], out courseId))
                {
                    UpdateCoursesData(courseId);
                }
                else
                {
                    // Hata işlemleri buraya eklenebilir
                }
            }
            else
            {
                // Hata işlemleri buraya eklenebilir
            }
        }

        private void UpdateCoursesData(int courseId)
        {
            using (var db = new StudentTrackingEntitiesDB())
            {
                var courses = db.courses.FirstOrDefault(s => s.id == courseId);
                if (courses != null)
                {
                    courses.course_name = course_name.Text;
                    courses.is_group_enabled = is_group_enabled.Checked; // CheckBox'tan Checked özelliğini alın
                    courses.is_alone_enabled = is_alone_enabled.Checked; // CheckBox'tan Checked özelliğini alın
                    courses.semester_id = Convert.ToInt32(semester_id.Text);
                    db.SaveChanges();
                    Response.Redirect("CourseList.aspx");
                }
                else
                {
                    // Hata işlemleri buraya eklenebilir
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseList.aspx"); // Kullanıcıyı önceki sayfaya yönlendir
        }
    }
}