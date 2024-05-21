using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Group
{
    public partial class GroupList : System.Web.UI.Page
    {
        StudentTrackingEntitiesDB db = new StudentTrackingEntitiesDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGroupList();
            }
        }

        private void BindGroupList()
        {
            GridViewGroups.DataSource = db.groups.Where(g => g.is_visible == true).ToList();
            GridViewGroups.DataBind();
        }

        protected void GridViewGroups_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Düzenleme işlemi için kod
            int groupId = Convert.ToInt32(GridViewGroups.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"GroupUpdate.aspx?groupId={groupId}");
            BindGroupList();

            // Yönlendirme veya düzenleme işlemi için gerekli kodu buraya ekleyin
        }

        protected void GridViewGroups_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Silme işlemi için kod
            int groupId = Convert.ToInt32(GridViewGroups.DataKeys[e.RowIndex].Value);
            groups group = db.groups.FirstOrDefault(c => c.id == groupId);
            group.is_visible=false;
            db.SaveChanges();

            BindGroupList();
        }

        protected void GridViewGroups_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int groupId = Convert.ToInt32(GridViewGroups.DataKeys[e.Row.RowIndex].Value);
                GridView gridViewMembers = e.Row.FindControl("GridViewMembers") as GridView;

                if (gridViewMembers != null) // gridViewMembers kontrolü ekleyin
                {
                    var members = db.group_memberships
                                    .Where(m => m.group_id == groupId)
                                    .Select(m => new
                                    {
                                        student_name = m.students.name,
                                        join_date = m.join_date,
                                        status = m.status
                                    }).ToList();

                    gridViewMembers.DataSource = members;
                    gridViewMembers.DataBind();
                }
            }
        }

    }
}