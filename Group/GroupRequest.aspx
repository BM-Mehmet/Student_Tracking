<%@ Page Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="true" CodeBehind="GroupRequest.aspx.cs" Inherits="StudentTracking.Group.GroupRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Gruba Katılma İsteği</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script>
        function showAlert(message) {
            var modal = document.createElement('div');
            modal.className = 'modal';
            modal.innerHTML = '<div class="modal-content">' +
                '<span class="close-button" onclick="this.parentElement.parentElement.remove();">&times;</span>' +
                '<p>' + message + '</p>' +
                '<button onclick="this.parentElement.parentElement.remove();">Tamam</button>' +
                '</div>';
            document.body.appendChild(modal);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="card-header">
            <h2>Gruba Katıl</h2>
        </div>
        <asp:GridView ID="GridViewGroups" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="GridViewGroups_RowCommand">
            <Columns>
                <asp:BoundField DataField="GroupName" HeaderText="Grup Adı" />
                <asp:BoundField DataField="Description" HeaderText="Açıklama" />
                <asp:TemplateField HeaderText="Üyeler">
                    <ItemTemplate>
                        <asp:Label ID="lblMembers" runat="server" Text='<%# Bind("Members") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Katılım Mesajı">
                    <ItemTemplate>
                        <asp:TextBox ID="txtJoinMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        <asp:Button ID="btnJoin" runat="server" CommandName="Join" CommandArgument='<%# Eval("Id") %>' Text="Katıl" CssClass="btn btn-primary" />
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
        <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
    </div>
</asp:Content>
