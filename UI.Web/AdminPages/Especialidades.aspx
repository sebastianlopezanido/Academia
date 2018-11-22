<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">

     <center> <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
         <asp:Panel ID="Panel1" runat="server">
             <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
             <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
             <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
             <br />
             <asp:Label ID="lblError1" runat="server"></asp:Label>
         </asp:Panel>
        <br />
    </asp:Panel>
 </center>
    <asp:Panel ID="formPanel" runat="server" Height="265px" Visible="False">
            <br />
            <br />
            <center><table dir="ltr">
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
                        <asp:Label ID="Label8" runat="server" Text="Descripcion"></asp:Label>
                    </td>
                    <td style="height: 26px">
                        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
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
                    </td>
                </tr>
            </table></center>
            <br />
        </asp:Panel>
</asp:Content>
