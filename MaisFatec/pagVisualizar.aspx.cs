using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.Adapters;
using System.Data;

public partial class pagVisualizar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null || Session["PalavraTopico"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            else
            {
                String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
                Usuario pes = (Usuario)Session["Usuario"];
                FuncoesBasicas.Funcoes.CriarDiv(divVisuTopico, Session["PalavraTopico"].ToString(), pagina, "divVisuTopico");
                Response.Write(pagina);
            }
        }
        
                
    }

    
   

    protected void btnBuscar_Click(object sender, EventArgs e)
    {

        FuncoesBasicas.Funcoes.Busca(txtBusca.Text);
    }
}