using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatriaFabricaMuebles.Entidades;
using PatriaFabricaMuebles.DAO;

namespace Web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected bool FormEditable
        {
            set
            {
                ddlUnidadMedida.Visible = value;
                txtCaracteristicas.Visible = value;
                txtDenominacion.Visible = value;
                txtStockMinimo.Visible = value;
                txtStockReal.Visible = value;

                showUnidadMedida.Visible = !value;
                showDenominacion.Visible = !value;
                showCaracteristicas.Visible = !value;
                showStockMinimo.Visible = !value;
                showStockReal.Visible = !value;
                
            }
        }

        protected void CargarFormulario(Material material)
        {
            showIdMaterial.Text = "" + material.IdMaterial;

            txtDenominacion.Text = material.Denominacion;
            showDenominacion.Text = material.Denominacion;

            txtCaracteristicas.Text = material.Caracteristicas;
            showCaracteristicas.Text = material.Caracteristicas;

            txtStockMinimo.Text =  (material.StockMin != null ? material.StockMin.ToString() : null);
            showStockMinimo.Text = (material.StockMin != null ? material.StockMin.ToString() : null);

            txtStockReal.Text = (material.StockReal != null ? material.StockReal.ToString() : null);
            showStockReal.Text = (material.StockReal != null ? material.StockReal.ToString() : null);

            ddlUnidadMedida.SelectedValue = (material.UdMedida == null ? null : material.UdMedida.UdMedida.ToString());
            showUnidadMedida.Text = (material.UdMedida == null ? null : material.UdMedida.Nombre);  
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMaterialesGridData();

                List<UnidadMedida> medidas = UnidadMedidaDAO.GetAll();
                ddlUnidadMedida.DataTextField = "Nombre";
                ddlUnidadMedida.DataValueField = "UdMedida";
                ddlUnidadMedida.DataSource = medidas;
                ddlUnidadMedida.DataBind();
            }
        }

        private void LoadMaterialesGridData()
        {
            List<Material> materiales = MaterialDAO.GetAll();

            gvMateriales.DataSource = materiales;
            gvMateriales.DataKeyNames = new String[] { "idMaterial" };
            gvMateriales.DataBind();
        }


        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            int idMaterial; 
            int.TryParse((string)e.CommandArgument, out idMaterial);
            MaterialDAO.Delete(idMaterial);
            LoadMaterialesGridData();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Material material = ExtractFormData();
            int? id = MaterialDAO.Insert(material);
            Material materialDB = MaterialDAO.GetById(id.Value);

            LoadMaterialesGridData();
            ViewMaterial(materialDB);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            FormEditable = false;
            MostrarOpcionesCreacion(true);
        }

        private void MostrarOpcionesCreacion(bool mostrar)
        {
            pnlCrear.Visible = mostrar;
            divIdMaterial.Visible = false;
            FormEditable = true;

            btnCancelar.Visible = true;
            btnCerrar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnGuardar.Visible = false;
            btnCrear.Visible = true;
            btnNuevo.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();    
            pnlCrear.Visible = false;
            btnCancelar.Visible = false;
            btnCerrar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnGuardar.Visible = false;
            btnCrear.Visible = false;
            btnNuevo.Visible = true;
        }

        private void LimpiarFormulario()
        {
            CargarFormulario(new Material());
        }

        protected void editButton_Command(object sender, CommandEventArgs e)
        {
            int idMaterial;
            int.TryParse((string)e.CommandArgument, out idMaterial);
            ViewState["idMaterial"] = idMaterial;
            Material material = MaterialDAO.GetById(idMaterial);
            CargarFormulario(material);
            FormEditable = true;

            pnlCrear.Visible = true;

            divIdMaterial.Visible = true;
            btnCancelar.Visible = true;
            btnCerrar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = true;
            btnGuardar.Visible = true;
            btnCrear.Visible = false;
            btnNuevo.Visible = false;
        }

        protected void viewButton_Command(object sender, CommandEventArgs e)
        {
            int idMaterial;
            int.TryParse((string)e.CommandArgument, out idMaterial);
            ViewState["idMaterial"] = idMaterial;
            Material materialDB = MaterialDAO.GetById(idMaterial);
            ViewMaterial(materialDB);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Material material = ExtractFormData();
            MaterialDAO.Update(material);
            Material materialDB = MaterialDAO.GetById(material);

            LoadMaterialesGridData();
            

            ViewMaterial(materialDB);

        }

        private void ViewMaterial(Material material)
        {
            FormEditable = false;
            CargarFormulario(material);
            pnlCrear.Visible = true;
            divIdMaterial.Visible = true;
            btnCancelar.Visible = false;
            btnCerrar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnGuardar.Visible = false;
            btnCrear.Visible = false;
            btnNuevo.Visible = false;
        }

        private Material ExtractFormData()
        {
            int? idMaterial = (int?)ViewState["idMaterial"];
            Material material = new Material();
            material.IdMaterial = idMaterial;
            material.Denominacion = txtDenominacion.Text;
            material.Caracteristicas = txtCaracteristicas.Text;
            decimal stockMinimo;
            decimal.TryParse(txtStockMinimo.Text, out stockMinimo);
            material.StockMin = stockMinimo;
            decimal stockReal;
            decimal.TryParse(txtStockReal.Text, out stockReal);
            material.StockReal = stockReal;
            material.StockAsign = 0;
            UnidadMedida unidad = new UnidadMedida();
            int idMedida;
            int.TryParse(ddlUnidadMedida.SelectedValue, out idMedida);
            unidad.UdMedida = idMedida;
            material.UdMedida = unidad;
            return material;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            FormEditable = true;
            divIdMaterial.Visible = true;
            btnCancelar.Visible = true;
            btnCerrar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = true;
            btnGuardar.Visible = true;
            btnCrear.Visible = false;
            btnNuevo.Visible = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMaterial = (int)ViewState["idMaterial"];
            MaterialDAO.Delete(idMaterial);
            btnCancelar_Click(sender, e);
            LoadMaterialesGridData();
        }
    }
}