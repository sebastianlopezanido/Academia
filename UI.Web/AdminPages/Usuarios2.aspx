<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Usuarios2.aspx.cs" Inherits="UI.Web.AdminPages.Usuarios2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=TP2_NETEntities1" DefaultContainerName="TP2_NETEntities1" EnableFlattening="False" EntitySetName="usuarios" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
    </asp:EntityDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_usuario" DataSourceID="EntityDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="id_usuario" HeaderText="id_usuario" ReadOnly="True" SortExpression="id_usuario" />
            <asp:BoundField DataField="nombre_usuario" HeaderText="nombre_usuario" SortExpression="nombre_usuario" />
            <asp:CheckBoxField DataField="habilitado" HeaderText="habilitado" SortExpression="habilitado" />
            <asp:BoundField DataField="tipo_usuario" HeaderText="tipo_usuario" SortExpression="tipo_usuario" />
            <asp:BoundField DataField="id_persona" HeaderText="id_persona" SortExpression="id_persona" />
            <asp:BoundField DataField="id_plan" HeaderText="id_plan" SortExpression="id_plan" />
        </Columns>
    </asp:GridView>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="id_usuario" DataSourceID="EntityDataSource1" DefaultMode="Insert">
        <EditItemTemplate>
            id_usuario:
            <asp:Label ID="id_usuarioLabel1" runat="server" Text='<%# Eval("id_usuario") %>' />
            <br />
            nombre_usuario:
            <asp:TextBox ID="nombre_usuarioTextBox" runat="server" Text='<%# Bind("nombre_usuario") %>' />
            <br />
            clave:
            <asp:TextBox ID="claveTextBox" runat="server" Text='<%# Bind("clave") %>' />
            <br />
            habilitado:
            <asp:CheckBox ID="habilitadoCheckBox" runat="server" Checked='<%# Bind("habilitado") %>' />
            <br />
            tipo_usuario:
            <asp:TextBox ID="tipo_usuarioTextBox" runat="server" Text='<%# Bind("tipo_usuario") %>' />
            <br />
            cambia_clave:
            <asp:CheckBox ID="cambia_claveCheckBox" runat="server" Checked='<%# Bind("cambia_clave") %>' />
            <br />
            id_persona:
            <asp:TextBox ID="id_personaTextBox" runat="server" Text='<%# Bind("id_persona") %>' />
            <br />
            id_plan:
            <asp:TextBox ID="id_planTextBox" runat="server" Text='<%# Bind("id_plan") %>' />
            <br />
            modulos_usuarios:
            <asp:TextBox ID="modulos_usuariosTextBox" runat="server" Text='<%# Bind("modulos_usuarios") %>' />
            <br />
            persona:
            <asp:TextBox ID="personaTextBox" runat="server" Text='<%# Bind("persona") %>' />
            <br />
            plane:
            <asp:TextBox ID="planeTextBox" runat="server" Text='<%# Bind("plane") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            id_usuario:
            <asp:TextBox ID="id_usuarioTextBox" runat="server" Text='<%# Bind("id_usuario") %>' />
            <br />
            nombre_usuario:
            <asp:TextBox ID="nombre_usuarioTextBox" runat="server" Text='<%# Bind("nombre_usuario") %>' />
            <br />
            clave:
            <asp:TextBox ID="claveTextBox" runat="server" Text='<%# Bind("clave") %>' />
            <br />
            habilitado:
            <asp:CheckBox ID="habilitadoCheckBox" runat="server" Checked='<%# Bind("habilitado") %>' />
            <br />
            tipo_usuario:
            <asp:TextBox ID="tipo_usuarioTextBox" runat="server" Text='<%# Bind("tipo_usuario") %>' />
            <br />
            cambia_clave:
            <asp:CheckBox ID="cambia_claveCheckBox" runat="server" Checked='<%# Bind("cambia_clave") %>' />
            <br />
            id_persona:
            <asp:TextBox ID="id_personaTextBox" runat="server" Text='<%# Bind("id_persona") %>' />
            <br />
            id_plan:
            <asp:TextBox ID="id_planTextBox" runat="server" Text='<%# Bind("id_plan") %>' />
            <br />
            
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            id_usuario:
            <asp:Label ID="id_usuarioLabel" runat="server" Text='<%# Eval("id_usuario") %>' />
            <br />
            nombre_usuario:
            <asp:Label ID="nombre_usuarioLabel" runat="server" Text='<%# Bind("nombre_usuario") %>' />
            <br />
            clave:
            <asp:Label ID="claveLabel" runat="server" Text='<%# Bind("clave") %>' />
            <br />
            habilitado:
            <asp:CheckBox ID="habilitadoCheckBox" runat="server" Checked='<%# Bind("habilitado") %>' Enabled="false" />
            <br />
            tipo_usuario:
            <asp:Label ID="tipo_usuarioLabel" runat="server" Text='<%# Bind("tipo_usuario") %>' />
            <br />
            cambia_clave:
            <asp:CheckBox ID="cambia_claveCheckBox" runat="server" Checked='<%# Bind("cambia_clave") %>' Enabled="false" />
            <br />
            id_persona:
            <asp:Label ID="id_personaLabel" runat="server" Text='<%# Bind("id_persona") %>' />
            <br />
            id_plan:
            <asp:Label ID="id_planLabel" runat="server" Text='<%# Bind("id_plan") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
