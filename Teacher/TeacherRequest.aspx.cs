using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace StudentTracking.Teacher
{
    public partial class TeacherRequest : System.Web.UI.Page
    {
        StudentTrackingEntitiesDb db = new StudentTrackingEntitiesDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null && Session["UserRole"].ToString() == "öğrenci") // Session kontrolü
                {
                    BindCourses();
                }
                else
                {
                    Response.Redirect("~/Student/StudentLogin.aspx"); // Öğrenci değilse veya oturum yoksa giriş sayfasına yönlendir.
                }
            }
        }

        private void BindCourses()
        {
            var studentId = Convert.ToInt32(Session["UserId"]);
            var courseIds = db.groups.Where(g => g.leader_student_id == studentId)
                                     .Select(g => g.course_id)
                                     .Distinct()
                                     .ToList();

            var courses = db.courses.Where(c => courseIds.Contains(c.id)).ToList();
            ddlCourses.DataSource = courses;
            ddlCourses.DataTextField = "course_name";
            ddlCourses.DataValueField = "id";
            ddlCourses.DataBind();

            if (ddlCourses.Items.Count > 0)
            {
                BindGroups();
                BindTeachers();
            }
        }

        private void BindGroups()
        {
            var studentId = Convert.ToInt32(Session["UserId"]);
            int selectedCourseId = int.Parse(ddlCourses.SelectedValue);

            var groups = db.groups
                            .Where(g => g.leader_student_id == studentId && g.course_id == selectedCourseId)
                            .ToList();

            ddlGroups.DataSource = groups;
            ddlGroups.DataTextField = "group_name";
            ddlGroups.DataValueField = "id";
            ddlGroups.DataBind();
        }

        private void BindTeachers()
        {
            int selectedCourseId = int.Parse(ddlCourses.SelectedValue);
            var teacherIds = db.CourseTeachers.Where(ct => ct.CourseId == selectedCourseId)
                                              .Select(ct => ct.TeacherId)
                                              .ToList();

            var teachers = db.teachers.Where(t => teacherIds.Contains(t.id)).ToList();
            ddlTeachers.DataSource = teachers;
            ddlTeachers.DataTextField = "name";
            ddlTeachers.DataValueField = "id";
            ddlTeachers.DataBind();
        }

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGroups();
            BindTeachers();
        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            var studentId = Convert.ToInt32(Session["UserId"]);
            var courseId = Convert.ToInt32(ddlCourses.SelectedValue);
            var groupId = Convert.ToInt32(ddlGroups.SelectedValue);
            var teacherId = Convert.ToInt32(ddlTeachers.SelectedValue);
            var joinMessage = txtJoinMessage.Text;  // Kullanıcının girdiği katılım mesajını al

            // Aynı grup ve öğretmen için daha önce istek gönderilmiş mi kontrol et
            var existingRequest = db.TeacherRequests
                                    .FirstOrDefault(tr => tr.StudentId == studentId &&
                                                          tr.CourseId == courseId &&
                                                          tr.GroupId == groupId &&
                                                          tr.TeacherId == teacherId);

            if (existingRequest == null)
            {
                var request = new TeacherRequests
                {
                    StudentId = studentId,
                    TeacherId = teacherId,
                    CourseId = courseId,
                    GroupId = groupId,  // GroupId ekle
                    RequestDate = DateTime.Now,
                    JoinMessage = joinMessage,  // Kullanıcının mesajını kaydet
                    is_visible = true,
                    Status = "Pending"
                };

                db.TeacherRequests.Add(request);
                db.SaveChanges();
                Response.Redirect("~/Student/Course/courseSign.aspx"); // İsteğin gönderildiği bilgisini gösteren bir sayfa
            }
            else
            {
                lblStatus.Text = "Bu grup ve öğretmen için zaten bir istek gönderdiniz.";
            }
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen grup değiştiğinde yapılacak işlemler burada yer alır
            BindTeachers(); // Bu metot, seçilen kursa göre öğretmenleri günceller
        }

    }
}
