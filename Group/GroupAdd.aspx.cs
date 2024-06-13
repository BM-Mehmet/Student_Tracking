using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Group
{
    public partial class GroupAdd : System.Web.UI.Page
    {
        StudentTrackingEntitiesDb db = new StudentTrackingEntitiesDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "öğrenci")
            {

                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Student/StudentLogin.aspx");
                }
                else if (!IsPostBack)
                {
                    InitializeFormData();
                }
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Student/StudentLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }

        private void InitializeFormData()
        {
            int studentId;
            int courseId;
            if (Session["UserId"] != null && int.TryParse(Session["UserId"].ToString(), out studentId))
            {
                if (Session["SelectedCourseId"] != null && int.TryParse(Session["SelectedCourseId"].ToString(), out courseId))
                {
                    studentId = Convert.ToInt32(Session["UserId"]);
                    courseId = Convert.ToInt32(Session["SelectedCourseId"]);

                    // Lider öğrenci ve kurs bilgilerini arka planda ayarla
                    Session["LeaderStudentId"] = studentId;
                    Session["SelectedCourseId"] = courseId;

                }
                else
                {
                    Response.Redirect("~/Student/Course/CourseSign");
                }
            }
            else
            {
                Response.Redirect("~/Student/Course/CourseSign");                     
            }

        }

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text;
            string groupDescription = txtDescription.Text;

            if (string.IsNullOrEmpty(groupName))
            {
                lblMessage.Text = "Grup ismi giriniz.";
                return;
            }

            int leaderStudentId = Convert.ToInt32(Session["LeaderStudentId"]);
            int programId = Convert.ToInt32(Session["SelectedProgramId"]);
            int courseId = Convert.ToInt32(Session["SelectedCourseId"]);

            bool groupExists = db.groups.Any(g => g.group_name == groupName);
            if (groupExists)
            {
                lblMessage.Text = "Bu grup adı zaten kullanılmış. Lütfen farklı bir isim deneyin.";
                return;
            }

            groups newGroup = new groups
            {
                group_name = groupName,
                leader_student_id = leaderStudentId,
                program_id = 1,
                description = groupDescription,
                course_id = courseId,
                is_visible = true
            };
            db.groups.Add(newGroup);
            db.SaveChanges();

            group_memberships leaderMembership = new group_memberships
            {
                group_id = newGroup.id,
                student_id = leaderStudentId,
                join_date = DateTime.Now,
                status = "Active"
            };
            db.group_memberships.Add(leaderMembership);
            db.SaveChanges();

            Response.Redirect("~/Student/Course/courseSign.aspx");
        }
    }
}
