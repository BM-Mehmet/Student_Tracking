using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Group
{
    public partial class GroupRequest : System.Web.UI.Page
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
                string courseId = Request.QueryString["courseId"];
                if (int.TryParse(courseId, out int parsedCourseId))
                {
                    BindGroups(parsedCourseId);
                    //LoadRequests(parsedCourseId);
                }
                else
                {
                    lblStatus.Text = "Invalid course ID.";
                }
            }
        }

        protected void RequestJoinButton_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(Session["UserId"]);
            int groupId = int.Parse(ddlGroups.SelectedValue);
            int courseId = Convert.ToInt32(Request.QueryString["courseId"]); // Burada courseId'yi nasıl aldığınıza bağlı olarak kod ekleyin.
            string joinMessage = txtJoinMessage.Text;

            var joinRequest = new group_requests
            {
                student_id = studentId,
                group_id = groupId,
                course_id = courseId,  // Yeni eklenen course_id
                is_visible = true,
                status = "Pending",
                request_date = DateTime.Now,
                join_message = joinMessage
            };

            db.group_requests.Add(joinRequest);
            db.SaveChanges();

            Response.Write("<script>alert('Join request sent successfully!');</script>");
        }

        private void BindGroups(int courseId)
        {
            // courseId ile ilişkili grupları DropDownList'e bağla
            ddlGroups.DataSource = db.groups.Where(g => g.course_id == courseId)
                                            .Select(g => new { g.id, g.group_name }).ToList();
            ddlGroups.DataTextField = "group_name";
            ddlGroups.DataValueField = "id";
            ddlGroups.DataBind();
        }

        //protected void LoadRequests(int courseId)
        //{
        //    try
        //    {
        //        int userId = Convert.ToInt32(Session["UserId"]);  // Lider ID olarak oturumdan alınan UserID kullan

        //        // Kullanıcıya ait lider olduğu grupların ID'lerini çek
        //        var leaderGroupIds = db.groups.Where(g => g.leader_student_id == userId && g.course_id == courseId).Select(g => g.id).ToList();

        //        // Sadece kullanıcı lider olduğu gruplara gelen istekleri yükle
        //        var groupRequests = db.group_requests
        //            .Where(gr => leaderGroupIds.Contains(gr.group_id) && gr.is_visible == true)
        //            .Select(gr => new
        //            {
        //                request_id = gr.id,
        //                student_name = db.students.FirstOrDefault(s => s.id == gr.student_id).name,
        //                group_name = gr.groups.group_name,
        //                join_message = gr.join_message,
        //                status = gr.status
        //            })
        //            .ToList();

        //        if (groupRequests.Count > 0)
        //        {
        //            RequestsGridView.DataSource = groupRequests;
        //            RequestsGridView.DataBind();
        //        }
        //        else
        //        {
        //            lblStatus.Visible = true;
        //            lblStatus.Text = "Seçilen kurs için herhangi bir talep bulunamadı veya lider olduğunuz grup yok.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblStatus.Visible = true;
        //        lblStatus.Text = "Error loading requests: " + ex.Message;
        //    }
        //}





        //protected void RequestsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int requestId = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
        //    TextBox txtRejectReason = (TextBox)row.FindControl("txtRejectReason");

        //    switch (e.CommandName)
        //    {
        //        case "Approve":
        //            ApproveRequest(requestId);
        //            break;
        //        case "Reject":
        //            string rejectReason = txtRejectReason.Text;
        //            RejectRequest(requestId, rejectReason);
        //            break;
        //    }

        //    // İstekleri güncellenmiş liste ile yeniden yükle
        //    int courseId = Convert.ToInt32(Request.QueryString["courseId"]);
        //    LoadRequests(courseId);
        //}

        //protected void ApproveRequest(int requestId)
        //{
        //    var request = db.group_requests.Find(requestId);
        //    if (request != null)
        //    {
        //        // İsteği onayla
        //        request.status = "Approved";
        //        request.is_visible = false;  // Onaylandıktan sonra görünmez yap

        //        // İlgili öğrenciyi students tablosundan bul
        //        var student = db.students.Find(request.student_id);
        //        if (student != null)
        //        {
        //            // Eğer öğrenci bulunuyorsa ve önceden bu gruba kayıtlı değilse
        //            bool isAlreadyMember = db.group_memberships.Any(gm => gm.group_id == request.group_id && gm.student_id == request.student_id);
        //            if (!isAlreadyMember)
        //            {
        //                // Öğrenciyi group_memberships tablosuna ekle
        //                var newMembership = new group_memberships
        //                {
        //                    group_id = request.group_id,
        //                    student_id = request.student_id,
        //                    join_date = DateTime.Now,  // Katılma tarihini şimdi olarak ayarla
        //                    status = "Active"  // Üyelik durumunu aktif olarak ayarla
        //                };
        //                db.group_memberships.Add(newMembership);
        //            }

        //            // Veritabanı değişikliklerini kaydet
        //            db.SaveChanges();
        //        }
        //    }
        //}


        //protected void RejectRequest(int requestId, string rejectReason)
        //{
        //    var request = db.group_requests.Find(requestId);
        //    if (request != null)
        //    {
        //        request.status = "Rejected";
        //        request.is_visible = false;
        //        request.reject_reason = rejectReason; // Reddedilme nedenini kaydet
        //        db.SaveChanges();
        //    }
        //}
    }
}
