using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Student.Course
{
    public partial class CourseEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Oturum kontrolü - öğretmen olarak giriş yapılmış mı kontrol et
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin")
            {
                if (!IsPostBack)
                {
                    BindAcademicYears();
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
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }

        private void BindAcademicYears()
        {
            using (var db = new StudentTrackingEntitiesDb())
            {
                var academicYears = db.semesters.Where(s => s.is_visible == true).ToList();
                ddlAcademicYear.DataSource = academicYears;
                ddlAcademicYear.DataTextField = "academic_year";
                ddlAcademicYear.DataValueField = "id";
                ddlAcademicYear.DataBind();
            }
        }

        private void PopulateUpdateData(int courseId)
        {
            using (var db = new StudentTrackingEntitiesDb())
            {
                var course = db.courses.FirstOrDefault(s => s.id == courseId);
                if (course != null)
                {
                    course_name.Text = course.course_name;
                    is_group_enabled.Checked = Convert.ToBoolean(course.is_group_enabled); // Email özelliğini ekle
                    is_alone_enabled.Checked = Convert.ToBoolean(course.is_alone_enabled);
                    ddlAcademicYear.SelectedValue = course.semester_id.ToString();
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
            using (var db = new StudentTrackingEntitiesDb())
            {
                var course = db.courses.FirstOrDefault(s => s.id == courseId);
                if (course != null)
                {
                    course.course_name = course_name.Text;
                    course.is_group_enabled = is_group_enabled.Checked; // CheckBox'tan Checked özelliğini alın
                    course.is_alone_enabled = is_alone_enabled.Checked; // CheckBox'tan Checked özelliğini alın
                    course.semester_id = Convert.ToInt32(ddlAcademicYear.SelectedValue);

                    db.SaveChanges();
                    Response.Redirect("CourseEdit.aspx");
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
