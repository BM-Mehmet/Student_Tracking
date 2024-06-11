using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace StudentTracking.Student
{
    public partial class StudentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Oturum kontrolü - öğretmen olarak giriş yapılmış mı kontrol et
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "admin")
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int studentId;
                        if (int.TryParse(Request.QueryString["id"], out studentId))
                        {
                            PopulateStudentData(studentId);
                        }
                        else
                        {
                            // Hata işlemleri buraya eklenebilir
                        }
                    }
                    else
                    {
                        // Hata işlemleri buraya eklenebilir
                    }
                }

            }
            else
            {
                // Öğretmen olarak giriş yapılmamışsa kullanıcıyı login sayfasına yönlendir
                Response.Redirect("~/Teacher/TeacherLogin.aspx"); // Giriş sayfasının URL'sini doğru yola göre ayarlayın
            }
        }
        private string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Giriş dizesini SHA256 hash'e dönüştür
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Diziyi bir string olarak formatla
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // x2, her byte'ı iki haneli onaltılık formata dönüştürür
                }
                return builder.ToString();
            }
        }
        private void PopulateStudentData(int studentId)
        {
            using (var db = new StudentTrackingEntitiesDb())
            {
                var student = db.students.FirstOrDefault(s => s.id == studentId);
                if (student != null)
                {
                    txtName.Text = student.name;
                    txtSurname.Text = student.surname;
                    txtEmail.Text = student.email; // Email özelliğini ekle
                    txtPassword.Text = student.password;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int studentId;
                if (int.TryParse(Request.QueryString["id"], out studentId))
                {
                    UpdateStudentData(studentId);
                }
                else
                {
                    // Hata işlemleri buraya eklenebilir
                }
            }
            else
            {
                // Hata işlemleri buraya eklenebilir
            }
        }

        private void UpdateStudentData(int studentId)
        {
            using (var db = new StudentTrackingEntitiesDb())
            {
                var student = db.students.FirstOrDefault(s => s.id == studentId);
                if (student != null)
                {
                    student.name = txtName.Text;
                    student.surname = txtSurname.Text;
                    student.email = txtEmail.Text; // Email özelliğini güncelle
                    student.password = ComputeSHA256Hash(txtPassword.Text);
                    db.SaveChanges();
                    Response.Redirect("StudentList.aspx");
                }
                else
                {
                    // Hata işlemleri buraya eklenebilir
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx"); // Kullanıcıyı önceki sayfaya yönlendir
        }
    }
}
