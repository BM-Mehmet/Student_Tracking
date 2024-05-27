using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace StudentTracking.Course
{
    public partial class courseSign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
            }
        }

        private void BindDropDownList()
        {
            if (Session["UserId"] != null) // Kullanıcı giriş yapmışsa
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                using (var db = new StudentTrackingDBEntities())
                {
                    // Kullanıcının kaydolduğu dersleri al
                    var courses = db.ders_kayıt.Where(en => en.student_id == userId && en.enrollment_status == "Aktif")
                                                .Select(en => en.courses).ToList();

                    DropDownList1.DataSource = null; // Verileri DropDownList'e bağlar
                    DropDownList1.DataSourceID = null; // Verileri DropDownList'e bağlar
                    DropDownList1.DataSource = courses; // Verileri DropDownList'e bağlar
                    DropDownList1.DataTextField = "course_name"; // Kurs adı sütunu
                    DropDownList1.DataValueField = "id"; // Kurs Id sütunu
                    DropDownList1.DataBind(); // Verileri görüntüler

                    // Eğer hiç kurs yoksa, kullanıcıya bilgi ver
                    if (!courses.Any())
                    {
                        DropDownList1.Items.Insert(0, new ListItem("Kayıtlı dersiniz bulunmamaktadır", ""));
                    }
                    else
                    {
                        DropDownList1.Items.Insert(0, new ListItem("Bir ders seçiniz", ""));
                    }
                }
            }
            else
            {
                // Kullanıcı giriş yapmamışsa, giriş sayfasına yönlendir
                Response.Redirect("~/Student/StudentLogin.aspx");
            }
        }

        protected void Leader_Click(object sender, EventArgs e)
        {
            Session["SelectedCourseId"] = DropDownList1.SelectedValue;
            Response.Redirect(Page.ResolveClientUrl($"~/Group/GroupAdd.aspx"));
        }

        protected void Member_Click(object sender, EventArgs e)
        {
            // Grup istek sayfasına, seçili ders ID ile yönlendir
            string courseId = DropDownList1.SelectedValue;
            Response.Redirect(Page.ResolveClientUrl($"~/Group/GroupRequest.aspx?courseId={courseId}"));
        }
        protected void btnManageRequests_Click(object sender, EventArgs e)
        {

            Session["SelectedCourseId"] = DropDownList1.SelectedValue;
            Response.Redirect("~/GroupRequests/ManageGroupRequests.aspx");
        }

    }
}
