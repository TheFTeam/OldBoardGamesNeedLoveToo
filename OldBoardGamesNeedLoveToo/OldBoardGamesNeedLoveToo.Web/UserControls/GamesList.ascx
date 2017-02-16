﻿<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="GamesList.ascx.cs"
    Inherits="OldBoardGamesNeedLoveToo.Web.UserControls.GamesList" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxtoolkit" %>

<div class="col-md-12">
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
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="col-md-3">
                    <h3>Filters</h3>
                    <div>
                        <h5>Price - EUR</h5>
                        <p>
                            <asp:TextBox ID="TextBoxSliderPrice" runat="server" Style="display: none;" />
                            <ajaxToolkit:MultiHandleSliderExtender ID="MultiHandleSliderExtenderPrice" runat="server"
                                BehaviorID="MultiHandleSliderExtenderPrice"
                                TargetControlID="TextBoxSliderPrice"
                                Minimum="0"
                                Maximum="1000"
                                Length="175"
                                TooltipText="{0}"
                                Orientation="Horizontal"
                                EnableHandleAnimation="true"
                                EnableKeyboard="false"
                                EnableMouseWheel="false"
                                ShowHandleDragStyle="true"
                                ShowHandleHoverStyle="true">
                                <MultiHandleSliderTargets>
                                    <ajaxToolkit:MultiHandleSliderTarget ControlID="TextBoxMinPrice" />
                                    <ajaxToolkit:MultiHandleSliderTarget ControlID="TextBoxMaxPrice" />
                                </MultiHandleSliderTargets>
                            </ajaxToolkit:MultiHandleSliderExtender>
                            <br />
                            <p>
                                <asp:TextBox ID="TextBoxMinPrice" runat="server" Width="50" Text="25" />
                                <asp:TextBox ID="TextBoxMaxPrice" runat="server" Width="50" Text="750" />
                            </p>
                    </div>
                    <hr />
                    <div>
                        <h5>Number of Players</h5>
                        <p>
                            <asp:TextBox ID="TextBoxSliderNumberOfPlayers" runat="server" Style="display: none;" />
                            <ajaxToolkit:MultiHandleSliderExtender ID="MultiHandleSliderExtenderNumberOfPlayers" runat="server"
                                BehaviorID="MultiHandleSliderExtenderNumberOfPlayers"
                                TargetControlID="TextBoxSliderNumberOfPlayers"
                                Minimum="2"
                                Maximum="20"
                                Length="175"
                                TooltipText="{0}"
                                Orientation="Horizontal"
                                EnableHandleAnimation="true"
                                EnableKeyboard="false"
                                EnableMouseWheel="false"
                                ShowHandleDragStyle="true"
                                ShowHandleHoverStyle="true">
                                <MultiHandleSliderTargets>
                                    <ajaxToolkit:MultiHandleSliderTarget ControlID="TextBoxMinPlayers" />
                                    <ajaxToolkit:MultiHandleSliderTarget ControlID="TextBoxMaxPlayers" />
                                </MultiHandleSliderTargets>
                            </ajaxToolkit:MultiHandleSliderExtender>
                            <br />
                            <p>
                                <asp:TextBox ID="TextBoxMinPlayers" runat="server" Width="50" Text="5" />
                                <asp:TextBox ID="TextBoxMaxPlayers" runat="server" Width="50" Text="13" />
                            </p>
                    </div>
                    <hr />
                    <div>
                        <h5>Age Appropriate</h5>
                        <p>
                            <asp:TextBox ID="TextBoxSliderAgeAppropriate" runat="server" Style="display: none;" />
                            <ajaxToolkit:MultiHandleSliderExtender ID="MultiHandleSliderExtenderAgeAppropriate" runat="server"
                                BehaviorID="MultiHandleSliderExtenderAgeAppropriate"
                                TargetControlID="TextBoxSliderAgeAppropriate"
                                Minimum="2"
                                Maximum="100"
                                Length="175"
                                TooltipText="{0}"
                                Orientation="Horizontal"
                                EnableHandleAnimation="true"
                                EnableKeyboard="false"
                                EnableMouseWheel="false"
                                ShowHandleDragStyle="true"
                                ShowHandleHoverStyle="true">
                                <MultiHandleSliderTargets>
                                    <ajaxToolkit:MultiHandleSliderTarget ControlID="TextBoxMinAge" />
                                    <ajaxToolkit:MultiHandleSliderTarget ControlID="TextBoxMaxAge" />
                                </MultiHandleSliderTargets>
                            </ajaxToolkit:MultiHandleSliderExtender>
                            <br />
                            <p>
                                <asp:TextBox ID="TextBoxMinAge" runat="server" Width="50" Text="15" />
                                <asp:TextBox ID="TextBoxMaxAge" runat="server" Width="50" Text="100" />
                            </p>
                    </div>
                    <hr />
                    <div>
                        <h5>Category</h5>
                        <asp:DropDownList ID="DropDownListCategories" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <hr />
                    <div>
                        <h5>Condition</h5>
                        <asp:DropDownList ID="DropDownListCondition" runat="server" DataValueField="" AutoPostBack="false">
                            <asp:ListItem Value="0">Excellent</asp:ListItem>
                            <asp:ListItem Value="1">VeryGood</asp:ListItem>
                            <asp:ListItem Value="2">Good</asp:ListItem>
                            <asp:ListItem Value="3">Poor</asp:ListItem>
                            <asp:ListItem Value="4">Very Poor</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <hr />
                    <div>
                        <h5>Release Date</h5>
                        <p>
                            <asp:TextBox runat="server" ID="TextBoxReleaseDateFrom" TextMode="Date" Text="<%# DateTime.MinValue %>" />
                            <asp:TextBox runat="server" ID="TextBoxReleaseDateTo" TextMode="Date" Text="<%# DateTime.Now %>" />
                        </p>
                    </div>
                    <hr />
                    <div class="text-center">
                        <asp:Button ID="ButtonFilterSubmit" CommandName="Submit" Text="Filter" runat="server" OnClick="ButtonFilterSubmit_Click" CssClass="btn btn-danger" />
                        <asp:Button ID="ButtonReset" CommandName="Cancel" Text="Reset" runat="server" OnClick="ButtonReset_Click" CssClass="btn btn-default" />                    
                    </div>
                    <hr />
                </div>
                <div class="col-md-9">
                    <asp:ListView ID="ListViewGames" runat="server"
                        ItemType="OldBoardGamesNeedLoveToo.Models.Game"
                        DataKeyNames="Id">
                        <ItemTemplate>
                            <div class="col-md-3">
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
                    </asp:ListView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
