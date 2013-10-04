using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using Datos;

public partial class _Default : System.Web.UI.Page
{
    List<Cliente> Clientes;
    //int contador = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       Trace.Warn("esta en el load");
       // Trace.IsEnabled = true;
       Trace.Write("kkk");
       // Trace.IsEnabled = true;
        if (Request.QueryString["valor1"] != null)
            txtNombre.Text = Request.QueryString["valor1"].ToString() + " " + Request.QueryString["valor2"].ToString();

        if (Session["Clientes"]!=null)
            Clientes = (List<Cliente>) Session["Clientes"];
        else
        {
            Clientes  = new List<Cliente>();
            Session["Clientes"] = Clientes;
        }
        lblMensaje.Text = "";
        //MostrarListaDeClientes();

        //HttpCookie cok = new HttpCookie("datosxx");
        //cok.Value = "20";
        //cok.Expires = DateTime.Now.AddMinutes(1);
        //Response.Cookies.Add(cok);

        string strcon = ConfigurationManager.ConnectionStrings["PAVUTN"].ConnectionString;

        //SqlConnection con;
        //con = DB.Conectar(sqlcon);
        //List<SqlParameter> milist = new List<SqlParameter>();
        //SqlDataReader dr;
        //dr = DB.GenerarReader("select * from clientes", milist, con);
        //Cliente Cli;

        //while (dr.Read())
        //{
        //    Cli = new Cliente();
        //    Cli.Nombre = dr["Nombre"].ToString();
        //    Cli.IdCliente = Int32.Parse(dr["IdCliente"].ToString());
        //    Cli.FechaNacimiento = dr.GetDateTime(4);
        //    Clientes.Add(Cli);
        //}
        gv1.DataSource = Datos.DAOClientes.ObtenerTodos(strcon, "numerodocumento desc");
        string[] claves = {"IdCliente"};
        gv1.DataKeyNames = claves;
        gv1.DataBind();
    }

    private void MostrarListaDeClientes()
    {  
        //TODO 01) Cargar lblListaDeClientes con el Nombre de todos los clientes
        // separar cada nombre con un salto de linea (etiqueta html </br>)
        //lbClientes.Items.Clear();
        //foreach (Cliente item in Clientes)
        //{
        //    string s = item.Nombre + "-" + item.NumeroDocumento + "-" + item.FechaNacimiento.ToString("dd/MM/yyyy") + "-" + item.Sexo;
        //    lbClientes.Items.Add(new ListItem(s, lbClientes.Items.Count.ToString()));
        //}
    }
    protected void butAgregar_Click(object sender, EventArgs e)
    {
        //TODO 02) Agregar un cliente desde los controles a la Lista y Mostrarlo en el listado
        if (txtNombre.Text != "")
        {
            Cliente Cli = new Cliente();
            Cli.Nombre = txtNombre.Text;
            try
            {
                Cli.NumeroDocumento = Int32.Parse(txtDcto.Text);
            }
            catch
            {
                lblMensaje.Text = "Nro de Documento no válido";
                return;
            }
            DateTime fec = DateTime.Today;
            try
            {
                DateTime.TryParse(txtFecNac.Text, out fec);
            }
            catch
            {
                lblMensaje.Text = "Fecha no válida";
                return;
            }
            Cli.FechaNacimiento = fec;
            Cli.Sexo = rbFem.Checked ? "F" : "M";
            Clientes.Add(Cli);
  //          txtNombre.Text = "";
            MostrarListaDeClientes();
            Session["Clientes"] = Clientes;
        }
        else
        {
            lblMensaje.Text = "No puede agregarse un cliente con nombre vacio!";
        }
        //TODO 04) Modificar la pantalla y completar este metodo para incluir todos los atributos de cliente, validar los posibles errores de conversion y mostrar mensaje de error en el label lblMensaje.
    }
    
    protected void butConsultar_Click(object sender, EventArgs e)
    {
        //TODO 05) a) reemplazar el control lblListaDeClientes por un listbox 
        //TODO 05) b) mostrar en los controles los datos del cliente seleccionado en el listBox
    }

    //TODO 06) Implementar la funcionalidad de Eliminar
    //TODO 07) Implementar la funcionalidad de Editar
    protected void lbClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string[] cliente = lbClientes.SelectedItem.Text.Split('-');
        //txtNombre.Text = cliente[0];
        //txtDcto.Text = cliente[1];
        //txtFecNac.Text = cliente[2];
        //rbFem.Checked = cliente[3] == "F" ? true : false;
        //rbMas.Checked = cliente[3] == "F" ? false : true;
        //Session["Elegido"] = lbClientes.SelectedValue;
    }
    protected void butEliminar_Click(object sender, EventArgs e)
    {
        //if (lbClientes.SelectedIndex >= 0)
        //    Clientes.RemoveAt(lbClientes.SelectedIndex);
        //MostrarListaDeClientes();
        //Session["Clientes"] = Clientes;
        string strcon = ConfigurationManager.ConnectionStrings["PAVUTN"].ConnectionString;
        DAOClientes.Eliminar(strcon, (int)gv1.SelectedDataKey[0]);

    }
    protected void butEditar_Click(object sender, EventArgs e)
    {
        //if (lbClientes.SelectedIndex >= 0)
        //{
        //    Cliente cli = Clientes[Int32.Parse(Session["Elegido"].ToString())];
        //    cli.Nombre = txtNombre.Text;
        //    try
        //    {
        //        cli.NumeroDocumento = Int32.Parse(txtDcto.Text);
        //    }
        //    catch
        //    {
        //        lblMensaje.Text  = "Nro de Documento no válido";
        //        return;
        //    }

        //    DateTime fec=DateTime.Today;
        //    try
        //    {
        //        DateTime.TryParse(txtFecNac.Text, out fec);
        //    }
        //    catch
        //    {
        //        lblMensaje.Text  = "Fecha no válida";
        //        return;
        //    }
        //    cli.FechaNacimiento = fec;
        //    cli.Sexo = rbFem.Checked ? "F" : "M";
        //    MostrarListaDeClientes();
        //}
    }
    protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtNombre.Text = gv1.SelectedRow.Cells[1].Text;
        //txtDcto.Text  = gv1.SelectedRow.Cells[2].Text;
        //txtFecNac.Text = gv1.SelectedRow.Cells[3].Text;
        //rbFem.Checked = (gv1.SelectedRow.Cells[4].Text == "F" ? true : false);
        //rbMas.Checked = (gv1.SelectedRow.Cells[4].Text == "F" ? false : true);

        string strcon = ConfigurationManager.ConnectionStrings["PAVUTN"].ConnectionString;
        Cliente clie = Datos.DAOClientes.BuscarPorId(strcon, (int)gv1.SelectedDataKey[0]);
        txtNombre.Text = clie.Nombre;
        txtDcto.Text = clie.NumeroDocumento.ToString();
        txtFecNac.Text = clie.FechaNacimiento.ToString();
        rbFem.Checked = (clie.Sexo == "F" ? true : false);
        rbMas.Checked = (clie.Sexo == "F" ? false : true);
    }
}