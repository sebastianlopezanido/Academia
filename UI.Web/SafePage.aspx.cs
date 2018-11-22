using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class SafePage : System.Web.UI.Page
    {
        
        

        virtual protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["tipo"].ToString() == "Default")
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}