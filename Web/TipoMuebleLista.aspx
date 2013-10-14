<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoMuebleLista.aspx.cs" Inherits="Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="form-horizontal">
    <label class="control-label" for="txtTipoMueble">Tipo Mueble</label>
    <asp:TextBox ID="txtTipoMueble" runat="server" CssClass="input-sm" 
        placeholder="Tipo de Mueble" ClientIDMode="Static"></asp:TextBox>
</div>
</asp:Content>
