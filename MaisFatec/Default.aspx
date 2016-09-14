<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="defTudo">
        <div id="defColEsq">
            <div id="defForum">
                    <div id="divHome" runat="server">

                    </div>
            </div>
            <div id="defSepForCol"></div>
            <div id="defColunas"></div>
        </div>
        <div id="defColDir">
            <div id="defSepPerf"></div>
            <div id="defPerfil">
                <asp:TextBox ID="txtDefBuscaPerfil" runat="server" Width="300px" OnTextChanged="txtDefBuscaPerfil_TextChanged"></asp:TextBox>
                <br /><br />
                <div id="BuscaPerfil" runat="server">
                    
                </div>



            </div>
        </div>
    </div>
</asp:Content>