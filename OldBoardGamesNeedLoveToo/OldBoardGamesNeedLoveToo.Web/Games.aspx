<%@ Page Title="Board Games" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.Games" %>

<%@ Register Src="~/UserControls/GamesList.ascx" TagPrefix="userControls"
    TagName="GamesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <userControls:GamesList runat="server" ID="DefaultGamesList"></userControls:GamesList>
</asp:Content>
