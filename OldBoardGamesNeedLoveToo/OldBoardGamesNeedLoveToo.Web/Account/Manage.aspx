<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %> </h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-4">
                <h4>Change your account settings</h4>
                <hr />
                <div class="dl-horizontal">
                    <%--<dt>Password:</dt>--%>
                    <p>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Change Password" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Create Password" Visible="false" ID="CreatePassword" runat="server" />
                    </p>
                    <%--<dt>External Logins:</dt>--%>
                    <p>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="Manage External Logins - " runat="server" /><%: LoginsCount %>
                    </p>
                    <%--
                        Phone Numbers can used as a second factor of verification in a two-factor authentication system.
                        See <a href="http://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                        for details on setting up this ASP.NET application to support two-factor authentication using SMS.
                        Uncomment the following blocks after you have set up two-factor authentication
                    --%>
                    <%--
                    <dt>Phone Number:</dt>
                    <% if (HasPhoneNumber)
                       { %>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Add]" />
                    </dd>
                    <% }
                       else
                       { %>
                    <dd>
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Change]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Remove]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    <% } %>
                    --%>

                    <%--<dt>Two-Factor Authentication:</dt>
                    <dd>
                        <p>
                            There are no two-factor authentication providers configured. See <a href="http://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                            for details on setting up this ASP.NET application to support two-factor authentication.
                        </p>--%>
                    <% if (TwoFactorEnabled)
                        { %>
                    <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                    --%>
                    <% }
                        else
                        { %>
                    <%--
                        Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                    --%>
                    <% } %>
                    </dd>
                </div>
            </div>
            <div class="col-md-4">
                <h4>Verify/Update Account</h4>
                <hr />
                <p>
                    <a id="HyperUserProfile" href='<%= string.Format("/userprofile.aspx?username={0}", GetCurrentUserProfileFromQueryString()) %>'>View your public profile</a>
                </p>
                Or
                <p>
                    <a id="HyperlinkAccountInfo" href="/accountinfo.aspx">Update Your Account Information</a>
                </p>
            </div>
            <div class="col-md-4">
                <h4>My Old Board Games</h4>
                <hr />
                <p>
                    <asp:HyperLink ID="HyperlinkAddGame" NavigateUrl="~/mygames.aspx" Text="Add a game to sell. It's easy and takes only few minutes." runat="server" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
