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
        StudentTrackingDB db = new StudentTrackingDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Öğrenci liderleri, programlar ve kurslar dropdown listelerini doldurmak için gerekli verileri veritabanından alın
                ddlLeaderStudent.DataSource = db.students.Select(x => new { StudentId = x.id, StudentName = x.name }).ToList();
                ddlLeaderStudent.DataTextField = "StudentName";
                ddlLeaderStudent.DataValueField = "StudentId";
                ddlLeaderStudent.DataBind();
                ddlProgram.DataSource = db.program.Select(x => new { ProgramId = x.id }).ToList();
                ddlProgram.DataValueField = "ProgramId";
                ddlProgram.DataBind();
                ddlCourse.DataSource = db.courses.Select(x => new { CourseName = x.course_name, CourseId = x.id }).ToList();
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();

                // Bu örnek kod yerine, veritabanından doğru verileri çekerek dropdown listelerini doldurun
            }
        }


        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text;
            int leaderStudentId = Convert.ToInt32(ddlLeaderStudent.SelectedValue);
            int programId = Convert.ToInt32(ddlProgram.SelectedValue);
            int courseId = Convert.ToInt32(ddlCourse.SelectedValue);
            if (string.IsNullOrEmpty(groupName))
            {
                // Kullanıcıya uygun bir hata mesajı göster
                lblMessage.Text = "Please enter a group name.";
                return;
            }

            bool groupExists = db.groups.Any(g => g.group_name == groupName);
            if (groupExists)
            {
                // Kullanıcıya uygun bir hata mesajı göster
                lblMessage.Text = "A group with the same name already exists. Please enter a different group name." +
                    "Bu grup ismi daha önce kullanılmış. Lütfen farklı bir grup ismi deneyiniz.";
                return;
            }

            groups newGroup = new groups { group_name = groupName, leader_student_id = leaderStudentId, program_id = programId, course_id = courseId , is_visible = true};
            db.groups.Add(newGroup);
            db.SaveChanges();
            // Grup ekleme işlemi tamamlandıktan sonra isteğe bağlı olarak bir mesaj gösterilebilir veya başka bir işlem yapılabilir
            Response.Write("<script>alert('Group added successfully!');</script>");
            Response.Redirect("ManageRequests.aspx");
        }
    }
}