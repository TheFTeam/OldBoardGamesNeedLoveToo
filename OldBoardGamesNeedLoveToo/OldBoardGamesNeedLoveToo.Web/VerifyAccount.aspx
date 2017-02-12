<%@ Page Title="Verify Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerifyAccount.aspx.cs" Inherits="OldBoardGamesNeedLoveToo.Web.VerifyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h2>Verify Your Account</h2>
        <div class="col-md-8 col-lg-offset-3 text-center">
            <p>Your data will not be displayed pulblicly. Buyers of your posted games will receive your personal information in order to contact you only after booking confirmation.</p>
            <hr />
        </div>
    </header>
    <div class="col-lg-6 col-lg-offset-3 text-center">
        <asp:Panel runat="server" ID="PanelPersonalInfo" GroupingText="Personal Info">
            <p>
                <asp:TextBox runat="server" ID="TextBoxFirstName" placeholder="FirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFrstName" runat="server"
                    ErrorMessage="*First name is required"
                    ControlToValidate="TextBoxFirstName"
                    ValidationGroup="PersonalInfo">
                </asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:TextBox runat="server" ID="TextBoxLastName" placeholder="LastName" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                    ErrorMessage="*Last name is required"
                    ControlToValidate="TextBoxLastName"
                    ValidationGroup="PersonalInfo">
                </asp:RequiredFieldValidator>
            </p>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelAddressInfo" GroupingText="Address Info">
            <p>
                <asp:TextBox runat="server" ID="TextBoxAddress" placeholder="Address" CssClass="form-control" />
                <p class="text-left small"><small>*Example: Country, City/Town, Street, ZIP Code, Number</small></p>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server"
                    ErrorMessage="*Address is required"
                    ControlToValidate="TextBoxAddress" ValidationGroup="AddressInfo">
                </asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:TextBox runat="server" ID="TextBoxPhone" placeholder="Phone" CssClass="form-control" />
                <p class="text-left small"><small>*Example: 213-123-1234 | 2131231234 | (213) 123-1234</small></p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server"
                    ErrorMessage="*Phone is required"
                    ControlToValidate="TextBoxPhone" ValidationGroup="AddressInfo">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1Phone" runat="server"
                    ErrorMessage="*Phone is invalid"
                    ControlToValidate="TextBoxPhone"
                    ValidationExpression="^(\([0-9]|[0-9])(\d{2}|\d{2}\))(-|.|\s)?\d{3}(-|.|\s)?\d{4}$"
                    ValidationGroup="AddressInfo">
                </asp:RegularExpressionValidator>
            </p>
        </asp:Panel>
        <p class="text-center">
            <asp:CheckBox runat="server" ID="CheckBoxIAccept" CssClass="checkbox" />
            <span class="accept-span">I accept the terms and conditions of "Old Board Games Need Love Too Inc."</span>
            <asp:CustomValidator ID="CustomValidatorCheckBoxIAccept" runat="server"
                OnServerValidate="CustomValidatorCheckBoxIAccept_ServerValidate"
                EnableClientScript="true"
                ErrorMessage="*Please, confirm that you agree with our terms and conditions">
            </asp:CustomValidator>
        </p>
        <hr />
        <p>
            <asp:Button Text="Submit" runat="server" ID="ButtonSubmit"
                OnClick="ButtonSubmit_Click"
                CausesValidation="true"
                CssClass="btn btn-primary btn-lg" />
        </p>
    </div>
    <br />
</asp:Content>
