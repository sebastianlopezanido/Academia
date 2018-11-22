<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <center><asp:Panel ID="gridPanel" runat="server" Height="161px">
        <asp:GridView ID="gridCursos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridCursos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="IDMateria" HeaderText="Materia" />
                <asp:BoundField DataField="IDComision" HeaderText="Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
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
            <br />
            <asp:Panel ID="formPanel" runat="server" style="margin-top: 0px" Visible="False">
                <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Materia"></asp:Label>
                <asp:TextBox ID="txtMateria" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Comision"></asp:Label>
                <asp:DropDownList ID="cbxComision" runat="server">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Año"></asp:Label>
                <asp:TextBox ID="txtAño" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label5" runat="server" Text="Cupo"></asp:Label>
                <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                <br />
                <br />
                <asp:Label ID="lblError" runat="server" BorderColor="Red" Font-Bold="True" Text="Label" Visible="False"></asp:Label>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel></center>
</asp:Content>
