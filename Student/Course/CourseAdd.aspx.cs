using System;
using System.Linq;
using System.Web.UI;

namespace StudentTracking.Student.Course
{
    public partial class CourseAdd : System.Web.UI.Page
    {
        StudentTrackingEntitiesDb db = new StudentTrackingEntitiesDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Oturum kontrolü - öğretmen olarak giriş yapılmış mı kontrol et
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin")
            {
                if (!IsPostBack)
                {
                    BindAcademicYears();
                }
            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }
 

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                string CourseName = txtNewcourse_name.Text;
                bool IsGroupEnabled = chkIsGroupEnabled.Checked;
                bool IsAloneEnabled = chkIsAloneEnabled.Checked;
                int semesterId = Convert.ToInt32(ddlAcademicYear.SelectedValue);

                using (var db = new StudentTrackingEntitiesDb())
                {
                    // Aynı akademik yıl içerisinde aynı isimde bir kurs var mı kontrol et
                    bool courseExists = db.courses.Any(c => c.course_name == CourseName && c.semester_id == semesterId);
                    if (courseExists)
                    {
                        lblError.Text = "Aynı akademik yıl içerisinde bu isimde bir kurs zaten mevcut.";
                        lblError.CssClass = "text-danger";
                        return;
                    }

                    var newCourse = new courses
                    {
                        course_name = CourseName,
                        is_group_enabled = IsGroupEnabled,
                        is_alone_enabled = IsAloneEnabled,
                        semester_id = semesterId,
                        is_visible = true
                    };
                    db.courses.Add(newCourse);
                    db.SaveChanges();
                }

                txtNewcourse_name.Text = "";
                lblError.Text = "Kurs başarıyla eklendi.";
                lblError.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                lblError.Text = "Hata: " + ex.Message;
                lblError.CssClass = "text-danger";
            }
        }

        protected void BindAcademicYears()
        {
            using (var db = new StudentTrackingEntitiesDb())
            {
                var academicYears = db.semesters.Where(s => s.is_visible == true).ToList();
                ddlAcademicYear.DataSource = academicYears;
                ddlAcademicYear.DataTextField = "academic_year";
                ddlAcademicYear.DataValueField = "id";
                ddlAcademicYear.DataBind();
            }
        }

    }
}
