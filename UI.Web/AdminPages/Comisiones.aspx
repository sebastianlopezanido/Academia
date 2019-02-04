<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <center><asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridComisiones" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowDataBound="gridComisiones_RowDataBound" EmptyDataText="No hay comisiones disponibles">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="IDPlan" HeaderText="Plan" />
                <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año esp." />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" >
                <ControlStyle Font-Bold="True" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White"/>
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            
            <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
            <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar"
                OnClientClick="return confirm('¿Seguro que desea eliminar la comision?')"/>
            <br />
             <br />
            <table dir="ltr">
                <tr> 
                    <td colspan="2" style="color: #FF0000">
                        <asp:Label ID="lblError1" runat="server" Visible="False"></asp:Label>
                    </td></table>

            </asp:Panel>
        </asp:Panel>        
            <asp:Panel ID="formPanel" runat="server" Visible="False">
                <table dir="ltr">
                <tr>
                    <td dir="rtl">
                        <asp:Label ID="Label6" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" ReadOnly="True"></asp:TextBox>
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
                        <asp:Label ID="Label9" runat="server" Text="Año"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAño" runat="server"></asp:TextBox>
                    </td>                    
                </tr>
                <tr>
                    <td dir="rtl">
                        <asp:Label ID="lblClave" runat="server" Text="Plan"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cbxPlan" runat="server" Height="26px" style="margin-bottom: 5px">
                        </asp:DropDownList>
                    </td>                    
                </tr>
                    </table>
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
                
            </asp:Panel>
        
    </center>
</asp:Content>