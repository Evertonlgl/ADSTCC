﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            carregaPerfilSide();   
        }

        Usuario pes = (Usuario)Session["Usuario"];
        bool a = pes.Permissoes.ModeradorForum;

        //FuncoesBasicas.Funcoes.FButton(divHome);
        String pagina = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
        FuncoesBasicas.Funcoes.CriarDiv(divHome, "v ", "pagHome.aspx", "divHome");

    }

    public void carregaPerfilSide()
    {
        PerfilBD perfil = new PerfilBD();
        foreach (PerfilC element in perfil.SelectBusca(""))
        {
            HtmlAnchor a = new HtmlAnchor();
            a.HRef = ("~/Perfil/" + element.UrlPerfil);
            a.Attributes.Add("style", "margin-right:3px;");
            BuscaPerfil.Controls.Add(a);
            Image img = new Image();
            a.Controls.Add(img);
            img.ImageUrl = element.FotoPerfil;
            img.ToolTip = element.NomePerfil + " " + element.SobrenomePerfil;
            img.Width = 100;
            img.Height = 100;
        }
    }

    protected void txtDefBuscaPerfil_TextChanged(object sender, EventArgs e)
    {
        PerfilBD perfil = new PerfilBD();
        foreach (PerfilC element in perfil.SelectBusca(txtDefBuscaPerfil.Text))
        {
            HtmlAnchor a = new HtmlAnchor();
            a.HRef = ("~/Perfil/" + element.UrlPerfil);
            a.Attributes.Add("style", "margin-right:3px;");
            BuscaPerfil.Controls.Add(a);
            Image img = new Image();
            a.Controls.Add(img);
            img.ImageUrl = element.FotoPerfil;
            img.ToolTip = element.NomePerfil + " " + element.SobrenomePerfil;
            img.Width = 100;
            img.Height = 100;
        }
    }
}//class