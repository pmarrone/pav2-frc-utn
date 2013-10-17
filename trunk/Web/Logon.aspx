<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Web.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <div>
                <fieldset>
                    <legend>Account Information</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server">Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                       
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                      
                    </p>
                    <p>
                        
                        <asp:Label ID="lblerror" runat="server" BackColor="White" ForeColor="Red"></asp:Label>
                        
                    </p>
                </fieldset>
                <p >
                    <asp:Button ID="btnValidar" runat="server" Text="Validar" />
                </p>
            </div>
</asp:Content>
