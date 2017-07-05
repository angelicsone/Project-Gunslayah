<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project_Gunslayah.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">   
        <h4 >Create a new account</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" autocomplete="off" ID="email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="email" ForeColor="red" ErrorMessage="This field is required." />
                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" ForeColor="red" ErrorMessage="Invalid email address."/>       
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="username" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" autocomplete="off" ID="username" CssClass="form-control"/>
                <asp:RequiredFieldValidator ForeColor="red" ErrorMessage="Required" ControlToValidate="username" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" autocomplete="off" ID="password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="password" ForeColor="red" ErrorMessage="This field is required." />
                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="password" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$" ForeColor="red" ErrorMessage="Password requirements not fulfilled."/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="confirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" autocomplete="off" ID="confirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword" Display="Dynamic" ForeColor="red" ErrorMessage="This field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="password" ControlToValidate="confirmPassword" Display="Dynamic" ErrorMessage="Password do not match." Forecolor ="red"/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
        <asp:Label ID="MessageBox" runat="server"></asp:Label>
        <hr />
        <asp:Label ID="Signin" runat="server">Have an account?</asp:Label>&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="GoToLogin" NavigateUrl="Login.aspx" Text="Log in" runat="server"/><br />
        <asp:Label ID="passwordPolicy" runat="server">Our password policy:</asp:Label> &nbsp;&nbsp;&nbsp;<asp:HyperLink ID="GoToFAQ" NavigateUrl="~/FAQ.aspx" Text="For more info.." runat="server"/><!--Link to stanley faq page -->
   
    </div>
</asp:Content>