﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchBy.aspx.cs" Inherits="BidWeb.SearchBy" EnableEventValidation="false" %>

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

                    <%--<ul class="nav navbar-nav navbar-right">
                        <li><a href="ViewAllItemByRepeater.aspx" style="color: white">Current Products</a></li>
                        <li><a href="SearchBy.aspx" style="color: white">Search Product</a></li>
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#" style="color: white">Menu<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="AddItem.aspx">Add Item</a></li>
                                <li><a href="ViewMyItem.aspx">View All Item</a></li>
                                <li><a href="ViewMyItem.aspx">View My Item</a></li>
                                <li><a href="MyProductBidingList.aspx">My Product Biding</a></li>
                                <li><a href="MyBoughtList.aspx">My Bought Product</a></li>
                            </ul>
                        </li>
                        <li><a href="#" data-toggle="modal" data-target="#loginModal" style="color: white">
                            <asp:Label ID="loginLabel" runat="server" Text=""></asp:Label></a></li>
                        <li><a href="EditProfile.aspx" style="color: white">
                            <asp:Label ID="userNameLabel" runat="server"></asp:Label></a></li>
                        <li><a style="color: white">
                            <asp:Button ID="logoutButton" runat="server" Text="Log out" OnClick="logoutButton_OnClick" ForeColor="White" BackColor="#4E5C72" BorderColor="#4E5C72" BorderStyle="None" /></a></li>

                    </ul>--%>

                    <ul class="nav navbar-nav navbar-right">

                        <li><a href="ViewAllItemByRepeater.aspx" style="color: white">Current Products</a></li>
                        <li><a href="SearchBy.aspx" style="color: white">Search Product</a></li>
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#" style="color: white">
                            <asp:Label ID="menuLabel" runat="server">Menu<span class="caret"></span></asp:Label>
                        </a>
                            <ul class="dropdown-menu">
                                <li><a href="AddItem.aspx">Add Item</a></li>
                                <li><a href="ViewMyItem.aspx">View All Item</a></li>
                                <li><a href="ViewMyItem.aspx">View My Item</a></li>
                                <li><a href="MyProductBidingList.aspx">My Product Biding</a></li>
                                <li><a href="MyBoughtList.aspx">My Bought Product</a></li>
                                <li><a href="SearchBy.aspx">Search Product</a></li>

                            </ul>
                        </li>

                        <li><a style="color: white" href="EditProfile.aspx">
                            <asp:Label ID="userNameLabel" runat="server" Text=""></asp:Label></a></li>
                        <li><a href="#" data-toggle="modal" data-target="#loginModal" style="color: white">
                            <asp:Label ID="loginLabel" runat="server" Text=""></asp:Label></a></li>
                        <li><a href="Register.aspx" style="color: white">
                            <asp:Label ID="registerLabel" runat="server" Text=""></asp:Label></a></li>
                        <li><a style="color: white">
                            <asp:Button ID="logoutButton" runat="server" Text="Log out" OnClick="logoutButton_OnClick" ForeColor="White" BackColor="#4E5C72" BorderColor="#4E5C72" BorderStyle="None" /></a></li>

                    </ul>


                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>
        <div class="container">
            <div class="jumbotron">

                <asp:Label ID="Label1" runat="server" Text="Search By Name/Code/Category"></asp:Label>
                <asp:TextBox ID="productTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="searchByProductButton" runat="server" OnClick="searchByProductButton_Click" Text="Search" />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Minimum Taka"></asp:Label>
                <asp:TextBox ID="minimumThenTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="searchMinimumButton" runat="server" OnClick="searchMinimumButton_Click" Text="Search" />
                <br />
                <br />
                <asp:GridView ID="searchedGridView" runat="server" CssClass="table table-hover table-responsive" AutoGenerateColumns="False" OnRowDataBound="searchedGridView_OnRowDataBound" OnSelectedIndexChanged="searchedGridView_OnSelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Name" />
                        <asp:BoundField DataField="ProductCode" HeaderText="Code" />
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="75px"
                                    ImageUrl='<%#Eval("ProductImage")%>' Width="75px" />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Category" HeaderText="Category" />
                        <asp:BoundField DataField="MinimumBid" HeaderText="Taka" />
                        <asp:BoundField DataField="LastDate" HeaderText="Last Date" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!-- Donate Modal -->
        <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="donateModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="donateModalLabel">Login</h4>
                    </div>
                    <div class="modal-body">


                        <div class="row">
                            <div class="form-group col-md-12 ">
                                <asp:TextBox ID="userNameTextBox" runat="server" CssClass="form-control" placeholder="User Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-md-12 ">
                                <asp:TextBox ID="passwordTextBox" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-md-12">
                                <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_OnClick" CssClass="btn btn-primary pull-left" />
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
        <!-- /.modal -->
    </form>
</body>
</html>
