﻿using BusinessLogic;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login1.FailureText = "";

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoginLogic ll = new LoginLogic();
                string nombreUsuario = Login1.UserName;
                string clave = Login1.Password;
                Usuario usr = ll.ValidarDatos(nombreUsuario, clave);
                Response.Redirect("http://localhost:57900/Menu.aspx"); //switch según tipo de usuario??
                //Server.Transfer("Menu.aspx");
                //Menu menu = new Menu(usr);
                //menu.Show();
            }
            catch (Exception Ex)
            {
                Login1.FailureText = Ex.Message;
                
            }
            
        }
    }
}