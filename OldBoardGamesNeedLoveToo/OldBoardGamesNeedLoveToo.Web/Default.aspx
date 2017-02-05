<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Old Board Games Need Love Too</h1>
        <p class="lead">A place to sell your old board game to someone who will play it with love.</p>
        <p class="lead">A place to find an old board game which needs to be played with love.</p>

        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-3">
        <h3>Filters</h3>
    </div>
    <div class="col-md-9">
        <asp:ListView ID="ListViewGames" runat="server" ItemType="OldBoardGamesNeedLoveToo.Models.Game" DataKeyNames="Id">
            <ItemTemplate>
                <div class="col-md-3">
                    <div class="panel panel-default">
                        <h2><%#: Item.Name %></h2>
                        <p>Producer: <%#: Item.Producer %></p>
                        <p>Price: <%# string.Format("{0:c}", Item.Price) %></p>
                        <p>Owner: <%#: Item.Owner.Username %></p>
                        <a href='<%#: string.Format("/gamedetails?id={0}", Item.Id) %>'>View more</a>
                        <p>Added on: <%#: Item.AddedOnDate %></p>
                    </div>
                </div>
            </ItemTemplate>            
        </asp:ListView>
    </div>
</asp:Content>
