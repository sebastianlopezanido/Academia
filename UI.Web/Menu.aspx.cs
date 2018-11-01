using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Menu : System.Web.UI.Page
    {
        //public Menu(Usuario user)
        //{
        //    UsuarioActual = user;
        //    //Ocultar();
        //}

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}