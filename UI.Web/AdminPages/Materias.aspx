<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <center><asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridMaterias" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gridView_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Hs Semanales" DataField="HSSemanales" />
                <asp:BoundField DataField="HSTotales" HeaderText="Hs Totales" />
                <asp:BoundField DataField="IDPlan" HeaderText="Plan" />
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
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </asp:Panel>           
            <br />
            <table dir="ltr">
                <tr> 
                    <td colspan="2" style="color: #FF0000">
                        <asp:Label ID="lblError1" runat="server" Visible="False"></asp:Label>
                    </td></table>
    </asp:Panel> </center>
        <asp:Panel ID="formPanel" runat="server" Height="265px" Visible="False">
            <center><table dir="ltr">
                <tr>
                    <td dir="rtl">
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td dir="rtl" style="height: 26px">
                        <asp:Label ID="Label8" runat="server" Text="Descripción"></asp:Label>
                    </td>
                    <td style="height: 26px">
                        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td dir="rtl">
                        <asp:Label ID="Label2" runat="server" Text="Hs Semanales"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHsSemanales" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td dir="rtl">
                        <asp:Label ID="Label3" runat="server" Text="Hs Totales"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHsTotales" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td dir="rtl">
                        <asp:Label ID="lblClave" runat="server" Text="Plan"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPlan" runat="server">
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                </table><br />
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
