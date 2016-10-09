<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PagRegistroSolicitud.aspx.cs" Inherits="DeninsonLirianoPrimerParcial.RegistroMaterial.PagRegistroSolicitud" %>

<script runat="server">

    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ID<asp:TextBox ID="idTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="buscarButton" runat="server" OnClick="buscarButton_Click" Text="Buscar" />
    <p>
        RAZON<asp:TextBox ID="razonTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FECHA:<asp:TextBox ID="fechaTextBox" runat="server"></asp:TextBox>
    </p>
    MATERIAL<asp:DropDownList ID="materialDropDownList" runat="server" Height="16px" Width="130px">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;CANTIDAD<asp:TextBox ID="cantidadTextBox" runat="server" style="margin-bottom: 2px"></asp:TextBox>
    Precio<asp:TextBox ID="precioTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="Agregar" runat="server" Text="Agregar" OnClick="Agregar_Click" style="margin-left: 17px" />
    &nbsp;Total:<asp:TextBox ID="TotalTextBox" runat="server"></asp:TextBox>
&nbsp;<p>
        <asp:GridView ID="MaterialGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Material" DataField="Material" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="nuevoButton" runat="server" OnClick="nuevoButton_Click" Text="NUEVO" />
        <asp:Button ID="guardarButton" runat="server" OnClick="guardarButton_Click" style="margin-left: 78px; width: 96px;" Text="GUARDAR" />
        <asp:Button ID="eliminarButton" runat="server" style="margin-left: 87px" Text="ELIMINAR" OnClick="eliminarButton_Click" />
    </p>
</asp:Content>
