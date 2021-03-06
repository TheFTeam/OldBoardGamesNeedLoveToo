﻿<%@ Page Title="Account Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountInfo.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.AccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h2>Your Account Information</h2>
        <h5>Review or update your personal data</h5>
        <br />
        <hr />
        <div class="col-md-4">
            <asp:FileUpload ID="FileUploadProfilePic" runat="server" CssClass="form-control" />
            <asp:Label ID="LabelFileUploadStatus" Text=".jpg | .jpeg | .png | .gif" runat="server" CssClass="smallest" />
            <hr />
            <p>
                <asp:Button runat="server" ID="ButtonSubmitProfilePic" Text="Submit" CssClass="btn btn-primary" OnClick="ButtonSubmitProfilePic_Click" />
            </p>
        </div>
        <div class="col-md-8">
            <asp:ListView ID="ListViewUserDetails" runat="server"
                SelectMethod="ListViewUserDetails_GetData"
                UpdateMethod="ListViewUserDetails_UpdateItem"
                DeleteMethod="ListViewUserDetails_DeleteItem"
                ItemType="OldBoardGamesNeedLoveToo.Models.UserCustomInfo" DataKeyNames="Id">
                <EditItemTemplate>
                    <ul class="list-group col-md-6 text-center">
                        <li class="list-group-item">
                            <asp:Image ID="ProfileImageOfCurrentUser" runat="server" ImageUrl='<%# string.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(Item.ProfilePricture)) %>' />
                            <%--<asp:FileUpload ID="FileUploadProfilePic" runat="server" CssClass="form-control" />--%>
                            <asp:Label ID="LabelFileUploadStatus" Text=".jpg | .jpeg | .png" runat="server" CssClass="smallest" />
                        </li>
                        <li class="list-group-item">
                            <h4>Username</h4>
                            <asp:TextBox Text='<%# BindItem.Username %>' runat="server" ID="UsernameTextBox" />
                        </li>
                        <li class="list-group-item">
                            <h4>First Name</h4>
                            <asp:TextBox Text='<%# BindItem.FirstName %>' runat="server" ID="FirstNameTextBox" />
                        </li>
                        <li class="list-group-item">
                            <h4>LastName</h4>
                            <asp:TextBox Text='<%# BindItem.LastName %>' runat="server" ID="LastNameTextBox" />
                        </li>
                        <li class="list-group-item">
                            <h4>Email</h4>
                            <asp:TextBox Text='<%# BindItem.Email %>' runat="server" ID="EmailTextBox" />
                        </li>
                        <li class="list-group-item">
                            <h4>Phone</h4>
                            <asp:TextBox Text='<%# BindItem.Phone %>' runat="server" ID="PhoneTextBox" />
                        </li>
                        <li class="list-group-item">
                            <h4>Address</h4>
                            <asp:TextBox Text='<%# BindItem.Address %>' runat="server" ID="AddressTextBox" />
                        </li>
                        <li class="list-group-item">
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" CssClass="btn btn-primary" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" CssClass="btn btn-default" />
                        </li>
                    </ul>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <div class="panel panel-warning">
                        <p>
                            <strong>No data was returned.</strong>
                        </p>
                    </div>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <ul class="list-group col-md-6">
                        <li class="list-group-item">
                            <asp:Image ID="ProfileImageOfCurrentUser" runat="server" ImageUrl='<%# string.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(Item.ProfilePricture)) %>' />
                            <%--<asp:Image ID="ProfileImageOfCurrentUser" runat="server" ImageUrl="~/Content/images/Superman-profile-pic.svg.png" />--%>
                        </li>
                        <li class="list-group-item">
                            <h4>Username</h4>
                            <asp:Label Text='<%#: Item.Username %>' runat="server" ID="UsernameLabel" />
                        </li>
                        <li class="list-group-item">
                            <h4>First Name</h4>
                            <asp:Label Text='<%#: Item.FirstName %>' runat="server" ID="FirstNameLabel" />
                        </li>
                        <li class="list-group-item">
                            <h4>LastName</h4>
                            <asp:Label Text='<%#: Item.LastName %>' runat="server" ID="LastNameLabel" />
                        </li>
                        <li class="list-group-item">
                            <h4>Email</h4>
                            <asp:Label Text='<%#: Item.Email %>' runat="server" ID="EmailLabel" />
                        </li>
                        <li class="list-group-item">
                            <h4>Phone</h4>
                            <asp:Label Text='<%#: Item.Phone %>' runat="server" ID="PhoneLabel" />
                        </li>
                        <li class="list-group-item">
                            <h4>Address</h4>
                            <asp:Label Text='<%#: Item.Address %>' runat="server" ID="AddressLabel" />
                        </li>
                    </ul>
                    <p>
                        <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" CssClass="btn btn-group-lg btn-danger" />
                        <a href="/account/manage" class="btn btn-default btn-lg">Back</a>
                    </p>
                </ItemTemplate>
                <LayoutTemplate>
                    <div runat="server" id="itemPlaceholder" class="col-md-6 col-lg-offset-3"></div>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
