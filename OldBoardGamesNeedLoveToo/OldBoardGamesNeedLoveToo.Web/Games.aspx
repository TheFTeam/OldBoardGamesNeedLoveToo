<%@ Page Title="Board Games" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.Games" %>

<%@ Register Src="~/UserControls/GamesList.ascx" TagPrefix="userControls"
    TagName="GamesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
            <userControls:GamesList runat="server" ID="DefaultGamesList"></userControls:GamesList>
        </div>
    </div>
</asp:Content>
