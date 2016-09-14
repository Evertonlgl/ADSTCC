<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administrador.aspx.cs" Inherits="Administrador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <style type="text/css">
        .modalBackground {
            background: #cdcdcd;
            opacity: 0.8;
            top: 0px;
            left: 0px;
            position: absolute;
            z-index: 1;
        }

        .modalPopup {
            background-color: #FFF;
            padding: 3px;
            z-index: 10001;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="gdvAdmin" runat="server" Height="100%" Width="840px" ShowHeaderWhenEmpty="True" OnRowDataBound="gdvAdmin_RowDataBound">
        <HeaderStyle BackColor="#09669D" Height="25px" ForeColor="White" BorderStyle="Solid" BorderColor="Black" BorderWidth="2px" />
        <RowStyle BorderColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="Silver" />

    </asp:GridView>
    <asp:Button ID="btnEditar" runat="server" Text="Button" OnClick="btnTeste_Click" />

    <asp:ModalPopupExtender ID="mpeAdminEditarUsuario" runat="server" TargetControlID="btnEditar" PopupControlID="pnlAdmEditarUsuario" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>

    <asp:Panel ID="pnlAdmEditarUsuario" runat="server" CssClass="modalPopup" Style="display: table" Width="600px" Height="400px">
        <table border="1">
            <tr>
                <td colspan="2"><asp:Label ID="lblUsuIDNome" runat="server" Text="Teste"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblColunista" runat="server" Text="Colunista"></asp:Label></td>
                <td><asp:CheckBox ID="ckbColunista" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblModerador" runat="server" Text="Moderador"></asp:Label></td>
                <td><asp:CheckBox ID="ckbModerador" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblForumPost" runat="server" Text="Postagem Fórum"></asp:Label></td>
                <td><asp:CheckBox ID="ckbForumPost" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblForumResp" runat="server" Text="Responder Fórum"></asp:Label></td>
                <td><asp:CheckBox ID="ckbForumResp" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblColunaResp" runat="server" Text="Responder Coluna"></asp:Label></td>
                <td><asp:CheckBox ID="ckbColunaResp" runat="server" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblAdmin" runat="server" Text="Administrador"></asp:Label></td>
                <td><asp:CheckBox ID="ckbAdmin" runat="server" /></td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>

