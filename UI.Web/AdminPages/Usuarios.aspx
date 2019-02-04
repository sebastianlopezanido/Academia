<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <center><asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridUsuarios" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gridView_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" Visible="False" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:BoundField DataField="IDPersona" HeaderText="Legajo" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo Usuario" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" >
                <ControlStyle Font-Bold="True" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
            <asp:Panel ID="Panel1" runat="server">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Seguro que desea eliminar curso?')"/>
            </asp:Panel>
            <br />
            <br />
            <table dir="ltr">
                <tr> 
                    <td colspan="2" style="color: #FF0000">
                        <asp:Label ID="lblError1" runat="server"></asp:Label>
                    </td></table>
    </asp:Panel> </center>
        <asp:Panel ID="formPanel" runat="server" Height="265px" Visible="False">
            <center><table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Usuario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="ID Persona"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIdPersona" runat="server" ReadOnly="True" Width="19px"></asp:TextBox>
                        <asp:TextBox ID="txtApellido" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td style="height: 26px">
                        <asp:Button ID="btnPersona" runat="server" OnClick="btnPersona_Click" Text="..." />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="IDPlan"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPlan" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCClave" runat="server" Text="Confirmar Clave"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmarClave" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="ckbHabilitado" runat="server" Text="Habilitado" TextAlign="Left" />
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Tipo Usuario"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipo" runat="server">
                            <asp:ListItem Value="0">Alumno</asp:ListItem>
                            <asp:ListItem Value="1">Profesor</asp:ListItem>
                            <asp:ListItem Value="2">Admin</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr> </table>
                <br />
                <table dir="ltr">
                <tr>
                    <td dir="rtl">                
                        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                    </td>
                    <tr><td></td></tr>
                <tr> 
                    <td colspan="2" style="color: #FF0000">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>                
                    </table>
           </center>
        </asp:Panel>
</asp:Content>
