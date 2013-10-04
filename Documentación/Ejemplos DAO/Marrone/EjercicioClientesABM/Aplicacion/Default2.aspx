<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Ingrese su nombre:"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" 
            ontextchanged="txtNombre_TextChanged"></asp:TextBox>
        <asp:Button ID="butSaludar" runat="server" onclick="butSaludar_Click" 
            Text="Saludar" />
        <input id="butHTML" type="button" value="Saludar" runat="server" /><br />
        <asp:Label ID="lblSaludo" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
