using System;
using System.Linq;
using System.Web.UI;

namespace StudentTracking.Teacher
{
    public partial class TeacherCourse : System.Web.UI.Page
    {
        StudentTrackingEntitiesDb db = new StudentTrackingEntitiesDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCourses();
                BindTeachers();
                BindCourseTeachers();
            }
        }

        private void BindCourses()
        {
            var courses = db.courses.Where(c => c.is_visible == true).ToList();
            ddlCourses.DataSource = courses;
            ddlCourses.DataTextField = "course_name";
            ddlCourses.DataValueField = "id";
            ddlCourses.DataBind();
        }

        private void BindTeachers()
        {
            var teachers = db.teachers.Where(t => t.is_visible == true).ToList();
            ddlTeachers.DataSource = teachers;
            ddlTeachers.DataTextField = "name";
            ddlTeachers.DataValueField = "id";
            ddlTeachers.DataBind();
        }

        private void BindCourseTeachers()
        {
            var courseTeachers = db.CourseTeachers
                                   .Select(ct => new
                                   {
                                       TeacherName = ct.teachers.name,
                                       CourseName = ct.courses.course_name
                                   })
                                   .ToList();

            GridViewCourseTeachers.DataSource = courseTeachers;
            GridViewCourseTeachers.DataBind();
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            int courseId = int.Parse(ddlCourses.SelectedValue);
            int teacherId = int.Parse(ddlTeachers.SelectedValue);

            // Daha önce bu kursa bu öğretmen atandı mı kontrol et
            bool alreadyAssigned = db.CourseTeachers.Any(ct => ct.CourseId == courseId && ct.TeacherId == teacherId);

            if (alreadyAssigned)
            {
                lblStatus.Text = "Bu kurs zaten seçilen öğretmene atanmış.";
                lblStatus.Visible = true;
            }
            else
            {
                var courseTeacher = new CourseTeachers
                {
                    CourseId = courseId,
                    TeacherId = teacherId
                };

                db.CourseTeachers.Add(courseTeacher);
                db.SaveChanges();

                lblStatus.Text = "Eşleştirme başarıyla yapıldı.";
                lblStatus.Visible = true;

                BindCourseTeachers(); // GridView'i güncelle
            }
        }
    }
}
