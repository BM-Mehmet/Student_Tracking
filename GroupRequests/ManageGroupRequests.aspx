<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageGroupRequests.aspx.cs" Inherits="StudentTracking.Group.ManageGroupRequests" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grup Katılım İsteklerini Yönet</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <h2>Grup Katılım İstekleri</h2>
        <asp:Label ID="lblStatus" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
        <div class="table-responsive">
            <asp:GridView ID="RequestsGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="RequestsGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="student_name" HeaderText="Öğrenci Adı" />
                    <asp:BoundField DataField="group_name" HeaderText="Grup Adı" />
                    <asp:BoundField DataField="join_message" HeaderText="Katılım Mesajı" />
                    <asp:BoundField DataField="status" HeaderText="Durum" />
                    <asp:TemplateField HeaderText="İşlemler">
                        <ItemTemplate>
                            <asp:Button ID="btnApprove" runat="server" CommandName="Approve" CommandArgument='<%# Eval("request_id") %>' Text="Onayla" CssClass="btn btn-success" />
                            <asp:TextBox ID="txtRejectReason" runat="server" CssClass="form-control" TextMode="SingleLine" Style="display:none;"></asp:TextBox>
                            <asp:Button ID="RejectButton" runat="server" Text="Reddet" CommandName="InitialReject" CommandArgument='<%# Eval("request_id") %>' CssClass="btn btn-danger" OnClientClick="return showRejectReasonBox(this);" />
        <asp:Button ID="ConfirmRejectButton" runat="server" Text="Reddet Onayla" CommandName="Reject" CommandArgument='<%# Eval("request_id") %>' CssClass="btn btn-danger" Style="display:none;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function showRejectReasonBox(button) {
            var row = button.closest('tr');
            var textBox = row.querySelector('.form-control');
            var rejectButton = row.querySelector('[id*="RejectButton"]');
            var confirmRejectButton = row.querySelector('[id*="ConfirmRejectButton"]');

            if (textBox.style.display === 'none') {
                textBox.style.display = 'block';
                rejectButton.style.display = 'none';
                confirmRejectButton.style.display = 'block';
                return false;
            }
            return true;  // İkinci tıklamada form submit edilecek.
        }

    </script>

</body>
</html>
