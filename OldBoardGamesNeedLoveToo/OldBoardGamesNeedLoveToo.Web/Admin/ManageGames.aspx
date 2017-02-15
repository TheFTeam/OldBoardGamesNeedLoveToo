<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManageGames.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.Admin.ManageGames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewGames" runat="server"
        ItemType="OldBoardGamesNeedLoveToo.Models.Game"
        DataKeyNames="Id">
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <span><%#: Item.Name %></span>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <EditItemTemplate >

        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
