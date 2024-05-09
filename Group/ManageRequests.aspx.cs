using StudentTracking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Group
{
    public partial class ManageRequests : System.Web.UI.Page
    {

        StudentTrackingDB db = new StudentTrackingDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRequests();
            }
        }

        protected void LoadRequests()
        {
            int leaderId = 1;

            var groupRequests = db.group_requests
                                  .Where(gr => db.groups
                                                 .Where(g => g.leader_student_id == leaderId)
                                                 .Select(g => g.id)
                                                 .Contains(gr.group_id) && gr.is_visible == true)
                                  .ToList();
            

            RequestsGridView.DataSource = groupRequests;
            RequestsGridView.DataBind();
        }

        protected void RequestsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                int requestId = Convert.ToInt32(e.CommandArgument);
                ApproveRequest(requestId);
            }
            else if (e.CommandName == "Reject")
            {
                int requestId = Convert.ToInt32(e.CommandArgument);
                RejectRequest(requestId);
            }

            // İstekleri yeniden yükle
            LoadRequests();
        }
        
        protected void ApproveRequest(int requestId)
        {
            var request = db.group_requests.Find(requestId);
            if (request != null)
            {
                request.status = "Approved";
                request.is_visible = false;

                var student = db.students.Find(request.student_id);
                if (student != null)
                {
                    student.group_id= request.group_id;
                }
                db.SaveChanges();
            }
        }

        protected void RejectRequest(int requestId)
        {
            var request = db.group_requests.Find(requestId);
            if (request != null)
            {
                request.status = "Rejected";
                request.is_visible= false;
                db.SaveChanges();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Group/GroupRequest.aspx"));
        }
    }
}