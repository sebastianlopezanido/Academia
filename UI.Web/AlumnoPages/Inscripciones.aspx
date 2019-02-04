<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <center><asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="gridCursos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridCursos_SelectedIndexChanged" OnRowDataBound="gridCursos_RowDataBound" EmptyDataText="No hay cursos disponibles">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="IDMateria" HeaderText="Materia" />
                <asp:BoundField DataField="IDComision" HeaderText="Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True">
                <ControlStyle Font-Bold="True" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <table dir="ltr">                
                <tr> 
                    <td colspan="2" style="color: #FF0000">
                        <asp:Label ID="lblInfo" runat="server" Text="La inscripcion fue exitosa" Visible="False"></asp:Label>
                    </td>
                </tr>                
                    </table>               
        <br />
        <br />
        <asp:Button ID="btnSalir" runat="server" OnClick="btnSalir_Click" Text="Salir" />
    </asp:Panel></center>
</asp:Content>
