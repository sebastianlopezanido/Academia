<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.AdminPages.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    
 <center> <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </asp:Panel>
        <br />
    </asp:Panel>
 </center>
    <asp:Panel ID="formPanel" runat="server" Height="265px" Visible="False">
            <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Direccion"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblClave" runat="server" Text="Telefono"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCClave" runat="server" Text="Fecha Nacimiento"></asp:Label>
            <asp:TextBox ID="txtFechaNac" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Legajo"></asp:Label>
            <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </asp:Panel>
    
</asp:Content>
