<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageForum.master" AutoEventWireup="true" CodeFile="PagTopico.aspx.cs" Inherits="PagTopico" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<script language="javascript" type="text/javascript" >//$(document).ready(function () { $('#btnCancelar').click({ alert('deu') } );   });</script>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentForum1" runat="Server">
    <%--<link href="App_Themes/Theme1/Style.css" rel="stylesheet" />--%>
    <link href="App_Themes/Theme1/estilo.css" rel="stylesheet" />
    <div id="divBusca" class="buscar">


        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
            TargetControlID="txtBusca" ServiceMethod="GetCompletionList"
            MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="true"
            CompletionSetCount="2" UseContextKey="True" >
        </asp:AutoCompleteExtender>


        <asp:TextBox ID="txtBusca" runat="server" ToolTip="Insira a Palavra chave para Busca" ></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    </div>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentForum2" runat="Server">

    <div id="divNovoTopico" runat="server" aria-setsize="500">
        <script src="tinymce/tinymce.min.js"></script>
        <script src="tinymce/Tiny.js"></script>
        <link href="uploadify/uploadify.css" rel="stylesheet" />
        <script src="uploadify/jquery.uploadify.min.js"></script>
        <script src="uploadify/uploadfile.js"></script>

        Titulo:
        <asp:TextBox ID="txtTitulo" runat="server" MaxLength="98" ToolTip="Titulo do tópico"></asp:TextBox><br />

        Conteudo:
        <textarea id="tnyConteudo" runat="server" style="" ToolTip="Conteúdo do Tópico">

        </textarea><br />

        Palavra Chave:
        <asp:TextBox ID="txtPalavraChave" runat="server" ToolTip="Esta palavra sera associada a seu tópico ajudando na busca "></asp:TextBox>
        <br />
        Anexar Arquivo:
        <asp:FileUpload ID="fupAnexo" runat="server" />
        
       <%-- <asp:AjaxFileUpload ID="File_Upload" runat="server" AllowedFileTypes="jpg,jpeg,png,gif"  MaximumNumberOfFiles="10" OnUploadComplete="File_Upload_UploadComplete" Width="500px"  />--%>


        <asp:Label ID="Label1" runat="server" Text="Label">OBS: Tamnho Limite do Anexo de 2MB</asp:Label>


        <br />
        <asp:Label ID="lblMsg" runat="server"></asp:Label>

        <script runat="server">
           
            

        </script>

        <br />
        <asp:ImageButton ID="btnInserir" runat="server" ImageUrl="~/img/postar.png" OnClick="btnInserir_Click" AlternateText="Postar" Style="margin-left: 20px" ToolTip="Inserir seu topico"/>

        <asp:ImageButton ID="btnCancelar"  runat="server" ImageUrl="~/img/Calcelar_postar.png" OnClick="btnCancelar_Click" AlternateText="Cancelar" Style="margin-left: 86px"  ToolTip="Botão Cancelar"/>




    </div>
    <div id="divTeste" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>

                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        Carregando....
                    </ProgressTemplate>
                    
                </asp:UpdateProgress>
                <div id="divButton" runat="server">
                </div>
            </ContentTemplate>


        </asp:UpdatePanel>
    </div>
</asp:Content>

