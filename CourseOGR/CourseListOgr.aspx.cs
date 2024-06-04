using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.CourseOGR
{
    public partial class CourseListOgr : System.Web.UI.Page
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
            using (var db = new StudentTrackingEntitiesDb()) // Veritabanı bağlantısı
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
            using (var db = new StudentTrackingEntitiesDb())
            {
                int studentId = Convert.ToInt32(Session["UserId"]);

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

        private void RemoveCourseFromEnrollment(int courseId)
        {
            using (var db = new StudentTrackingEntitiesDb())
            {
                int studentId = Convert.ToInt32(Session["UserId"]);

                var enrollment = db.ders_kayıt.FirstOrDefault(en => en.student_id == studentId && en.course_id == courseId && en.enrollment_status == "Aktif");
                if (enrollment != null)
                {
                    enrollment.enrollment_status = "Pasif";
                    db.SaveChanges();

                    lblStatus.Text = "Kurs kaydınız başarıyla kaldırıldı.";
                }
                else
                {
                    lblStatus.Text = "Bu kursa kayıtlı değilsiniz.";
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
            else if (e.CommandName == "DeleteCourse")
            {
                int courseId = Convert.ToInt32(e.CommandArgument);
                RemoveCourseFromEnrollment(courseId);
            }
        }

        protected void btnViewEnrolledCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Student/Course/CourseSign.aspx");  // Kullanıcıyı CourseSign sayfasına yönlendir
        }
    }
}
