<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageForum.master" AutoEventWireup="true" CodeFile="PopNotificacao.aspx.cs" Inherits="PopNotificacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentForum1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentForum2" Runat="Server">
        
        <div id="Titulo" class="titulo">Deseja banir usuário? <br/><br/><br/>
        
        <asp:ImageButton ID="btnBanir" runat="server" ImageUrl="~/img/ok.png" style="margin-left: 0px; margin-right: 0px" /><%--<asp:Button ID="btnBanir" runat="server" Text="Banir" />--%>
        <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/img/del.png" style="margin-left: 29px" /><%--<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Height="28px" />--%>

    </div>

</asp:Content>

