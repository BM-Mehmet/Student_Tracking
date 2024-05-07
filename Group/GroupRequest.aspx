<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupRequest.aspx.cs" Inherits="StudentTracking.Group.GroupRequest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Join Group Request</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Join a Group</h2>
            
            <!-- Dropdown list to select group -->
            <asp:Label ID="GroupLabel" runat="server" Text="Select Group:"></asp:Label>
            <asp:DropDownList ID="ddlGroups" runat="server" DataTextField="GroupName" DataValueField="Id"></asp:DropDownList>
            
            <!-- Submit button -->
            <asp:Button ID="RequestJoinButton" runat="server" Text="Send Join Request" OnClick="RequestJoinButton_Click" />
        </div>
    </form>
</body>
</html>