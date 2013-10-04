using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {

        int i = Int16.Parse(args.Value);
        args.IsValid = (i % 2 == 0);

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string[] lista = ConfigurationManager.AppSettings.AllKeys;
        foreach (string l in lista)
            TextBox4.Text += ConfigurationManager.AppSettings[l].ToString();
        HttpCookie cok = new HttpCookie("mic");
        cok.Expires = DateTime.Now.AddMinutes(1);
        cok.Value = "hola";
        Response.Cookies.Add(cok);
        Response.Redirect("Default.aspx?valor1=10&valor2=20");
    }
}