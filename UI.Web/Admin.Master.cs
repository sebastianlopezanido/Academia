using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_Init(object sender, EventArgs e)
        {
            
        }
        protected void Page_Init(object sender, EventArgs e)
        {            
            if (Session["tipo"].ToString() == "Default")
            {
                Response.Redirect("http://localhost:57900/Login.aspx");
            }            
            
            switch (Session["tipo"].ToString())
            {
                case "Administrador": Menu1.Visible = true; break;
                case "Alumno": Menu2.Visible = true; break;
                case "Profesor": Menu3.Visible = true; break;
            }
            lblTipo.Text = Session["usuario"].ToString();
        }
                
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["usuario"] = "Default";
            Session["tipo"] = "Default";
            Response.Redirect("http://localhost:57900/Login.aspx");
        }
    }
}