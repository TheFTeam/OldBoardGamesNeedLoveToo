<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="Rating.ascx.cs"
    Inherits="OldBoardGamesNeedLoveToo.Web.UserControls.Rating" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxtoolkit" %>

<style type="text/css">
    .starRating {
        width: 50px;
        height: 50px;
        cursor: pointer;
        background-repeat: no-repeat;
        display: block;
    }

    .filledStars {
        background-image: url("../Content\images\full-star-image-50px.png");
    }

    .emptyStars {
        background-image: url("../Content\images\empty-star-image-50px.png");
    }

    .savedRatingStar {
        background-image: url("../Content/images/full-star-image-50px.png");
    }
</style>

<div class="rating-container">
    <asp:UpdatePanel ID="UpdatePanelRating" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <ajaxToolkit:Rating ID="RatingAjaxToolkit" runat="server"
                StarCssClass="starRating"
                Direction="LeftToRight"
                FilledStarCssClass="filledStars"
                EmptyStarCssClass="emptyStars"
                WaitingStarCssClass="savedRatingStar"
                AutoPostBack="true"
                OnChanged="RatingAjaxToolkit_Changed"
                MaxRating="5">
            </ajaxToolkit:Rating>
            <asp:Button Text="Rate" runat="server" ID="ButtomRateSumbit" CssClass="btn btn-default"/>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
