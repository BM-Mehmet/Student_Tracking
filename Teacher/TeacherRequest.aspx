<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherRequest.aspx.cs" Inherits="StudentTracking.Teacher.TeacherRequest" MasterPageFile="~/StudentMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Öğretmene Katılma İsteği Gönder</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
          <div class="card-header">
        <h2 class="text-center">Öğretmene Katılma İsteği Gönder</h2>
              </div>
        <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red" CssClass="mb-3"></asp:Label>
        <div class="form-group">
            <label for="ddlCourses">Ders Seç:</label>
            <asp:DropDownList ID="ddlCourses" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="ddlGroups">Grup Seç:</label>
            <asp:DropDownList ID="ddlGroups" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="ddlTeachers">Öğretmen Seç:</label>
            <asp:DropDownList ID="ddlTeachers" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="txtJoinMessage">Katılım Mesajınız:</label>
            <asp:TextBox ID="txtJoinMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Katılım mesajınızı buraya yazınız..."></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="İstek Gönder" OnClick="btnSendRequest_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
