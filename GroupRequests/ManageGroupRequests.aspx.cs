using System;
using System.Linq;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Group
{
    public partial class ManageGroupRequests : System.Web.UI.Page
    {
        StudentTrackingEntitiesDb db = new StudentTrackingEntitiesDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Oturum kontrolü - öğretmen olarak giriş yapılmış mı kontrol et
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin")
            {
                if (!IsPostBack)
                {
                    int courseId = Convert.ToInt32(Session["SelectedCourseId"]);
                    LoadRequests(courseId);
                }
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }

        protected void LoadRequests(int courseId)
        {
            try
            {
                int userId = Convert.ToInt32(Session["UserId"]);

                var leaderGroupIds = db.groups.Where(g => g.leader_student_id == userId && g.course_id == courseId).Select(g => g.id).ToList();

                var groupRequests = db.group_requests
                    .Where(gr => leaderGroupIds.Contains(gr.group_id) && gr.is_visible == true)
                    .Select(gr => new
                    {
                        request_id = gr.id,
                        student_name = db.students.FirstOrDefault(s => s.id == gr.student_id).name,
                        group_name = gr.groups.group_name,
                        course_name = gr.groups.courses.course_name, // Ders adını ekleyin
                        join_message = gr.join_message,
                        status = gr.status
                    })
                    .ToList();

                if (groupRequests.Count > 0)
                {
                    RequestsGridView.DataSource = groupRequests;
                    RequestsGridView.DataBind();
                }
                else
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Seçilen ders için herhangi bir talep bulunamadı veya lider olduğunuz grup yok.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Error loading requests: " + ex.Message;
            }
        }

        protected void RequestsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int requestId = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = ((Control)e.CommandSource).NamingContainer as GridViewRow;
            TextBox txtRejectReason = row.FindControl("txtRejectReason") as TextBox;

            switch (e.CommandName)
            {
                case "Approve":
                    ApproveRequest(requestId);
                    break;
                case "Reject":
                    string rejectReason = txtRejectReason.Text;
                    if (!string.IsNullOrWhiteSpace(rejectReason))
                    {
                        RejectRequest(requestId, rejectReason);
                    }
                    break;
            }

            int courseId = Convert.ToInt32(Session["SelectedCourseId"]);
            LoadRequests(courseId);  // Yeniden yükleme

        }

        protected void ApproveRequest(int requestId)
        {
            var request = db.group_requests.Find(requestId);
            if (request != null)
            {
                // İsteği onayla
                request.status = "Approved";
                request.is_visible = false;  // Onaylandıktan sonra görünmez yap

                // İlgili öğrenciyi students tablosundan bul
                var student = db.students.Find(request.student_id);
                if (student != null)
                {
                    // Eğer öğrenci bulunuyorsa ve önceden bu gruba kayıtlı değilse
                    bool isAlreadyMember = db.group_memberships.Any(gm => gm.group_id == request.group_id && gm.student_id == request.student_id);
                    if (!isAlreadyMember)
                    {
                        // Öğrenciyi group_memberships tablosuna ekle
                        var newMembership = new group_memberships
                        {
                            group_id = request.group_id,
                            student_id = request.student_id,
                            join_date = DateTime.Now,  // Katılma tarihini şimdi olarak ayarla
                            status = "Active"  // Üyelik durumunu aktif olarak ayarla
                        };
                        db.group_memberships.Add(newMembership);
                    }

                    // Veritabanı değişikliklerini kaydet
                    db.SaveChanges();
                    Response.Redirect("ManageGroupRequests.aspx");
                }
            }
        }

        protected void RejectRequest(int requestId, string rejectReason)
        {
            var request = db.group_requests.Find(requestId);
            if (request != null)
            {
                request.status = "Rejected";
                request.is_visible = false;
                request.reject_reason = rejectReason; // Reddedilme nedenini kaydet
                db.SaveChanges();
                Response.Redirect("ManageGroupRequests.aspx");
            }
        }
    }
}
