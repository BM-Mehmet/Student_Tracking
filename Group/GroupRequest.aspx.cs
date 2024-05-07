
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Group
{
    public partial class GroupRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the dropdown list with groups
                ddlGroups.DataSource = db.groups.Where(g=> g.course_id == 1).
                    Select(g => new { g.id, GroupName = g.group_name }).ToList();
                ddlGroups.DataBind();
            }
        }

        StudentTrackingDB db = new StudentTrackingDB();
        protected void RequestJoinButton_Click(object sender, EventArgs e)
        {
            // Join request işlemi
            int groupId = int.Parse(ddlGroups.SelectedValue);
            int studentId = 1;

            // İstek veritabanına kaydedilebilir
            // Örnek kod:
            var joinRequest = new group_requests
            {
                student_id = studentId,
                group_id = groupId,
                is_visible = true,
                status = "Pending" // İlk olarak istek durumu "Pending" olur
            };

            db.group_requests.Add(joinRequest);
            db.SaveChanges();

            // İstek gönderildikten sonra geri bildirim verebilirsiniz
            Response.Write("<script>alert('Join request sent successfully!');</script>");
            Response.Redirect(Page.ResolveClientUrl("~/Group/ManageRequests.aspx"));

        }

    }
}

