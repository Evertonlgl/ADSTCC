using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class pagResultado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            else
            {

                Usuario pes = (Usuario)Session["Usuario"];
                Session["Topico"] = Request.QueryString["id"].ToString().Replace(" ", "+");
                TopicoDB.ContadorVisualizacao(Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))));
                if (Request.QueryString["id3"] != null)
                {
                    Post pos = new Post();

                    pos.Codigo = Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id1"].ToString().Replace(" ", "+")));
                    pos.Avaliacao = Convert.ToInt32(Request.QueryString["id2"].ToString());
                    
                    if (PostDB.Avaliacao(pos)==-2)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Por Favor preencher todos os campos')", true);
                    }
                    if (Convert.ToInt32(Request.QueryString["id2"].ToString()) >= 5)
                    {
                        if (TopicoDB.Status(Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), "Fechado") == -2)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Por aow votar')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('ok')", true);
                        }
                    }
                    else
                    {
                        Topico top = TopicoDB.MelhorResposta(Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))));

                        if (top.MelhorResposta > 0)
                        {

                            if (TopicoDB.Status(Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), "Fechado") == -2)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Por aow votar')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('" + Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id1"].ToString().Replace(" ", "+"))) + "Aberto" + "')", true);
                            }

                        }
                        else
                        {
                            if (TopicoDB.Status(Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), "Aberto") == -2)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Por aow votar')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('" + Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id1"].ToString().Replace(" ", "+"))) + "Aberto" + "')", true);
                            }

                        }

                    }

                }
                Anexo();
                AtualizaPagina();

            }
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        FuncoesBasicas.Funcoes.Busca(txtBusca.Text);
        
    }


    protected void btnInserir_Click(object sender, EventArgs e)
    {
        Usuario usu = (Usuario)Session["Usuario"];
        if (string.IsNullOrWhiteSpace(tnyConteudo.Value) | string.IsNullOrEmpty(tnyConteudo.Value))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Por Favor preencher todos os campos')", true);
            String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
            FuncoesBasicas.Funcoes.CriarDiv(divTopico, criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+")), pagina, "divTopico");

            FuncoesBasicas.Funcoes.Post(divPost, Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), Convert.ToInt32(Session["PAI"]), pagina, usu.PerfilC.IdPerfil);
        }
        else
        {

            Post pos = new Post();
            
            pos.CodigoTop = Convert.ToInt32(Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))));

            pos.CodigoPessoa = usu.PerfilC.IdPerfil;

            pos.Descricao = (Texts.ToString());
            pos.DataPost = (DateTime.Now);




            if (PostDB.Insert(pos) == -2)
            {
                ClientScript.RegisterStartupScript(GetType(), "alerta", "alert('Erro ao Inserir Post');", true);
                String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
                FuncoesBasicas.Funcoes.CriarDiv(divTopico, criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+")), pagina, "divTopico");
                
                FuncoesBasicas.Funcoes.Post(divPost, Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), Convert.ToInt32(Session["PAI"]), pagina,usu.PerfilC.IdPerfil);
            }
            else
            {
                Session["pai"] = 5;
                Session["TOTAL"] = 0;


                DataSet ds = PostDB.SelectCount(Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))));
                Session["TOTAL"] = ds.Tables[0].Rows[0]["total"].ToString();
                Session["DIV"] = Convert.ToInt32(Session["TOTAL"]) / Convert.ToInt32(Session["PAI"]);
                Session["DIV2"] = Convert.ToInt32(Session["TOTAL"]) % Convert.ToInt32(Session["PAI"]);
                if (Convert.ToInt32(Session["DIV2"]) > 0)
                {
                    Session["DIV"] = Convert.ToInt32(Session["DIV"]) + 1;
                }
                tnyConteudo.Value = "";
                DataSet ds2 = PostDB.SelectCount(Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))));
                Session["TOTAL"] = ds2.Tables[0].Rows[0]["total"].ToString();
                Session["DIV"] = Convert.ToInt32(Session["TOTAL"]) / Convert.ToInt32(Session["PAI"]);
                Session["DIV2"] = Convert.ToInt32(Session["TOTAL"]) % Convert.ToInt32(Session["PAI"]);
                if (Convert.ToInt32(Session["PAI"]) < Convert.ToInt32(Session["TOTAL"]))
                {
                    btnCarrega.Visible = true;

                }
                if (Convert.ToInt32(Session["TOTAL"]) < Convert.ToInt32(Session["PAI"]))
                {
                    lblTotal.Text = "Total de Resposta Encontrada: " + Session["TOTAL"].ToString();
                }
                else
                {
                    lblTotal.Text = "Total de Resposta Encontrada: " + Session["PAI"].ToString();
                }
                
                String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
                FuncoesBasicas.Funcoes.CriarDiv(divTopico, criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+")), pagina, "divTopico");

                FuncoesBasicas.Funcoes.Post(divPost, Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), Convert.ToInt32(Session["PAI"]), pagina, usu.PerfilC.IdPerfil);
            }
        }
    }
    public string Texts
    {
        get
        {
            return HttpUtility.HtmlDecode(tnyConteudo.Value);
        }
        set
        {
            tnyConteudo.Value = value;
        }
    }
    public void Anexo()
    {
        Topico top = TopicoDB.VisualizarTopico(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+")));
        string s = top.Anexo.ToString();
        
        
        if (string.IsNullOrEmpty(s.ToString()) || string.IsNullOrWhiteSpace(s.ToString()))
        {
            lblFoto.Visible = false;
            //Response.Write("não tem foto" + top.Anexo.ToString());
        }
        else
        {
            //Response.Write("Tem foto" + top.Anexo.ToString());
            lblFoto.ImageUrl = "~/Anexo/AnexoImagem//P_" + s;
            lblFoto.Visible = true;
        }


        Session["TopicoAnexo"] = top.Anexo;
    }
    protected void btnCarrega_Click(object sender, EventArgs e)
    {
        Page.Page.MaintainScrollPositionOnPostBack = true;
        Usuario usu = (Usuario)Session["Usuario"];
        
        if (Convert.ToInt32(Session["DIV"]) >= 1)
        {

            Session["PAI"] = Convert.ToInt32(Session["PAI"]) + 5;
            Session["DIV"] = Convert.ToInt32(Session["DIV"]) - 1;
            lblTotal.Text = "Total de Resposta Encontrada: " + Session["PAI"].ToString();
            String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
            Response.Write((Request.QueryString["id"].ToString().Replace(" ", "+")));
            FuncoesBasicas.Funcoes.Post(divPost, Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), Convert.ToInt32(Session["PAI"]), pagina, usu.PerfilC.IdPerfil);
            FuncoesBasicas.Funcoes.CriarDiv(divTopico, criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+")), pagina, "divTopico");
            if (Convert.ToInt32(Session["DIV"]) == 1)
            {
                btnCarrega.Visible = false;
                if (Convert.ToInt32(Session["TOTAL"]) < Convert.ToInt32(Session["PAI"]))
                {
                    lblTotal.Text = "Total de Resposta Encontrada: " + Session["TOTAL"].ToString();
                }
                else
                {
                    lblTotal.Text = "Total de Resposta Encontrada: " + Session["PAI"].ToString();
                }


                FuncoesBasicas.Funcoes.Post(divPost, Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), Convert.ToInt32(Session["PAI"]), pagina, usu.PerfilC.IdPerfil);
                FuncoesBasicas.Funcoes.CriarDiv(divTopico, criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+")), pagina, "divTopico");
            }
        }
        else
        {

            btnCarrega.Visible = false;
            lblTotal.Text = "Total de Resposta Encontrada: " + Session["TOTAL"].ToString();
            String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
            FuncoesBasicas.Funcoes.CriarDiv(divTopico, criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+")), pagina, "divTopico");
            FuncoesBasicas.Funcoes.Post(divPost, Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), Convert.ToInt32(Session["PAI"]), pagina, usu.PerfilC.IdPerfil);
            
        }

    }

    public void AtualizaPagina()
    {

        Session["PAI"] = 5;
        Session["TOTAL"] = 0;
        Usuario usu = (Usuario)Session["Usuario"];
        

         

        DataSet ds = PostDB.SelectCount(Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))));
        Session["TOTAL"] = ds.Tables[0].Rows[0]["total"].ToString();
        Session["DIV"] = Convert.ToInt32(Session["TOTAL"]) / Convert.ToInt32(Session["PAI"]);
        Session["DIV2"] = Convert.ToInt32(Session["TOTAL"]) % Convert.ToInt32(Session["PAI"]);

        if (Convert.ToInt32(Session["DIV2"]) > 0)
        {
            Session["DIV"] = Convert.ToInt32(Session["DIV"]) + 1;

        }
        if (Convert.ToInt32(Session["TOTAL"]) > 5 && Convert.ToInt32(Session["DIV"]) >= 1)
        {
            btnCarrega.Visible = true;
        }
        if (Convert.ToInt32(Session["TOTAL"]) == 0)
        {
            lblTotal.Text = "Nenhuma Resposta Encontrada: ";
        }
        else
        {
            if (Convert.ToInt32(Session["TOTAL"]) < Convert.ToInt32(Session["PAI"]))
            {
                lblTotal.Text = "Total de Resposta Encontrada: " + Session["TOTAL"].ToString();
            }
            else
            {
                lblTotal.Text = "Total de Resposta Encontrada: " + Session["PAI"].ToString();
            }
        }
        

        String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
        FuncoesBasicas.Funcoes.CriarDiv(divTopico, criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+")), pagina, "divTopico");
        FuncoesBasicas.Funcoes.Post(divPost, Convert.ToInt32(criptografia.Decrypty(Request.QueryString["id"].ToString().Replace(" ", "+"))), Convert.ToInt32(Session["PAI"]),pagina,usu.PerfilC.IdPerfil);
        //Post(Convert.ToInt32(Session["PAI"]));
    }
   
    protected void lkbAnexo_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/x-pot";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Session["TopicoAnexo"].ToString());
        Response.TransmitFile(@"~\Anexo\AnexoImagem\" + Session["TopicoAnexo"].ToString());
        Response.End();
    }
    public void Post(int limit)
    {
       
    }
}