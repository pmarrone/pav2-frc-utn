<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1 {
            width: 100%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Clientes:<br />
        <br />
        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="gv1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="IdCliente" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="NumeroDocumento" HeaderText="Nro Dcto" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" 
                    DataFormatString="{0:d}" />
                <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:PAVUTN %>" 
            SelectCommand="SELECT * FROM [Clientes]"></asp:SqlDataSource>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td valign="middle">
                    Nombre: 
                    <asp:TextBox ID="txtNombre" runat="server" Width="162px"></asp:TextBox>
                </td>
                <td valign="middle">
                    Nro Dcto:
                    <asp:TextBox ID="txtDcto" runat="server" Width="143px"></asp:TextBox>
                </td>
                <td valign="middle">
                    FecNacimiento: 
                    <asp:TextBox ID="txtFecNac" runat="server"></asp:TextBox>
                </td>
                <td valign="middle">
                    Sexo:
                    <asp:RadioButton ID="rbFem" runat="server" Text="Femenino" />
                    <asp:RadioButton ID="rbMas" runat="server" Text="Masculino" />
                </td>
            </tr>
            </table>
        <br />
        <asp:Button ID="butAgregar" runat="server" onclick="butAgregar_Click" 
            Text="Agregar" />&nbsp;
        <asp:Button ID="butConsultar" runat="server" onclick="butConsultar_Click" 
            Text="Consultar" />&nbsp;
        <asp:Button ID="butEliminar" runat="server" Text="Eliminar" 
            onclick="butEliminar_Click" />&nbsp;
        <asp:Button ID="butEditar" runat="server" Text="Editar" 
            onclick="butEditar_Click" />
        &nbsp;<br />
        <br />&nbsp;<br />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="#CC0000"></asp:Label>
    </div>
    </form>
</body>
</html>

