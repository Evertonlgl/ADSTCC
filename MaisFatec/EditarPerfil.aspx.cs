using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class EditarPerfil : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario objUsuario = ((Usuario)Session["usuario"]);
        if (!Page.IsPostBack)
        {
            PerfilBD perfilbd = new PerfilBD();
            carregaDadosBasicos(objUsuario);
            carregaMiniCv(objUsuario);
            carregaInteresses(objUsuario);
        }
    }//page load

    protected void FileUploadComplete(object sender, EventArgs e)
    {
        Usuario objUsuario = ((Usuario)Session["usuario"]);
        //string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
        string extension = Path.GetExtension(AsyncFileUpload1.FileName);
        string filename = (objUsuario.IdUsuario.ToString() + objUsuario.PerfilC.NomePerfil + extension);
        AsyncFileUpload1.SaveAs(Server.MapPath("FotosPerfil/") + filename);
        PerfilBD perfilbd = new PerfilBD();
        objUsuario.PerfilC.FotoPerfil = (("~/FotosPerfil/") + filename);
        perfilbd.Update(objUsuario);
        imgPerfilUsuario.ImageUrl = (("~/FotosPerfil/") + filename);
    }

    private void carregaInteresses(Usuario usr)
    {
        InteressesBD interessesbd = new InteressesBD();
        foreach (Interesses element in interessesbd.Select(usr.PerfilC.IdPerfil))
        {
            if (element.InteressesDescricao != "")
            {
                switch (element.InteressesTipo)
                {
                    case "Lazer":
                        switch (element.IndexInteresse)
                        {
                            case 1:
                                txtEdtPerfLazer1.Text = element.InteressesDescricao;
                                break;
                            case 2:
                                txtEdtPerfLazer2.Text = element.InteressesDescricao;
                                txtEdtPerfLazer2.Visible = true;
                                break;
                            case 3:
                                txtEdtPerfLazer3.Text = element.InteressesDescricao;
                                txtEdtPerfLazer3.Visible = true;
                                break;
                            case 4:
                                txtEdtPerfLazer4.Text = element.InteressesDescricao;
                                txtEdtPerfLazer4.Visible = true;
                                break;
                            case 5:
                                txtEdtPerfLazer5.Text = element.InteressesDescricao;
                                txtEdtPerfLazer5.Visible = true;
                                break;
                        }
                        break;
                    case "Filme":
                        switch (element.IndexInteresse)
                        {
                            case 1:
                                txtEdtPerfFilme1.Text = element.InteressesDescricao;
                                break;
                            case 2:
                                txtEdtPerfFilme2.Text = element.InteressesDescricao;
                                txtEdtPerfFilme2.Visible = true;
                                break;
                            case 3:
                                txtEdtPerfFilme3.Text = element.InteressesDescricao;
                                txtEdtPerfFilme3.Visible = true;
                                break;
                            case 4:
                                txtEdtPerfFilme4.Text = element.InteressesDescricao;
                                txtEdtPerfFilme4.Visible = true;
                                break;
                            case 5:
                                txtEdtPerfFilme5.Text = element.InteressesDescricao;
                                txtEdtPerfFilme5.Visible = true;
                                break;
                        }
                        break;
                    case "Esporte":
                        switch (element.IndexInteresse)
                        {
                            case 1:
                                txtEdtPerfEsporte1.Text = element.InteressesDescricao;
                                break;
                            case 2:
                                txtEdtPerfEsporte2.Text = element.InteressesDescricao;
                                txtEdtPerfEsporte2.Visible = true;
                                break;
                            case 3:
                                txtEdtPerfEsporte3.Text = element.InteressesDescricao;
                                txtEdtPerfEsporte3.Visible = true;
                                break;
                            case 4:
                                txtEdtPerfEsporte4.Text = element.InteressesDescricao;
                                txtEdtPerfEsporte4.Visible = true;
                                break;
                            case 5:
                                txtEdtPerfEsporte5.Text = element.InteressesDescricao;
                                txtEdtPerfEsporte5.Visible = true;
                                break;
                        }
                        break;
                    case "Livros":
                        switch (element.IndexInteresse)
                        {
                            case 1:
                                txtEdtPerfLivros1.Text = element.InteressesDescricao;
                                break;
                            case 2:
                                txtEdtPerfLivros2.Text = element.InteressesDescricao;
                                txtEdtPerfLivros2.Visible = true;
                                break;
                            case 3:
                                txtEdtPerfLivros3.Text = element.InteressesDescricao;
                                txtEdtPerfLivros3.Visible = true;
                                break;
                            case 4:
                                txtEdtPerfLivros4.Text = element.InteressesDescricao;
                                txtEdtPerfLivros4.Visible = true;
                                break;
                            case 5:
                                txtEdtPerfLivros5.Text = element.InteressesDescricao;
                                txtEdtPerfLivros5.Visible = true;
                                break;
                        }
                        break;
                    case "Musica":
                        switch (element.IndexInteresse)
                        {
                            case 1:
                                txtEdtPerfMusica1.Text = element.InteressesDescricao;
                                break;
                            case 2:
                                txtEdtPerfMusica2.Text = element.InteressesDescricao;
                                txtEdtPerfMusica2.Visible = true;
                                break;
                            case 3:
                                txtEdtPerfMusica3.Text = element.InteressesDescricao;
                                txtEdtPerfMusica3.Visible = true;
                                break;
                            case 4:
                                txtEdtPerfMusica4.Text = element.InteressesDescricao;
                                txtEdtPerfMusica4.Visible = true;
                                break;
                            case 5:
                                txtEdtPerfMusica5.Text = element.InteressesDescricao;
                                txtEdtPerfMusica5.Visible = true;
                                break;
                        }
                        break;
                }//switch tipo 
            }
        }//foreach
    }//carrega Interesses

    private void carregaDadosBasicos(Usuario usr)
    {
        txtEdtPerfNome.Text = usr.PerfilC.NomePerfil;
        txtEdtPerfSobrenome.Text = usr.PerfilC.SobrenomePerfil;
        txtEdtPerfDtNasc.Text = usr.PerfilC.DataNascimentoPerfil.ToShortDateString();
        txtEdtPerfSobreVoce.Text = usr.PerfilC.SobrePerfil;
        txtEdtPerfCidadeAtual.Text = usr.PerfilC.CidadeAtualPerfil;
        txtEdtPerfCidadeNatal.Text = usr.PerfilC.CidadeNatalPerfil;
        ddlEdtPerfSexo.SelectedValue = usr.PerfilC.SexoPerfil;
        ddlEdtPerfRelacionamento.SelectedValue = usr.PerfilC.RelacionamentoPerfil;
        imgPerfilUsuario.ImageUrl = usr.PerfilC.FotoPerfil;
    }//Carrega Dados Básicos
    private void carregaMiniCv(Usuario usr)
    {
       
    }//Carrega Mini CV

    protected void btnEdtPerfSalvarDadosBasicos_Click(object sender, EventArgs e)
    {
        Usuario objUsuario = ((Usuario)Session["usuario"]);

        objUsuario.PerfilC.SobrenomePerfil = txtEdtPerfSobrenome.Text;
        objUsuario.PerfilC.RelacionamentoPerfil = ddlEdtPerfRelacionamento.Text;
        objUsuario.PerfilC.FotoPerfil = imgPerfilUsuario.ImageUrl;
        objUsuario.PerfilC.SobrePerfil = txtEdtPerfSobreVoce.Text;
        objUsuario.PerfilC.CidadeAtualPerfil = txtEdtPerfCidadeAtual.Text;
        objUsuario.PerfilC.CidadeNatalPerfil = txtEdtPerfCidadeNatal.Text;

        PerfilBD perfilbd = new PerfilBD();
        if (perfilbd.Update(objUsuario) == 0)
        {
            Session["usuario"] = objUsuario;
            btnEdtPerfSalvarDadosBasicos.Text = "Dados salvos com sucesso!"; 
        }
    }

    protected void btnEdtPerfSalvarInteresses_Click(object sender, EventArgs e)
    {
       
    }
    protected void ibtEdtPerfSalvarMiniCv_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtEdtPerfCurComp_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtEdtPerfExpProf_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtEdtPerfLazer_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtEdtPerfEsporte_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtEdtPerfLivros_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtEdtPerfMusica_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtEdtPerfFilme_Click(object sender, ImageClickEventArgs e)
    {

    }
}//class