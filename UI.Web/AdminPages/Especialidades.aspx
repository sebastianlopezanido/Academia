﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">

     <center> <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridEspecialidades" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
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
            <br />
        </asp:Panel>
</asp:Content>
