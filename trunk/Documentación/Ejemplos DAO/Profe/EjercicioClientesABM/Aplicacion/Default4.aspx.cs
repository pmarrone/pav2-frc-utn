using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Datos;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox6.Text = Application["contador"].ToString();
        if (ViewState["info"] != null)
        {
            TextBox7.Text = ViewState["info"].ToString();
        }
        string[] keys = ConfigurationManager.AppSettings.AllKeys;
        foreach (string key in keys)
            if(key.IndexOf("TD_")>=0)
            ListBox1.Items.Add(new ListItem(ConfigurationManager.AppSettings[key].ToString()));


        if (Request.Cookies["datosxx"] != null)
            TextBox2.Text = Request.Cookies["datosxx"].Value;

    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int i = int.Parse(args.Value.ToString());
        if (i % 2 == 0)
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Cliente cli = new Cliente();
        cli.Nombre = "Fernando";
        ViewState["info"] = "Fernando gfadsfgasdf asdfasdfasdfasdf asdfasdfa sdfasdfas dfas dfasdf asdf a sdf asdfa sdf as df";
        string cadena = "valor1=" + TextBox1.Text + "&valor2=fijo";
        Response.Redirect("Default.aspx?"+cadena);
        
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {

    }
}