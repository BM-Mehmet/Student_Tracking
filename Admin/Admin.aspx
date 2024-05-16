<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="StudentTracking.Admin.Admin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Navbar</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
   <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>

</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container">
            <a class="navbar-brand" href="#">KSÜ Admin</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="<%= ResolveUrl("~/Student/StudentList.aspx") %>">Students</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= ResolveUrl("~/Teacher/TeacherList.aspx") %>">Teachers</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= ResolveUrl("~/program/ProgramList.aspx") %>">Programs</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= ResolveUrl("~/Student/Course/CourseList.aspx") %>">Courses</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= ResolveUrl("~/Group/GroupList.aspx") %>">Groups</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="<%= ResolveUrl("~/Semester/SemesterList.aspx") %>">Semesters</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>

