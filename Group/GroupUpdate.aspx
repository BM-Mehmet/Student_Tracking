<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupUpdate.aspx.cs" Inherits="StudentTracking.Group.GroupUpdate" %>
<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Group</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h1>Grubu Güncelle</h1>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <div class="form-group">
                <asp:TextBox ID="txtGroupName" runat="server" CssClass="form-control" placeholder="Grup Adı" Text='<%# Eval("GroupName") %>'></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:DropDownList ID="ddlLeaderStudent" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Text="-- Lider Öğrenciyi Seç --" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Text="-- Dersi Seç --" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
