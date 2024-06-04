
using System;
using System.Web.UI;
using System.Xml.Linq;

namespace StudentTracking.Student
{
    public partial class StudentDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int studentId = Convert.ToInt32(Request.QueryString["id"]);

                using (var db = new StudentTrackingEntitiesDb())
                {
                    var student = db.students.Find(studentId);

                    if (student != null)
                    {
                        txtName.Text = student.name;
                        txtSurname.Text = student.surname;
                        txtEmail.Text = student.email;
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(Request.QueryString["id"]);

            using (var db = new StudentTrackingEntitiesDb())
            {
                var student = db.students.Find(studentId);

                if (student != null)
                {
                    student.is_visible = false;
                    db.SaveChanges();
                }
            }

            Response.Redirect("StudentList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx");
        }
    }


}