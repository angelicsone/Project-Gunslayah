<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="Project_Gunslayah.Account.Activation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div id="msform">
    <!-- fieldsets -->
    <h4>Not yet activate your account?</h4> <br/>
    <fieldset>
        <h2 class="fs-title">Enter your activation code</h2>
        <asp:TextBox ID="actCode" runat="server" maxlength="5" minimumlength="5" placeholder="Code"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="actCode" Display="Dynamic" ErrorMessage="This field is required."/>
        <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="actCode" ErrorMessage="Invalid code" />
        <asp:RangeValidator runat="server" Type="Integer" MinimumValue="0" MaximumValue="99999" ControlToValidate="actCode" />
        <asp:Button runat="server" OnClick="VerifyUser_Click" Text="Verify" CssClass="actionButton" />
        <br />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <asp:Label ID="MessageBox" runat="server"></asp:Label>
     </fieldset>
  </div>
</asp:Content>

 
