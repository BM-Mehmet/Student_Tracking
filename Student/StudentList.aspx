<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="StudentTracking.Student.StudentList" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Students Page</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <div class="card-header">
                <h2 class="text-center">Öğrenci Listesi</h2>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                    OnRowEditing="GridViewStudents_RowEditing" OnRowDeleting="GridViewStudents_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="true" />
                        <asp:BoundField DataField="name" HeaderText="Ad" />
                        <asp:BoundField DataField="surname" HeaderText="Soyad" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:TemplateField HeaderText="İşlemler">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Düzenle" CommandName="Edit" CssClass="btn btn-sm btn-primary" />
                                <asp:Button ID="btnDelete" runat="server" Text="Sil" CommandName="Delete" CssClass="btn btn-sm btn-danger" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" CommandName="Update" CssClass="btn btn-sm btn-success" />
                                <asp:Button ID="btnCancel" runat="server" Text="İptal Et" CommandName="Cancel" CssClass="btn btn-sm btn-secondary" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
            <asp:Button ID="btnAddStudent" runat="server" Text="Yeni Öğrenci ekle" OnClick="btnAddStudent_Click" CssClass="btn btn-success mt-3" />
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
