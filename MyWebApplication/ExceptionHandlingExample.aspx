<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExceptionHandlingExample.aspx.cs" Inherits="MyWebApplication.ExceptionHandlingExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exception Handling Example</h1>
    <asp:Label ID="lblMessage" CssClass="alert-danger" runat="server" Visible="False"></asp:Label>
    <div class="form-group">
        <label>This should be a decimal: </label>
        <asp:TextBox ID="txtDecimal" CssClass="form-control" runat="server"/>
    </div>
    <div class="form-group">
        <asp:Button ID="btnSubmit" CssClass="btn btn-success" Text="Submit" OnClick="btnSubmit_OnClick" runat="server"/>
    </div>
</asp:Content>
