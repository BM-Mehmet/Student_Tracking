<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseEdit.aspx.cs" Inherits="StudentTracking.Student.Course.CourseEdit" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dersleri Düzenle</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <div class="card-header">
                <h2>Dersi Düzenle</h2>
            </div>
            <div class="form-group row">
                <label for="course_name" class="col-md-2 col-form-label">Ders Adı:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="course_name" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="is_group_enabled" class="col-md-2 col-form-label">Gruplu Çalışmaya İzin Ver:</label>
                <div class="col-md-10">
                    <asp:CheckBox ID="is_group_enabled" runat="server" Checked="True" />
                </div>
            </div>
            <div class="form-group row">
                <label for="is_alone_enabled" class="col-md-2 col-form-label">Tekli Çalışmaya İzin Ver:</label>
                <div class="col-md-10">
                    <asp:CheckBox ID="is_alone_enabled" runat="server" Checked="True" />
                </div>
            </div>

            <div class="form-group row">
                <label for="Donem" class="col-md-2 col-form-label">Akademik Yıl:</label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-10 offset-md-2">
                <asp:Button ID="btnSave" runat="server" Text="Kaydet" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnCancel" runat="server" Text="İptal Et" OnClick="btnCancel_Click" CssClass="btn btn-secondary" />
            </div>
        </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
