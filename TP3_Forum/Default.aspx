<%@ Page Title="First page" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TP3_Forum.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <form id="form2" runat="server">
        <asp:Label ID="test" runat="server"></asp:Label>
        <div id="container" runat="server"></div>
    </form>
</asp:Content>