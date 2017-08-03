<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GunSlayah Forum.aspx.cs" Inherits="Project_Gunslayah.GunSlayah_Forum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    <!-- CSS Styles -->
    <style>
        .speech {
            border: 3px solid #020202;
            width: 300px;
            padding: 0;
            margin: 0;
        }

            .speech input {
                border: 0;
                width: 254px;
                display: inline-block;
                height: 40px;
            }

            .speech img {
                float: right;
                width: 40px;
                background-color: aqua;
            }
    </style>

    <!-- Search Form -->
    <br />
    <br />
    <br />

    <div class="speech">
        <asp:TextBox ID="transcript" runat="server"></asp:TextBox>
        <%--<input type="text" name="q" id="transcript" placeholder="Speak" />--%>
        <img onclick="startDictation()" src="//i.imgur.com/cHidSVu.gif" />
    </div>


    <!-- HTML5 Speech Recognition API -->
    <script>
        function startDictation() {

            if (window.hasOwnProperty('webkitSpeechRecognition')) {

                var recognition = new webkitSpeechRecognition();

                recognition.continuous = false;
                recognition.interimResults = false;

                recognition.lang = "en-US";
                recognition.start();

                recognition.onresult = function (e) {
                    document.getElementById('<%= transcript.ClientID %>').value
                                             = e.results[0][0].transcript;
                    recognition.stop();
                    document.forms[0].submit();
                };

                recognition.onerror = function (e) {
                    recognition.stop();
                    document.write('failed');
                }

            }
        }
    </script>
    <br />
    <asp:Table class="table table-hover" runat="server" ID="ThreadsTable">
       <asp:TableRow>

           <asp:TableHeaderCell Width="70%">Thread</asp:TableHeaderCell>
          
            </asp:TableRow>
           </asp:Table>
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
                <h4 style="margin: auto;">Porterhouse are steaks of beef cut from the short loin (called the sirloin in Commonwealth countries).  Porterhouse steaks are generally considered one of the highest quality steaks, and prices at steakhouses are accordingly high.</h4>
            </div>
            <div class="mgmt-right">
                <img width="100" height="100" src="../Images/porterhouse.jpg" />
            </div>
        </div>
        <asp:Panel ID="Panel2" runat="server">
        </asp:Panel>
    </div>
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Gunslayah Forum2.aspx" Text="Go to Page 2" runat="server"></asp:HyperLink>
</asp:Content>
