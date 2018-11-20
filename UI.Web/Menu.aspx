<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="UI.Web.Menu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div aria-orientation="vertical">
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem NavigateUrl="~/Usuarios.aspx" Text="Usuarios" Value="Usuarios"></asp:MenuItem>
                    <asp:MenuItem Text="Personas" Value="Personas"></asp:MenuItem>
                    <asp:MenuItem Text="Especialidades" Value="Especialidades"></asp:MenuItem>
                    <asp:MenuItem Text="Planes" Value="Planes"></asp:MenuItem>
                    <asp:MenuItem Text="Materias" Value="Materias"></asp:MenuItem>
                    <asp:MenuItem Text="Comisiones" Value="Comisiones"></asp:MenuItem>
                    <asp:MenuItem Text="Cursos" Value="Cursos"></asp:MenuItem>
                </Items>
                
            </asp:Menu>
            <asp:Button ID="Button1" runat="server" PostBackUrl="~/Login.aspx" Text="Cerrar Sesión" />
        </div>
</asp:Content>
