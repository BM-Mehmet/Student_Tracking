<%@ Page Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="true" CodeBehind="ManageGroupRequests.aspx.cs" Inherits="StudentTracking.Group.ManageGroupRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Grup Katılma İsteklerini Yönet</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Grup Katılma İsteklerini Yönet</h2>
        <asp:Label ID="lblStatus" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
        <div class="table-responsive">
            <asp:GridView ID="RequestsGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="RequestsGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="student_name" HeaderText="Öğrenci Adı" />
                    <asp:BoundField DataField="group_name" HeaderText="Grup Adı" />
                    <asp:BoundField DataField="course_name" HeaderText="Ders Adı" />
                    <asp:BoundField DataField="join_message" HeaderText="Katılım Mesajı" />
                    <asp:BoundField DataField="status" HeaderText="Durum" />
                    <asp:TemplateField HeaderText="İşlemler">
                        <ItemTemplate>
                            <asp:Button ID="btnApprove" runat="server" CommandName="Approve" CommandArgument='<%# Eval("request_id") %>' Text="Onayla" CssClass="btn btn-success" />
                            <asp:TextBox ID="txtRejectReason" runat="server" CssClass="form-control" TextMode="SingleLine" Style="display:none;"></asp:TextBox>
                            <asp:Button ID="btnReject" runat="server" Text="Reddet" CommandName="InitialReject" CommandArgument='<%# Eval("request_id") %>' CssClass="btn btn-danger" OnClientClick="return showRejectReasonBox(this);" />
                            <asp:Button ID="btnConfirmReject" runat="server" Text="Reddet Onayla" CommandName="Reject" CommandArgument='<%# Eval("request_id") %>' CssClass="btn btn-danger" Style="display:none;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <script>
        function showRejectReasonBox(button) {
            var row = button.closest('tr');
            var textBox = row.querySelector('.form-control');
            textBox.style.display = textBox.style.display === 'none' ? 'block' : 'none';
            return false; // Prevent form submission
        }
    </script>
</asp:Content>
