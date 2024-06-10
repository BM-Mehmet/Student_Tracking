using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Teacher
{
    public partial class ManageTeacherRequests : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] != null && (Session["UserRole"].ToString() == "teacher" || Session["UserRole"].ToString() == "admin"))
            {
                if (!IsPostBack)
                {
                    if (Session["UserId"] == null || Session["UserRole"] == null)
                    {
                        Response.Redirect("~/Teacher/TeacherLogin.aspx");
                        return;
                    }
                    else
                    {
                        BindTeacherRequests();
                    }
                }
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }


        private void BindTeacherRequests()
        {
            int teacherId = Convert.ToInt32(Session["UserId"]);

            using (var db = new StudentTrackingEntitiesDb())
            {
                var requests = db.TeacherRequests.Where(g => g.TeacherId == teacherId && g.is_visible == true).Select(r => new
                {
                    RequestId = r.RequestId,
                    StudentName = r.students.name + " " + r.students.surname,
                    CourseName = r.courses.course_name,
                    JoinMessage = r.JoinMessage,
                    RequestDate = r.RequestDate
                }).ToList();

                gvTeacherRequests.DataSource = requests;
                gvTeacherRequests.DataBind();
            }
        }

        protected void gvTeacherRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int requestId = Convert.ToInt32(e.CommandArgument);
            using (var db = new StudentTrackingEntitiesDb())
            {
                var request = db.TeacherRequests.Find(requestId);
                if (e.CommandName == "Approve")
                {
                    request.Status = "Approved";
                    request.is_visible = false;
                }
                else if (e.CommandName == "Reject")
                {
                    var row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    var txtRejectReason = (TextBox)row.FindControl("txtRejectReason");
                    request.Status = "Rejected";
                    request.is_visible = false;
                    request.RejectReason = txtRejectReason.Text;
                }
                db.SaveChanges();
            }
            BindTeacherRequests();
        }
    }
}
