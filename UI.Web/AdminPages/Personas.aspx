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
            <br />
            <asp:Label ID="lblError1" runat="server"></asp:Label>
        </asp:Panel>
        <br />
    </asp:Panel>
 </center>
    <asp:Panel ID="formPanel" runat="server" Height="265px" Visible="False">
            <br />
            <center>
                <table dir="ltr">
                    <tr>
                        <td dir="rtl" style="height: 26px">
                            <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                        </td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td dir="rtl" style="height: 26px">
                            <asp:Label ID="Label8" runat="server" Text="Apellido"></asp:Label>
                        </td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td dir="rtl">
                            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td dir="rtl">
                            <asp:Label ID="Label3" runat="server" Text="Direccion"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td dir="rtl">
                            <asp:Label ID="lblClave" runat="server" Text="Telefono"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td dir="rtl">
                            <asp:Label ID="lblCClave" runat="server" Text="Fecha Nacimiento"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaNac" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td dir="rtl">
                            <asp:Label ID="Label7" runat="server" Text="Legajo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td dir="rtl">
                            <asp:Label ID="Label9" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td dir="rtl">
                            <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                            <asp:CompareValidator Runat="Server" ControlToValidate="txtFechaNac" Display="Dynamic" Operator="DataTypeCheck" Text="Error, fecha incorrecta" Type="Date" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <br />
        </asp:Panel>
    
</asp:Content>
