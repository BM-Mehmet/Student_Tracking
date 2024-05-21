<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="CourseAdd.aspx.cs" Inherits="StudentTracking.Student.Course.CourseAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Course</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h1>Add New Course</h1>
            <div class="form-group row">
                <label for="txtNewcourse_name" class="col-md-2 col-form-label">Course Name:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNewcourse_name" runat="server" CssClass="form-control" placeholder="Course Name"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label for="chkIsGroupEnabled" class="col-md-2 col-form-label">Is Group Enabled:</label>
                <div class="col-md-10">
                    <asp:CheckBox ID="chkIsGroupEnabled" runat="server" Checked="True" />
                </div>
            </div>
                        <div class="form-group row">
                <label for="chkIsAloneEnabled" class="col-md-2 col-form-label">Is Alone Enabled:</label>
                <div class="col-md-10">
                    <asp:CheckBox ID="chkIsAloneEnabled" runat="server" Checked="True" />
                </div>
            </div>


            <div class="form-group row">
                <label for="txtNewsemester_id" class="col-md-2 col-form-label">Semester id:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNewsemester_id" runat="server" CssClass="form-control" placeholder="Semester id"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="offset-md-2 col-md-10">
                    <asp:Button ID="btnAddCourse" runat="server" Text="Add Course" OnClick="btnAddCourse_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>

