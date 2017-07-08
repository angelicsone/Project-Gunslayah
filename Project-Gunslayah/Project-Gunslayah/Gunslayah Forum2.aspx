<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gunslayah Forum2.aspx.cs" Inherits="Project_Gunslayah.Gunslayah_Forum2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<asp:Panel ID="Panel2" runat="server">
    </asp:Panel>
     <div class="panel panel-info">
            <div class="panel-heading">Pizza</div>
            <div class="panel-body">
                <div class="mgmt-left">
                    <h4 style="margin: auto;">Pizza is a yeasted flatbread typically topped with tomato sauce and cheese and baked in an oven. It is commonly topped with a selection of meats, vegetables and condiments.</h4>
                </div>
                <div class="mgmt-right">
                    <img width="100" height="100" src="../Images/pizza.jpg" />
                </div>
            </div>
        </div>
         <div class="panel panel-info">
            <div class="panel-heading">Burger</div>
            <div class="panel-body">
                <div class="mgmt-left">
                    <h4 style="margin: auto;">A hamburger or burger is a sandwich consisting of one or more cooked patties of ground meat, usually beef, placed inside a sliced bread roll or bun.</h4>
                </div>
                <div class="mgmt-right">
                    <img width="100" height="100" src="../Images/burger.jpg" />
                </div>
            </div>
        </div>
         <div class="panel panel-info">
            <div class="panel-heading">Hot dog bun</div>
            <div class="panel-body">
                <div class="mgmt-left">
                    <h4 style="margin: auto;">A hot dog bun is a type of soft bun shaped specifically to contain a hot dog or frankfurter.</h4>
                </div>
                <div class="mgmt-right">
                    <img width="100" height="100" src="../Images/hotdog.jpg" />
                </div>
            </div>
        </div>
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Gunslayah Forum.aspx" text="Go to Page 1" runat="server"></asp:HyperLink>
</asp:Content>
