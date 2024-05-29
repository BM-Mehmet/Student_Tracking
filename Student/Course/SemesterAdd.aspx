﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SemesterAdd.aspx.cs" Inherits="StudentTracking.Student.Course.SemesterAdd" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Course</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h5>Add New Semester</h5>
            <div class="form-group row">
                <label for="Donem" class="col-md-2 col-form-label">Academic Year:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtNewDonem" runat="server" CssClass="form-control" placeholder="Academic Year And Semester"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="txtStartDate" class="col-md-2 col-form-label">Start Date:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" placeholder="Start Date (dd-MM-yyyy)"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label for="txtEndDate" class="col-md-2 col-form-label">End Date:</label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" placeholder="End Date (dd-MM-yyyy)"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="offset-md-2 col-md-10">
                    <asp:Button ID="btnAddCourse" runat="server" Text="Add Semester" OnClick="btnAddCourse_Click" CssClass="btn btn-success" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-md-12">
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
