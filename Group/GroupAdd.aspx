<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupAdd.aspx.cs" Inherits="StudentTracking.Group.GroupAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Group</title>
    <link rel="stylesheet" type="text/css" href="../Css/AddGroup.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add Group</h1>
            <div>
                <label for="txtGroupName">Group Name:</label>
                <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <label for="ddlLeaderStudent">Leader Student:</label>
                <asp:DropDownList ID="ddlLeaderStudent" runat="server"></asp:DropDownList>
                <!-- Öğrenci liderlerin listesini veritabanından doldurmak için bir yöntem kullanılmalıdır -->
            </div>
            <div>
                <label for="ddlProgram">Program:</label>
                <asp:DropDownList ID="ddlProgram" runat="server"></asp:DropDownList>
                <!-- Programların listesini veritabanından doldurmak için bir yöntem kullanılmalıdır -->
            </div>
            <div>
                <label for="ddlCourse">Course:</label>
                <asp:DropDownList ID="ddlCourse" runat="server"></asp:DropDownList>
                <!-- Kursların listesini veritabanından doldurmak için bir yöntem kullanılmalıdır -->
            </div>
            <asp:Button ID="btnAddGroup" runat="server" Text="Add Group" OnClick="btnAddGroup_Click" />
        </div>
    </form>
</body>
</html>