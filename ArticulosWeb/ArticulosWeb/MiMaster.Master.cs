using Microsoft.Win32;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace ArticulosWeb
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

            if (!(Page is Login || Page is Default || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["cliente"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Cliente user = (Cliente)Session["cliente"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}