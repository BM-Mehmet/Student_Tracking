<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupList.aspx.cs" Inherits="StudentTracking.Group.GroupList" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group List</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5  ">

        <div class="card-header">
            <h2 class="text-center">Grup Listesi</h2>
        </div>

        <asp:GridView ID="GridViewGroups" runat="server" AutoGenerateColumns="False"
            OnRowDeleting="GridViewGroups_RowDeleting" OnRowEditing="GridViewGroups_RowEditing"
            OnRowDataBound="GridViewGroups_RowDataBound" DataKeyNames="id" CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="group_name" HeaderText="Grup adı" />
                <asp:BoundField DataField="LeaderStudentName" HeaderText="Lider Öğrenci Adı" />
                <asp:BoundField DataField="CourseName" HeaderText="Ders Adı" />
                <asp:CommandField ShowEditButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                <asp:TemplateField HeaderText="Üyeler">
                    <ItemTemplate>
                        <asp:GridView ID="GridViewMembers" runat="server" AutoGenerateColumns="False" CssClass="table table-sm">
                            <Columns>
                                <asp:BoundField DataField="student_name" HeaderText="Öğrenci adı" />
                                <asp:BoundField DataField="join_date" HeaderText="Kayıt Tarihi" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField DataField="status" HeaderText="Durumu" />
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

    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
