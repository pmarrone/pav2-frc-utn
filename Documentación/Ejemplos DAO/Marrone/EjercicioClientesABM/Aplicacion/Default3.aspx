<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script language="vbscript">

   Sub ClientValidate(source, arguments)
            
      If (arguments.Value mod 2) = 0 Then
         arguments.IsValid =true
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
    
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ErrorMessage="CustomValidator"></asp:CustomValidator>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="Campo1" ValidationGroup="AA"></asp:RequiredFieldValidator>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox2" ErrorMessage="Campo2" ValidationGroup="AA"></asp:RequiredFieldValidator>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="TextBox3" ErrorMessage="Campo3" ValidationGroup="BB"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" ValidationGroup="AA" />
        <asp:Button ID="Button2" runat="server" Text="Button" ValidationGroup="BB" />
    
        <br />
        <br />
    
        <asp:TextBox ID="TextBox4" runat="server" 
            ValidationGroup="BB"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator2" runat="server" 
            ClientValidationFunction="ClientValidate" ControlToValidate="TextBox4" 
            ErrorMessage="No es Par" 
            onservervalidate="CustomValidator_ServerValidate" ValidationGroup="BB"></asp:CustomValidator>
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Button" />
        <br />
    
    </div>
    </form>
</body>
</html>
