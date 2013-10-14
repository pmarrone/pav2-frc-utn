<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Material.aspx.cs" Inherits="Web.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvMateriales" runat="server" AutoGenerateColumns="False" 
                onrowdeleting="gvMateriales_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Denominacion" HeaderText="Nombre" />
                <asp:BoundField DataField="StockMinString" HeaderText="Stock Min." />
                <asp:BoundField DataField="StockRealString" HeaderText="Stock" />
                <asp:BoundField DataField="StockAsign" HeaderText="Stock Asignado" />
                <asp:CommandField CancelText="" 
                    DeleteText="&lt;span class=&quot;glyphicon glyphicon-remove&quot;&gt;&lt;/span&gt;" 
                    EditText="&lt;span class=&quot;glyphicon glyphicon-pencil&quot;&gt;&lt;/span&gt;" 
                    SelectText="&lt;span class=&quot;glyphicon glyphicon-search&quot;&gt;&lt;/span&gt;" 
                    ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            </Columns>
            </asp:GridView>
           
        </ContentTemplate>


    </asp:UpdatePanel>
     <!-- Modal -->
            <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">Eliminar material</h4>
                            </div>
                            <div class="modal-body">
                                ¿Seguro desea eliminar este material?
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Confirmar" 
                                    CssClass="btn btn-primary" onclick="btnConfirmarEliminar_Click"/>
                            </div>        
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div><!-- /.modal-content -->
            </div><!-- /.modal-dialog -->
            </div><!-- /.modal -->

      
</asp:Content>
