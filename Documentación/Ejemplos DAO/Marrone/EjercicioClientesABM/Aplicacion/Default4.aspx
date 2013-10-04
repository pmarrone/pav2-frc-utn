<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script language="vbscript">

   Sub ClienteValida(source, arguments)
            
      If (arguments.Value mod 2) = 0 Then
         arguments.IsValid=true
      Else
         arguments.IsValid=false
      End If

   End Sub
</script>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="No es un mail valido" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ControlToValidate="TextBox2" ErrorMessage="El nro no es PAR" 
            onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox3" 
            ValidationGroup="AA"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="TextBox5" ErrorMessage="RequiredFieldValidator" 
            ValidationGroup="AA"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox4" 
            ValidationGroup="BB"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Button" ValidationGroup="AA" />
        <asp:Button ID="Button3" runat="server" Text="Button" ValidationGroup="BB" />
        <br />
        <br />
        Cantidad de usuarios logueados:
        <asp:TextBox ID="TextBox6" runat="server" ontextchanged="TextBox6_TextChanged" 
            ReadOnly="True"></asp:TextBox>
        <br />
        Nombre del cliente:
        <asp:TextBox ID="TextBox7" runat="server" ontextchanged="TextBox7_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
