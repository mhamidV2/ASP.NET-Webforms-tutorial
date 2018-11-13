<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageLifeCycle.aspx.cs" Inherits="MyWebApplication.PageLifeCycle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Page Life Cycle Events</h2>
    <p>
        <asp:Label ID="lblInit" runat="server"/>
    </p>
    <p>
        <asp:Label ID="lblPageLoad" runat="server"/>
    </p>
    <p>
        <asp:Label ID="lblPostBack" runat="server"/>
    </p>
    <p>
        <asp:Label ID="lblButtonEvent" runat="server"/>
    </p>
    <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-primary btn-lg" OnClick="btnSubmit_OnClick" runat="server"/>

</asp:Content>
