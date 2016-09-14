<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MenuAdministrador.aspx.cs" Inherits="MenuAdministrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Painel Administrativo - Módulo Colunistas - Mais FATEC</title>
<link href="css/estilo.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--topo -->
<div id="titulo" title="Painel de Controle">
  <div id="logo_painel">
  	<img src="images/logomarca.png" />
  </div>
  <div id="painel_de_controle">
  	PAINEL DE CONTROLE - Módulo Colunistas
  </div>
</div>
<div id="barrinha_vermelha"></div>
<!--topo -->


<div id="menu_principal">
<!--ferramentas -->
  <div id="ferramentas_post_menu_principal">
    
   	<div id="adm_colunista">
<table align="right">
    <tr>
         <td width="82"><div align="center"><a href="adm_add_user.html" class="link_icones_menu"><img src="images/tools/64px/perfil.png" width="64" height="64" border="0" class="icones_menu" /></a></div></td>
    </tr>
    <tr>
        <td><a href="adm_add_user.html">&nbsp;&nbsp;Colunistas</a></td>
    </tr>
</table>
    </div>
        
        
       <div id="adm_publicacoes">
       <table align="center">
            <tr>
                <td><div align="center"><a href="publicacao/cadastro.html" class="link_icones_menu"><img src="images/tools/64px/posts.png" width="64" height="64" border="0" class="icones_menu"/></a></div></td>
            </tr>
            <tr>
                <td><a href="publicacao/cadastro.html" class="link_icones_menu">&nbsp;&nbsp;Publicações</a></td>
            </tr>
         </table>
    </div>
        
        <div id="adm_comentarios">
            <table>
            	<tr>
                	<td><div align="center"><img src="images/tools/64px/comentarios.png" width="64" height="64" class="icones_menu" /></div></td>
              </tr>
               	<tr>
                	<td>&nbsp;Comentários</td>
              </tr>
            </table>
        
        </div>
        
  </div>
	<!--ferramentas -->
</div>
</asp:Content>


