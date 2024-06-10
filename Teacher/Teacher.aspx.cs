using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Admin
{
    public partial class Teachers : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Oturum kontrolü - öğretmen olarak giriş yapılmış mı kontrol et
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "teacher")
            {
                if (!IsPostBack)
                {
                    LoadTeacherGroups();
                }
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }

        private void LoadTeacherGroups()
        {
            try
            {
                int teacherUserId = Convert.ToInt32(Session["UserId"]);
                using (var db = new StudentTrackingEntitiesDb())
                {
                    var courseList = db.CourseTeachers
                                        .Where(ct => ct.TeacherId == teacherUserId)
                                        .Select(ct => ct.CourseId)
                                        .ToList();

                    var groups = db.groups
                                   .Where(g => courseList.Contains(g.course_id))
                                   .ToList();

                    GridViewGroups.DataSource = groups;
                    GridViewGroups.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi kodu
                // Örneğin: Loglama veya hata mesajı gösterme
                Console.WriteLine(ex.Message);
            }
        }
    }
}
