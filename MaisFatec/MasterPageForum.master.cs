using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class MasterPageForum : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario pes = (Usuario)Session["Usuario"];

        bool a = pes.Permissoes.ModeradorForum;

        if (a == true)
        {
            btnNotificacaoes.Visible = true;
        }
        else
        {
            btnNotificacaoes.Visible = false;
        }
    }


    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("pagHome.aspx");
    }
    protected void btnNovoTopico_Click(object sender, EventArgs e)
    {
        Response.Redirect("PagTopico.aspx");
    }
    protected void btnMeusTopicos_Click(object sender, EventArgs e)
    {
        Response.Redirect("pagMeusTopicos.aspx");
    }
    protected void btnNotificacaoes_Click(object sender, EventArgs e)
    {
        Response.Redirect("pagNotificacao.aspx");
    }
    
}
