<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GunSlayah Forum.aspx.cs" Inherits="Project_Gunslayah.GunSlayah_Forum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    <div class="panel panel-info">
            <div class="panel-heading">Chicken Rice</div>
            <div class="panel-body">
                <div class="mgmt-left">
                    <h4 style="margin: auto;">It is one of the national dishes in Singapore. Catherine Ling of CNN describes Hainanese chicken rice as one of the "40 Singapore foods we can't live without.</h4>
                </div>
                <div class="mgmt-right">
                    <img width="100" height="100" src="../Images/chickenrice.jpg" />
                </div>
            </div>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">Kobe Beef Steak</div>
            <div class="panel-body">
                <div class="mgmt-left">
                    <h4 style="margin: auto;">The meat is a delicacy renowned for its flavor, tenderness, and fatty, well-marbled texture. Kobe beef is generally considered one of the three top brands (known as Sandai Wagyuu, "the three big beefs"), along with Matsusaka beef and Ōmi beef or Yonezawa beef.</h4>
                </div>
                <div class="mgmt-right">
                    <img width="100" height="100" src="../Images/kobebeef.jpg" />
                </div>
            </div>
        </div>
    <div class="panel panel-info">
            <div class="panel-heading">Nasi Lemak</div>
            <div class="panel-body">
                <div class="mgmt-left">
                    <h4 style="margin: auto;">Nasi lemak is a Malay fragrant rice dish cooked in coconut milk and pandan leaf.</h4>
                </div>
                <div class="mgmt-right">
                    <img width="100" height="100" src="../Images/nasilemak.jpg" />
                </div>
            </div>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">Porterhouse Steak</div>
            <div class="panel-body">
                <div class="mgmt-left">
                    <h4 style="margin: auto;"> Porterhouse are steaks of beef cut from the short loin (called the sirloin in Commonwealth countries).  Porterhouse steaks are generally considered one of the highest quality steaks, and prices at steakhouses are accordingly high.</h4>
                </div>
                <div class="mgmt-right">
                    <img width="100" height="100" src="../Images/porterhouse.jpg" />
                </div>
            </div>
            <asp:Panel ID="Panel2" runat="server">
            </asp:Panel>       
        </div>
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Gunslayah Forum2.aspx" text="Go to Page 2" runat="server"></asp:HyperLink>
</asp:Content>
