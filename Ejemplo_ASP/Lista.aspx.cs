using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Ejemplo_ASP
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioDisco negocio = new NegocioDisco();
            //dgvDiscos.DataSource = negocio.ListarSp();
            Session.Add("ListaDiscos", negocio.ListarSp());
            dgvDiscos.DataSource = (List<Disco>)Session["ListaDiscos"];
            dgvDiscos.DataBind();
        }

        protected void dgvDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioDiscos.aspx?id=" + id);
        }

        protected void dgvDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDiscos.PageIndex = e.NewPageIndex;
            dgvDiscos.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Disco> lista = (List<Disco>)Session["ListaDiscos"];
            List<Disco> listaFiltrada = lista.FindAll(x=>x.Titulo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvDiscos.DataSource =listaFiltrada;
            dgvDiscos.DataBind();
        }
    }
}