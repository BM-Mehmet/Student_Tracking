using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Group
{
    public partial class GroupRequest : System.Web.UI.Page
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
                string courseId = Request.QueryString["courseId"];
                if (int.TryParse(courseId, out int parsedCourseId))
                {
                    BindGroups(parsedCourseId);
                }
                else
                {
                    lblStatus.Text = "Invalid course ID.";
                    lblStatus.Visible = true;
                }
            }
        }

        protected void BindGroups(int courseId)
        {
            var studentId = Convert.ToInt32(Session["UserId"]);
            // Önce veritabanından grupları çekin
            var groups = db.groups
                .Where(g => g.course_id == courseId)
                .ToList() // Veritabanı sorgusunu burada bitirir
                .Select(g => new
                {
                    Id = g.id,
                    GroupName = g.group_name,
                    Description = g.description,
                    // Şimdi bellekteyken, üyeler için string.Join kullanabilirsiniz
                    Members = string.Join(", ", g.students.Select(s => s.name + " " + s.surname))
                }).ToList();

            GridViewGroups.DataSource = groups;
            GridViewGroups.DataBind();
        }


        protected void GridViewGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Join")
            {
                int studentId = Convert.ToInt32(Session["UserId"]);
                int groupId = Convert.ToInt32(e.CommandArgument);
                int courseId = Convert.ToInt32(Request.QueryString["courseId"]);

                // GridViewRow ve TextBox kontrollerini al
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                TextBox txtJoinMessage = (TextBox)row.FindControl("txtJoinMessage");
                string joinMessage = txtJoinMessage.Text;

                if (string.IsNullOrWhiteSpace(joinMessage))
                {
                    lblStatus.Text = "Lütfen bir katılma mesajı giriniz.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Lütfen bir katılma mesajı giriniz.');", true);
                    return;
                }
                var group = db.groups.FirstOrDefault(g => g.id == groupId);

                if (group.leader_student_id == studentId)
                {
                    lblStatus.Text = "Kendi lideri olduğunuz gruba katılma isteği gönderemezsiniz.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Kendi lideri olduğunuz gruba katılma isteği gönderemezsiniz.');", true);
                    return;
                }

                bool alreadyRequested = db.group_requests.Any(r => r.student_id == studentId && r.group_id == groupId && r.course_id == courseId);

                if (!alreadyRequested)
                {
                    var joinRequest = new group_requests
                    {
                        student_id = studentId,
                        group_id = groupId,
                        course_id = courseId,
                        is_visible = true,
                        status = "Pending",
                        request_date = DateTime.Now,
                        join_message = joinMessage
                    };

                    db.group_requests.Add(joinRequest);
                    db.SaveChanges();

                    lblStatus.Text = "Katılma isteği başarıyla gönderildi!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Katılma isteği başarıyla gönderildi!');", true);
                    return;
                }
                else
                {
                    lblStatus.Text = "Bu grup için zaten bir katılma isteği gönderdiniz.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('\"Bu grup için zaten bir katılma isteği gönderdiniz.');", true);
                    return;
                }
            }
        }

    }
}
