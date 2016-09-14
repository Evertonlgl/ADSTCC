<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageForum.master" AutoEventWireup="true" CodeFile="pagMeusTopicos.aspx.cs" Inherits="pagMeusTopicos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentForum1" Runat="Server">
    <link href="App_Themes/Theme1/Style.css" rel="stylesheet" />
    <div id="divBusca" class="buscar">
        
        <asp:AutoCompleteExtender  ID="AutoCompleteExtender1" runat="server"
            TargetControlID="txtBusca" ServiceMethod="GetCompletionList"
                    MinimumPrefixLength="2" CompletionInterval="10" EnableCaching="true" 
                    CompletionSetCount="2" UseContextKey="True"></asp:AutoCompleteExtender>

        <asp:TextBox ID="txtBusca" runat="server" ToolTip="Insira a Palavra chave para Busca" ></asp:TextBox> 
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
     </div>
    
    
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentForum2" Runat="Server">
    <link href="App_Themes/Theme1/Style.css" rel="stylesheet" />
    <div id="divMeusTopicos" runat="server">

    </div>
    
</asp:Content>

