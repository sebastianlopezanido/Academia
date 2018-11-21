using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Session["usuario"].ToString() + Session["tipo"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["usuario"] = "Default";
            Session["tipo"] = "Default";
            Response.Redirect("http://localhost:57900/Login.aspx");
        }
    }
}