<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseSign.aspx.cs" Inherits="StudentTracking.Course.courseSign" MasterPageFile="~/StudentMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kayıt Olunan Dersler</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container mt-5">
        <div class="form-group">
            <label for="DropDownList1">Ders Seçiniz:</label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Button ID="btnLeader" runat="server" OnClick="Leader_Click" Text="Grup Lideri Ol" CssClass="btn btn-primary" />
            <asp:Button ID="btnSingleGroup" runat="server" OnClick="SingleGroup_Click" Text="Tek Kişilik Grup Oluştur" CssClass="btn btn-primary" />
            <asp:Button ID="btnMember" runat="server" OnClick="Member_Click" Text="Gruba Katıl" CssClass="btn btn-primary" />
            <asp:Button ID="btnManageRequests" runat="server" OnClick="btnManageRequests_Click" Text="Gruba Katılım İsteklerini Yönet" CssClass="btn btn-secondary" />
            <asp:Button ID="btnSendTeacherRequest" runat="server" OnClick="btnSendTeacherRequest_Click" Text="Öğretmene Katılma İsteği Gönder" CssClass="btn btn-info" />
        </div>
    </div>
</asp:Content>


