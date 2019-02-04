<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Cursado.aspx.cs" Inherits="UI.Web.Cursado" %>
<asp:Content ID="ContentCursado" ContentPlaceHolderID="Contenido" runat="server">
    <center> <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridInscripciones" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gridView_RowDataBound" EmptyDataText="No se encuentra inscripto a ningún curso">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="IDCurso" HeaderText="Materia" AccessibleHeaderText="Materia" />
                <asp:BoundField DataField="IDCurso" HeaderText="Comision" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
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
        <br />
        <table dir="ltr">
                <tr> 
                    <td colspan="2" style="color: #FF0000">
                        <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
                    </td></table>
    </asp:Panel>
 </center>
    </asp:Content>
