using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Student.Course
{
    public partial class CourseList : System.Web.UI.Page
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
            using (var db = new StudentTrackingDB()) // Veritabanı bağlantısı
            {
                var visibleCourses = db.courses.Where(s => s.is_visible == true).ToList(); // Görünür öğrencileri alır
                GridViewCourses.DataSource = visibleCourses; // Verileri GridView'e bağlar
                GridViewCourses.DataBind(); // Verileri görüntüler
            }
        }


        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("CourseAdd.aspx"));
            BindGrid(); // GridView'i önce bağla
        }

        protected void GridViewCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int courseId = Convert.ToInt32(GridViewCourses.DataKeys[e.NewEditIndex].Values["id"]);
            Response.Redirect($"CourseEdit.aspx?id={courseId}");
        }

        protected void GridViewCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int courseId = Convert.ToInt32(GridViewCourses.DataKeys[e.RowIndex].Values["id"]);
            Response.Redirect($"CourseDelete.aspx?id={courseId}");
        }
    }
}