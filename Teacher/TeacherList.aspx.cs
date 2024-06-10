using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Teacher
{
    public partial class TeacherList : System.Web.UI.Page
    {
        StudentTrackingEntitiesDb db = new StudentTrackingEntitiesDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Oturum kontrolü - öğretmen olarak giriş yapılmış mı kontrol et
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin")
            {
                if (!IsPostBack)
            {
                BindTeachers();
            }
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }

        private void BindTeachers()
        {
            // Öğretmen verilerini veritabanından al ve GridView'e bağla
            GridViewTeachers.DataSource = db.teachers.Where(t => t.is_visible == true).ToList();
            GridViewTeachers.DataBind();
        }

        protected void GridViewTeachers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int teacherId = Convert.ToInt32(GridViewTeachers.DataKeys[e.NewEditIndex].Values["ID"]);
            Response.Redirect($"TeacherUpdate.aspx?ID={teacherId}");
        }
        protected void btnAddTeacher_Click(object sender, EventArgs e)
        {
            // Yeni öğretmen ekleme işlemleri burada yapılacak
            Response.Redirect("~/Teacher/TeacherAdd.aspx");

          
        }

        protected void GridViewTeachers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int teacherId = Convert.ToInt32(GridViewTeachers.DataKeys[e.RowIndex].Value);
            teachers teacherToUpdate = db.teachers.FirstOrDefault(x => x.id == teacherId);
            if (teacherToUpdate != null)
            {
                teacherToUpdate.is_visible = false;
                db.SaveChanges(); // Değişiklikleri veritabanına kaydet
            }
            BindTeachers();
        }


    }
}