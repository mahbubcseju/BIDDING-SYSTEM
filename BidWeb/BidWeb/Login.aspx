<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BidWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap-3.3.6-dist/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-default" style="background-color: #4e5c72; font-size: 20px; height: 70px">
            <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#" style="font-size: 30px; color: white">
                        <img src="Images/logo1.png" width="166" height="46" />
                    </a>
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">


                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="ViewAllItemByRepeater.aspx" style="color: white">Current Products</a></li>
                        <li><a href="Login.aspx" style="color: white">Login</a></li>
                        <li><a href="Register.aspx" style="color: white">Register</a></li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>
        <section class="container">
            <div class="jumbotron">
                <asp:Label ID="Label2" runat="server" Text="User Name" CssClass="h3"></asp:Label>
                <asp:TextBox ID="userNameTextBox" runat="server" CssClass="form-control" Width="250px" placeholder="User Name..."></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Password" CssClass="h3"></asp:Label>
                <asp:TextBox ID="passwordTextBox" runat="server" CssClass="form-control" Width="250px" TextMode="Password" placeholder="Password..."></asp:TextBox>
                <br />
                <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="Login" CssClass="btn btn-primary"/>
            </div>
        </section>
    </form>
</body>
</html>
