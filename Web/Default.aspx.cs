using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PanelAdmin.Visible = User.IsInRole("administradores");

            if (User.Identity.IsAuthenticated)
            {
                //Label1.Text = string.Format("Bienvenido {0}", User.Identity.Name);
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Register.aspx");
        }
    }
}
