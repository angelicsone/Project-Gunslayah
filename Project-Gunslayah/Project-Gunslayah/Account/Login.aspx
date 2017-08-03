<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project_Gunslayah.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" autocomplete="off" ID="Username" CssClass="form-control"/>
                            <asp:RequiredFieldValidator ValidationGroup="Login" runat="server" ControlToValidate="Username" CssClass="text-danger" ForeColor="red" ErrorMessage="This field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" autocomplete="off" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator ValidationGroup="Login" runat="server" ControlToValidate="Password" CssClass="text-danger" ForeColor="red" ErrorMessage="This field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" ValidationGroup="Login"/>
                        </div>
                    </div>
                </div>
                <asp:Label ID="MessageBox" runat="server"></asp:Label>
                <hr />              
                
            </section>
        </div>
    </div>
</asp:Content>
