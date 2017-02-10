<%@ Page Title="Game Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.GameDetails" %>

<asp:Content ID="ContentGameDetails" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <asp:FormView ID="FormViewGameDetails" runat="server" ItemType="OldBoardGamesNeedLoveToo.Models.Game">
            <ItemTemplate>
                <div class="level level-img-right">
                    <div class="container xs-mb-30">
                        <img class="img-right-sprite" src="<%# Item.Image %>"/>">
                        <div class="row mb-60 xs-mb-20">
                            <div class="col-sm-6 col-lg-offset-1 col-lg-5">
                                <h1 class="mb-20 xs-mb-10 heading color-dark heading-bordered xl-heading-outdent"><%#: Item.Name %> Details</h1>
                                <h2 class="w-300 color-dark mb-10">A game waiting for you</h2>
                                <p class="xs-mw">
                            </div>

                            <div class=" col-md-4 visible-xs xs-mw xs-mb-30">
                                <img src="<%# Item.Image %>"/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-4 col-sm-offcet-1">
                                <div class="col-sm-3">
                                    <i class="icon icon-globe"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Description:</h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.Desription %>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="col-sm-3">
                                    <i class="icon icon-eye"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Contents:</h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.Contents %>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="col-sm-3">
                                    <i class="icon icon-calendar"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Release date</h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.ReleaseDate %>
                                </div>
                            </div>
                            <div class="col-lg-4 col-sm-offcet-1">
                                <div class="col-sm-3">
                                    <i class="icon icon-user"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Producer </h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.Producer %>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="col-sm-3">
                                    <i class="icon icon-check"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Condition </h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.Condition %>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-sm-3">
                                    <i class="icon icon-globe"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Language </h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.Language %>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-4 col-sm-offcet-1">
                                <div class="col-sm-3">
                                    <i class="icon icon-user"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Minimum players </h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.MinPlayers %>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-sm-3">
                                    <i class="icon icon-user"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Maximum Players </h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.MaxPlayers %>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="col-sm-3">
                                    <i class="icon icon-eye"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Min age</h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.MinAgeOfPlayers %>
                                </div>
                            </div>
                            <div class="col-lg-4 col-sm-offcet-1">
                                <div class="col-sm-3">
                                    <i class="icon icon-eye"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Max age</h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.MaxAgeOfPlayers %>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="col-sm-3">
                                    <i class="icon icon-user"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Owner</h3>
                                    <p class="smaller xs-mw">
                                        <%#: Item.Owner.Username %>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="col-sm-3">
                                    <i class="icon icon-bubble"></i>
                                </div>
                                <div class="col-sm-9">
                                    <h3 class="mb-15">Price</h3>
                                    <p class="smaller xs-mw">
                                        <%#: string.Format("{0:c}", Item.Price) %>
                                </div>
                            </div>
                        </div>
                        <a href="#" class="text-right">Contact Owner</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:FormView>
        <asp:LinkButton Text="Back" runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-default text-right" />
    </div>
</asp:Content>
