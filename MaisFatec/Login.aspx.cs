using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        
        UsuarioBD usuariobd = new UsuarioBD();
        Usuario usr = usuariobd.ValidaUsuario(Login1.UserName, usuariobd.HashValue(Login1.Password));

        if (usr != null)
        {
            e.Authenticated = true;
            Session["usuario"] = usr;
            FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
        }
        else
        {
            e.Authenticated = false;
        }
    }
    protected void btnCadastro_Click(object sender, EventArgs e)
    {
        logCadastro.Visible = true;
        Login1.Visible = false;
        btnCadastro.Visible = false;

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        logCadastro.Visible = false;
        Login1.Visible = true;
        btnCadastro.Visible = true;

    }
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        UsuarioBD usuariobd = new UsuarioBD();
        Usuario usr = new Usuario();

        if (usuariobd.VerificaUsuarioExiste(txtRegistro.Text, txtRg.Text) == null)
        {
            usr.PerfilC = usuariobd.ValidaCadastro(txtRegistro.Text, txtRg.Text);
            if (usr != null)
            {
                usr.LoginUsuario = txtEmail.Text;
                usr.SenhaUsuario = txtSenha.Text;
                usr.EmailUsuario = txtEmail.Text;
                usr.RgUsuario = txtRg.Text;
                usr.RegistroUsuario = txtRegistro.Text;
                usuariobd.Insert(usr);
                btnCadastrar.Text = "Cadastro Realizado";
                btnCadastro.Visible = true;
            }
            else
            {
                btnCadastrar.Text = "Erro";
                btnCadastro.Visible = true;
            } 
        }
        else
        {
            btnCadastrar.Text = "Usuário já cadastrado";
        }
    }
}//class