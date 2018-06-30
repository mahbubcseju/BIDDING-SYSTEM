<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="BidWeb.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap-3.3.6-dist/css/bootstrap.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            var header = $('body');

            var backgrounds = new Array(
                'url(Images/a.jpg)'
              , 'url(Images/b.jpg)'
              , 'url(http://placekitten.com/300)'
              , 'url(http://placekitten.com/400)'
            );

            var current = 0;

            function nextBackground() {
                current++;
                current = current % backgrounds.length;
                header.css('background-image', backgrounds[current]);
            }
            setInterval(nextBackground, 5000);

            header.css('background-image', backgrounds[0]);
        });
    </script>
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
                        <li><a href="SearchBy.aspx" style="color: white">Search Product</a></li>


                        <%--<li><a href="ViewAllItem.aspx" style="color: white">View All Item</a></li>
                        <li><a href="ViewMyItem.aspx" style="color: white">View My Item</a></li>
                        <li><a href="ViewAllItem.aspx" style="color: white">My Product Biding</a></li>
                        <li><a href="ViewMyItem.aspx" style="color: white">My Bought Product</a></li>--%>
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#" style="color: white">Menu<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="AddItem.aspx">Add Item</a></li>
                                <li><a href="ViewMyItem.aspx">View All Item</a></li>
                                <li><a href="ViewMyItem.aspx">View My Item</a></li>
                                <li><a href="MyProductBidingList.aspx">My Product Biding</a></li>
                                <li><a href="MyBoughtList.aspx">My Bought Product</a></li>
                                <li><a href="SearchBy.aspx">Search Product</a></li>

                            </ul>
                        </li>
                        <li><a href="Register.aspx" style="color: white">
                            <asp:Label ID="registerLabel" runat="server" Text="Register"></asp:Label></a></li>
                        <li><a style="color: white" href="EditProfile.aspx">
                            <asp:Label ID="userNameLabel" runat="server" Text=""></asp:Label></a></li>
                        <li><a style="color: white">
                            <asp:Button ID="logoutButton" runat="server" Text="Log out" OnClick="logoutButton_OnClick" ForeColor="White" BackColor="#4E5C72" BorderColor="#4E5C72" BorderStyle="None" /></a></li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>

        <section class="container">
            <div class="jumbotron">

                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4">
                        <asp:Button ID="addItemButton" runat="server" OnClick="addItemButton_Click" Text="Add Item" CssClass="btn btn-lg btn-success" Width="201px" />
                        <br />
                        <br />
                        <asp:Button ID="viewMyItemButton" runat="server" OnClick="viewMyItemButton_Click" Text="View My Item" CssClass="btn btn-lg btn-success" Width="202px" />
                        <br />
                        <br />
                        <asp:Button ID="viewAllItemButton" runat="server" OnClick="viewAllItemButton_Click" Text="View All Item" CssClass="btn btn-lg btn-success" Width="202px" />
                        <br />
                        <br />
                        <asp:Button ID="myBidingListButton" runat="server" Text="My Biding List" OnClick="myBidingListButton_OnClick" CssClass="btn btn-lg btn-success" Width="202px" />
                        <br />
                        <br />
                        <asp:Button ID="myBuyingItemButton" runat="server" Text="My Bought Item" OnClick="myBuyingItemButton_OnClick" CssClass="btn btn-lg btn-success" Width="202px" />
                    </div>
                    <div class="col-md-4"></div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
