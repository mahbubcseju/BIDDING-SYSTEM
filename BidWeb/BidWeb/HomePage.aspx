<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BidWeb.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Images/cs1.css" rel="stylesheet" />
    <link href="Images/cs2.css" rel="stylesheet" />
    <link href="Images/cs3.css" rel="stylesheet" />
    <link href="bootstrap-3.3.6-dist/css/bootstrap.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        .carousel-inner > .item > img,
        .carousel-inner > .item > a > img {
            width: 70%;
            margin: auto;
        }
    </style>

    
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








        <div class="container">
            <br />
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                    <li data-target="#myCarousel" data-slide-to="3"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="Images/pic1.jpg" class="img-rounded" alt="Chania" />
                    </div>

                    <div class="item">
                        <img src="Images/pic2.jpg" class="img-rounded" alt="Chania" />
                    </div>

                    <div class="item">
                        <img src="Images/pic3.jpg" alt="Flower" />
                    </div>

                    <div class="item">
                        <img src="Images/pic2.jpg" alt="Flower" />
                    </div>
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
        <div class="hrw-logos container" id="wrapper">
            <div class="caroufredsel_wrapper" style="display: block; text-align: center; float: none; position: relative; top: auto; right: auto; bottom: auto; left: auto; z-index: auto; width: 1223.75px; height: 90px; margin: 0px 0px 0px -73.0312px; overflow: hidden;">
                <div class="logo-slider slider unstyled plT plB text-center school-logo" id="logocarousel" style="text-align: left; float: none; position: absolute; top: 0px; right: auto; bottom: auto; left: -72.819px; margin: 0px; width: 3879px; height: 90px; z-index: auto;">

                    <div class="slide">
                        <img src="Images/a.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/b.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/c.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/d.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/e.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/f.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/g.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/h.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/i.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/j.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/k.jpg" />
                    </div>
                    <div class="slide">
                        <img src="Images/l.jpg" />
                    </div>

                </div>
            </div>
        </div>



        <script>
            $(function () {
                var $c = $('#logocarousel'),
                    $w = $(window);
                $c.carouFredSel({
                    align: false,
                    items: 5,
                    scroll: {
                        items: 1,
                        duration: 2000,
                        timeoutDuration: 0,
                        easing: 'linear',
                        pauseOnHover: 'immediate'
                    }
                });
                $w.bind('resize.example', function () {
                    var nw = $w.width();
                    if (nw < 990) {
                        nw = 990;
                    }
                    $c.width(nw * 3);
                    $c.parent().width(nw);
                }).trigger('resize.example');
            });
        </script>
        <script src="Images/js1.js"></script>
        <script src="Images/js2.js"></script>
        <script src="Images/js3.js"></script>
        <script src="Images/js4.js"></script>
        <script src="Images/js5.js"></script>



    </form>
</body>
</html>
