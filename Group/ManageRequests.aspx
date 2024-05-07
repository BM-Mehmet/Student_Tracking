<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRequests.aspx.cs" Inherits="StudentTracking.Group.ManageRequests" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Join Requests</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Join Requests</h2>
            <asp:GridView ID="RequestsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="RequestsGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="Student ID" />
                    <asp:BoundField DataField="group_id" HeaderText="Group ID" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="ApproveButton" runat="server" Text="Approve" CommandName="Approve" CommandArgument='<%# Eval("Id") %>' />
                            <asp:Button ID="RejectButton" runat="server" Text="Reject" CommandName="Reject" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Come Back" />
    </form>
</body>
</html>
