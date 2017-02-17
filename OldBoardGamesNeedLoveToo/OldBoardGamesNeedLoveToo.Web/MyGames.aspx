<%@ Page Title="My Games" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyGames.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.MyGames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h2>My Games</h2>
        <h5>Review or update your old board games</h5>
        <br />
        <hr />
        <div class="col-md-12 add-game-btn">
            <a href="/addgame.aspx" class="btn btn-primary btn-lg">Add an Old Game</a>
        </div>
        <div class="col-md-12">
            <asp:GridView ID="GridViewMyGames" runat="server"
                ItemType="OldBoardGamesNeedLoveToo.Models.Game"
                DataKeyNames="Id"
                AutoGenerateColumns="false" CssClass="table table-responsive table-bordered">
                <Columns>
                    <asp:ImageField  DataImageUrlField="Image"></asp:ImageField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="AddedOnDate" HeaderText="Added On" SortExpression="AddedOnDate" ReadOnly="True"></asp:BoundField>
                    <asp:BoundField DataField="Producer" HeaderText="Producer" SortExpression="Producer"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:c}"></asp:BoundField>
                    <asp:CheckBoxField DataField="isSold" HeaderText="Is sold" SortExpression="isSold"></asp:CheckBoxField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ShowSelectButton="True" ControlStyle-CssClass="btn btn-group btn-default"></asp:CommandField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
