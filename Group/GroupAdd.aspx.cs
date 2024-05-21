using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Group
{
    public partial class GroupAdd : System.Web.UI.Page
    {
        StudentTrackingEntitiesDB db = new StudentTrackingEntitiesDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Student/StudentLogin.aspx");
            }
            else if (!IsPostBack)
            {
                int studentId = Convert.ToInt32(Session["UserId"]);
                ddlLeaderStudent.Items.Insert(0, new ListItem { Text = "You", Value = studentId.ToString() });
                ddlLeaderStudent.SelectedIndex = 0; // Oturumda olan kullanıcıyı lider olarak set et

                int courseId = Convert.ToInt32(Session["SelectedCourseId"]); // Seçilen ders ID'sini al
                ddlCourse.DataSource = db.courses.Where(c => c.id == courseId).Select(x => new { CourseName = x.course_name, CourseId = x.id }).ToList();
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();

                ddlProgram.DataSource = db.program.Select(x => new { ProgramId = x.id }).ToList();
                ddlProgram.DataValueField = "ProgramId";
                ddlProgram.DataBind();
            }
        }




        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text;
            if (string.IsNullOrEmpty(groupName))
            {
                lblMessage.Text = "Please enter a group name.";
                return;
            }

            // Lider olarak oturumda olan öğrenci atanır.
            int leaderStudentId = Convert.ToInt32(Session["UserId"]);
            int programId = Convert.ToInt32(ddlProgram.SelectedValue);

           

            // Grup isminin zaten var olup olmadığını kontrol et
            bool groupExists = db.groups.Any(g => g.group_name == groupName);
            if (groupExists)
            {
                lblMessage.Text = "Bu grup ismi daha önce kullanılmış. Lütfen farklı bir grup ismi deneyiniz.";
                return;
            }

            // Yeni grup oluştur
            groups newGroup = new groups
            {
                group_name = groupName,
                leader_student_id = leaderStudentId,
                program_id = programId,
                course_id = Convert.ToInt32(Session["SelectedCourseId"]),
                is_visible = true
            };
            db.groups.Add(newGroup);
            db.SaveChanges();

            // Başarılı grup ekleme mesajı
            Response.Write("<script>alert('Group added successfully!');</script>");
            // Kullanıcıyı başka bir sayfaya yönlendir
            Response.Redirect("GroupList.aspx");
        }

    }
}