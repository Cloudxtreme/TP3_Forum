<%@ Page Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TP3_Forum.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <h2>Inscription</h2>
    <asp:TextBox ID="txtUsername" placeholder="Username" class="form-control register" runat="server" required="true" />
    <asp:TextBox ID="txtEmail" placeholder="Email" class="form-control register" runat="server" required="true" />
    <asp:TextBox ID="txtPassword" type="password" placeholder="Password" class="form-control register" runat="server" required="true" />
    <asp:Label ID="lblAvatar" runat="server" Text="Veuillez choisir un avatar : "></asp:Label><asp:FileUpload ID="avatar" runat="server" class="register" required="true"/>
    <asp:Button class="btn btn-primary register" ID="btnFinishRegister" runat="server" Text="Register" OnClick="btnFinishRegister_Click"/>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
</asp:Content>

