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
                BindDropDownList(); // Sayfa ilk kez yüklendiğinde DropDownList'i doldur
            }
        }

        private void BindDropDownList()
        {
            using (var db = new StudentTrackingDB()) // Veritabanı bağlantısı
            {
                var courses = db.courses.ToList(); // Tüm kursları alır
                DropDownList1.DataSource = null; // Verileri DropDownList'e bağlar
                DropDownList1.DataSourceID = null; // Verileri DropDownList'e bağlar
                DropDownList1.DataSource = courses; // Verileri DropDownList'e bağlar
                DropDownList1.DataTextField = "course_name"; // Kurs adı sütunu
                DropDownList1.DataValueField = "id"; // Kurs Id sütunu
                DropDownList1.DataBind(); // Verileri görüntüler
            }
        }

        protected void Leader_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Group/GroupAdd.aspx"));
        }

        protected void Member_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Group/GroupRequest.aspx"));
        }
    }
}
