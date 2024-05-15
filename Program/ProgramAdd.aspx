<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramAdd.aspx.cs" Inherits="StudentTracking.Program.ProgramAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Program</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h1>Add New Program</h1>
            <div class="form-group row">
                <label for="txtNewCourse_id" class="col-md-2 col-form-label">Course ID:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNewcourse_id" runat="server" CssClass="form-control" placeholder="Course ID"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="txtNewtacher_id" class="col-md-2 col-form-label">Teacher ID:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNewteacher_id" runat="server" CssClass="form-control" placeholder="Teacher ID"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="txtNewsemester_id" class="col-md-2 col-form-label">Semester ID:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNewsemester_id" runat="server" CssClass="form-control" placeholder="Semester ID"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="offset-md-2 col-md-10">
                    <asp:Button ID="btnAddProgram" runat="server" Text="Add Program" OnClick="btnAddProgram_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>

