using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PopNotificar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOk_Click(object sender, ImageClickEventArgs e)
    {
        Usuario usu = (Usuario)Session["Usuario"];

        Notificacao not = new Notificacao();
        not.CodigoPessoa = Convert.ToInt32(usu.PerfilC.IdPerfil.ToString());
        not.Data = DateTime.Today;
        not.Descricao = ddlDesc.SelectedValue.ToString();
        not.Postcodigo = Convert.ToInt32(Request.QueryString["id"].ToString());
        Response.Write(Convert.ToInt32(usu.PerfilC.IdPerfil.ToString()) + "     " + Convert.ToInt32(Request.QueryString["id"].ToString()) + " " + DateTime.Now + " " + ddlDesc.SelectedValue.ToString());
        if (NotificacaoDB.Insert(not) == -2)
        {
            Response.Write("Não Inserido");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "window.close();", true);
        }
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "window.close();", true);
    }
}