<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDelete.aspx.cs" Inherits="StudentTracking.Student.Course.CourseDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Course</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h2>Delete Course</h2>
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
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger btn-block" Text="Sil" OnClick="btnDelete_Click" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary btn-block" Text="Vazgeç" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>



