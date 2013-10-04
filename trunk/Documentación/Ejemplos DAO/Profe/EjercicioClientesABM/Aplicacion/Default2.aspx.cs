using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Trace.IsEnabled = true;
        HttpContext.Current.Trace.Write("esto fue habilitado");
     }
    protected void butSaludar_Click(object sender, EventArgs e)
    {
        lblSaludo.Text = "Bienvenido " + txtNombre.Text + "!!!????";
    }
    protected void txtNombre_TextChanged(object sender, EventArgs e)
    {

    }
}