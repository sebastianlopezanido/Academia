<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <center><asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridPlanes" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gridView_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="IDEspecialidad" HeaderText="Especialidad" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True">
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
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"
                    OnClientClick="return confirm('¿Seguro que desea eliminar el plan?')"/>
                <br />
                <asp:Button ID="btnReporte" runat="server" OnClick="btnReporte_Click" Text="Imprimir" />
            </asp:Panel>

            <br />
            <br />
            <table dir="ltr">
                <tr> 
                    <td colspan="2" style="color: #FF0000">
                        <asp:Label ID="lblError1" runat="server" Visible="False"></asp:Label>
                    </td></table>
    </asp:Panel> 
    <asp:Panel ID="formPanel" runat="server" Height="265px" Visible="False">
        <br />
        
            <table dir="ltr" style="width: 80px; height: 100px">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                    </td>
                    <td style="width: 128px">
                        <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Descripción"></asp:Label>
                    </td>
                    <td style="width: 128px">
                        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Especialidad"></asp:Label>
                    </td>
                    <td style="width: 128px">
                        <asp:DropDownList ID="ddlEsp" runat="server">
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
    </asp:Panel>
    <asp:Panel ID="reportPanel" runat="server" Visible="False">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" BorderStyle="None" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" ShowBackButton="False" ShowFindControls="False" ShowZoomControl="False" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="6.6in">
            <LocalReport ReportPath="AdminPages\Planes_Report.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        <br />
        <asp:Button ID="btnVolver_Reporte" runat="server" OnClick="btnVolver_Reporte_Click" Text="Volver" />
    </asp:Panel>
    </center>
</asp:Content>
