<%@ Page Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="NewThread.aspx.cs" Inherits="TP3_Forum.NewThread" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <h2>Création d'un nouveau sujet</h2>
    <div class="jumbotron">
        <div class="container" id="newThreadVerify" runat="server">
            <asp:TextBox class="form-control" ID="txtTitle" runat="server" placeholder="Titre" required="true"></asp:TextBox><br />
            <textarea id="txtMessage" runat="server" class="form-control" rows="3" required="true"></textarea>
            <div class="col-md-1 col-md-offset-10">
                <asp:Button class="btn btn-primary" ID="btnCreate" runat="server" Text="Soumettre" OnClick="btnCreate_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

