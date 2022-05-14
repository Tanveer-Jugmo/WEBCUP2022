<%@ Page Title="" Language="C#" MasterPageFile="~/WEBCUPMASTER.Master" AutoEventWireup="true" CodeBehind="REgistrationPAge.aspx.cs" Inherits="WEBCUP2022.REgistrationPAge" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>WEBCUP 2022 :)</h1>

    <br />
    <br />

    <br />

    <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
    <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rvtutFname" runat="server" ControlToValidate="txtfname" ForeColor="Red" Display="Dynamic" EnableClientScrpt="false" ErrorMessage="First Name is a mandatory field!"></asp:RequiredFieldValidator>
    <br />

    <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
    <asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rvtutLname" runat="server" ControlToValidate="txtlname" ForeColor="Red" Display="Dynamic" EnableClientScrpt="false" ErrorMessage="Last Name is a mandatory field!"></asp:RequiredFieldValidator>
    <br />

    <asp:Label ID="Label3" runat="server" Text="City"></asp:Label>
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCity" ForeColor="Red" Display="Dynamic" EnableClientScrpt="false" ErrorMessage="City is a mandatory field!"></asp:RequiredFieldValidator>
    <br />

    <asp:Label ID="Label4" runat="server" Text="Country"></asp:Label>
    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCountry" ForeColor="Red" Display="Dynamic" EnableClientScrpt="false" ErrorMessage="Country is a mandatory field!"></asp:RequiredFieldValidator>
    <br />


    <asp:Label ID="Label5" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="txtuname" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtuname" ForeColor="Red" Display="Dynamic" ValidationExpression="\w{5,10}" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtuname"  ForeColor="Red" Display="Dynamic" EnableClientScrpt="false" ErrorMessage="Username is a mandatory field!"></asp:RequiredFieldValidator>


    <br />

    <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="reqPassword" Display="Dynamic" ForeColor="Red" ControlToValidate="txtPassword" runat="server" ErrorMessage="Password is mandatory!"></asp:RequiredFieldValidator>


    <br />


    <asp:Label ID="Label7" runat="server" Text="Confirm Password"></asp:Label>
    <asp:TextBox ID="txtCpassword" TextMode="Password" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReqCpassword" Display="Dynamic" ForeColor ="Red" ControlToValidate="txtCpassword" runat="server" ErrorMessage="Password is Required"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="conPassword" Display="Dynamic" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtCpassword" ForeColor ="Red"  ErrorMessage="Password does not match"></asp:CompareValidator>
    <br />

    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Button" />


    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>












</asp:Content>
