using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatriaFabricaMuebles.DAO;
using PatriaFabricaMuebles.Entidades;
using System.Data;

namespace Web
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        enum Operacion
        {
            None,
            Insert,
            Update
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtDni.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            txtLegajo.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");

            if (!IsPostBack)
            {
                InicializarFormulario();
                CargarGrilla();
                //DesabilitarCampos();
                CargarRoles();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Empleado oEmpleado = new Empleado();
            oEmpleado.Apellido = txtApellido.Text;
            oEmpleado.Nombre = txtNombre.Text;
            oEmpleado.Dni = Convert.ToInt64(txtDni.Text);
            oEmpleado.FechaAlta = Convert.ToDateTime(txtFechaAlta.Text.Trim());
            oEmpleado.FechaBaja = txtFechaBaja.Text.Trim() != String.Empty ? Convert.ToDateTime(txtFechaBaja.Text.Trim()) : (DateTime?)null;
            oEmpleado.FechaNac = txtFechaNac.Text.Trim() != String.Empty ? Convert.ToDateTime(txtFechaNac.Text.Trim()) : (DateTime?)null;
            oEmpleado.Legajo = Convert.ToInt64(txtLegajo.Text);

            Usuario oUsuario = new Usuario();
            oUsuario.Id_rol = Convert.ToInt32(ddlRol.SelectedItem.Value);
            oUsuario.Legajo = Convert.ToInt64(txtLegajo.Text);
            oUsuario.Id_usuario = txtUsuario.Text;
            oUsuario.Hashed_password = txtPassword.Text;
            oUsuario.Id_cliente = null;

            if (Page.IsValid)
            {
                if (hdfOperacion.Value == Operacion.Insert.ToString())
                {
                    Insert(oEmpleado, oUsuario);
                }
                if (hdfOperacion.Value == Operacion.Update.ToString())
                {
                    Updadte(oEmpleado, oUsuario);
                }
                hdfOperacion.Value = Operacion.None.ToString();
                CargarGrilla();
                ClickGuardar();
            }

        }

        private void Insert(Empleado oEmpleado, Usuario oUsuario)
        {
            EmpleadoDAO.Insert(oEmpleado);
            UsuarioDAO.Insert(oUsuario);
        }

        private void Updadte(Empleado oEmpleado, Usuario oUsuario)
        {
            UsuarioDAO.Update(oUsuario);
            EmpleadoDAO.Update(oEmpleado);
        }

        private List<Empleado> GetAllEmpleados()
        {
            return EmpleadoDAO.GetAll();
        }

        private DataSet GetAllEmpleados2()
        {
            return EmpleadoDAO.GetAllwithUserAndRol();
        }

        private List<Rol> GetAllRoles()
        {
            return RolDAO.GetAll();
        }

        private void CargarGrilla()
        {

            gvEmpleados.DataSource = GetAllEmpleados2();//GetAllEmpleados();
            gvEmpleados.DataBind();
        }

        public void CargarRoles()
        {
            ddlRol.DataSource = GetAllRoles();
            ddlRol.DataTextField = "descripcion";
            ddlRol.DataValueField = "id_rol";
            ddlRol.DataBind();
            ddlRol.SelectedIndex = -1;
            //ddlRol.Items.Insert(0, "-seleccione-");
        }

        protected void gvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // get the row index stored in the CommandArgument property
            int index = Convert.ToInt32(e.CommandArgument);

            // get the GridViewRow where the command is raised
            GridViewRow selectedRow = ((GridView)e.CommandSource).Rows[index];

            if (e.CommandName == "Select")
            {
                // for bound fields, values are stored in the Text property of Cells [ fieldIndex ]
                txtNombre.Text = selectedRow.Cells[0].Text;
                txtApellido.Text = selectedRow.Cells[1].Text;
                txtDni.Text = selectedRow.Cells[2].Text;
                txtFechaNac.Text = Server.HtmlDecode(selectedRow.Cells[3].Text);
                txtLegajo.Text = selectedRow.Cells[4].Text;
                txtFechaAlta.Text = Server.HtmlDecode(selectedRow.Cells[5].Text);
                txtFechaBaja.Text = Server.HtmlDecode(selectedRow.Cells[6].Text);
                txtUsuario.Text = Server.HtmlDecode(selectedRow.Cells[7].Text);
                txtFechaBaja.Text = String.Format("{0:dd/MM/yyyy}", gvEmpleados.DataKeys[index]["FechaBaja"]);
                txtPassword.Text = gvEmpleados.DataKeys[index]["hashed_password"].ToString();
                DataSet ds = EmpleadoDAO.GetRolEmpleado(txtUsuario.Text);

                ddlRol.SelectedValue = ds.Tables[0].Rows[0]["id_rol"].ToString();
                ClickModificar();
            }
            if (e.CommandName == "Delete")
            {
                int legajo = Convert.ToInt32(selectedRow.Cells[4].Text);
                Empleado oEmpleado = new Empleado();
                oEmpleado.Legajo = legajo;
                //Le paso el id_usuario
                UsuarioDAO.Delete(selectedRow.Cells[7].Text);
                EmpleadoDAO.Delete(oEmpleado);
                CargarGrilla();
            }

        }
        private void InicializarFormulario()
        {
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void ClickModificar()
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            hdfOperacion.Value = Operacion.Update.ToString();
            HabilitarCampos();
            txtNombre.Focus();
            txtLegajo.Enabled = false;
            txtUsuario.Enabled = false;
        }
        private void ClickGuardar()
        {
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
            hdfOperacion.Value = Operacion.None.ToString();
            DesabilitarCampos();
            LimpiarCampos();
            chkHabilitarBusqueda.Checked = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            InicializarFormulario();
            CargarGrilla();
            LimpiarCampos();
            DesabilitarCampos();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //LimpiarCampos();
            txtNombre.Focus();
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
            HabilitarCampos();
            hdfOperacion.Value = Operacion.Insert.ToString();
        }

        private void HabilitarCampos()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDni.Enabled = true;
            txtFechaNac.Enabled = true;
            txtLegajo.Enabled = true;
            txtFechaAlta.Enabled = true;
            txtFechaBaja.Enabled = true;
            txtUsuario.Enabled = true;
            ddlRol.Enabled = true;
            txtPassword.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDni.Enabled = false;
            txtFechaNac.Enabled = false;
            txtLegajo.Enabled = false;
            txtFechaAlta.Enabled = false;
            txtFechaBaja.Enabled = false;
            txtUsuario.Enabled = false;
            ddlRol.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtDni.Text = String.Empty;
            txtFechaNac.Text = String.Empty;
            txtLegajo.Text = String.Empty;
            txtFechaAlta.Text = String.Empty;
            txtFechaBaja.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtUsuario.Text = String.Empty;
            ddlRol.SelectedIndex = -1;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Empleado oEmpleado = new Empleado();
            oEmpleado.Apellido = txtApellido.Text;
            oEmpleado.Nombre = txtNombre.Text;
            oEmpleado.Dni = txtDni.Text.Trim() != String.Empty ? Convert.ToInt64(txtDni.Text.Trim()) : (Int64?)null;
            oEmpleado.FechaAlta = txtFechaAlta.Text.Trim() != String.Empty ? Convert.ToDateTime(txtFechaAlta.Text.Trim()) : (DateTime?)null;
            oEmpleado.FechaBaja = txtFechaBaja.Text.Trim() != String.Empty ? Convert.ToDateTime(txtFechaBaja.Text.Trim()) : (DateTime?)null;
            oEmpleado.FechaNac = txtFechaNac.Text.Trim() != String.Empty ? Convert.ToDateTime(txtFechaNac.Text.Trim()) : (DateTime?)null;
            oEmpleado.Legajo = txtLegajo.Text.Trim() != String.Empty ? Convert.ToInt64(txtLegajo.Text.Trim()) : (Int64?)null;



            gvEmpleados.DataSource = EmpleadoDAO.GetByParam(oEmpleado);
            gvEmpleados.DataBind();
        }

        protected void chkHabilitarBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarBusqueda.Checked)
            {
                txtApellido.Enabled = true;
                txtNombre.Enabled = true;
                txtLegajo.Enabled = true;
                txtDni.Enabled = true;
            }

        }

        protected void gvEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}