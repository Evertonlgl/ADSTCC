using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
            CarregarGrid(); 
            
    }

    public void CarregarGrid()
    {
        UsuarioBD usuariobd = new UsuarioBD();
        gdvAdmin.DataSource = usuariobd.UsuarioAdm();
        gdvAdmin.DataBind();

    }

    protected void gdvAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';");
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click on select row";
            e.Row.Attributes["OnClick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gdvAdmin, "Select$" + e.Row.RowIndex);
            MaintainScrollPositionOnPostBack = true;

            LinkButton selectbutton = new LinkButton()
            {
                CommandName = "Select",
                Text = e.Row.Cells[0].Text
            };
            e.Row.Cells[0].Controls.Add(selectbutton);
            e.Row.Attributes["OnClick"] = Page.ClientScript.GetPostBackClientHyperlink(selectbutton, "");
        }
        
        /*
        if (e.Row.Cells[2].GetType() == typeof(System.Web.UI.WebControls.DataControlFieldCell))
        {
            TableCell tc = e.Row.Cells[2];
            if (tc.Controls.Count > 0)
            {
                CheckBox cb = (CheckBox)tc.Controls[0];
                if (!(cb == null))
                {
                    cb.Enabled = true;
                }
            }
        }
        */
    } 


    protected void btnTeste_Click(object sender, EventArgs e)
    {
        lblUsuIDNome.Text = "Nome"+ gdvAdmin.SelectedRow.Cells[0].Text + gdvAdmin.SelectedRow.Cells[1].Text;
    }
}//class