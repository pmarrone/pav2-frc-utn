<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="Web.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function ValidNum(e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;

            return (tecla <= 13 || (tecla >= 48 && tecla <= 57));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        ADMINISTRACION DE EMPLEADOS</h2>
    <div class="accountInfo">
        <fieldset class="register">
            <legend>Información de Cuenta</legend>
            <table border="0">
                <tr>
                    <td>
                        <p>
                            <asp:Label ID="UserNameLabel" runat="server">*Nombre:</asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" Width="150px" border="1px solid #ccc"
                                MaxLength="12">hernan</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtNombre"
                                ErrorMessage="El campo &quot;Nombre&quot; es requerido" ForeColor="Red" CssClass="failureNotification"
                                Display="Dynamic" ToolTip="El campo &quot;Nombre&quot; es requerido" ValidationGroup="EmpleadoGuardar"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="EmailLabel" runat="server">*Apellido:</asp:Label>
                            <asp:TextBox ID="txtApellido" runat="server" Width="150px" border="1px solid #ccc"
                                MaxLength="12">moreno</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtApellido"
                                ErrorMessage="El campo &quot;Apellido&quot; es requerido" ForeColor="Red" Display="Dynamic"
                                ToolTip="El campo &quot;Apellido&quot; es requerido" ValidationGroup="EmpleadoGuardar"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="PasswordLabel" runat="server">*Nro Doc.:</asp:Label>
                            <asp:TextBox ID="txtDni" runat="server" Width="150px" border="1px solid #ccc" MaxLength="8">28417801</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtDni" ErrorMessage="El campo &quot;Nro Doc&quot; es requerido"
                                ForeColor="Red" Display="Dynamic" ToolTip="El campo &quot;Nro Doc&quot; es requerido"
                                ValidationGroup="EmpleadoGuardar" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="ConfirmPasswordLabel" runat="server">Fec. Nac.:</asp:Label>
                            <asp:TextBox ID="txtFechaNac" runat="server" Width="150px" border="1px solid #ccc"
                                MaxLength="10">05/09/1980</asp:TextBox>                            
                            <asp:Label ID="Label9" runat="server" Text="dd/mm/aaaa"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="Label1" runat="server">*Legajo:</asp:Label>
                            <asp:TextBox ID="txtLegajo" runat="server" Width="150px" border="1px solid #ccc">42480</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txtLegajo"
                                ErrorMessage="El campo &quot;Legajo&quot; es requerido" ForeColor="Red" Display="Dynamic"
                                ToolTip="El campo &quot;Legajo&quot; es requerido" ValidationGroup="EmpleadoGuardar"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </p>
                    </td>
                    <td>
                        <p>
                            <asp:Label ID="Label2" runat="server">*Fec. Alta:</asp:Label>
                            <asp:TextBox ID="txtFechaAlta" runat="server" Width="150px" border="1px solid #ccc"
                                MaxLength="10">03/10/2011</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="txtFechaAlta"
                                ErrorMessage="El campo &quot;Fec. Alta&quot; es requerido" ForeColor="Red" ToolTip="El campo &quot;Fec. Alta&quot; es requerido"
                                ValidationGroup="EmpleadoGuardar" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:Label ID="Label7" runat="server" Text="dd/mm/aaaa"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="Label3" runat="server">Fec. Baja:</asp:Label>
                            <asp:TextBox ID="txtFechaBaja" runat="server" Width="150px" border="1px solid #ccc"
                                MaxLength="10">23/10/2013</asp:TextBox>
                            <asp:Label ID="Label8" runat="server" Text="dd/mm/aaaa"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="Label4" runat="server">*Rol:</asp:Label>
                            <asp:DropDownList ID="ddlRol" runat="server" Width="150px" border="2px solid #ccc">
                            </asp:DropDownList>
                        </p>
                        <p>
                            <asp:Label ID="Label5" runat="server">*Usuario:</asp:Label>
                            <asp:TextBox ID="txtUsuario" runat="server" Width="150px" border="1px solid #ccc"
                                MaxLength="10">Cover.hm</asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="txtUsuario"
                                ErrorMessage="El campo &quot;Usuario&quot; es requerido" ForeColor="Red" ToolTip="El campo &quot;Usuario&quot; es requerido"
                                ValidationGroup="EmpleadoGuardar" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="Label6" runat="server">*Password:</asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv7" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="El campo &quot;Pasword&quot; es requerido" ForeColor="Red" ToolTip="El campo &quot;Pasword&quot; es requerido"
                                ValidationGroup="EmpleadoGuardar" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </p>
                    </td>
                </tr>
            </table>
            <asp:Label ID="Label10" runat="server" Text="*Indica campo obligatorio."></asp:Label>
             
             
        </fieldset>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
            ForeColor="Red" ValidationGroup="EmpleadoGuardar" HeaderText="Por favor corriga los siguientes errores:" />
        <p>
       
            <asp:Button ID="btnNuevo" runat="server" CommandName="MoveNext" Text="Nuevo" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnCancelar" runat="server" CommandName="MoveNext" Text="Cancelar"
                OnClick="btnCancelar_Click" />
            
            <asp:Button ID="btnBuscar" runat="server" CommandName="MoveNext" Text="Buscar" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnGuardar" runat="server" CommandName="MoveNext" Text="Guardar"
                OnClick="btnGuardar_Click" ValidationGroup="EmpleadoGuardar" />
              
        </p>
          <asp:CheckBox ID="chkHabilitarBusqueda" runat="server" Text="" 
            oncheckedchanged="chkHabilitarBusqueda_CheckedChanged" 
            AutoPostBack="True" />
             <asp:Label ID="Label11" runat="server" 
            Text="Habilitar búsqueda (Apellido, Nombre, DNI y/o Legajo)."></asp:Label>
    </div>
    <asp:HiddenField ID="hdfOperacion" runat="server" />
    <asp:GridView ID="gvEmpleados" AutoGenerateColumns="False" runat="server" 
        CellPadding="4" ForeColor="#333333" DataKeyNames="FechaBaja,hashed_password"  
        GridLines="None" OnRowCommand="gvEmpleados_RowCommand" 
        onrowdeleting="gvEmpleados_RowDeleting">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
       <Columns>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="dni" HeaderText="DNI" />
            <asp:BoundField DataField="FechaNac" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Nacimiento" />
            <asp:BoundField DataField="legajo" HeaderText="Legajo" />
            <asp:BoundField DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Alta" />
            <asp:BoundField DataField="FechaBaja" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Baja"
                Visible="False" />
            <asp:BoundField DataField="nombreUser" HeaderText="Usuario" />
            <asp:BoundField DataField="id_rol" HeaderText="id_rol" Visible="False" />
            <asp:BoundField DataField="descripcion" HeaderText="Rol" />
            <asp:BoundField DataField="hashed_password" HeaderText="Password" 
                Visible="False" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Modificar" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
