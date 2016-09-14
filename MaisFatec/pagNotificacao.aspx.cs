using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pagNotificacao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
            // FuncoesBasicas.Funcoes.Post(divNotificacao, 1, 5, pagina);
            CarregaGrid();
            //FuncoesBasicas.Funcoes.Post(divNotificacao, 1, 5);
            //Session["Resposta"] = Request.Form["confirm_value"];
            
        }
        
    }
    protected void btnBanir_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie cookie = Request.Cookies["Resposta"];

        if (Convert.ToBoolean(cookie.Value) == true)
        {
            ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('ok');", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('Post Removido');", true);
        }



        Usuario usr = ((Usuario)Session["usuario"]);
        Notificacao not = NotificacaoDB.Select(Convert.ToInt32(Session["idPost"].ToString()));
        
        usr.Permissoes.DataPermissao = DateTime.Now;
        usr.Permissoes.MotivoPermissao = "1";
        usr.Permissoes.ForumPostagem = false;
        usr.Permissoes.TempoPermissao = 10;
        usr.IdUsuario = not.CodigoPessoa;
        if (PermissoesBD.UpdateForum(usr, Convert.ToInt32(Session["idPost"].ToString())) == -2)
        {
            ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('usuario não  Removido');", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('usuario Removido');", true);
        }
    }
    private void CarregaGrid()
    {
        DataSet ds = NotificacaoDB.SelectAll(5);
        int qtde = ds.Tables[0].Rows.Count;
        if (qtde > 0)
        {
            grvNotificacao.DataSource = ds.Tables[0].DefaultView;
            grvNotificacao.DataBind();
            lblTotal.Text = "Foram encontrados " + qtde.ToString() + " registros";
            grvNotificacao.Visible = true;

        }
        else
        {
            lblTotal.Text = "Não foram encontrados registros";
            grvNotificacao.Visible = false;
        }
    }
   


    protected void grvNotificacao_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Usuario usu = (Usuario)Session["Usuario"];
        if (e.CommandName == "Abrir")
        {

            divMod.Visible = true;
            String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
            FuncoesBasicas.Funcoes.Post(divNot,Convert.ToInt32(e.CommandArgument.ToString()), 5, pagina,usu.PerfilC.IdPerfil);
            
            Session["idPost"]=e.CommandArgument.ToString();


        }
    }
    protected void btnExcComent_Click(object sender, ImageClickEventArgs e)
    {
        Post pos = new Post();
        pos.Codigo=Convert.ToInt32(Session["idPost"].ToString());
        pos.Spam=1;
        Response.Write(pos.Codigo.ToString() + pos.Spam.ToString());
        if (PostDB.PostSpam(pos) == -2)
        {
            ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('Erro ao ao Remover Post);", true);

        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('Post Removido');", true);
        }
    }
}