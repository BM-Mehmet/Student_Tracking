<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseEdit.aspx.cs" Inherits="StudentTracking.Student.Course.CourseEdit" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Course</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h5>Edit Course</h5>
            <div class="form-group row">
                <label for="course_name" class="col-md-2 col-form-label">Course Name:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="course_name" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="is_group_enabled" class="col-md-2 col-form-label">Is Group Enabled:</label>
                <div class="col-md-10">
                    <asp:CheckBox ID="is_group_enabled" runat="server" Checked="True" />
                </div>
            </div>
            <div class="form-group row">
                <label for="is_alone_enabled" class="col-md-2 col-form-label">Is Alone Enabled:</label>
                <div class="col-md-10">
                    <asp:CheckBox ID="is_alone_enabled" runat="server" Checked="True" />
                </div>
            </div>

            <div class="form-group row">
                <label for="semester_id" class="col-md-2 col-form-label">Semester id: </label>
                <div class="col-md-10">
                    <asp:TextBox ID="semester_id" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-10 offset-md-2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-secondary" />
                </div>
            </div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseEdit.aspx.cs" Inherits="StudentTracking.Student.Course.CourseEdit" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Course</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h5>Edit Course</h5>
            <div class="form-group row">
                <label for="course_name" class="col-md-2 col-form-label">Course Name:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="course_name" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="is_group_enabled" class="col-md-2 col-form-label">Is Group Enabled:</label>
                <div class="col-md-10">
                    <asp:CheckBox ID="is_group_enabled" runat="server" Checked="True" />
                </div>
            </div>
            <div class="form-group row">
                <label for="is_alone_enabled" class="col-md-2 col-form-label">Is Alone Enabled:</label>
                <div class="col-md-10">
                    <asp:CheckBox ID="is_alone_enabled" runat="server" Checked="True" />
                </div>
            </div>

            <div class="form-group row">
                <label for="semester_id" class="col-md-2 col-form-label">Semester:</label>
                <div class="col-md-10">
                    <asp:DropDownList ID="semester_id" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-10 offset-md-2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-secondary" />
                </div>
            </div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
