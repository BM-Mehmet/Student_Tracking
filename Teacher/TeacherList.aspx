<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherList.aspx.cs" Inherits="StudentTracking.Teacher.TeacherList" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teachers List</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
</head>
<body>
    <uc:Navbar ID="Navbar2" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <div class="card-header">
                <h2 class="text-center">Öğretmen Listesi</h2>
            </div>
            <!-- Add Button -->
            <div class="table-responsive">
                <asp:GridView ID="GridViewTeachers" runat="server" AutoGenerateColumns="False" OnRowEditing="GridViewTeachers_RowEditing" OnRowDeleting="GridViewTeachers_RowDeleting"
                    SelectedRowStyle-CssClass="selectedRow" DataKeyNames="ID"
                    CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Ad" />
                        <asp:BoundField DataField="Surname" HeaderText="Soyad" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:TemplateField HeaderText="İşlemler">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" Text="Düzenle" CssClass="btn btn-primary" />
                                <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Sil" Text="Sil" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this teacher?');" />
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
            <asp:Button ID="btnAddTeacher" runat="server" Text="Öğretmen Ekle" CssClass="btn btn-success mb-3" OnClick="btnAddTeacher_Click" />
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
