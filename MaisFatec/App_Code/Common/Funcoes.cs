using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;



/// <summary>
/// Summary description for Funcoes
/// </summary>
///


namespace FuncoesBasicas
{
    public class Funcoes
    {
        public static void Topico(HtmlControl divs, string sessao, string pag)
        {


            HtmlGenericControl div = new HtmlGenericControl("divVisuTopico");
            div.ID = "divVisuTopico";
            DataSet ds = TopicoDB.BuscaTopico(sessao.ToString());

            String varHTML = "<table> ";
            HyperLink hyp = new HyperLink();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string id = "+++yh+";
                id += "aa" + criptografia.EncodeRijndael(dr["top_id"].ToString());

                varHTML += " <tr><td><a id='lktResult'  href='pagResultado.aspx?id=" + id + "'>" + dr["top_titulo"].ToString() + "</a></td></tr> ";
                //varHTML += " <tr><td>  <a id='lktResult'  href='javascript: window.open(\"pagHome.aspx?projeto=" + dr["top_id"].ToString() + "\",null, \"height = 800, width = 1200, status = no, resizable = no, scrollbars = no, toolbar = no, location = no, menubar = no url=no\");'>" + dr["top_titulo"].ToString() + "</a></td></tr> ";
            }
            varHTML += " </table>";



            div.InnerHtml = varHTML;

            divs.Controls.Add(div);

        }

        public static void CriarDiv(HtmlControl divs, string sessao, string pag, string divAtual)
        {
            if (divAtual.ToString() == "divTopico" && pag == "pagResultado.aspx")
            {
                HtmlGenericControl div = new HtmlGenericControl("divTopico2");
                div.ID = "divTopico2";
                //DataSet ds = TopicoDB.BuscaTopico(Session["PalavraTopico"].ToString());

                Topico top = TopicoDB.VisualizarTopico(sessao);
                String varHTML = "<table> ";
                varHTML += "<tr>";
                varHTML += "<th class='th' nowrap='nowrap' width='150' height='30'>Autor</th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'>Mensagem</th>";

                varHTML += "<tr>";



                varHTML += "<td class='td' valign='top' align='left' rowspan='2'>";
                varHTML += "<b>" + top.Nome.ToString() + "</b>";
                varHTML += "</br>";
                varHTML += "</td>";


                varHTML += "<td class='td' valign='top' id='post_text_277032' width='100%'>";
                varHTML += "	<span >" + top.Titulo + "</span>";
                varHTML += "	<span >" + top.Conteudo + "</span>";

                varHTML += "	</td>";
                varHTML += "	</tr>";



                //varHTML += " <tr><th class='th' nowrap='nowrap' width='100%' valign=top align=midle>" + top.Titulo + "</td></tr> ";



                // varHTML += " <tr><th class='th' nowrap='nowrap' width='100%'>" + top.Conteudo + "</td></tr> ";
                varHTML += "</tr>";
                varHTML += " <tr>";
                varHTML += "    <td colspan='2'> Data: " + top.DataTopico.ToString("MM/dd/yyyy ") + " Status: " + top.Status + " Palavra Chave " + top.PalavraChave + "</td>";

                varHTML += "</tr>";
                //varHTML += " <tr><td> Data:</td><td> " + top.DataTopico.ToString("MM/dd/yyyy ") + " </td>" + "<td>  Status: </td><td>  <td>" +  + "</td>" + " <td> Palavra Chave: </td><td><td> " + top.PalavraChave + "</th>" + "</tr> ";

                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    varHTML += " <tr><td>" +top.Titulo+"</td></tr> ";

                //}


                varHTML += " </table>";



                div.InnerHtml = varHTML;

                divs.Controls.Add(div);
            }
            else if (divAtual.ToString() == "divVisuTopico" && pag == "pagVisualizar.aspx")
            {
                HtmlGenericControl div = new HtmlGenericControl("divVisuTopico");
                div.ID = "divVisuTopico";
                DataSet ds = TopicoDB.BuscaTopico(sessao);

                String varHTML = "<table> ";
                HyperLink hyp = new HyperLink();
                varHTML += "<tr>";
                varHTML += "<th class='th' nowrap='nowrap' width='150' height='30'>Autor</th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'>Mensagem</th>";

                varHTML += "<tr style='border:1px solid'>";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {





                    varHTML += "<td class='td' valign='top' align='left' rowspan='2'  >";
                    varHTML += "<b>" + dr["perf_nome"].ToString() + "</b>";
                    varHTML += "</br>";
                    varHTML += "</td>";


                    varHTML += "<td class='td' valign='top'  >";

                    varHTML += " <tr><td><a id='lktResult'  href='pagResultado.aspx?id=" + criptografia.EncodeRijndael(dr["top_id"].ToString()) + "'>" + dr["top_titulo"].ToString() + "" + "</a></td></tr> ";
                    //varHTML += "<span >" + dr["pos_descricao"].ToString() + "</span>";

                    varHTML += "</td>";
                    varHTML += "</tr>";



                    //varHTML += " <tr><th class='th' nowrap='nowrap' width='100%' valign=top align=midle>" + top.Titulo + "</td></tr> ";



                    // varHTML += " <tr><th class='th' nowrap='nowrap' width='100%'>" + top.Conteudo + "</td></tr> ";
                    varHTML += "</tr>";
                    varHTML += " <tr>";
                    varHTML += "    <td colspan='2'> Data: " + dr["top_data"].ToString() + "</td>";

                    varHTML += "</tr>";


                    //varHTML += " <tr><td>"+ dr["top_id"].ToString() + dr["top_titulo"].ToString() +"</td></tr> ";
                    //varHTML += " <tr><td> " + dr["perf_nome"].ToString() + " </td></tr> ";
                    //varHTML += " <tr><td> " + dr["pos_descricao"].ToString() + " </td></tr> ";
                    //varHTML += " <tr><td> " + dr["pos_data"].ToString() + " </td></tr> ";


                    varHTML += "<tr><td colspan='2' id='tdPost'></td></tr>";


                }
                varHTML += " </table>";



                div.InnerHtml = varHTML;

                divs.Controls.Add(div);
            }
            else if (divAtual.ToString() == "divHome" && pag == "pagHome.aspx")
            {
                HtmlGenericControl div = new HtmlGenericControl("divHome3");
                div.ID = "divHome3";
                DataSet ds = TopicoDB.GeralTopico();

                String varHTML = "<table> ";
                HyperLink hyp = new HyperLink();
                varHTML += "<tr>";
                varHTML += "<th class='th' nowrap='nowrap' width='150' height='30'>Data Postagem</th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'> Titulo </th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'> Visualizações </th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'> Situação </th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'> Respostas </th>";


                varHTML += "</tr>";
                varHTML += "<tr style='border:1px solid'>";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    varHTML += "<tr>";
                    DateTime dataa = Convert.ToDateTime(dr["Postagem"].ToString());

                    varHTML += "<td class='td' nowrap='nowrap' width='150' height='30'>" + dataa.ToString("dd/MM/yyyy") + "</td>";
                    varHTML += "<td class='td' nowrap='nowrap' width='100%'>" + "<a id='lktResult'  href='pagResultado.aspx?id=" + criptografia.EncodeRijndael(dr["top_id"].ToString()) + "'>" + dr["top_titulo"].ToString() + "</a></td>";
                    varHTML += "<td class='td' nowrap='nowrap' width='100%'>" + dr["Visualizacoes"].ToString() + "</td>";
                    varHTML += "<td class='td' nowrap='nowrap' width='100%'>" + dr["Situacao"].ToString() + "</td>";
                    varHTML += "<td class='td' nowrap='nowrap' width='100%'>" + dr["resposta"].ToString() + "</td>";



                    varHTML += "</tr>";

                    varHTML += "<tr><td colspan='5' id='tdPost'></td></tr>";

                }
                varHTML += "</tr>";
                varHTML += " </table>";



                div.InnerHtml = varHTML;

                divs.Controls.Add(div);

            }
            else if (divAtual.ToString() == "divMeusTopicos" && pag == "pagMeusTopicos.aspx")
            {
                HtmlGenericControl div = new HtmlGenericControl("divMeusTopicos3");
                div.ID = "divMeusTopicos3";
                DataSet ds = TopicoDB.MeusTopicos(Convert.ToInt32(sessao));

                String varHTML = "<table> ";
                HyperLink hyp = new HyperLink();
                varHTML += "<tr>";
                varHTML += "<th class='th' nowrap='nowrap' width='150' height='30'>Data Postagem</th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'> Titulo </th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'> Visualizações </th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'> Situação </th>";


                varHTML += "</tr>";
                varHTML += "<tr style='border:1px solid'>";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    varHTML += "<tr>";
                    DateTime dataa = Convert.ToDateTime(dr["Postagem"].ToString());

                    varHTML += "<td class='td' nowrap='nowrap' width='150' height='30'>" + dataa.ToString("dd/MM/yyyy") + "</td>";
                    varHTML += "<td class='td' nowrap='nowrap' width='100%'>" + "<a id='lktResult'  href='pagResultado.aspx?id=" + criptografia.EncodeRijndael(dr["top_id"].ToString()) + "'>" + dr["top_titulo"].ToString() + "</a></td>";
                    varHTML += "<td class='td' nowrap='nowrap' width='100%'>" + dr["Visualizacoes"].ToString() + "</td>";
                    varHTML += "<td class='td' nowrap='nowrap' width='100%'>" + dr["Situacao"].ToString() + "</td>";

                    varHTML += "</tr>";

                    varHTML += "<tr><td colspan='4' id='tdPost'></td></tr>";

                }
                varHTML += "</tr>";
                varHTML += " </table>";



                div.InnerHtml = varHTML;

                divs.Controls.Add(div);

            }

        }

        public static void Post(HtmlControl divs, int sessao, int limit, String pag,int perf)
        {
            if (pag.ToString().Equals("pagResultado.aspx"))
            {
                string a = Screen.PrimaryScreen.Bounds.ToString();
                HtmlGenericControl div = new HtmlGenericControl("divPost");
                div.ID = "divPost";
                DataSet ds = PostDB.SelectAll(sessao, limit);

                String varHTML = "<table > ";
                HyperLink hyp = new HyperLink();
                varHTML += "<tr>";
                varHTML += "<th class='th' nowrap='nowrap' width='150' height='30'>Autor</th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'>Mensagem</th>";

                varHTML += "<tr style='border:1px solid'>";
                int cont1 = 1;
                int cont2 = 2;
                int cont3 = 3;
                int cont4 = 4;
                int cont5 = 5;
                int cont6 = 1;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    varHTML += "<td class='td' valign='top' align='left' rowspan='2'  >";
                    varHTML += "<b>" + dr["perf_nome"].ToString() + "</b>";
                    varHTML += "</br>";
                    varHTML += "</td>";


                    varHTML += "<td class='td' valign='top'  >";

                    varHTML += "<span >" + dr["pos_descricao"].ToString() + "</span>";

                    varHTML += "</td>";
                    varHTML += "</tr>";


                    varHTML += "</tr>";
                    varHTML += " <tr>";
                    varHTML += "    <td colspan='2'> Data: " + dr["pos_data"].ToString() + "</td>";

                    varHTML += "</tr>";


                    varHTML += " <tr><td class='td'><a id='lktResult'  href='javascript: window.open(\"PopNotificar.aspx?id=" + dr["pos_id"].ToString() + "\",null, \"height = 300px, width = 320px, status = no, resizable = no, scrollbars = no, toolbar = no, top = " + ((Screen.PrimaryScreen.Bounds.Height / 2) - (320 / 2)) + ", left = " + ((Screen.PrimaryScreen.Bounds.Width / 2) - (300 / 2)) + " location = no, menubar = no url=no\");'> Notificar  </a></td></tr> ";
                    varHTML += "<tr><td colspan='2' id='tdPost'></td></tr>";
                    varHTML += "<tr><td colspan='6'>";



                    if (Convert.ToInt32(dr["perf_id"].ToString()) == perf)
                    {
                        if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) > 0)
                        {
                            if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) == 1)
                            {
                                varHTML += " <p>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "3" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "4" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "5" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" + "</a>";
                                varHTML += "</p>";
                            }
                            else if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) == 2)
                            {
                                varHTML += " <p>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "3" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "4" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "5" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" + "</a>";

                            }
                            else if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) == 3)
                            {
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "3" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "4" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "5" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" + "</a>";
                                varHTML += "</p>";
                            }
                            else if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) == 4)
                            {
                                varHTML += " <p>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "3" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "4" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "5" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" + "</a>";
                                varHTML += "</p>";
                            }
                            else
                            {
                                varHTML += " <p>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "3" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "4" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" + "</a>";
                                varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "5" + "&id3=" + "Rating" + "'>" + "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" + "</a>";
                                varHTML += "</p>";
                            }


                        }
                        else
                        {
                            varHTML += " <p>";
                            varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" + "</a>";
                            varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" + "</a>";
                            varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "3" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" + "</a>";
                            varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "4" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" + "</a>";
                            varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "5" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" + "</a>";
                            varHTML += "</p>";
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) > 0)
                        {
                            if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) == 1)
                            {
                                varHTML += " <p>";
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" ;
                                varHTML += "</p>";
                            }
                            else if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) == 2)
                            {
                                varHTML += " <p>";
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" ;

                            }
                            else if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) == 3)
                            {
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" ;
                                varHTML += "</p>";
                            }
                            else if (Convert.ToInt32(dr["pos_avaliacao"].ToString()) == 4)
                            {
                                varHTML += " <p>";
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" ;
                                varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" ;
                                varHTML += "</p>";
                            }
                            else
                            {
                                varHTML += " <p>";
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" ;
                                varHTML += "<img src=\"FilledStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" ;
                                varHTML += "</p>";
                            }


                        }
                        else
                        {
                            varHTML += " <p>";
                            varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont1 + " />" ;
                            varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont2 + " />" ;
                            varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont3 + " />" ;
                            varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont4 + " />" ;
                            varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\"  id=" + cont5 + " />" ;
                            varHTML += "</p>";
                        }
                    }

                    //varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" id=" + cont1 + " />";
                    //varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" id=" + cont2 + " />";
                    //varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" id=" + cont3 + " />";
                    //varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" id=" + cont4 + " />";
                    //varHTML += "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" id=" + cont5 + " />";
                    //onclick=\"SubmitRating(this)\"  onmouseover=\"ChangeImage(this)\"onmouseout=\"ChangeImageOut(this)\"
                    //varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "1" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" onclick=\"SubmitRating(this)\"  onmouseover=\"ChangeImage(this)\"onmouseout=\"ChangeImageOut(this)\"  id=" + cont1 + "/>" + "</a>";
                    //varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "2" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" onclick=\"SubmitRating(this)\"  onmouseover=\"ChangeImage(this)\"onmouseout=\"ChangeImageOut(this)\" id=" + cont2 + " />" + "</a>";
                    //varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "3" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" onclick=\"SubmitRating(this)\"  onmouseover=\"ChangeImage(this)\"onmouseout=\"ChangeImageOut(this)\" id=" + cont3 + " />" + "</a>";
                    //varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "4" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" onclick=\"SubmitRating(this)\"  onmouseover=\"ChangeImage(this)\"onmouseout=\"ChangeImageOut(this)\" id=" + cont4 + " />" + "</a>";
                    //varHTML += "<a href='pagResultado.aspx?id1=" + criptografia.EncodeRijndael(dr["pos_id"].ToString()) + "&id=" + System.Web.HttpContext.Current.Session["Topico"].ToString() + "&id2=" + "5" + "&id3=" + "Rating" + "'>" + "<img src=\"EmptyStar.png\" alt=\"Star Rating\" align=\"middle\" onclick=\"SubmitRating(this)\"  onmouseover=\"ChangeImage(this)\"onmouseout=\"ChangeImageOut(this)\" id=" + cont5 + " />" + "</a>";
                    
                    varHTML += " </td></tr>";
                    cont1+=5;
                    cont2+= 5;
                    cont3 += 5;
                    cont4 += 5;
                    cont5+= 5;
                }
                varHTML += " </table>";

                

                div.InnerHtml = varHTML;

                divs.Controls.Add(div);

            } 
            else
            {

                int k = 0;
                string a = Screen.PrimaryScreen.Bounds.ToString();
                HtmlGenericControl div = new HtmlGenericControl("divNot");
                div.ID = "divNot";
                DataSet ds = NotificacaoDB.SelectAbrir(sessao);
                

                String varHTML = "<table > ";
                HyperLink hyp = new HyperLink();
                varHTML += "<tr>";
                varHTML += "<th class='th' nowrap='nowrap' width='150' height='30'>Autor</th>";
                varHTML += "<th class='th' nowrap='nowrap' width='100%'>Mensagem</th>";

                varHTML += "<tr style='border:1px solid'>";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    varHTML += "<td class='td' valign='top' align='left' rowspan='2'  >";
                    varHTML += "<b>" + dr["NomePost"].ToString() + "</b>";
                    varHTML += "</br>";
                    varHTML += "</td>";


                    varHTML += "<td class='td' valign='top'  >";

                    varHTML += "<span >" + dr["pos_descricao"].ToString() + "</span>";

                    varHTML += "</td>";
                    varHTML += "</tr>";


                    varHTML += "</tr>";
                    varHTML += " <tr>";
                    varHTML += "    <td colspan='2'> Data: " + dr["pos_data"].ToString() + "</td>";

                    varHTML += "</tr>";


                    
                    

                    varHTML += "<tr><td colspan='2' id='tdPost'></td></tr>";


                }
                varHTML += " </table>";



                div.InnerHtml = varHTML;

                divs.Controls.Add(div);
            }
            
        }

        //else
        //{

        //    int k=0;
        //    string a = Screen.PrimaryScreen.Bounds.ToString();
        //    HtmlGenericControl div = new HtmlGenericControl("divnotificacao");
        //    div.ID = "divnotificacao";
        //    //DataSet ds = NotificacaoDB.SelectAll(1);
        //    string script = "<scritp>function setCookie(c_name,value,exdays)";
        //    script += "{";
        //    script += "var exdate=new Date();";
        //    script += "exdate.setDate(exdate.getDate() + exdays);";
        //    script += "var c_value=escape(value) + ((exdays==null) ? \"\" : \"; expires=\"+exdate.toUTCString());";
        //    script += "document.cookie=c_name + \"=\" + c_value;";
        //    script += "}</script\">";

        //    String varHTML = "<table > ";
        //    HyperLink hyp = new HyperLink();
        //    varHTML += "<tr>";
        //    varHTML += "<th class='th' nowrap='nowrap' width='150' height='30'>Autor</th>";
        //    varHTML += "<th class='th' nowrap='nowrap' width='100%'>Mensagem</th>";

        //    //varHTML += "<tr style='border:1px solid'>";
        //    //foreach (DataRow dr in ds.Tables[0].Rows)
        //    //{

        //    //    varHTML += "<td class='td' valign='top' align='left' rowspan='2'  >";
        //    //    varHTML += "<b>" + dr["perf_nome"].ToString() + "</b>";
        //    //    varHTML += "</br>";
        //    //    varHTML += "</td>";


        //    //    varHTML += "<td class='td' valign='top'  >";

        //    //    varHTML += "<span >" + dr["pos_descricao"].ToString() + "</span>";

        //    //    varHTML += "</td>";
        //    //    varHTML += "</tr>";


        //    //    varHTML += "</tr>";
        //    //    varHTML += " <tr>";
        //    //    varHTML += "    <td colspan='2'> Data: " + dr["pos_data"].ToString() + "</td>";

        //    //    varHTML += "</tr>";


        //    //    varHTML += " <tr><td class='td'><a id='lktResult'  href='javascript: window.open(\"PopNotificar.aspx?projeto=" + dr["pos_id"].ToString() + "\",null, \"height = 300px, width = 320px, status = no, resizable = no, scrollbars = no, toolbar = no, top = " + ((Screen.PrimaryScreen.Bounds.Height / 2) - (320 / 2)) + ", left = " + ((Screen.PrimaryScreen.Bounds.Width / 2) - (300 / 2)) + " location = no, menubar = no url=no\");'> Notificar  </a></td></tr> ";
        //    //    varHTML += " <tr><td class='td'><a id='lktResult'  href='javascript:setCookie(\"Teste\",2) ;'> Notificar  </a></td></tr> ";

        //    //    varHTML += "<tr><td colspan='2' id='tdPost'></td></tr>";


        //    //}
        //    varHTML += " </table>";



        //    div.InnerHtml = varHTML;

        //    divs.Controls.Add(div);
        //}
        //}




        public static string criptografar_sha1(string texto)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                string sha = FormsAuthentication.HashPasswordForStoringInConfigFile(texto, "SHA1");

                return sha;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// contar a quantidade de registro de um data set
        /// </summary>
        /// <param name="ds"> obj DataSet</param>
        /// <returns></returns>count de linhas do ds
        public static int QuatidadeDeRegistro(DataSet ds)
        {
            return ds.Tables[0].Rows.Count;
        }

        public static DropDownList DDLSlecionaItem(DropDownList ddl, string valor)
        {
            for (int i = 0; i <= ddl.Items.Count - 1; i++)
            {
                ddl.Items[i].Selected = false;
            }
            for (int i = 0; i <= ddl.Items.Count - 1; i++)
            {
                if (ddl.Items[i].Text == valor)
                {
                    ddl.Items[i].Selected = true;
                    break;
                }
            }
            return ddl;
        }

        public static DropDownList DDLSlecionaItem(DropDownList ddl, int valor)
        {
            for (int i = 0; i <= ddl.Items.Count - 1; i++)
            {
                ddl.Items[i].Selected = false;
            }
            for (int i = 0; i <= ddl.Items.Count - 1; i++)
            {
                if (Convert.ToInt32(ddl.Items[i].Value) == valor)
                {
                    ddl.Items[i].Selected = true;
                    break;
                }
            }
            return ddl;
        }

        public static void Logoff()
        {
            //lembrar de trocar o nome para a sessçao que esta sendo utilizada
            System.Web.HttpContext.Current.Session["Usuario"] = null;
            System.Web.HttpContext.Current.Session.Abandon();
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.RemoveAll();

            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Response.Redirect("caminho da pagina de login ou inicial");
        }

        public static void Busca(string busca)
        {
            if (!string.IsNullOrEmpty(busca))
            {
                if (!string.IsNullOrWhiteSpace(busca))
                {
                    System.Web.HttpContext.Current.Session["PalavraTopico"] = busca.ToString();
                    System.Web.HttpContext.Current.Response.Redirect("pagVisualizar.aspx");
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Redirect("pagHome.aspx");
                }
            }
            else
            {
                System.Web.HttpContext.Current.Response.Redirect("pagHome.aspx");
            }
        }



        public static void FButton(HtmlControl divs)
        {
            HtmlGenericControl div = new HtmlGenericControl("divButton");
            div.ID = "divButton";


            String varHTML = "<table> ";
            HyperLink hyp = new HyperLink();
            varHTML += "<tr>";
            varHTML += "<th class='th' nowrap='nowrap' width='150' height='30'>Autor</th>";
            varHTML += "<th class='th' nowrap='nowrap' width='100%'>Mensagem</th>";
            varHTML += "</br></br></br></br>";
            varHTML += "<tr style='border:1px solid'>";
            varHTML += "<a onclick='Salvar_click' id='_1' title='ehh...' onmouseover='rating(this)' onmouseout='off(this)'>a</a>";
            varHTML += "<a onclick=\"rateIt(this)\" id=\"_2\" title=\"mais ou menos\" onmouseover=\"rating(this)\" onmouseout=\"off(this)\">b</a>";
            varHTML += "<a onclick=\"rateIt(this)\" id=\"_3\" title=\" mais ou menos mais ou meunos\" onmouseover=\"rating(this)\" onmouseout=\"off(this)\">c</a>";
            varHTML += "<a onclick=\"rateIt(this)\" id=\"_4\" title=\"Melhor\" onmouseover=\"rating(this)\" onmouseout=\"off(this)\">b</a>";
            varHTML += "<a onclick=\"rateIt(this)\" id=\"_5\" title=\"Melhor melhor\" onmouseover=\"rating(this)\" onmouseout=\"off(this)\">c</a>";
            varHTML += "</br></br></br></br>";

            System.Web.UI.WebControls.LinkButton bt = new System.Web.UI.WebControls.LinkButton();

            bt.ID = "bbtn";


            //ImageUrl = "Calcular";


            //bt.o;

            div.InnerHtml = varHTML;

            divs.Controls.Add(div);

        }

        protected static void Salvar_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), " ", "alert('Por Favor preencher todos os campos')", true);
            System.Web.HttpContext.Current.Response.Redirect("Default.aspx");
        }


        public static void Home(HtmlControl divs)
        {
            HtmlGenericControl div = new HtmlGenericControl("divPost");
            div.ID = "divPost";
            DataSet ds = TopicoDB.GeralTopico();

            String varHTML = "<table> ";
            HyperLink hyp = new HyperLink();
            varHTML += "<tr>";
            varHTML += "<th class='th' nowrap='nowrap' width='150' height='30'>Autor</th>";
            varHTML += "<th class='th' nowrap='nowrap' width='100%'>Mensagem</th>";

            varHTML += "<tr style='border:1px solid'>";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                varHTML += "<td class='td' valign='top' align='left' rowspan='2'  >";
                varHTML += "<b>" + dr["perf_nome"].ToString() + "</b>";
                varHTML += "</br>";
                varHTML += "</td>";


                varHTML += "<td class='td' valign='top'  >";

                varHTML += "<span >" + dr["pos_descricao"].ToString() + "</span>";

                varHTML += "</td>";
                varHTML += "</tr>";



                //varHTML += " <tr><th class='th' nowrap='nowrap' width='100%' valign=top align=midle>" + top.Titulo + "</td></tr> ";



                // varHTML += " <tr><th class='th' nowrap='nowrap' width='100%'>" + top.Conteudo + "</td></tr> ";
                varHTML += "</tr>";
                varHTML += " <tr>";
                varHTML += "    <td colspan='2'> Data: " + dr["pos_data"].ToString() + "</td>";

                varHTML += "</tr>";


                varHTML += " <tr><td><a id='lktResult'  href='javascript: window.open(\"pagHome.aspx?projeto=" + dr["pos_id"].ToString() + "\",null, \"height = 800, width = 1200, status = no, resizable = no, scrollbars = no, toolbar = no, location = no, menubar = no, top=500, left=500 url=no\");'> Notificar  </a></td></tr> ";
                varHTML += "<tr><td colspan='2' id='tdPost'></td></tr>";


            }
            varHTML += " </table>";



            div.InnerHtml = varHTML;

            divs.Controls.Add(div);

        }


    }

}