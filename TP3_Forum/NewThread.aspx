<%@ Page Language="C#" MasterPageFile="~/TP3.Master" AutoEventWireup="true" CodeBehind="NewThread.aspx.cs" Inherits="TP3_Forum.NewThread" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <h2>Création d'un nouveau sujet</h2>
    <div class="jumbotron">
        <div class="container" id="newThreadVerify" runat="server">
            <asp:TextBox class="form-control" ID="txtTitle" runat="server" placeholder="Titre"></asp:TextBox><br />
            <textarea id="txtMessage" runat="server" class="form-control" rows="3"></textarea>
            <div class="col-md-1 col-md-offset-10">
                <button type="submit" class="btn btn-primary">Soumettre</button>
            </div>
        </div>
    </div>
</asp:Content>

