<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupRequest.aspx.cs" Inherits="StudentTracking.Group.GroupRequest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Join Group Request</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div>
            <h2>Join a Group</h2>
            
            <!-- Dropdown list to select group -->
            <div class="form-group">
                <asp:Label ID="GroupLabel" runat="server" Text="Select Group:"></asp:Label>
                <asp:DropDownList ID="ddlGroups" runat="server" DataTextField="GroupName" DataValueField="Id" CssClass="form-control"></asp:DropDownList>
            </div>
            
            <!-- Submit button -->
            <asp:Button ID="RequestJoinButton" runat="server" Text="Send Join Request" OnClick="RequestJoinButton_Click" CssClass="btn btn-primary" />
        </div>
        
        <div>
            <h2>Manage Join Requests</h2>
            <div class="table-responsive">
                <asp:GridView ID="RequestsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="RequestsGridView_RowCommand" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="student_id" HeaderText="Student ID" />
                        <asp:BoundField DataField="group_id" HeaderText="Group ID" />
                        <asp:BoundField DataField="status" HeaderText="Status" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="ApproveButton" runat="server" Text="Approve" CommandName="Approve" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-success" />
                                <asp:Button ID="RejectButton" runat="server" Text="Reject" CommandName="Reject" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
