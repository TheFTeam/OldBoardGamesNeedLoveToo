<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentsList.ascx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.UserControls.CommentsList" %>


<div class="comments-container">
    <asp:UpdatePanel runat="server" ID="UpdatePanelComments" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <div class="panel panel-defaut">
                <p>
                    <h3>Leave Your Comment Here</h3>
                </p>
                <ul class="comments-list">
                    <li>Comment
                    </li>
                </ul>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="5000" />
    <div class="col-md-12">
        <div class="col-md-4">
            <asp:TextBox ID="TextBoxInputComment" runat="server" placeholder="What do you think about this game?" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonSubmitComment" runat="server" Text="Comment" CssClass="btn btn-primary" />
        </div>
    </div>
</div>