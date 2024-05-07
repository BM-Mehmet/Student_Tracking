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
        StudentTrackingDB db = new StudentTrackingDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGroupList();
            }
        }

        private void BindGroupList()
        {
            // Grup verilerini veritabanından al ve GridView'e bağla
            // Örnek kod:
             GridViewGroups.DataSource = db.groups.Where(g => g.is_visible == true).ToList();
             GridViewGroups.DataBind();

            // Burada veritabanından grup verilerini alarak GridView'e bağlayın
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
    }
}