using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticulosWeb
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {

        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;

            try
            {
                // Configuración inicial de la pantalla:
                if (!IsPostBack)
                {
                    MarcaNegocio negocioM = new MarcaNegocio();
                    List<Marca> listaM = negocioM.listar();

                    CategoriaNegocio negocioC = new CategoriaNegocio();
                    List<Categoria> listaC = negocioC.listar();

                    ddlMarca.DataSource = listaM;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaC;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }

                // Configuracion si estamos Modficando:
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listar(id))[0];

                    // Guardo Articulo seleccionado en session
                    Session.Add("articuloSeleccionado", seleccionado);

                    // Precargamos los campos:
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.CodigoArticulo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    txtPrecio.Text = seleccionado.Precio.ToString();

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    txtImagenUrl_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        // Cambiar Imagen Automaticamente
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        // CREAMOS ARTICULO O  MODIFICAMOS
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio= new ArticuloNegocio();

                // Cargamos los datos
                nuevo.CodigoArticulo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagenUrl.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                // Preguntamos si modificar (con id en url) o agregar
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }
                else
                {
                    negocio.agregarConSP(nuevo);
                }

                Response.Redirect("ArticuloLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        // ELIMINAMOS
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }
        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked )
                {
                    ArticuloNegocio negocio= new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ArticuloLista.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

    } 
}