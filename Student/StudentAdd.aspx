<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAdd.aspx.cs" Inherits="StudentTracking.Student.StudentAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add New Student</h1>
            <table>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="txtNewName" runat="server" placeholder="Name"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Surname:</td>
                    <td>
                        <asp:TextBox ID="txtNewSurname" runat="server" placeholder="Surname"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="txtNewEmail" runat="server" placeholder="Email"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
