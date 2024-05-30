using System;
using System.Linq;
using System.Web.UI;
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
                using (var db = new StudentTrackingEntitiesDb())
                {
                    var courses = db.ders_kayıt.Where(en => en.student_id == userId && en.enrollment_status == "Aktif")
                                                .Select(en => en.courses).ToList();

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

        protected void SingleGroup_Click(object sender, EventArgs e)
        {
            int courseId = Convert.ToInt32(DropDownList1.SelectedValue);
            using (var db = new StudentTrackingEntitiesDb())
            {
                var selectedCourse = db.courses.FirstOrDefault(c => c.id == courseId);
                if (selectedCourse != null && selectedCourse.is_alone_enabled == true)
                {
                    int studentId = Convert.ToInt32(Session["UserId"]);
                    var student = db.students.FirstOrDefault(s => s.id == studentId);
                    if (student != null)
                    {
                        string groupName = $"{student.name}_{selectedCourse.course_name}_Grup";

                        groups newGroup = new groups
                        {
                            group_name = groupName,
                            leader_student_id = studentId,
                            program_id = 1, // Varsayılan program ID'si
                            course_id = courseId,
                            is_visible = true,
                            is_single_member = true // Tek kişilik grup olduğunu belirten sütun
                        };

                        db.groups.Add(newGroup);
                        db.SaveChanges();

                        Response.Write("<script>alert('Tek kişilik grup başarıyla oluşturuldu!');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Bu ders için tek kişilik grup oluşturma aktif değil.');</script>");
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int courseId = Convert.ToInt32(DropDownList1.SelectedValue);
            using (var db = new StudentTrackingEntitiesDb())
            {
                var selectedCourse = db.courses.FirstOrDefault(c => c.id == courseId);
                if (selectedCourse != null)
                {
                    btnLeader.Enabled = selectedCourse.is_group_enabled ?? false;
                    btnMember.Enabled = selectedCourse.is_alone_enabled ?? false;
                    btnSingleGroup.Enabled = selectedCourse.is_alone_enabled ?? false;
                }
            }
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

        protected void btnSendTeacherRequest_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != null)
            {
                Session["SelectedCourseId"] = DropDownList1.SelectedValue;
                Response.Redirect("~/Teacher/TeacherRequest.aspx"); // Öğretmene katılma isteği sayfasına yönlendir
            }
            else
            {
                // Eğer ders seçilmemişse kullanıcıyı uyar
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lütfen önce bir ders seçiniz')", true);
            }
        }
    }
}
