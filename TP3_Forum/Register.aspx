﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TP3_Forum.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
                <asp:TextBox ID="txtUsername" placeholder="Username" class="form-control" runat="server" />
                <asp:TextBox ID="txtEmail" placeholder="Email" class="form-control" runat="server"/>
                <asp:TextBox ID="txtPassword" type="password" placeholder="Password" class="form-control" runat="server" />
</asp:Content>
