<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegistroMateriales.aspx.cs" Inherits="DeninsonLirianoPrimerParcial.RegistroMaterial.RegistroMateriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ID<asp:TextBox ID="idmTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="bmButton" runat="server" OnClick="bmButton_Click" Text="BUSCAR" />
    <p>
        DESCRIPCION<asp:TextBox ID="descripcionTextBox" runat="server" Width="171px"></asp:TextBox>
    </p>
    <p>
        PRECIO<asp:TextBox ID="precioMaTextBox" runat="server" style="margin-left: 47px" Width="176px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="nmButton" runat="server" OnClick="nmButton_Click" Text="NUEVO" />
        <asp:Button ID="gmButton" runat="server" OnClick="gmButton_Click" style="margin-left: 59px" Text="GUARDAR" />
        <asp:Button ID="eliminarButton" runat="server" OnClick="eliminarButton_Click" style="margin-left: 67px" Text="ELIMINAR" />
    </p>
</asp:Content>
