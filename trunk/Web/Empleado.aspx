<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Empleado.aspx.cs" Inherits="Web.WebForm2" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    


        <asp:Panel ID="pnlCrear" runat="server" 
            CssClass="form-horizontal col-lg-12 container" role="form" Visible="False">
            
            <div class="form-group" runat="server" id="divId">
                <label for="txtLegajo" class="col-lg-2 control-label">
                    <asp:Label ID="lblLegajo" runat="server" Text="Legajo:"></asp:Label>
                </label>
                <asp:TextBox ID="txtLegajo" runat="server" ClientIDMode="Static" 
                            CssClass="form-control " ValidationGroup="crear">
                </asp:TextBox> 
                <div class="col-lg-5">    
                    <asp:Label ID="showLegajo" runat="server" CssClass="form-control">                    
                    </asp:Label>                        
                </div>                
            </div>
            <div class="form-group">
                <label for="txtNombre" class="col-lg-2 control-label">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                </label>
                
                <div class="col-lg-5">    
                    <asp:TextBox ID="txtNombre" runat="server" ClientIDMode="Static" 
                        CssClass="form-control " ValidationGroup="crear">
                        </asp:TextBox> 
                    <asp:Label ID="lblDenominacion" CssClass="form-control" runat="server"></asp:Label>
                </div>
                
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                    ControlToValidate="txtNombre" 
                    Display="Dynamic" CssClass="col-lg-4 form-control-static text-danger" 
                    ValidationGroup="crear">
                    Este campo es obligatorio                      
                </asp:RequiredFieldValidator> 

            </div>
            
            <div class="form-group">
                <label for="txtApellido" class="col-lg-2 control-label">
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                </label>
                <div class="col-lg-5">
                    <asp:TextBox ID="txtApellido" runat="server" 
                        ClientIDMode="Static" CssClass="form-control "></asp:TextBox>
                    <asp:Label ID="showApellido" CssClass="form-control" runat="server"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server" 
                    ControlToValidate="txtApellido" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    ValidationGroup="crear">
                    Este campo es obligatorio   
                </asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="ddlRol" class="col-lg-2 control-label">
                    <asp:Label ID="lblRol" runat="server" Text="Rol"></asp:Label>
                </label>
                <div class="col-lg-5">
                     <asp:DropDownList ID="ddlRol" runat="server" ClientIDMode="Static" 
                         CssClass="form-control "></asp:DropDownList>
                    <asp:Label ID="showRol" CssClass="form-control" runat="server"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="rfvRol" runat="server" 
                    ControlToValidate="ddlRol" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    ValidationGroup="crear">
                        Este campo es obligatorio 
                </asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="txtDNI" class="col-lg-2 control-label">
                    <asp:Label ID="lblDNI" runat="server" Text="Stock"></asp:Label>
                </label>
                <div class="col-lg-5">
                     <asp:TextBox ID="txtDNI" runat="server" ClientIDMode="Static" 
                         CssClass="form-control "></asp:TextBox>
                    <asp:Label ID="showDNI" CssClass="form-control" runat="server"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="rfvDNI" runat="server" 
                    ControlToValidate="txtDNI" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    ValidationGroup="crear">
                        Este campo es obligatorio 
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpDNI" runat="server" 
                    CssClass="col-lg-4 form-control-static text-danger" Operator="DataTypeCheck" 
                    Type="Double" ControlToValidate="txtDNI" Display="Dynamic" 
                    ValidationGroup="crear">
                    El valor ingresado debe ser un número
                </asp:CompareValidator>
            </div>
            
            <div class="form-group">
                <label for="txtFechaIngreso" class="col-lg-2 control-label">
                    <asp:Label ID="lblFechaIngreso" runat="server" Text="Fecha de Ingreso"></asp:Label>
                </label>
                <div class="col-lg-5">
                     <asp:TextBox ID="txtFechaIngreso" runat="server" ClientIDMode="Static" 
                         CssClass="form-control "></asp:TextBox>
                    <asp:Label ID="showFechaIngreso" CssClass="form-control" runat="server"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="rfvFechaIngreso" runat="server" 
                    ControlToValidate="txtFechaIngreso" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    ValidationGroup="crear">
                        Este campo es obligatorio 
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpFechaIngreso" runat="server" 
                    ControlToValidate="txtFechaIngreso" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    Operator="DataTypeCheck" Type="DateTime" ValidationGroup="crear">
                    El valor ingresado debe ser un número
                </asp:CompareValidator>
            </div>

        
        </asp:Panel>
        <div class="form-horizontal col-lg-12 container" role="form" id="pnlBotonCrear" runat="server">
            <div class="form-group">
                <div class="col-lg-9">
                    <asp:Button ID="btnNuevo" CssClass="btn btn-primary" runat="server" 
                        Text="Nuevo Empleado" onclick="btnNuevo_Click" CausesValidation="False"/>                        
                    <asp:Button ID="btnCrear" CssClass="btn btn-primary" runat="server" 
                        Text="Crear" onclick="btnCrear_Click" ValidationGroup="crear" 
                        Visible="False" />
                    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" 
                        Text="Guardar" onclick="btnGuardar_Click" Visible="False" 
                        ValidationGroup="crear"/>
                    <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" 
                        Text="Editar" Visible="False" onclick="btnEditar_Click" />                      
                    <asp:Button ID="btnEliminar" CssClass="btn btn-default" runat="server" 
                        Text="Eliminar" onclick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de eliminar el material?')" Visible="False" />
                    <asp:Button ID="btnCancelar" CssClass="btn btn-default" runat="server" 
                        Text="Cancelar" onclick="btnCancelar_Click" Visible="False" />
                    <asp:Button ID="btnCerrar" CssClass="btn btn-default" runat="server" 
                        Text="Cerrar" Visible="False" onclick="btnCancelar_Click" />
                    
                </div>
            </div>
        </div>
        <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title">Filtros</h3>
              </div>
            <div class="panel-body">
            <div class="form-horizontal col-lg-12">
                <div class="form-group">
                    
                    <label for="txtNombreFiltro" class="col-lg-1 control-label">
                        Nombre: 
                    </label> 
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtNombreFiltro" CssClass="form-control" runat="server" 
                            ValidationGroup="filtros"></asp:TextBox>
                    </div>   
                    <div class="col-lg-1">
                        <asp:Button ID="btnFiltrar" CssClass="btn btn-default" runat="server" 
                            Text="Filtrar" onclick="btnFiltrar_Click" ValidationGroup="filtros" />
                    </div>
                    <div class="col-lg-2">
                     <asp:Button ID="btnLimpiarFiltros" CssClass="btn btn-default" runat="server" 
                            Text="Limpiar filtros" onclick="btnLimpiarFiltros_Click" 
                            ValidationGroup="filtros" />
                    </div>
                    
                   
                </div>
                <div class="form-group">
                    <asp:RadioButtonList ID="rblStockFiltro" runat="server" 
                    RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="todos" class="radio-inline" Selected="True">Todos</asp:ListItem>
                    <asp:ListItem Value="sinStock" class="radio-inline">Sin stock</asp:ListItem>
                    <asp:ListItem Value="conStock" class="radio-inline">Con stock</asp:ListItem>
                    <asp:ListItem Value="sobreMinimo" class="radio-inline">Sobre el mímimo</asp:ListItem>
                    <asp:ListItem Value="debajoMinimo" class="radio-inline">Debajo minimo</asp:ListItem>
                </asp:RadioButtonList>
            
                </div>
            </div>
            
                

            </div>
        </div>
            

        <asp:GridView ID="gvMateriales" runat="server" AutoGenerateColumns="False" 
            CssClass="table table-hover table-striped" BorderStyle="None" GridLines="None">
            <Columns>
                <asp:BoundField DataField="Denominacion" HeaderText="Nombre" />
                <asp:BoundField DataField="StockMinString" HeaderText="Stock Min." />
                <asp:BoundField DataField="StockRealString" HeaderText="Stock" />
                <asp:BoundField DataField="StockAsign" HeaderText="Stock Asignado" />
                <asp:TemplateField>
                    <ItemTemplate>                        
                        <asp:LinkButton ID="viewButton" CssClass="glyphicon glyphicon-search" runat="server"
                            CommandArgument='<%# Eval("IdMaterial") %>' CausesValidation="False"
                            OnCommand="viewButton_Command"></asp:LinkButton>
                        <asp:LinkButton ID="editButton" CssClass="glyphicon glyphicon-pencil" runat="server"
                            CommandArgument='<%# Eval("IdMaterial") %>' CausesValidation="False"
                            OnCommand="editButton_Command"></asp:LinkButton>
                        <asp:LinkButton ID="deleteButton" CssClass="glyphicon glyphicon-remove" runat="server"
                            CommandArgument='<%# Eval("IdMaterial") %>' CausesValidation="False" OnClientClick="return confirm('¿Está seguro de eliminar el material?')"
                            OnCommand="deleteButton_Command"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>
