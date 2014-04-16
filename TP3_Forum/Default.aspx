<%@ Page Title="First page" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TP3_Forum.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <asp:Label ID="test" runat="server"></asp:Label>
    <div id="container" runat="server"></div>
    <div id="post" class="register" runat="server">
        <h4>Postez un nouveau Message : </h4>
        <textarea id="txtMessage" runat="server" class="form-control" rows="3"></textarea>
        <asp:Button ID="btnSubmit" runat="server" Text="Envoyer" class="btn btn-success" OnClick="btnNouveauMessage_Click"/>
    </div>
</asp:Content>