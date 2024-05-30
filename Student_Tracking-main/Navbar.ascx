<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="StudentTracking.Navbar" %>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container">
        <a class="navbar-brand" href='<%= ResolveUrl("~/Admin/Admin.aspx") %>'>KSÜ Admin</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href='<%= ResolveUrl("~/Teacher/TeacherList.aspx") %>'>Teachers</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href='<%= ResolveUrl("~/Student/Course/CourseList.aspx") %>'>Courses</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href='<%= ResolveUrl("~/Student/Course/SemesterAdd.aspx") %>'>Semesters</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href='<%= ResolveUrl("~/Student/StudentList.aspx") %>'>Students</a>
                </li>
<%--                <li class="nav-item">
                    <a class="nav-link" href='<%= ResolveUrl("~/Program/ProgramAdd.aspx") %>'>Programs</a>
                </li>--%>
                <li class="nav-item">
                    <a class="nav-link" href='<%= ResolveUrl("~/Group/GroupList.aspx") %>'>Groups</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href='<%= ResolveUrl("~/Teacher/ManageTeacherRequest.aspx") %>'>Öğretmen İstekleri</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href='<%= ResolveUrl("~/Teacher/TeacherCourse.aspx") %>'>Öğretmen Ders Eşleştirmesi</a>
                </li>
            </ul>
        </div>
    </div>
</nav>
