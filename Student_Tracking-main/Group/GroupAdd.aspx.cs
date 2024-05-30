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
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Student/StudentLogin.aspx");
            }
            else if (!IsPostBack)
            {
                InitializeFormData();
            }
        }

        private void InitializeFormData()
        {
            int studentId = Convert.ToInt32(Session["UserId"]);
            int courseId = Convert.ToInt32(Session["SelectedCourseId"]); 
            int programId = 1; 

            // Lider öğrenci ve kurs bilgilerini arka planda ayarla
            Session["LeaderStudentId"] = studentId;
            Session["SelectedProgramId"] = programId;
            Session["SelectedCourseId"] = courseId;
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
                program_id = programId,
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
