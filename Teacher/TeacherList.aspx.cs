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
        StudentTrackingDB db = new StudentTrackingDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTeachers();
            }
        }


        private void BindTeachers()
        {
            // Öğretmen verilerini veritabanından al ve GridView'e bağla
            // Örnek kod:
            // GridViewTeachers.DataSource = GetTeachersFromDatabase();
            // GridViewTeachers.DataBind();
            GridViewTeachers.DataSource = db.teachers.Where(t => t.is_visible == true).ToList();
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

            // Veritabanından ilgili öğretmeni silme işlemini burada yapın
            // Örneğin:
            // var teacherToDelete = db.Teachers.Find(teacherId);
            // db.Teachers.Remove(teacherToDelete);
            // db.SaveChanges();

            // Son olarak, öğretmen listesini güncelleyerek GridView'i yeniden bağlayın


            int teacherId = Convert.ToInt32(GridViewTeachers.DataKeys[e.RowIndex].Value);
            teachers teacherToUpdate = db.teachers.FirstOrDefault(x => x.id == teacherId);
            if (teacherToUpdate != null)
            {
                // Öğretmenin IsActive değerini false olarak güncelle
                teacherToUpdate.is_visible = false;
                db.SaveChanges(); // Değişiklikleri veritabanına kaydet
            }
            db.SaveChanges();
            // Öğretmenleri yeniden bağla
            BindTeachers();
            BindTeachers();
        }



    }
}