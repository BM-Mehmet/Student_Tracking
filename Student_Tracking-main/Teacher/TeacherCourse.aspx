<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherCourse.aspx.cs" Inherits="StudentTracking.Teacher.TeacherCourse" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Öğretmen Kurs Atama</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div class="form-group">
            <label for="ddlCourses">Ders Seç:</label>
            <asp:DropDownList ID="ddlCourses" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="ddlTeachers">Öğretmen Seç:</label>
            <asp:DropDownList ID="ddlTeachers" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <asp:Button ID="btnAssign" runat="server" Text="Atama Yap" CssClass="btn btn-primary" OnClick="btnAssign_Click" />
        <asp:Label ID="lblStatus" runat="server" CssClass="mt-3"></asp:Label>

        <h3 class="mt-5">Öğretmen Kurs Eşleşmeleri</h3>
        <div class="table-responsive">
            <asp:GridView ID="GridViewCourseTeachers" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="TeacherName" HeaderText="Öğretmen Adı" />
                    <asp:BoundField DataField="CourseName" HeaderText="Ders Adı" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
