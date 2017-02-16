<%@ Page Title="Add Game" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGame.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.AddGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-6">
        <h2>Add Game</h2>
        <h5>Add an old game to find someone to love</h5>
        <br />
    </div>
    <div class="col-md-6">
        <a href="/mygames" class="btn btn-default btn-lg pull-right">Back</a>
    </div>
    <hr />
    <div class="col-md-12">
        <div class="col-lg-6 col-lg-offset-3 text-center">
            <asp:Panel runat="server" ID="DisplayGameInfo" GroupingText="Display Game Info" CssClass="input-group">
                <p>
                    <asp:TextBox runat="server" ID="TextBoxName" placeholder="Name of the game" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server"
                        ErrorMessage="*Name of the game is required"
                        ControlToValidate="TextBoxName"
                        ValidationGroup="DisplayGameInfo">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:FileUpload ID="FileUploadGameImage" runat="server" CssClass="form-control" />
                    <asp:Label ID="LabelFileUploadStatus" Text=".jpg | .jpeg | .png | .gif" runat="server" CssClass="smallest" />
                    <br />
                </p>
                <p>
                    <asp:TextBox ID="TextBoxProducer" runat="server" placeholder="Producer" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorProducer" runat="server"
                        ErrorMessage="Producer is required"
                        ValidationGroup="DisplayGameInfo"
                        ControlToValidate="TextBoxProducer">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="TextBoxPrice" placeholder="Price" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" runat="server"
                        ValidationGroup="DisplayGameInfo"
                        ErrorMessage="*Price is required"
                        ControlToValidate="TextBoxPrice">
                    </asp:RequiredFieldValidator>
                    <%--<asp:RangeValidator ID="RangeValidatorPrice" runat="server"
                        ErrorMessage="*Price should not be negative"
                        MinimumValue="0"
                        MaximumValue="100000000"
                        ControlToValidate="TextBoxPrice">
                    </asp:RangeValidator>--%>
                </p>
            </asp:Panel>

            <asp:Panel runat="server" ID="DetailedGameInfo" GroupingText="Detailed Game Info">
                <p>
                    <asp:TextBox runat="server" ID="TextBoxDescription"
                        TextMode="MultiLine" placeholder="Description" CssClass="form-control" Width="470" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server"
                        ErrorMessage="*Description is required"
                        ControlToValidate="TextBoxDescription"
                        ValidationGroup="DetailedGameInfo">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="TextBoxContents" placeholder="Content" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContents" runat="server"
                        ErrorMessage="*Content is required"
                        ControlToValidate="TextBoxContents"
                        ValidationGroup="DetailedGameInfo">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:DropDownList ID="DropDownListCondition" runat="server" AutoPostBack="false" CssClass="dropdown form-control" DataTextField="-- Condition --">
                        <asp:ListItem Text="Excellent" Value="0" />
                        <asp:ListItem Text="Very Good" Value="1" />
                        <asp:ListItem Text="Good" Value="2" />
                        <asp:ListItem Text="Poor" Value="3" />
                        <asp:ListItem Text="Very Poor" Value="4" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorCondition" runat="server"
                        ErrorMessage="*Condition is required"
                        ValidationGroup="DetailedGameInfo"
                        ControlToValidate="DropDownListCondition">
                    </asp:RequiredFieldValidator>
                </p>
                <br />
                <p>
                    <asp:TextBox runat="server" TextMode="Date" ID="TextBoxReleaseDate" CssClass="form-control" />
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorReleaseDate" runat="server"
                        ControlToValidate="TextBoxReleaseDate"
                        ValidationGroup="DetailedGameInfo"
                        ErrorMessage="*Release date is required">
                    </asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="TextBoxLanguage" placeholder="Language" CssClass="form-control" />
                </p>
                <p>
                    <asp:TextBox runat="server" ID="TextBoxMinPlayers" placeholder="Minimum Number of Players" TextMode="Number" CssClass="form-control" />
                    <asp:RangeValidator ID="RangeValidatorMinPlayers" runat="server"
                        ErrorMessage="*Minimum number of players is 1 and should not be negative"
                        MinimumValue="1"
                        MaximumValue="100"
                        ValidationGroup="DetailedGameInfo"
                        ControlToValidate="TextBoxMinPlayers">
                    </asp:RangeValidator>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="TextBoxMaxPlayers" placeholder="Maximum Number of Players" TextMode="Number" CssClass="form-control" />
                    <asp:RangeValidator ID="RangeValidatorMaxPlayers" runat="server"
                        ErrorMessage="*Maximum number of players is 100 and should not be negative"
                        MinimumValue="1"
                        MaximumValue="20"
                        ValidationGroup="DetailedGameInfo"
                        ControlToValidate="TextBoxMaxPlayers">
                    </asp:RangeValidator>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="TextBoxMinAgeOfPlayers" placeholder="Minimum Age of Players" TextMode="Number" CssClass="form-control" />
                    <%--<asp:rangevalidator id="rangevalidatorminageofplayers" runat="server"
                        ErrorMessage="*minimum age of players is 2 and should not be negative" 
                        ForeColor="BurlyWood"
                        minimumvalue="2"
                        maximumvalue="100"
                        validationgroup="detailedgameinfo"
                        ControlToValidate="TextBoxMinAgeOfPlayers">
                    </asp:rangevalidator>--%>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="TextBoxMaxAgeOfPlayers" placeholder="Maximum Age of Players" TextMode="Number" CssClass="form-control" />
                    <%--<asp:RangeValidator ID="RangeValidatorMaxEgeofPlayers" runat="server"
                        ErrorMessage="*Maximum age of players is 100 and should not be negative"
                        ForeColor="BurlyWood"
                        MinimumValue="2"
                        MaximumValue="100"
                        ValidationGroup="DetailedGameInfo"
                        ControlToValidate="TextBoxMaxAgeOfPlayers">
                    </asp:RangeValidator>--%>
                </p>
            </asp:Panel>
        </div>
        <div class="col-md-12 text-center">
            <hr />
            <p>
                <asp:Button Text="Submit" runat="server" ID="ButtonSubmit"
                    CausesValidation="true"
                    OnClick="ButtonSubmit_Click"
                    CssClass="btn btn-primary btn-lg" />
            </p>
        </div>
    </div>
</asp:Content>
