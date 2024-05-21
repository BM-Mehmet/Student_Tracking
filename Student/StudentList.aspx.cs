using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Css.Ast.Selectors;

namespace StudentTracking.Student
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(); // Sayfa ilk kez yüklendiğinde verileri bağlar
            }
        }

        private void BindGrid()
        {
            using (var db = new StudentTrackingEntitiesDB()) // Veritabanı bağlantısı
            {
                var visibleStudents = db.students.Where(s => s.is_visible == true).ToList(); // Görünür öğrencileri alır
                GridViewStudents.DataSource = visibleStudents; // Verileri GridView'e bağlar
                GridViewStudents.DataBind(); // Verileri görüntüler
            }
        }


        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("StudentAdd.aspx"));
            BindGrid(); // GridView'i önce bağla
        }

        protected void GridViewStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int studentId = Convert.ToInt32(GridViewStudents.DataKeys[e.NewEditIndex].Values["id"]);
            Response.Redirect($"StudentEdit.aspx?id={studentId}");
        }

        protected void GridViewStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int studentId = Convert.ToInt32(GridViewStudents.DataKeys[e.RowIndex].Values["id"]);
            Response.Redirect($"StudentDelete.aspx?id={studentId}");
        }

    }
}   