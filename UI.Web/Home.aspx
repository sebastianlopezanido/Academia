<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div aria-orientation="vertical">
            
            <asp:Button ID="Button1" runat="server" Text="Cerrar Sesión" OnClick="Button1_Click" />
            <asp:Label ID="lblUsuario" runat="server" Text="Label"></asp:Label>
        </div>
</asp:Content>
