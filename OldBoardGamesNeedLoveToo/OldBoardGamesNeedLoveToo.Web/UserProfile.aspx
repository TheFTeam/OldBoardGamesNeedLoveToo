<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.UserProfile" %>

<%@ Register Src="~/UserControls/GamesList.ascx" TagPrefix="userControls"
    TagName="GamesList" %>

<%@ Register Src="~/UserControls/Rating.ascx" TagPrefix="userControls"
    TagName="Rating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormViewUserProfile" runat="server" ItemType="OldBoardGamesNeedLoveToo.Models.UserCustomInfo">
        <ItemTemplate>
            <div class="col-md-12 xs-mb-30">
                <div class="container xs-mb-30 col-md-8">
                    <div class="row mb-60 xs-mb-20">
                        <div class="col-md-6">
                            <asp:Image ID="ProfilePic" runat="server" CssClass="img-fluid" Width="400" ImageUrl='<%# string.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(Item.ProfilePricture)) %>'/>
                        </div>
                        <div class="col-sm-6 col-lg-offset-1 col-lg-5">
                            <h2 class="mb-20 xs-mb-10 heading color-dark heading-bordered xl-heading-outdent">Meet <%#: Item.Username %></h2>
                            <h3 class="w-300 color-dark mb-10">Find friends who share their old board games</h3>
                            <p class="xs-mw">
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <h4>Name  <%# Item.FirstName %> <%# Item.LastName %></h4>
                <h4>Email  <%# Item.Email %></h4>
                <h4>Phone  <%# Item.Phone %></h4>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <div class="col-md-12">
        <userControls:Rating runat="server" ID="UserControlRating"></userControls:Rating>
    </div>
    <br />
    <br />
    <hr />
    <div class="col-md-12">
        <userControls:GamesList runat="server" ID="UserProfileGamesList"></userControls:GamesList>
    </div>
</asp:Content>
