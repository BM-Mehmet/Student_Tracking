using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentTracking.Group
{
    public partial class GroupUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdownLists();
                PopulateGroupDetails();
            }
        }

        private void BindDropdownLists()
        {
            // Öğrenci liderleri, programlar ve kurslar dropdown listelerini doldurmak için gerekli verileri veritabanından alın
            using (var db = new StudentTrackingDB())
            {
                ddlLeaderStudent.DataSource = db.students.Select(x => new { StudentId = x.id, StudentName = x.name }).ToList();
                ddlLeaderStudent.DataTextField = "StudentName";
                ddlLeaderStudent.DataValueField = "StudentId";
                ddlLeaderStudent.DataBind();




                ddlProgram.DataSource = db.program.Select(x => new { ProgramId = x.id}).ToList();
                ddlProgram.DataValueField = "ProgramId";
                ddlProgram.DataBind();

                ddlCourse.DataSource = db.courses.Select(x => new { CourseId = x.id, CourseName = x.course_name }).ToList();
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();

                // ddlProgram ve ddlCourse için benzer şekilde veri bağlama işlemlerini gerçekleştirin
            }
        }

        private void PopulateGroupDetails()
        {
            if (Request.QueryString["groupId"] != null)
            {
                int groupId = Convert.ToInt32(Request.QueryString["groupId"]);
                using (var db = new StudentTrackingDB())
                {
                    var group = db.groups.FirstOrDefault(g => g.id == groupId);
                    if (group != null)
                    {
                        txtGroupName.Text = group.group_name;
                        ddlLeaderStudent.SelectedValue = group.leader_student_id.ToString();
                        ddlCourse.SelectedValue = group.course_id.ToString();
                        ddlProgram.SelectedValue = group.program_id.ToString();
                        // Diğer alanları da grup verileriyle doldurun
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["groupId"] != null)
            {
                int groupId = Convert.ToInt32(Request.QueryString["groupId"]);
                using (var db = new StudentTrackingDB())
                {
                    var groupToUpdate = db.groups.FirstOrDefault(g => g.id == groupId);
                    if (groupToUpdate != null)
                    {
                        // Formdan alınan verilerle grup nesnesini güncelle
                        groupToUpdate.group_name = txtGroupName.Text;
                        groupToUpdate.leader_student_id = Convert.ToInt32(ddlLeaderStudent.SelectedValue);
                        groupToUpdate.course_id = Convert.ToInt32(ddlCourse.SelectedValue);
                        groupToUpdate.program_id = Convert.ToInt32(ddlProgram.SelectedValue);

                        // Değişiklikleri veritabanına kaydet
                        db.SaveChanges();

                        // Kullanıcıya güncelleme işleminin başarılı olduğunu bildir
                        Response.Write("<script>alert('Grup başarıyla güncellendi');</script>");
                        Response.Redirect("GroupList.aspx");

                        // Opsiyonel: Güncelleme işleminden sonra kullanıcıyı başka bir sayfaya yönlendir
                        // Response.Redirect("SomeOtherPage.aspx");
                    }
                    else
                    {
                        // Grup bulunamadıysa kullanıcıya bir hata mesajı göster
                        Response.Write("<script>alert('Güncellenecek grup bulunamadı');</script>");
                    }
                }
            }
            else
            {
                // QueryString "groupId" parametresi yoksa, bir hata mesajı göster
                Response.Write("<script>alert('Geçersiz grup ID');</script>");
            }
        }


    }
}