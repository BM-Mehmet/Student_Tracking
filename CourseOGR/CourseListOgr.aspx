<%@ Page Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="true" CodeBehind="CourseListOgr.aspx.cs" Inherits="StudentTracking.CourseOGR.CourseListOgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ders Sayfası</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div>
            <h1 class="mb-4">Ders Listesi</h1>
            <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Green" CssClass="mb-3"></asp:Label>
            <div class="table-responsive">
                <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                    OnRowCommand="GridViewCourses_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="true" />
                        <asp:BoundField DataField="course_name" HeaderText="Ders Adı" />
                        <asp:BoundField DataField="is_group_enabled" HeaderText="Grup Açık" />
                        <asp:BoundField DataField="is_alone_enabled" HeaderText="Tek Kişilik Açık" />
                        <asp:TemplateField HeaderText="Eylemler">
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" runat="server" CommandName="SelectCourse" CommandArgument='<%# Eval("id") %>' Text="Seç" CssClass="btn btn-sm btn-primary" />
                                <asp:Button ID="btnDelete" runat="server" CommandName="DeleteCourse" CommandArgument='<%# Eval("id") %>' Text="Sil" CssClass="btn btn-sm btn-danger" />
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
            <asp:Button ID="btnViewEnrolledCourses" runat="server" Text="Kayıtlı Olduğum Dersler" OnClick="btnViewEnrolledCourses_Click" CssClass="btn btn-secondary mt-3" />
        </div>
    </div>
</asp:Content>
