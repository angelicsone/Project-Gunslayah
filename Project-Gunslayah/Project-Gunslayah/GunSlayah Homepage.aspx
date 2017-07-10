<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GunSlayah Homepage.aspx.cs" Inherits="Project_Gunslayah._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="toptron" class="jumbotron">
        <div class="page header">
                        <img src="Images/gunslayah.jpg" style="max-width:200px;" />
                    </div>
        <div class="topLeft">
            
            <h5>~View Our Gun Slayah Forum for a variety of delicous cuisines~</h5>
            <a class="btn btn-info" href="GunSlayah Forum.aspx">Enter GunSlayah Forum &raquo;</a>
        </div>
        
        <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="3000">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                 <li data-target="#myCarousel" data-slide-to="2"></li>
                 <li data-target="#myCarousel" data-slide-to="3"></li>
                 <li data-target="#myCarousel" data-slide-to="4"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img style="width: 50%; height: 250px; margin: auto;" src="Images/chickenrice.jpg" />
                </div>

                <div class="item">
                    <img style="width: 50%; height: 250px; margin: auto;" src="Images/Roland-Restaurant.jpg" />
                </div>

                <div class="item">
                    <img style="width: 50%; height: 250px; margin: auto;" src="Images/Penang asam laksa.jpg" />
                </div>

                <div class="item">
                    <img style="width: 50%; height: 250px; margin: auto;" src="Images/fish.jpg" />
                </div>

                <div class="item">
                    <img style="width: 50%; height: 250px; margin: auto;" src="Images/steak.jpg" />
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

    <div class="row">
        <div class="col-md-4">
            <h2>Restaurant</h2>
            <p>
                Explore over 60 restaurants, offering the best of local and international cuisines in one convenient dining destination. Discover exclusive culinary creations by ten of the world’s best celebrity chef restaurants. And don't miss the exciting dining and nightlife events happening this month at Marina Bay Sands.
            </p>
            <p>
                <a class="btn btn-default" href="GunSlayah Forum.aspx">SEE DETAILS &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>WINE DINNERS AND PROMOTIONS</h2>
            <p>
               Discover the art of wine appreciation with exclusive tasting events and tempting offers.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">SEE DETAILS &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Private Events</h2>
            <p>
                Be it for business or pleasure, make your next private dining event more than memorable.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">SEE DETAILS &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
