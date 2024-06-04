<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegister.aspx.cs" Inherits="StudentTracking.Student.StudentRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Register</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form2" runat="server" class="container mt-5">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Student Register</h5>
                <div class="form-group row">
                    <label for="txtNewName" class="col-md-2 col-form-label">Name:</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtNewName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtNewSurname" class="col-md-2 col-form-label">Surname:</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtNewSurname" runat="server" CssClass="form-control" placeholder="Surname"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="txtRecipient" class="col-md-2 col-form-label">Alıcı E-posta Adresi:</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtRecipient" runat="server" CssClass="form-control" placeholder="Alıcı E-posta Adresi"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-12 text-center">
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btnSendEmail" runat="server" Text="Register" OnClick="btnSendEmail_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

itle text-center">Gmail API ile E-posta Gönderme</h2>
                        <div class="form-group">
                            <label for="EmailTextBox">E-posta Adresi:</label>
                            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="SendEmailButton" runat="server" Text="E-posta Gönder" OnClick="SendEmailButton_Click" CssClass="btn btn-primary btn-block" />
                        <p class="mt-3">
                            <asp:Label ID="InfoLabel" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
