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
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Material> materiales = MaterialDAO.GetAll();
            
            gvMateriales.DataSource = materiales;
            gvMateriales.DataKeyNames = new String[] { "idMaterial" };
            gvMateriales.DataBind();
        }

        protected void gvMateriales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idMaterial = (int)gvMateriales.DataKeys[e.RowIndex]["idMaterial"];
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "ShowConfirmModal", "$('#deleteModal').modal('show')", true);
            ViewState["selectedID"] = idMaterial;

        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            int idMaterial = (int)ViewState["selectedID"];
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "ShowConfirmModal", "$('#deleteModal').modal('hide')", true);
        }
    }
}