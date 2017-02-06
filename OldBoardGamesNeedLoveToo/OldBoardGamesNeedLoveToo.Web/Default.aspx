<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="level level-hero hero-home has-hint">
        <div class="hero-overlay visible-lg"></div>

        <video loop id="bg-video" class="fullscreen-video">
            <source src="http://alvarez.is/bt/appi.webm" type="video/webm">
            <source src="http://alvarez.is/bt/appi.mp4" type="video/mp4">
        </video>

        <div class="container full-height">
            <div class="v-align-parent">
                <div class="v-center">
                    <div class="row">
                        <div class="col-xs-10 col-sm-6">
                            <h1 class="mb-10 heading">Old Board Games <span>Need Love Too</span></h1>
                            <div class="subheading mb-20">
                                A place to sell your old board game to someone who will play it with love 
                               
                                <br class="hidden-xs">
                                A place to find an old board game which needs to be played with love 
                            </div>
                        </div>
                    </div>
                    <div>
                        <a class="btn btn-prepend btn-launch-video" href="/account/login.aspx">
                            <i class="prepended icon-append-play"></i>Login
						</a>
                        <a class="btn btn-prepend" href="#">
                            <i class="prepended icon-append-iphone"></i>Check games
						</a>
                    </div>
                </div>
            </div>
            <div class="hint-arrow"></div>
        </div>
    </div>
    <div class="level">

        <div class="container mb-100 xs-mb-40">
            <div class="row">
                <div class="col-sm-5 col-md-4 col-md-offset-2 col-sm-offset-1">
                    <h1 class="mb-10 xs-mb-10 heading color-dark heading-bordered">Browse Games<br class="hidden-xs">
                        Now</h1>
                </div>
                <br />
                <br />
                <div class="col-sm-5 col-sm-offset-1">
                    <h2 class="w-300 color-dark mb-10 xs-mb-10">Find the one to love</h2>
                    <p class="xs-mw">
                        Just call your friends and have fun                        			
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <h3>Filters</h3>
        </div>
        <div class="container">
            <div class="col-md-9">
                <asp:UpdatePanel runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:ListView ID="ListViewGames" runat="server"
                            ItemType="OldBoardGamesNeedLoveToo.Models.Game"
                            DataKeyNames="Id">
                            <ItemTemplate>
                                <div class="col-sm-3">
                                    <div class="panel panel-default">
                                        <h3 class="mb-15"><%#: Item.Name %></h3>
                                        <p class="smaller xs-mb-40 xs-mw">Producer: <%#: Item.Producer %></p>
                                        <p class="smaller xs-mb-40 xs-mw">Price: <%# string.Format("{0:c}", Item.Price) %></p>
                                        <p class="smaller xs-mb-40 xs-mw">Owner: <%#: Item.Owner.Username %></p>
                                        <p class="smaller xs-mb-40 xs-mw">Added on: <%#: Item.AddedOnDate %></p>
                                        <a runat="server" href='<%# string.Format("GameDetails.aspx?id={0}", Item.Id) %>'>Details</a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>