using System;
using Negocio;
using Entidades;

namespace Ejemplo_ASP
{
    public partial class DetalleDisco : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTitulo.ReadOnly = true;
            txtCanciones.ReadOnly = true;
            txtEdicion.ReadOnly = true;
            txtEstilo.ReadOnly = true;
            txtFecha.ReadOnly = true;
            try
            {                

                if (Request.QueryString["id"] != null)
                {
                    string user = Request.QueryString["id"].ToString(); //viene del enlace en la card de Default
                    NegocioDisco negocio = new NegocioDisco();
                    Disco disco = new Disco();
                    
                    disco = negocio.ListarDisco(user);
                    txtTitulo.Text = disco.Titulo.ToString();
                    txtCanciones.Text = disco.CantCanciones.ToString();                    
                    txtEstilo.Text = disco.Estilo.ToString();                    
                    txtEdicion.Text = disco.TipoEdicion.ToString();
                    txtFecha.Text   = disco.FechaLanzamiento.ToString("dd/MM/yyyy");                    
                    imgUrl.ImageUrl = disco.UrlImagen.ToString();
                }
                else
                {
                    txtTitulo.Text = "";
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error",ex);               
            }
        }
    }
}