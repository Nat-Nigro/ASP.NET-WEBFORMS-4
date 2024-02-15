<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Libri._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:Label ID="Label1" runat="server" Text="Collezione Libri">
            <br />
            <div id="Libri" runat="server"></div>
            
        </asp:Label>
    </main>

</asp:Content>
