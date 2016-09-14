<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageForum.master" AutoEventWireup="true" CodeFile="pagHome.aspx.cs" Inherits="pagHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentForum1" runat="Server">
    
    
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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentForum2" runat="Server">
    <div id="divHome" runat="server">

    </div>

    
    <%--<asp:GridView ID="gvGeral" runat="server" AllowPaging="True" DataSourceID="odsGeral" PageSize="5"></asp:GridView>

    <asp:ObjectDataSource ID="odsGeral" runat="server" SelectMethod="GeralTopico" TypeName="TopicoDB"></asp:ObjectDataSource>--%>
</asp:Content>

