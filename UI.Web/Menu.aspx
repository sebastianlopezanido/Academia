<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="UI.Web.Menu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div aria-orientation="vertical">
            
            <asp:Button ID="Button1" runat="server" PostBackUrl="~/Login.aspx" Text="Cerrar Sesión" />
        </div>
</asp:Content>
