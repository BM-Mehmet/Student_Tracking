<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupAdd.aspx.cs" Inherits="StudentTracking.Group.GroupAdd" MasterPageFile="~/StudentMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Grup Ekle</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h1 class="text-center">Grup Ekle</h1>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="txtGroupName">Grup Adı:</label>
                    <asp:TextBox ID="txtGroupName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="txtDescription">Açıklama:</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
                <asp:Button ID="btnAddGroup" runat="server" Text="Grup Ekle" OnClick="btnAddGroup_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
