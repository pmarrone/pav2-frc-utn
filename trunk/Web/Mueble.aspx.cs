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
    public partial class MueblePage : System.Web.UI.Page
    {
        protected bool FormEditable
        {
            set
            {
                ddlTipoMueble.Visible = value;
                txtCaracteristicas.Visible = value;
                txtNombre.Visible = value;
                txtPrecio.Visible = value;

                showTipoMueble.Visible = !value;
                showNombre.Visible = !value;
                showCaracteristicas.Visible = !value;
                showPrecio.Visible = !value;
                
            }
        }

        protected void CargarFormulario(Mueble mueble)
        {
            showId.Text = "" + mueble.IdMueble;

            txtNombre.Text = mueble.Denominacion;
            showNombre.Text = mueble.Denominacion;

            txtCaracteristicas.Text = mueble.Caracteristicas;
            showCaracteristicas.Text = mueble.Caracteristicas;

            txtPrecio.Text =  (mueble.PrecioVta != null ? mueble.PrecioVta.ToString() : null);
            showPrecio.Text = (mueble.PrecioVta != null ? mueble.PrecioVta.ToString() : null);


            ddlTipoMueble.SelectedValue = (mueble.IdTipoMueble == null ? null : mueble.IdTipoMueble.IdTipoMueble.ToString());
            showTipoMueble.Text = (mueble.IdTipoMueble == null ? null : mueble.IdTipoMueble.Descrip);  
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMueblesGridData();

                List<TipoMueble> tiposMueble = TipoMuebleDAO.GetAll();
                ddlTipoMueble.DataTextField = "Descrip";
                ddlTipoMueble.DataValueField = "IdTipoMueble";
                ddlTipoMueble.DataSource = tiposMueble;
                ddlTipoMueble.DataBind();
            }
        }

        private void LoadMueblesGridData()
        {
            String nombreFiltro = txtNombreFiltro.Text;
            String stockFiltro = rblStockFiltro.SelectedValue;
            List<Mueble> muebles = MuebleDAO.GetAll();
            gvMuebles.DataSource = muebles;
            gvMuebles.DataKeyNames = new String[] { "IdMueble" };
            gvMuebles.DataBind();
        }


        protected void deleteButton_Command(object sender, CommandEventArgs e)
        {
            int idMueble;
            int.TryParse((string)e.CommandArgument, out idMueble);
            MuebleDAO.Delete(idMueble);
            LoadMueblesGridData();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Mueble mueble = ExtractFormData();
            int? id = MuebleDAO.Insert(mueble);
            Mueble muebleDB = MuebleDAO.GetById(id.Value);

            LoadMueblesGridData();
            ViewMueble(muebleDB);
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
            CargarFormulario(new Mueble());
        }

        protected void editButton_Command(object sender, CommandEventArgs e)
        {
            int idMueble;
            int.TryParse((string)e.CommandArgument, out idMueble);
            ViewState["IdMueble"] = idMueble;
            Mueble mueble = MuebleDAO.GetById(idMueble);
            CargarFormulario(mueble);
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
            int idMueble;
            int.TryParse((string)e.CommandArgument, out idMueble);
            ViewState["IdMueble"] = idMueble;
            Mueble muebleDB = MuebleDAO.GetById(idMueble);
            ViewMueble(muebleDB);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Mueble mueble = ExtractFormData();
            MuebleDAO.Update(mueble);
            Mueble muebleDB = MuebleDAO.GetById(mueble.IdMueble);

            LoadMueblesGridData();
            

            ViewMueble(muebleDB);

        }

        private void ViewMueble(Mueble mueble)
        {
            FormEditable = false;
            CargarFormulario(mueble);
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

        private Mueble ExtractFormData()
        {
            int? idMueble = (int?)ViewState["IdMueble"];
            Mueble mueble = new Mueble();
            mueble.IdMueble = idMueble;
            mueble.Denominacion = txtNombre.Text;
            mueble.Caracteristicas = txtCaracteristicas.Text;
            decimal precio;
            decimal.TryParse(txtPrecio.Text, out precio);
            mueble.PrecioVta = precio;

            TipoMueble tipoMueble = new TipoMueble();
            int idTipoMueble;
            int.TryParse(ddlTipoMueble.SelectedValue, out idTipoMueble);
            tipoMueble.IdTipoMueble = idTipoMueble;
            mueble.IdTipoMueble = tipoMueble;
            return mueble;
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
            int idMueble = (int)ViewState["IdMueble"];
            MuebleDAO.Delete(idMueble);
            btnCancelar_Click(sender, e);
            LoadMueblesGridData();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            LoadMueblesGridData();
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtNombreFiltro.Text = null;
            rblStockFiltro.SelectedValue = "todos";
            LoadMueblesGridData();
        }
    }
}