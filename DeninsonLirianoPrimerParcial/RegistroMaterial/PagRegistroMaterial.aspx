<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PagRegistroMaterial.aspx.cs" Inherits="DeninsonLirianoPrimerParcial.RegistroMaterial.PagRegistroMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ID<asp:TextBox ID="idTextBox" runat="server"></asp:TextBox>
    <p>
        RAZON<asp:TextBox ID="razonTextBox" runat="server"></asp:TextBox>
    </p>
    MATERIAL<asp:TextBox ID="materialTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CANTIDAD<asp:TextBox ID="cantidadTextBox" runat="server" style="margin-bottom: 2px"></asp:TextBox>
    <asp:Button ID="Agregar" runat="server" Text="Agregar" />
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="nuevoButton" runat="server" Text="NUEVO" />
        <asp:Button ID="guardarButton" runat="server" style="margin-left: 78px" Text="GUARDAR" />
        <asp:Button ID="eliminarButton" runat="server" style="margin-left: 87px" Text="ELIMINAR" />
    </p>
</asp:Content>
