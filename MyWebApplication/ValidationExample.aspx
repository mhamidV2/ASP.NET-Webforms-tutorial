<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidationExample.aspx.cs" Inherits="MyWebApplication.ValidationExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Validation Example</h1>
    <div class="form-group">
        <div class="form-text">
            *Fields marked with an asterix are required
        </div>
    </div>
    <p class="panel-primary">
        <asp:Literal ID="ltMessage" runat="server" />
        <asp:ValidationSummary ID="valSummaryForm" CssClass="text-danger"  ValidationGroup="valForm" DisplayMode="BulletList" HeaderText="Please fix the following errors:" Visible="False" runat="server"/>
    </p>
    <div class="form-group">
        <label>* Your Full Name:</label>
        <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server" />
        <asp:RequiredFieldValidator ID="rqFullName" ControlToValidate="txtFullName" ValidationGroup="valForm" CssClass="text-danger" ErrorMessage="*Full name required." Display="Dynamic" runat="server" />
    </div>
    <div class="form-group">
        <label>Your Nickname</label>
        <asp:TextBox ID="txtNickname" CssClass="form-control" runat="server" />
    </div>
    <div class="form-group">
        <label>*Your Age</label>
        <asp:TextBox ID="txtAge" CssClass="form-control" runat="server"/>
        <asp:RequiredFieldValidator ID="rqAge" ControlToValidate="txtAge" ValidationGroup="valForm" CssClass="text-danger" ErrorMessage="*Age is required" Display="Dynamic" runat="server" />
        <asp:RangeValidator ID="rvAge" ControlToValidate="txtAge" ValidationGroup="valForm" Type="Integer" MinimumValue="4" MaximumValue="120" CssClass="text-danger" ErrorMessage="I find it hard to believe that is your age. Please enter your real age." Display="Dynamic" runat="server"/>
    </div>
    <div class="form-group">
        <label>*Your Email Address:</label>
        <asp:TextBox ID="txtEmailAddress" CssClass="form-control" runat="server"/>
        <asp:RequiredFieldValidator ID="rqEmailAddress" ControlToValidate="txtEmailAddress" ValidationGroup="valForm" CssClass="text-danger"  ErrorMessage="*Email Address is required" runat="server" />
    </div>
    <div class="form-group">
        <label>*Name a Price (in USD):</label>
        <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"/>
        <asp:RequiredFieldValidator ID="rqPrice" ControlToValidate="txtPrice" ValidationGroup="valForm" CssClass="text-danger" ErrorMessage="*Price is required" Display="Dynamic" runat="server" />
        <asp:CompareValidator ID="cvPrice" ControlToValidate="txtPrice" CssClass="text-danger"  Operator="DataTypeCheck" Type="Currency" ValidationGroup="valForm" ErrorMessage="Please enter a valid price." runat="server"/>
    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" CssClass="btn btn-success" Text="Submit" OnClick="btnSubmit_OnClick" ValidationGroup="valForm" CausesValidation="True" runat="server"/>
    </div>
</asp:Content>
