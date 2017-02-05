<%@ Page Title="Game Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.GameDetails" %>

<asp:Content ID="ContentGameDetails" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormViewGameDetails" runat="server" ItemType="OldBoardGamesNeedLoveToo.Models.Game">
        <HeaderTemplate>
            <h1><%#: Item.Name %></h1>
        </HeaderTemplate>
        <ItemTemplate>
            <p>Description: <%#: Item.Desription %></p>
            <p>Contents: <%#: Item.Contents %></p>
            <p>Release date: <%#: Item.ReleaseDate %></p>
            <p>Producer: <%#: Item.Producer %></p>
            <p>Condition: <%#: Item.Condition %></p>
            <p>Language: <%#: Item.Language %></p>
            <p>Minimum players: <%#: Item.MinPlayers %></p>
            <p>Maximum Players: <%#: Item.MaxPlayers %></p>
            <p>Min age: <%#: Item.MinAgeOfPlayers %></p>
            <p>Max age: <%#: Item.MaxAgeOfPlayers %></p>
            <p>Owner: <%#: Item.Owner.Username %></p>
            <p>Owner: <%#: string.Format("{0:c}", Item.Price) %></p>
        </ItemTemplate>
        <FooterTemplate>
            <a href="#">Contact Owner</a>
        </FooterTemplate>
    </asp:FormView>

    <asp:LinkButton Text="Back" runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-default" />
</asp:Content>
