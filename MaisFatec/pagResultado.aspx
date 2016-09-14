

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageForum.master" AutoEventWireup="true" CodeFile="pagResultado.aspx.cs" Inherits="pagResultado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentForum1" runat="Server" >
    <%--<link href="App_Themes/Theme1/Style.css" rel="stylesheet" />--%>
    <link href="App_Themes/Theme1/estilo.css" rel="stylesheet" />
    
    <div id="divBusca" class="buscar">

        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
            TargetControlID="txtBusca" ServiceMethod="GetCompletionList"
            MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="true"
            CompletionSetCount="2" UseContextKey="True">
        </asp:AutoCompleteExtender>
        <asp:TextBox ID="txtBusca" runat="server" ToolTip="Insira a Palavra chave para Busca" ></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentForum2" runat="Server">
    <link href="App_Themes/Theme1/Style.css" rel="stylesheet" />
    <link href="App_Themes/Theme1/estilo.css" rel="stylesheet" />
    <div id="divGeral" runat="server">

        <div id="divTopico" runat="server" style="height: 250px;">

        </div>

        <div id="divAnexo" runat="server" style="height: 75px;">
            <asp:LinkButton ID="lkbAnexo" runat="server" OnClick="lkbAnexo_Click" >
                
            <asp:Image ID="lblFoto" runat="server"> </asp:Image>
                </asp:LinkButton>

            
        </div>

    </div>
    <div id="divTiny" runat="server" style="height: 250px;">
        <br/>
        <div id='tdPost' class="line-separator"></div>
        <script src="tinymce/tinymce.min.js"></script>
        <script src="tinymce/Tiny.js"></script>

        <textarea id="tnyConteudo" runat="server" style="">

        </textarea><br />
        <asp:Button ID="btnInserir" runat="server" Text="Inserir" OnClick="btnInserir_Click" />

    </div>
    <br />
    <div id="divPost" runat="server">
        <link href="App_Themes/Theme1/Style.css" rel="stylesheet" />
        <script src="jquery-1.4a2.js"></script>
        <script src="jquery-1.9.1.min.js"></script>
        <script language="javascript" type="text/javascript">
            $(function () {
                $("img").mouseover(function () {

                    
                    if ($(this).attr("src") == "EmptyStar.png") {
                        giveRating($(this), "FilledStar.png");
                        
                        $(this).css("cursor", "pointer");
                   }
                });

                $("img").mouseout(function () {
                   if ($(this).attr("src") == "FilledStar.png") {
                        giveRating($(this), "EmptyStar.png");
                       
                    }
                });

                $("img").click(function () {
                    $("img").unbind("mouseout mouseover click");

                    // call ajax methods to update database
                    var url = "pagResultado.aspx?rating=" + parseInt($(this).attr("id"));
                    $.post(url, null, function (data) {
                        $("#result").text(data);
                    });
                });
            });

            function giveRating(img, image) {
                
                img.attr("src", image)
                   .prevAll("img").attr("src", image);
            }
    </script>

        <%--<script type="text/javascript">
            var StarStore = 0;

            function ChangeImage(img) {
                var cnt = img.id;
                
                while (cnt >= 0) {
                    document.getElementById(cnt).src = "FilledStar.png";
                    cnt = parseInt(cnt) -1;
                }
            }
            function ChangeImageOut(img) {
                var cnt = img.id;
                ClearAllimg();
                
                while (cnt <= 5) {
                    document.getElementById(cnt).src = "FilledStar.png";
                    cnt = parseInt(cnt-1);
                }
            }
            function ClearAllimg() {
                var cnt = 5
                while (cnt >= 0) {
                    document.getElementById(cnt).src = "EmptyStar.png";
                    cnt = parseInt(cnt) ;
                }
            }
            function SubmitRating(imgs) {
                StarStore = imgs.id;    // or  you can save that data to database and calculate rating 
                alert('You give ' + imgs.id + ' rate to this page');
            }

            function StoreValStar() {
                var cnt = StarStore;
                if (StarStore == 0) {
                    ClearAllimg();
                }
                else {
                    while (cnt > 0) {
                        document.getElementById(cnt).src = "EmptyStar.png";
                        cnt = parseInt(cnt) - 1;
                    }
                }
            }
    </script>--%>
        
        <asp:Image ID="teste" runat="server" />
        <asp:Label ID="lblTotal" runat="server"></asp:Label>
    </div>
    <asp:Button ID="btnCarrega" runat="server" text="Mais" Visible="false" OnClick="btnCarrega_Click" CssClass="btnMais"/>
</asp:Content>

