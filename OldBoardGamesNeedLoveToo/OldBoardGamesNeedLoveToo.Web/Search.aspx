<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <asp:ListView ID="ListViewSearchResultsGames" runat="server" SelectMethod="ListViewSearchResultsGames_GetData"
            ItemType="OldBoardGamesNeedLoveToo.Models.Game" ItemPlaceholderID="groupGamesPlaceHolder"
            DataKeyNames="Id">
            <ItemTemplate>
                <div class="col-md-3 game-container">
                    <div class="panel panel-default">
                        <h3 class="mb-15 text-center"><a runat="server" href='<%# string.Format("/GameDetails.aspx?id={0}", Item.Id) %>'><%#: Item.Name %></a></h3>
                        <asp:Image ID="ImageOfGame" runat="server" ImageUrl='<%# string.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(Item.Image)) %>' Width="200" />
                        <p class="smaller xs-mb-40 xs-mw">Producer: <%#: Item.Producer %></p>
                        <p class="smaller xs-mb-40 xs-mw">Price: <%# string.Format("{0:c}", Item.Price) %></p>
                        <p class="smaller xs-mb-40 xs-mw">Added on: <%#: string.Format("{0:dd/MM/ yyyy}", Item.AddedOnDate) %></p>
                        <a runat="server" href='<%# string.Format("/GameDetails.aspx?id={0}", Item.Id) %>'>Details</a>
                    </div>
                </div>
            </ItemTemplate>
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="groupGamesPlaceHolder"></asp:PlaceHolder>
                <div class="col-md-12 text-center">
                    <asp:DataPager ID="DataPagerGamesList" runat="server" PagedControlID="ListViewSearchResultsGames" PageSize="8">
                        <Fields>
                            <asp:NumericPagerField ButtonType="Link" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
        </asp:ListView>
    </div>
    <div class="col-md-12">
        <a class="btn btn-default" href="/games">All Games</a>
    </div>
</asp:Content>
