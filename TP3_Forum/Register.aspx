<%@ Page Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TP3_Forum.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <h2>Inscription</h2>
    <asp:TextBox ID="txtUsername" placeholder="Username" class="form-control register" runat="server" required="true"/>
    <asp:TextBox ID="txtRegEmail" placeholder="Email" class="form-control register" runat="server" required="true" />
    <asp:TextBox ID="txtRegPassword" type="password" placeholder="Password" class="form-control register" runat="server" required="true" />
    <asp:Label ID="lblAvatar" runat="server" Text="Veuillez choisir un avatar : "></asp:Label><asp:FileUpload ID="avatar" runat="server" class="register"/>
    <asp:Button class="btn btn-primary register" ID="btnFinishRegister" runat="server" Text="Register" OnClick="btnFinishRegister_Click"/>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
   
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="Veuillez entrer un nom d'utilisateur." ControlToValidate="txtUsername" />
    <asp:RequiredFieldValidator ID="validatorEmail" runat="server" Text="Veuillez entrer une adresse courriel." ControlToValidate="txtRegEmail" />
    <asp:RequiredFieldValidator ID="validatorPassword" runat="server" Text="Veuillez entrer un mot de passe." ControlToValidate="txtRegPassword" />
</asp:Content>

