<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <center><asp:Panel ID="gridPanel" runat="server" Height="155px" HorizontalAlign="Center">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="IDPlan" HeaderText="Plan" />
                <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año esp." />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
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
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
            <br />
            <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
            <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            <asp:Panel ID="formPanel" runat="server">
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="txtID" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="ID Plan"></asp:Label>
                <asp:DropDownList ID="cbxPlan" runat="server">
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Año especialidad"></asp:Label>
                <asp:TextBox ID="txtAño" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
            </asp:Panel>
        </asp:Panel>
    </asp:Panel></center>
</asp:Content>