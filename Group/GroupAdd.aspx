<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupAdd.aspx.cs" Inherits="StudentTracking.Group.GroupAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Group</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="text-center">Add Group</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="txtGroupName">Group Name:</label>
                    <asp:TextBox ID="txtGroupName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="ddlLeaderStudent">Leader Student:</label>
                    <asp:DropDownList ID="ddlLeaderStudent" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    <!-- Lider olarak otomatik olarak giriş yapan kullanıcı seçilir -->
                </div>
                <div class="form-group">
                    <label for="ddlProgram">Program:</label>
                    <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control"></asp:DropDownList>
                    <!-- Programların listesini veritabanından doldurmak için bir yöntem kullanılmalıdır -->
                </div>
                <div class="form-group">
                    <label for="ddlCourse">Course:</label>
                    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    <!-- Kurs bilgisi önceki sayfadan alınarak burada gösterilir ve değiştirilemez -->
                </div>
                <asp:Button ID="btnAddGroup" runat="server" Text="Add Group" OnClick="btnAddGroup_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
