<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopNotificar.aspx.cs" Inherits="PopNotificar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Theme1/estilo.css" rel="stylesheet" />
</head>

<body class="bodyNot">
    <form id="form1" runat="server" class="bodyNot">
        <div  id="divNotificacao" runat="server" style="background-position: center; width: 300px; height: 192px">
            <div style="width: 289px">
                <p style="background-position: center; font-size: 18px; font-family: verdana; font-weight: bold; background-color: #FFFFFF; color: #000000; width: 219px; height: 30px; margin-left: 69px;">Notificar post</p>
            </div>
            <br />
            <br />

            <div id="justificativa">Justificativa:
                <br />
            </div>
            <asp:DropDownList ID="ddlDesc" runat="server" Height="25px" Style="margin-left: 33px" Width="250px">
                <asp:ListItem>Linguagem ofensiva</asp:ListItem>
                <asp:ListItem>Postagem de Pornografia</asp:ListItem>
                <asp:ListItem>Spam</asp:ListItem>
                <asp:ListItem>Discriminação racial</asp:ListItem>
                <asp:ListItem>Discriminação religiosa</asp:ListItem>
                <asp:ListItem>Discriminação social</asp:ListItem>
                <asp:ListItem>Plagio</asp:ListItem>
            </asp:DropDownList><br />
            <br />
            <br />

            <div id="okCancel">
                <asp:ImageButton ID="btnOk" AlternateText="Ok" ImageUrl="~/img/ok.png" runat="server" OnClick="btnOk_Click" />
                <asp:ImageButton ID="btnCancelar" AlternateText="Cancelar" ImageUrl="~/img/del.png" runat="server" Style="margin-left: 31px" OnClick="btnCancelar_Click" />
            </div>
        </div>


    </form>
</body>
</html>
