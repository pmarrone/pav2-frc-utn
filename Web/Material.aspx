<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Material.aspx.cs" Inherits="Web.WebForm2" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    


        <asp:Panel ID="pnlCrear" runat="server" 
            CssClass="form-horizontal col-lg-12 container" role="form" Visible="False">
            
            <div class="form-group" runat="server" id="divIdMaterial">
                <label class="col-lg-2 control-label">
                    <asp:Label ID="lblIdMaterial" runat="server" Text="Id."></asp:Label>
                </label>
                
                <div class="col-lg-5">    
                    <asp:Label ID="showIdMaterial" runat="server" CssClass="form-control">                    
                    </asp:Label>                        
                </div>                
            </div>
            <div class="form-group">
                <label for="txtDenominacion" class="col-lg-2 control-label">
                    <asp:Label ID="lblDenominacion" runat="server" Text="Denominacion"></asp:Label>
                </label>
                
                <div class="col-lg-5">    
                        <asp:TextBox ID="txtDenominacion" runat="server" ClientIDMode="Static" 
                            CssClass="form-control " ValidationGroup="crear">
                            </asp:TextBox> 
                        <asp:Label ID="showDenominacion" CssClass="form-control" runat="server"></asp:Label>
                </div>
                
                <asp:RequiredFieldValidator ID="rfdDenominacion" runat="server" 
                    ControlToValidate="txtDenominacion" 
                    Display="Dynamic" CssClass="col-lg-4 form-control-static text-danger" 
                    ValidationGroup="crear">
                    Este campo es obligatorio                      
                </asp:RequiredFieldValidator> 
            </div>
            
            <div class="form-group">
                <label for="txtCaracteristicas" class="col-lg-2 control-label">
                    <asp:Label ID="lblCaracteristicas" runat="server" Text="Características"></asp:Label>
                </label>
                <div class="col-lg-5">
                    <asp:TextBox ID="txtCaracteristicas" runat="server" TextMode="MultiLine" 
                        ClientIDMode="Static" CssClass="form-control "></asp:TextBox>
                    <asp:Label ID="showCaracteristicas" CssClass="form-control" runat="server"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="rfdCaracteristicas" runat="server" 
                    ControlToValidate="txtCaracteristicas" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    ValidationGroup="crear">
                    Este campo es obligatorio   
                </asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="ddlUnidadMedida" class="col-lg-2 control-label">
                    <asp:Label ID="lblUnidadMedida" runat="server" Text="U. de Medida"></asp:Label>
                </label>
                <div class="col-lg-5">
                     <asp:DropDownList ID="ddlUnidadMedida" runat="server" ClientIDMode="Static" 
                         CssClass="form-control "></asp:DropDownList>
                    <asp:Label ID="showUnidadMedida" CssClass="form-control" runat="server"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="rfdUnidadMedida" runat="server" 
                    ControlToValidate="ddlUnidadMedida" 
                    ErrorMessage="El campo Unidad de Medida es obligatorio" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    ValidationGroup="crear">
                        Este campo es obligatorio 
                </asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="txtStockReal" class="col-lg-2 control-label">
                    <asp:Label ID="lblStockReal" runat="server" Text="Stock"></asp:Label>
                </label>
                <div class="col-lg-5">
                     <asp:TextBox ID="txtStockReal" runat="server" ClientIDMode="Static" 
                         CssClass="form-control "></asp:TextBox>
                    <asp:Label ID="showStockReal" CssClass="form-control" runat="server"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="rfdStockReal" runat="server" 
                    ControlToValidate="txtStockReal" 
                    ErrorMessage="El campo Unidad de Medida es obligatorio" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    ValidationGroup="crear">
                        Este campo es obligatorio 
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpStockReal" runat="server" 
                    CssClass="col-lg-4 form-control-static text-danger" Operator="DataTypeCheck" 
                    Type="Double" ControlToValidate="txtStockReal" Display="Dynamic" 
                    ValidationGroup="crear">
                    El valor ingresado debe ser un número
                </asp:CompareValidator>
            </div>
            
            <div class="form-group">
                <label for="txtStockMinimo" class="col-lg-2 control-label">
                    <asp:Label ID="lblStockMinimo" runat="server" Text="Stock Mínimo"></asp:Label>
                </label>
                <div class="col-lg-5">
                     <asp:TextBox ID="txtStockMinimo" runat="server" ClientIDMode="Static" 
                         CssClass="form-control "></asp:TextBox>
                    <asp:Label ID="showStockMinimo" CssClass="form-control" runat="server"></asp:Label>
                </div>
                <asp:RequiredFieldValidator ID="rfdStockMinimo" runat="server" 
                    ControlToValidate="txtStockMinimo" 
                    ErrorMessage="El campo Unidad de Medida es obligatorio" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    ValidationGroup="crear">
                        Este campo es obligatorio 
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpStockMinimo" runat="server" 
                    ControlToValidate="txtStockMinimo" 
                    CssClass="col-lg-4 form-control-static text-danger" Display="Dynamic" 
                    Operator="DataTypeCheck" Type="Double" ValidationGroup="crear">
                    El valor ingresado debe ser un número
                </asp:CompareValidator>
            </div>

            <div class="form-group">  
                <div class="col-lg-offset-3 col-lg-9">
                    
                </div>
            </div>
        
        </asp:Panel>
        <div class="form-horizontal col-lg-12 container" role="form" id="pnlBotonCrear" runat="server">
            <div class="form-group">
                <div class="col-lg-9">
                    <asp:Button ID="btnNuevo" CssClass="btn btn-primary" runat="server" 
                        Text="Nuevo Material" onclick="btnNuevo_Click" CausesValidation="False"/>                        
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
