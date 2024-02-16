<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="back_end_s3_l05.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Stili aggiuntivi per la pagina del carrello -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contenuto specifico della pagina del carrello -->
    <div class="container">
        <h1>Carrello</h1>
        <asp:GridView runat="server" ID="GridViewCart" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Codice" HeaderText="Codice"/>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" DataFormatString="{0:C}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Rimuovi" CommandName="Rimuovi" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger m-2" OnClick="Rimuovi_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button runat="server" Text="Svuota Carrello" OnClick="SvuotaCarrello_Click" CssClass="btn btn-danger" />
        <br />
        <asp:Label runat="server" ID="lblTotale" />
    </div>
</asp:Content>
