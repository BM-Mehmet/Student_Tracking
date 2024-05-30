using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Teacher
{
    public partial class TeacherManagement : System.Web.UI.Page
    {
        private StudentTrackingEntitiesDb db = new StudentTrackingEntitiesDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Öğretmenleri GridView'e bağla
                BindTeachers();
            }
        }

        private void BindTeachers()
        {
            // Öğretmenleri veritabanından al ve GridView'e bağla
            // Örnek bir veritabanı işlemi yapılacak
            // Öğretmenler tablosundan veriler alınacak ve GridViewTeachers'a atanacak
            var teachers = db.teachers.Where(t => t.is_visible == true).ToList();

            // GridView'e öğretmenleri bağla
            GridViewTeachers.DataSource = teachers;
            GridViewTeachers.DataBind();
        }

        protected void GridViewTeachers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Seçili satırın indeksini al
           // int rowIndex = e.NewEditIndex;

            // Seçili satırın öğretmen ID'sini al
            int teacherId = Convert.ToInt32(GridViewTeachers.DataKeys[e.NewEditIndex].Values["ID"]);

            // TeacherUpdate.aspx sayfasına yönlendir
            Response.Redirect($"TeacherUpdate.aspx?ID={teacherId}");
            BindTeachers();
        }

        protected void GridViewTeachers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Silme işlemini gerçekleştir
           // int teacherId = Convert.ToInt32(GridViewTeachers.DataKeys[e.RowIndex].Value);
            int teacherId = Convert.ToInt32(GridViewTeachers.DataKeys[e.RowIndex].Value);
            teachers teacherToUpdate = db.teachers.FirstOrDefault(x => x.id == teacherId);
            if (teacherToUpdate != null)
            {
                // Öğretmenin IsActive değerini false olarak güncelle
                teacherToUpdate.is_visible = false;
                db.SaveChanges(); // Değişiklikleri veritabanına kaydet
            }

            BindTeachers();
        }


        protected void btnAddTeacher_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherAdd.aspx");
        }

    }
}