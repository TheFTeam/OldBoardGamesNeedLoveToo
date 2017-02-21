<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <div class="level level-img-right">
            <div class="container xs-mb-30">
                <div class="row mb-60 xs-mb-20">
                    <div class="col-sm-6 col-lg-offset-1 col-lg-5">
                        <h1 class="mb-20 xs-mb-10 heading color-dark heading-bordered xl-heading-outdent"><%: Title %></h1>
                        <h2>OldBoardGamesNeedLoveToo is a website for people to find the board games they've always desired</h2>
                        <p class="xs-mw">
                        </p>
                    </div>
                    <img src="Content/images/diceWithHerats.jpg" width="200" class="pull-right" />
                    <br />
                </div>
                <div class="col-md-12>">
                    <p>Users connect with other board games lovers, find people who will love their old board games and find people who want to give/sell their old board game</p>
                    <br />
                    <h3>The site includes cool features like:</h3>
                    <ul>
                        <li>Adding a detailed information about the game they want to give/sell.</li>
                        <li>Browsing a collection of cool board games</li>
                        <li>Searching a type of game by name</li>
                        <li>Filtering game results</li>
                        <li>Commenting cool games with other users</li>
                        <li>Rate other users who love board games</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
