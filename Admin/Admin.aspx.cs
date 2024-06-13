using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        StudentTrackingEntitiesDb db = new StudentTrackingEntitiesDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Oturum kontrolü - öğretmen olarak giriş yapılmış mı kontrol et
            if (Session["UserRole"] != null && (Session["UserRole"].ToString() == "teacher" || Session["UserRole"].ToString() == "admin"))
            {
                if (!IsPostBack)
                {
                    LoadTeacherGroups();
                }
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }
        protected void GridViewGroups_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var groupMembers = ((dynamic)e.Row.DataItem).GroupMembers;
                var gridViewMembers = (GridView)e.Row.FindControl("GridViewMembers");
                gridViewMembers.DataSource = groupMembers;
                gridViewMembers.DataBind();
            }
        }
        private void LoadTeacherGroups()
        {
            int teacherId = Convert.ToInt32(Session["UserId"]);

            using (var db = new StudentTrackingEntitiesDb())
            {
                var groupsAndCourses = db.GroupTeacherAssignments
                    .Where(gta => gta.TeacherId == teacherId)
                    .Select(gta => new
                    {
                        GroupId = gta.GroupId,
                        CourseName = gta.courses.course_name,
                        GroupName = gta.groups.group_name,
                        GroupMembers = db.group_memberships
                                         .Where(gm => gm.group_id == gta.GroupId)
                                         .Select(gm => new
                                         {
                                             StudentName = gm.students.name + " " + gm.students.surname,
                                             JoinDate = gm.join_date,
                                             Status = gm.status
                                         }).ToList()
                    }).ToList();

                GridViewGroups.DataSource = groupsAndCourses;
                GridViewGroups.DataBind();
            }

        }

    }
}