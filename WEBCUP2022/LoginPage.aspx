<%@ Page Title="" Language="C#" MasterPageFile="~/WEBCUPMASTER.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WEBCUP2022.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login Page</h1>
    <br />

    <p>Use your username for login</p>

    <asp:TextBox ID="txtuname" placeholder="Username" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtuname" ForeColor="Red" Display="Dynamic" ValidationExpression="\w{5,10}" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtuname" Text="Required!!" ForeColor="Red" Display="Dynamic" EnableClientScrpt="false" ErrorMessage="Username is a mandatory field!"></asp:RequiredFieldValidator>

    <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqPassword" Display="Dynamic" ControlToValidate="txtPassword" runat="server" ErrorMessage="Password is mandatory!"></asp:RequiredFieldValidator>


    <asp:Button ID="btnlogin" Width="150px" runat="server" Text="Sign In" OnClick="btnlogin_Click" class="cv-btn submitForm" />

                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label><br />

</asp:Content>
