using System;
using System.Linq;
using System.Web.UI;

namespace StudentTracking.Student.Course
{
    public partial class CourseAdd : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAcademicYears();
            }
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                string CourseName = txtNewcourse_name.Text;
                bool IsGroupEnabled = chkIsGroupEnabled.Checked;
                bool IsAloneEnabled = chkIsAloneEnabled.Checked;

                using (var db = new StudentTrackingDBEntities())
                {
                    var newCourse = new courses
                    {
                        course_name = CourseName,
                        is_group_enabled = IsGroupEnabled,
                        is_alone_enabled = IsAloneEnabled,
                        semester_id = Convert.ToInt32(ddlAcademicYear.SelectedValue),
                        is_visible = true
                    };
                    db.courses.Add(newCourse);
                    db.SaveChanges();
                }

                txtNewcourse_name.Text = "";
                lblError.Text = "Kurs başarıyla eklendi.";
                lblError.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                lblError.Text = "Hata: " + ex.Message;
            }
        }

        protected void BindAcademicYears()
        {
            using (var db = new StudentTrackingDBEntities())
            {
                var academicYears = db.semesters.Where(s => s.is_visible == true).ToList();
                ddlAcademicYear.DataSource = academicYears;
                ddlAcademicYear.DataTextField = "academic_year";
                ddlAcademicYear.DataValueField = "id";
                ddlAcademicYear.DataBind();
            }
        }
    }
}

