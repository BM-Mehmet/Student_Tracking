using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace StudentTracking.Student.Course
{
    public partial class CourseDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int courseId = Convert.ToInt32(Request.QueryString["id"]);

                using (var db = new StudentTrackingDB())
                {
                    var course = db.courses.Find(courseId);

                    if (course != null)
                    {
                        course_name.Text = course.course_name;
                        semester_id.Text = Convert.ToString(course.semester_id);
                        is_group_enabled.Checked = Convert.ToBoolean(course.is_group_enabled);
                        is_alone_enabled.Checked = Convert.ToBoolean(course.is_alone_enabled);

                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int courseId = Convert.ToInt32(Request.QueryString["id"]);

            using (var db = new StudentTrackingDB())
            {
                var course = db.courses.Find(courseId);

                if (course != null)
                {
                    course.is_visible = false;
                    db.SaveChanges();
                }
            }

            Response.Redirect("CourseList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseList.aspx");
        }
    }
}
