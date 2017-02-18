<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManageGames.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.Admin.ManageGames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewGames" runat="server"
        SelectMethod="ListViewGames_GetData"
        UpdateMethod="ListViewGames_UpdateItem"
        ItemType="OldBoardGamesNeedLoveToo.Models.Game"
        DataKeyNames="Id">
        <LayoutTemplate>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th></th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Contents</th>
                        <th>Category</th>
                        <th>Image</th>
                        <th>Condition</th>
                        <th>MinPlayers</th>
                        <th>MaxPlayers</th>
                        <th>MinAgeOfPlayers</th>
                        <th>MaxAgeOfPlayers</th>
                        <th>Language</th>
                        <th>Release Date</th>
                        <th>Producer</th>
                        <th>Price</th>
                        <th>isSold</th>
                        <th>OwnerId</th>
                        <th>BuyerId</th>
                    </tr>
                </thead>
                <tbody id="itemPlaceholder" runat="server"></tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" CssClass="btn" />
                </td>
                <td><%#: Item.Name %></td>
                <td><%#: Item.Desription%> </td>
                <td><%#: Item.Contents%></td>
                <td><%#: Item.Categories.Count %></td>
                <td>
                    <asp:Image ID="ImageOfGame2" runat="server" CssClass="img-thumbnail" ImageUrl='<%# string.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(Item.Image)) %>' />
                </td>
                <td><%#: Item.Condition%></td>
                <td><%#: Item.MinPlayers%></td>
                <td><%#: Item.MaxPlayers%></td>
                <td><%#: Item.MinAgeOfPlayers%></td>
                <td><%#: Item.MaxAgeOfPlayers%></td>
                <td><%#: Item.ReleaseDate%></td>
                <td><%#: Item.Language%></td>
                <td><%#: Item.Producer%></td>
                <td><%#: Item.Price%></td>
                <td><%#: Item.isSold%></td>
                <td><%#: Item.OwnerId%></td>
                <td><%#: Item.BuyerId%></td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr style="background-color: #008A8C; color: #FFFFFF;">
                <td>
                    <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                </td>
                <td>
                    <asp:TextBox Text="<%# BindItem.Name %>" runat="server" ID="Name"/>
                </td>
                <td>
                    <asp:TextBox Text='<%# BindItem.Desription %>' runat="server" ID="Description"/>
                </td>
                <td>
                    <asp:TextBox Text='<%# BindItem.Contents %>' runat="server" ID="Contents"/>
                </td>
                <td>
                    <%--<asp:DropDownList DataTextField="Categories" runat="server"  ItemType="OldBoardGamesNeedLoveToo.Models.Category" SelectMethod="ListViewGames_GetCategories" ID="Categories" />--%>
                </td>
                <td>
                    <asp:FileUpload  runat="server" CssClass="form-control" ID="Image"/>
                </td>

                <td>
                    <asp:DropDownList  runat="server" SelectedValue="<%# BindItem.Condition %>" AutoPostBack="false" ID="Condition">
                        <asp:ListItem Value="Excellent">Excellent</asp:ListItem>
                        <asp:ListItem Value="VeryGood">VeryGood</asp:ListItem>
                        <asp:ListItem Value="Good">Good</asp:ListItem>
                        <asp:ListItem Value="Poor">Poor</asp:ListItem>
                        <asp:ListItem Value="Very Poor">Very Poor</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>

                    <asp:TextBox Text='<%# BindItem.MinPlayers %>' runat="server" ID="MinPlayers" />
                </td>
                <td>
                    <asp:TextBox Text='<%# BindItem.MaxPlayers %>' runat="server" ID="MaxPlayers" />
                </td>
                <td>
                    <asp:TextBox Text='<%# BindItem.MinAgeOfPlayers %>' runat="server" ID="MinAgePlayers" />
                </td>
                <td>
                    <asp:TextBox Text='<%# BindItem.MaxAgeOfPlayers %>' runat="server" ID="MaxAgePlayers" />
                </td>
                <td>
                    <asp:TextBox TextMode="Date" runat="server" Text='<%# BindItem.ReleaseDate %>' ID="Date"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox Text='<%# BindItem.Language %>' runat="server" ID="Language" />
                </td>
                <td>
                    <asp:TextBox Text='<%# BindItem.Producer %>' runat="server" ID="Producer"/>
                </td>
                <td>
                    <asp:TextBox Text='<%# BindItem.Price %>' runat="server" ID="Price" />
                </td>
                <td>
                    <asp:CheckBox Checked='<%# BindItem.isSold %>' Text="isSold" runat="server" ID="isSold"  />
                <td>
                    <asp:TextBox Text='<%# BindItem.OwnerId %>' runat="server" ID="OnwerId" />
                </td>
                <td>
                    <asp:TextBox Text='<%# BindItem.BuyerId %>' runat="server" ID="BuyerId" />
                </td>
                
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
