<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <center><asp:Panel ID="gridPanel" runat="server" Height="161px">
        <asp:GridView ID="gridCursos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridCursos_SelectedIndexChanged" OnRowDataBound="gridCursos_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="IDMateria" HeaderText="Materia" />
                <asp:BoundField DataField="IDComision" HeaderText="Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                <asp:BoundField DataField="ID" HeaderText="Profesor" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" >
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
        <asp:Panel ID="Panel2" runat="server" Height="37px">
            <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
            <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            <br />
            <br />
            <table dir="ltr">
                <tr> 
                    <td colspan="2" style="color: #FF0000">
                        <asp:Label ID="lblError1" runat="server" Visible="False"></asp:Label>
                    </td></table>
            <asp:Panel ID="formPanel" runat="server" style="margin-top: 0px" Visible="False" Height="256px">
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
                        <asp:Label ID="Label8" runat="server" Text="Materia"></asp:Label>
                    </td>
                    <td style="height: 26px">
                        <asp:TextBox ID="txtMateria" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 26px">
                        <asp:Button ID="btnMateria" runat="server" OnClick="btnMateria_Click" Text="..." />
                    </td>
                    
                </tr>
                    <tr>
                    <td dir="rtl" style="height: 26px">
                        <asp:Label ID="Label1" runat="server" Text="Profesor"></asp:Label>
                    </td>
                    <td style="height: 26px">
                        <asp:TextBox ID="txtProfesor" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 26px">
                        <asp:Button ID="btnProfesor" runat="server" OnClick="btnProfesor_Click" Text="..." />
                    </td>
                    
                </tr>
                <tr>
                    <td dir="rtl">
                        <asp:Label ID="Label7" runat="server" Text="Cupo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
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
                        <asp:Label ID="lblClave" runat="server" Text="Comision"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cbxComision" runat="server">
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
                </tr> 
                    <tr> 
                    <td colspan="2" style="color: #FF0000">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr> 
                </table>  
                             
            </asp:Panel>
        </asp:Panel>
    </asp:Panel></center>
</asp:Content>
