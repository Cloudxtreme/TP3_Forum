<%@ Page Language="C#" Title="Panneau d'administration" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="TP3_Forum.Administration" MasterPageFile="~/TP3.Master"%>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <h2>Panneau d'administration</h2>
    <asp:GridView runat="server" AutoGenerateColumns="False" DataKeyNames="Pseudo" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField DataField="Pseudo" HeaderText="Pseudo" ReadOnly="True" SortExpression="Pseudo"></asp:BoundField>
            <asp:BoundField DataField="Courriel" HeaderText="Courriel" SortExpression="Courriel"></asp:BoundField>
            <asp:CheckBoxField DataField="Utilisateur" HeaderText="Utilisateur" SortExpression="Utilisateur"></asp:CheckBoxField>
            <asp:CheckBoxField DataField="Administrateur" HeaderText="Administrateur" SortExpression="Administrateur"></asp:CheckBoxField>
            <asp:CheckBoxField DataField="Moderateur" HeaderText="Moderateur" SortExpression="Moderateur"></asp:CheckBoxField>
            <asp:CheckBoxField DataField="Banni" HeaderText="Banni" SortExpression="Banni"></asp:CheckBoxField>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:GeneralDatabase %>' ProviderName='<%$ ConnectionStrings:GeneralDatabase.ProviderName %>' SelectCommand="SELECT [Pseudo], [Courriel], [Utilisateur], [Administrateur], [Moderateur], [Banni] FROM [Utilisateurs]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Utilisateurs] WHERE [Pseudo] = ? AND (([Courriel] = ?) OR ([Courriel] IS NULL AND ? IS NULL)) AND [Utilisateur] = ? AND [Administrateur] = ? AND [Moderateur] = ? AND [Banni] = ?" InsertCommand="INSERT INTO [Utilisateurs] ([Pseudo], [Courriel], [Utilisateur], [Administrateur], [Moderateur], [Banni]) VALUES (?, ?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Utilisateurs] SET [Courriel] = ?, [Utilisateur] = ?, [Administrateur] = ?, [Moderateur] = ?, [Banni] = ? WHERE [Pseudo] = ? AND (([Courriel] = ?) OR ([Courriel] IS NULL AND ? IS NULL)) AND [Utilisateur] = ? AND [Administrateur] = ? AND [Moderateur] = ? AND [Banni] = ?">
        <DeleteParameters>
            <asp:Parameter Name="original_Pseudo" Type="String"></asp:Parameter>
            <asp:Parameter Name="original_Courriel" Type="String"></asp:Parameter>
            <asp:Parameter Name="original_Courriel" Type="String"></asp:Parameter>
            <asp:Parameter Name="original_Utilisateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="original_Administrateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="original_Moderateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="original_Banni" Type="Boolean"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Pseudo" Type="String"></asp:Parameter>
            <asp:Parameter Name="Courriel" Type="String"></asp:Parameter>
            <asp:Parameter Name="Utilisateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="Administrateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="Moderateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="Banni" Type="Boolean"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Courriel" Type="String"></asp:Parameter>
            <asp:Parameter Name="Utilisateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="Administrateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="Moderateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="Banni" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="original_Pseudo" Type="String"></asp:Parameter>
            <asp:Parameter Name="original_Courriel" Type="String"></asp:Parameter>
            <asp:Parameter Name="original_Courriel" Type="String"></asp:Parameter>
            <asp:Parameter Name="original_Utilisateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="original_Administrateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="original_Moderateur" Type="Boolean"></asp:Parameter>
            <asp:Parameter Name="original_Banni" Type="Boolean"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>