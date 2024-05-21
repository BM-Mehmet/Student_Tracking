using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Student.Course
{
    public partial class CourseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null && Session["UserRole"].ToString() == "öğrenci") // Session kontrolü
                {
                    BindGrid(); 
                }
                else
                {
                    Response.Redirect("~/Student/StudentLogin.aspx"); // Öğrenci değilse veya oturum yoksa giriş sayfasına yönlendir.
                }
            }
        }

        private void BindGrid()
        {
            using (var db = new StudentTrackingEntitiesDB()) // Veritabanı bağlantısı
            {
                var visibleCourses = db.courses.Where(s => s.is_visible == true).ToList(); // Görünür dersleri alır
                GridViewCourses.DataSource = visibleCourses; // Verileri GridView'e bağlar
                GridViewCourses.DataBind(); // Verileri görüntüler
            }
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("CourseAdd.aspx"));
            BindGrid(); // GridView'i tekrar bağla
        }
        private void AddCourseToEnrollment(int courseId)
        {
            using (var db = new StudentTrackingEntitiesDB())
            {
                int studentId = Convert.ToInt32(Session["UserId"]); // Session'dan öğrenci ID'sini alır

                // Öğrencinin bu kursa zaten kaydolup kaydolmadığını kontrol et
                var existingEnrollment = db.ders_kayıt.FirstOrDefault(en => en.student_id == studentId && en.course_id == courseId);
                if (existingEnrollment == null)
                {
                    var enrollment = new ders_kayıt
                    {
                        student_id = studentId,
                        course_id = courseId,
                        enrollment_date = DateTime.Now,
                        enrollment_status = "Aktif"
                    };
                    db.ders_kayıt.Add(enrollment);
                    db.SaveChanges();

                    lblStatus.Text = "Kursa başarıyla kaydoldunuz.";
                }
                else
                {
                    lblStatus.Text = "Bu kursa zaten kaydoldunuz.";
                }
            }
        }
        protected void GridViewCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectCourse")
            {
                int courseId = Convert.ToInt32(e.CommandArgument);
                AddCourseToEnrollment(courseId);
            }
        }
        protected void GridViewCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int courseId = Convert.ToInt32(GridViewCourses.DataKeys[e.NewEditIndex].Values["id"]);
            Response.Redirect($"CourseEdit.aspx?id={courseId}");
        }

        protected void GridViewCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int courseId = Convert.ToInt32(GridViewCourses.DataKeys[e.RowIndex].Values["id"]);
            Response.Redirect($"CourseDelete.aspx?id={courseId}");
        }
        protected void btnViewEnrolledCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/Course/CourseSign.aspx");  // Kullanıcıyı CourseSign sayfasına yönlendir
        }

    }
}
