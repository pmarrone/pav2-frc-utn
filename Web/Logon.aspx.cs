using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using PatriaFabricaMuebles.DAO;

namespace Web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Autenticar(UserName.Text.ToString(), Password.Text))
                {
                    FormsAuthentication.RedirectFromLoginPage(UserName.Text.ToString(), false);
                    Response.Redirect("Default.aspx");
                }
                else
                    lblerror.Text = "error";
            }
        }

        public Boolean Autenticar(string username, string password)
        {
            bool existe = false;

            try
            {
                existe = UsuarioDAO.ValidarUsuario(username, password);

                if (!existe)
                    return false;


                return existe;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }
    }
}