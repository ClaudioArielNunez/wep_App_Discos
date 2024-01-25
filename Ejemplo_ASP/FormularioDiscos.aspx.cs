using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Ejemplo_ASP
{
    public partial class FormularioDiscos : System.Web.UI.Page
    {
        public bool chkConfirmacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            chkConfirmacion = false;

            try
            {
                if (!IsPostBack)
                {
                    NegocioEstilo estilo = new NegocioEstilo();
                    ddlEstilo.DataSource = estilo.listar();
                    ddlEstilo.DataTextField = "Descripcion";
                    ddlEstilo.DataValueField = "Id";
                    ddlEstilo.DataBind();

                    NegocioTipoEdicion edicion = new NegocioTipoEdicion();
                    ddlEdicion.DataSource = edicion.listar();
                    ddlEdicion.DataTextField = "Descripcion";
                    ddlEdicion.DataValueField = "Id";
                    ddlEdicion.DataBind();
                }
                if(!IsPostBack && Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    NegocioDisco negocio = new NegocioDisco();                    
                    Disco aux = negocio.ListarDisco(id);

                    //Guardamos el disco buscado - para usarlo en btn desactivar
                    Session.Add("DiscoBuscado", aux);

                    //Configuramos cambio de texto del boton 
                    if (!aux.Estado)
                    {
                        btnDesactivar.Text = "Reactivar";
                    }

                    //Precargamos el formulario con los datos del id
                    txtTitulo.Text = aux.Titulo.ToString();
                    ddlEstilo.SelectedValue = aux.Estilo.Id.ToString();
                    ddlEdicion.SelectedValue = aux.TipoEdicion.Id.ToString();
                    txtCanciones.Text = aux.CantCanciones.ToString();
                    //Chequear que en el textbox su textMode diga Datetime
                    txtFecha.Text = aux.FechaLanzamiento.ToString("dd/MM/yyyy");
                    txtImagen.Text = aux.UrlImagen.ToString();
                    imgUrl.ImageUrl = aux.UrlImagen.ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioDisco negocio = new NegocioDisco();

                Disco nuevo = new Disco();
                nuevo.Titulo = txtTitulo.Text;
                nuevo.CantCanciones = int.Parse(txtCanciones.Text);
                nuevo.UrlImagen = txtImagen.Text;
                nuevo.FechaLanzamiento = DateTime.Parse(txtFecha.Text);

                nuevo.Estilo = new Estilo();
                nuevo.Estilo.Id = int.Parse(ddlEstilo.SelectedValue);
                nuevo.TipoEdicion = new TipoEdicion();
                nuevo.TipoEdicion.Id = int.Parse(ddlEdicion.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificarConSp(nuevo);
                }
                else
                {
                    negocio.agregarConSp(nuevo);
                }
                
                Response.Redirect("Lista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
            
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imgUrl.ImageUrl = txtImagen.Text;
            
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            chkConfirmacion = true;
        }

        protected void btn_ConfirmaEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirma.Checked)
                {
                    NegocioDisco negocio = new NegocioDisco();
                    int id = int.Parse(Request.QueryString["id"]);
                    negocio.eliminar(id);
                    Response.Redirect("Lista.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);               
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioDisco negocio = new NegocioDisco();
                //int id = int.Parse(Request.QueryString["id"]);
                Disco disco = (Disco)Session["DiscoBuscado"];
                if(disco.Estado == true)
                {
                    negocio.enviarPapelera(disco.Id);
                }
                else
                {
                    negocio.enviarPapelera(disco.Id, true);
                }

                Response.Redirect("Lista.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }

        }
    }
}