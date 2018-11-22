<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CursosProfesor.aspx.cs" Inherits="UI.Web.CursosProfesor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <center><asp:Panel ID="gridPanel" runat="server" Height="161px">
        <asp:GridView ID="gridCursos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridCursos_SelectedIndexChanged" OnRowDataBound="gridCursos_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="IDCurso" HeaderText="Materia" />
                <asp:BoundField DataField="IDCurso" HeaderText="Comision" />
                <asp:BoundField DataField="IDCurso" HeaderText="Año" />
                <asp:CommandField SelectText="Ver" ShowSelectButton="True" >
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
        <asp:GridView ID="GridAlumnos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnRowDataBound="GridAlumnos_RowDataBound" OnSelectedIndexChanged="gridAlumnos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="IDAlumno" HeaderText="Legajo" />
                <asp:BoundField DataField="IDAlumno" HeaderText="Nombre" />
                <asp:BoundField DataField="IDAlumno" HeaderText="Apellido" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:CommandField SelectText="Editar" ShowSelectButton="True">
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
            <asp:Button ID="btnSalir" runat="server" OnClick="btnSalir_Click" Text="Salir" Visible="False" />

        <asp:Panel ID="Panel2" runat="server" Height="289px">
            
            <br />
            <br />
            <br />
            <asp:Panel ID="formPanel" runat="server" Height="256px" style="margin-top: 0px" Visible="False">
                <table dir="ltr">
                    <tr>
                        <td dir="rtl">Nombre</td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td dir="rtl" style="height: 26px">Apellido</td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtApellido" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td dir="rtl">Nota</td>
                        <td>
                            <asp:TextBox ID="txtNota" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td dir="rtl">Condición</td>
                        <td>
                            <asp:DropDownList ID="ddlCondicion" runat="server">
                                <asp:ListItem>Indefinida</asp:ListItem>
                                <asp:ListItem>Libre</asp:ListItem>
                                <asp:ListItem>Regular</asp:ListItem>
                                <asp:ListItem>Promovido</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table dir="ltr">
                    <tr>
                        <td dir="rtl">
                            <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                        </td>
                        <tr>
                            <td></td>
                        </tr>
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
