<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherUpdate.aspx.cs" Inherits="StudentTracking.Teacher.TeacherUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Teacher</title>
    <link rel="stylesheet" type="text/css" href="../Css/TeacherUpdate.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update Teacher</h1>
            <div>
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtSurname">Surname:</label>
                <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </div>
    </form>
</body>
</html>
