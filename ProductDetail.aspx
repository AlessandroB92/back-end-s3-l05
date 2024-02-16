<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="back_end_s3_l05.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Stili aggiuntivi per la pagina di dettaglio -->
    <style>
        /* Stili CSS aggiuntivi per la pagina di dettaglio */
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contenuto specifico della pagina di dettaglio -->
    <div class="container">
        <h1>Dettaglio Prodotto</h1>
        <div>
            <asp:Label runat="server" ID="lblNome" />
            <br />
            <asp:Label runat="server" ID="lblDescrizione" />
            <br />
            <asp:Label runat="server" ID="lblPrezzo" />
            <br />
            <asp:Button runat="server" Text="Aggiungi al Carrello" OnClick="AggiungiAlCarrello_Click" CssClass="btn btn-success" />
        </div>
    </div>
</asp:Content>
