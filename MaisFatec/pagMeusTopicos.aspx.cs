using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class pagMeusTopicos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
        }
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            else
            {

                Usuario usu= (Usuario)Session["Usuario"];
                String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);

                FuncoesBasicas.Funcoes.CriarDiv(divMeusTopicos, usu.PerfilC.IdPerfil.ToString(), pagina, "divMeusTopicos");

            }
        }
    }

    
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {


        List<string> CompletionSet = new List<string>();
        CompletionSet = TopicoDB.PesquisaTopico();



        return (from m in CompletionSet where m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select m).Take(count).ToArray();

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        FuncoesBasicas.Funcoes.Busca(txtBusca.Text);
    }
}