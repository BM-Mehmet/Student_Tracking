<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTeacherRequest.aspx.cs" Inherits="StudentTracking.Teacher.ManageTeacherRequests" %>

<%@ Register Src="~/Navbar.ascx" TagName="Navbar" TagPrefix="uc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Öğretmene Katılma İsteklerini Yönet</title>
    <!-- Bootstrap CSS for styling -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <uc:Navbar ID="Navbar1" runat="server" />
    <form id="form2" runat="server" class="container mt-5">
        <h2>Öğretmene Katılma İsteklerini Yönet</h2>
        <asp:GridView ID="GvTeacherRequests" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvTeacherRequests_RowCommand">
            <Columns>
                <asp:BoundField DataField="StudentName" HeaderText="Öğrenci Adı" />
                <asp:BoundField DataField="CourseName" HeaderText="Ders Adı" />
                <asp:BoundField DataField="JoinMessage" HeaderText="Katılma Mesajı" />
                <asp:BoundField DataField="RequestDate" HeaderText="İstek Tarihi" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                <asp:BoundField DataField="GroupName" HeaderText="Grup Adı" />
                <asp:TemplateField HeaderText="İşlemler">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" runat="server" CommandName="Approve" CommandArgument='<%# Eval("RequestId") %>' Text="Onayla" CssClass="btn btn-success" />
                        <asp:TextBox ID="txtRejectReason" runat="server" CssClass="form-control" TextMode="SingleLine" Style="display: none;"></asp:TextBox>
                        <asp:Button ID="btnReject" runat="server" Text="Reddet" CommandName="InitialReject" CommandArgument='<%# Eval("RequestId") %>' CssClass="btn btn-danger" OnClientClick="return showRejectReasonBox(this);" />
                        <asp:Button ID="btnConfirmReject" runat="server" Text="Reddet Onayla" CommandName="Reject" CommandArgument='<%# Eval("RequestId") %>' CssClass="btn btn-danger" Style="display: none;" />
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

    <!-- Bootstrap JS for interaction -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script>
        function showRejectReasonBox(button) {
            var row = button.closest('tr');
            var textBox = row.querySelector('.form-control');
            var rejectButton = row.querySelector('[id*="btnReject"]');
            var confirmRejectButton = row.querySelector('[id*="btnConfirmReject"]');

            textBox.style.display = 'block'; // TextBox'ı görünür yap
            rejectButton.style.display = 'none'; // Reddet düğmesini gizle
            confirmRejectButton.style.display = 'block'; // Reddet Onayla düğmesini göster
            return false;  // Form submit'ini durdur
        }
    </script>
</body>
</html>
