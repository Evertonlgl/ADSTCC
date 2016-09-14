<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageForum.master" AutoEventWireup="true" CodeFile="pagNotificacao.aspx.cs" Inherits="pagNotificacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentForum1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentForum2" runat="Server">
    <link href="App_Themes/Theme1/Style.css" rel="stylesheet" />
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>

            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    Carregando....
                </ProgressTemplate>
            </asp:UpdateProgress>--%>


    <div id="divNotificacao" runat="server">
        <asp:GridView ID="grvNotificacao" runat="server" AutoPostBack="true" AutoGenerateColumns="false" OnRowCommand="grvNotificacao_RowCommand" CssClass="td">
            <HeaderStyle CssClass="th" Font-Size="14px" />
            <Columns>
                <asp:BoundField DataField="perf_nome" HeaderText="Autor da Nofiticação" />
                <asp:BoundField DataField="not_descricao" HeaderText="Motivo" />

                <asp:TemplateField HeaderText="Excluir">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbAbrir" runat="server" CommandName="Abrir"  CommandArgument='<%# Bind("pos_id") %> '>Abrir</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>


        </asp:GridView>
        <asp:Label ID="lblTotal" runat="server"></asp:Label>

    </div>
    <br />
    <br />
    <br />


    <div>
        <div id="divNot" runat="server">
        </div>
        <script type="text/javascript">
            function Confirm() {
                //var confirm_value = document.createElement("INPUT");
                /*confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";*/
                var confirm_value = confirm("Deseja Realmente Excluir?");
                if (confirm_value == true) {
                    document.cookie = "Resposta" + "=" + confirm_value;
                    window.location("/pagNotificacao.aspx?id=1" + confirm_value.valueOf);
                    document.forms[0].appendChild(confirm_value);
                } else
                {
                    document.cookie = "Resposta" + "=" + confirm_value;
                    window.location("/pagNotificacao.aspx?id=1" + confirm_value.valueOf);
                }


            }
        </script>
        <div id="divMod" runat="server" visible="false">
        <asp:ImageButton ID="btnExcComent" ImageUrl="~/img/Comment-delete.png" runat="server" AlternateText="Excluir comentário" OnClick="btnExcComent_Click" Style="margin-left: 16px" ToolTip="Bloquear Usuario" />
        <asp:ImageButton ID="btnBanir" ImageUrl="~/img/remove_user.png" runat="server" AlternateText="Banir usuário" OnClick="btnBanir_Click" OnClientClick="Confirm()" Style="margin-left: 35px" ToolTip="Excluir Comentario" />
            </div>
    </div>
     
    <%--</ContentTemplate>


    </asp:UpdatePanel>--%>
</asp:Content>

