<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="StudentTracking.Student.Course.CourseList" %>
<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Page</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <uc:Navbar ID="Navbar1" runat="server" />
            <h5 class="mb-4">Courses List</h5>
            <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Green" CssClass="mb-3"></asp:Label>
            <div class="table-responsive">
                <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" DataKeyNames="id" 
                    OnRowCommand="GridViewCourses_RowCommand" OnRowEditing="GridViewCourses_RowEditing" OnRowDeleting="GridViewCourses_RowDeleting" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="true" />
                        <asp:BoundField DataField="course_name" HeaderText="Course Name" />
                        <asp:BoundField DataField="is_group_enabled" HeaderText="Is Group Enabled" />
                        <asp:BoundField DataField="is_alone_enabled" HeaderText="Is Alone Enabled" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
<%--                                <asp:Button ID="btnSelect" runat="server" CommandName="SelectCourse" CommandArgument='<%# Eval("id") %>' Text="Select" CssClass="btn btn-sm btn-primary" />--%>
                                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("id") %>' Text="Edit" CssClass="btn btn-sm btn-primary" />
                                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("id") %>' Text="Delete" CssClass="btn btn-sm btn-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
<%--            <asp:Button ID="btnViewEnrolledCourses" runat="server" Text="View Enrolled Courses" OnClick="btnViewEnrolledCourses_Click" CssClass="btn btn-secondary mt-3" />--%>
            <asp:Button ID="btnAddCourses" runat="server" Text="Ders Ekle" OnClick="btnAddStudent_Click" CssClass="btn btn-primary mt-3" />
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
