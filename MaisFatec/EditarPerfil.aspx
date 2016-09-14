<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditarPerfil.aspx.cs" Inherits="EditarPerfil" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <link href="colunista/kendo/styles/kendo.default.min.css" rel="stylesheet" />

    <asp:UpdatePanel id="upnEdtPerfil" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="upg" runat="server">
                <ProgressTemplate>
                    Carregando...
                </ProgressTemplate>
            </asp:UpdateProgress>

    <div id="perfilTudo">
        <div style="text-align: center">
            <asp:Label ID="lblDadosPessoais" runat="server" Text="Dados Pessoais"></asp:Label>
            <br />
            <br />
        </div>
        <div id="editarPerfilConteudo">
            <div id="perfilDadosPessoaisP" class="perfilItens" style="float: left; width: 1024px;">
                <div id="dadosPessoaisEsq" style="float: left; margin-left:20px; margin-top:20px; margin-bottom:20px;">
                    <div>
                        <div class="edtPerfilLinha">
                            Nome:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfNome" runat="server" Enabled="false" CssClass="k-textbox"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />                    
                    <div>
                        <div class="edtPerfilLinha">
                            Sobrenome:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfSobrenome" runat="server" CssClass="k-textbox"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Data de Nascimento:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfDtNasc" runat="server" Enabled="false" CssClass="k-textbox"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Sexo:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:DropDownList ID="ddlEdtPerfSexo" runat="server" CssClass="k-dropdown">
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Feminino</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Cidade Natal:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfCidadeNatal" runat="server" CssClass="k-textbox"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Cidade Atual:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfCidadeAtual" runat="server" CssClass="k-textbox"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Relacionamento:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:DropDownList ID="ddlEdtPerfRelacionamento" runat="server" CssClass="k-dropdown">
                                <asp:ListItem>Solteiro</asp:ListItem>
                                <asp:ListItem>Namorando</asp:ListItem>
                                <asp:ListItem>Noivo</asp:ListItem>
                                <asp:ListItem>Casado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br /><br />
                    <div style="margin-bottom:100px;">
                        <div class="edtPerfilLinha">
                            Sobre você:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfSobreVoce" runat="server" Height="75px" TextMode="MultiLine" Width="395px" CssClass="k-textbox"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="btnEdtPerfSalvarDadosBasicos" runat="server" Text="Salvar" OnClick="btnEdtPerfSalvarDadosBasicos_Click" />
                </div>
                <div id="dadosPessoaisDir" style="float: right; margin-right: 20px; margin-top: 20px;">
                    <div style="margin-left:210px">
                        <asp:Image ID="imgPerfilUsuario" runat="server" Width="180px" Height="180px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"/>
                    </div>
                    <br />
                    <asp:AsyncFileUpload runat="server" ID="AsyncFileUpload1" Width="400px" UploaderStyle="Modern" CompleteBackColor="White" UploadingBackColor="#CCFFFF" OnUploadedComplete="FileUploadComplete" />
                </div>
            </div>

            <div id="perfilDivHor1" class="perfilDivHor"></div>

            <br /><br />
            <asp:Label ID="lblInteresses" runat="server" Text="Interesses"></asp:Label>
            <br />
            <div id="perfilInteressesP" class="perfilItens">

                <div class="edtPerfilTxt">O que gosta de fazer em seu tempo livre?</div>
                <br /><br />
                <div id="edtPerfilLazer" runat="server">
                    <asp:TextBox ID="txtEdtPerfLazer1" runat="server" CssClass="k-textbox"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfLazer2" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfLazer3" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfLazer4" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfLazer5" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ibtEdtPerfLazer" runat="server" ImageUrl="~/Images/add.png" Width="16px" Height="16px" CssClass="edtPerfilTxt" OnClick="ibtEdtPerfLazer_Click" />
                </div>

                <br /><br />
                <div class="edtPerfilTxt">Você pratica algum esporte?</div>
                <br />
                <div id="edtPerfilEsporte" runat="server">
                    <asp:TextBox ID="txtEdtPerfEsporte1" runat="server" CssClass="k-textbox"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfEsporte2" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfEsporte3" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfEsporte4" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfEsporte5" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ibtEdtPerfEsporte" runat="server" ImageUrl="~/Images/add.png" Width="16px" Height="16px" CssClass="edtPerfilTxt" OnClick="ibtEdtPerfEsporte_Click" />
                </div>
                
                <br /><br />
                <div class="edtPerfilTxt">Quais livros, ou tipos de livro, são de seu interesse?</div>
                <br />
                <div id="edtPerfilLivros" runat="server">
                    <asp:TextBox ID="txtEdtPerfLivros1" runat="server" CssClass="k-textbox"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfLivros2" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfLivros3" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfLivros4" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfLivros5" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ibtEdtPerfLivros" runat="server" ImageUrl="~/Images/add.png" Width="16px" Height="16px" CssClass="edtPerfilTxt" OnClick="ibtEdtPerfLivros_Click" />
                </div>

                <br /><br />
                <div class="edtPerfilTxt">O que gosta de ouvir?</div>
                <br />
                <div id="edtPerfilMusica" runat="server">
                    <asp:TextBox ID="txtEdtPerfMusica1" runat="server" CssClass="k-textbox"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfMusica2" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfMusica3" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfMusica4" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfMusica5" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ibtEdtPerfMusica" runat="server" ImageUrl="~/Images/add.png" Width="16px" Height="16px" CssClass="edtPerfilTxt" OnClick="ibtEdtPerfMusica_Click" />
                </div>

                <br /><br />
                <div class="edtPerfilTxt">Gosta de filmes, séries? Compartilhe o que gosta!</div>
                <br />
                <div id="edtPerfilFilme" runat="server">
                    <asp:TextBox ID="txtEdtPerfFilme1" runat="server" CssClass="k-textbox"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfFilme2" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfFilme3" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfFilme4" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfFilme5" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ibtEdtPerfFilme" runat="server" ImageUrl="~/Images/add.png" Width="16px" Height="16px" CssClass="edtPerfilTxt" OnClick="ibtEdtPerfFilme_Click" />
                </div>

                <br /><br />
                <asp:ImageButton ID="ibtEdtPerfSalvarInteresses" runat="server" ImageUrl="~/Images/ok.png" OnClick="btnEdtPerfSalvarInteresses_Click" CssClass="edtPerfilTxt" Width="32px" Height="32px" />
                <asp:Label ID="lblEdtPerfSalvarSucesso" runat="server"></asp:Label>
            </div>

            <div id="edtPerfDivHor2" class="perfilDivHor"></div>

            <asp:Label ID="lblEdtPerfMiniCv" runat="server" Text="Mini CV"></asp:Label>
            <br />
            <br />
            <div id="edtPerfMiniCv" class="perfilItens">

                <div class="edtPerfilTxt">Você está fazendo algum curso de formação acadêmica?</div>
                <br /><br />
                <div id="edtPerfilCursando" runat="server">
                    Curso: <asp:TextBox ID="txtEdtPerfCursandoNome" runat="server" CssClass="k-textbox"></asp:TextBox>
                    Instituição: <asp:TextBox ID="txtEdtPerfCursandoInstituição" runat="server" CssClass="k-textbox"></asp:TextBox>
                </div>

                <br /><br />
                <div class="edtPerfilTxt">Onde você trabalha?</div>
                <br />
                <div id="edtPerfilEmprego" runat="server">
                    Empresa: <asp:TextBox ID="txtEdtPerfEmpregoLocal" runat="server" CssClass="k-textbox"></asp:TextBox>
                    Função: <asp:TextBox ID="txtEdtPerfEmpregoFuncao" runat="server" CssClass="k-textbox"></asp:TextBox>
                </div>
                
                <br /><br />
                <div class="edtPerfilTxt">Onde você já trabalhou?</div>
                <br />
                <div id="edtPerfilExpProf" runat="server">
                    <asp:TextBox ID="txtEdtPerfExpProf1" runat="server" CssClass="k-textbox"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfExpProf2" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfExpProf3" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfExpProf4" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfExpProf5" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ibtEdtPerfExpProf" runat="server" ImageUrl="~/Images/add.png" Width="16px" Height="16px" CssClass="edtPerfilTxt" OnClick="ibtEdtPerfExpProf_Click" />
                </div>

                <br /><br />
                <div class="edtPerfilTxt">Você tem cursos complementares?</div>
                <br />
                <div id="edtPerfilCurComp" runat="server">
                    <asp:TextBox ID="txtEdtPerfCurComp1" runat="server" CssClass="k-textbox"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfCurComp2" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfCurComp3" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfCurComp4" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtEdtPerfCurComp5" runat="server" CssClass="k-textbox" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ibtEdtPerfCurComp" runat="server" ImageUrl="~/Images/add.png" Width="16px" Height="16px" CssClass="edtPerfilTxt" OnClick="ibtEdtPerfCurComp_Click" />
                </div>

                <br /><br />
                <asp:ImageButton ID="ibtEdtPerfSalvarMiniCv" runat="server" ImageUrl="~/Images/ok.png" OnClick="ibtEdtPerfSalvarMiniCv_Click" CssClass="edtPerfilTxt" Width="32px" Height="32px" />
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
        </div>
    </div>

                </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

