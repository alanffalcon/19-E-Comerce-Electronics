using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace ArticulosWeb
{
    public partial class Default : System.Web.UI.Page
    {
        // Creamos Lista
        public List<Articulo> ListaArticulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio= new ArticuloNegocio();
            ListaArticulo = negocio.listarConSP();

            // REPEATER
            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo; 
                repRepetidor.DataBind();
            }
            
        }
    }
}