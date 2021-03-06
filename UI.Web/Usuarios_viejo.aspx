﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios_viejo.aspx.cs" Inherits="UI.Web.Usuarios_viejo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:BoundField DataField="IDPersona" HeaderText="ID Persona" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo Usuario" />
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
        <asp:Panel ID="formPanel" runat="server" Height="265px" Visible="False">
            <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="ID Persona"></asp:Label>
            <asp:TextBox ID="txtIdPersona" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="IDPlan"></asp:Label>
            <asp:TextBox ID="txtIdPlan" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
            <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCClave" runat="server" Text="Confirmar Clave"></asp:Label>
            <asp:TextBox ID="txtConfirmarClave" runat="server"></asp:TextBox>
            <br />
            <asp:CheckBox ID="ckbHabilitado" runat="server" Text="Habilitado" />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Tipo Usuario"></asp:Label>
            <asp:DropDownList ID="cbxTipo" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </asp:Panel>
    </form>
    


</body>
</html>
