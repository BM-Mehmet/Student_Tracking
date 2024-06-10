<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="StudentTracking.Admin.Teachers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">

        <a class="navbar-brand" href='<%= ResolveUrl("~/Teacher/Teacher.aspx") %>'>KSÜ Öğretmen</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href='<%= ResolveUrl("~/Teacher/TManageTeacherRequests.aspx") %>'>Öğretmen İstekleri</a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <asp:GridView ID="GridViewGroups" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="TeacherId" HeaderText="Grup Adı" />
                    <asp:BoundField DataField="CourseId" />
                    <asp:BoundField DataField="course_id" HeaderText="Ders İd" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
