<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectCalculation.aspx.cs" Inherits="MyWebApplication.ProjectCalculation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Get a Quote For Your Custom Project.</h1>
    <p class="lead">Base Price: <asp:Literal ID="ltBasePrice" runat="server"/></p>
    <p>We primarly serve the western half of te United States. East of Colorado we charge a flat state fee rate of $49.99. West Coast rates are less, but </p>
    <div class="form-group">
        <label>Your State</label>
        <asp:DropDownList  ID="ddlStates" CssClass="form-control" OnSelectedIndexChanged="ddlStates_OnSelectedIndexChanged" AutoPostBack="True" runat="server">
            <asp:ListItem Value="">Select Your State</asp:ListItem>
            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
            <asp:ListItem Value="CA">California</asp:ListItem>
            <asp:ListItem Value="IN">Indiana</asp:ListItem>
            <asp:ListItem Value="NY">New York</asp:ListItem>
            <asp:ListItem Value="AR">Arkansas</asp:ListItem>
            <asp:ListItem Value="CO">Colorado</asp:ListItem>
            <asp:ListItem Value="CT">Connecticut</asp:ListItem>
            <asp:ListItem Value="AK">Alaska</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="jumbotron">
        <h3>Your Custom Price: <asp:Literal ID="ltCustomPrice" Text="(select your state to get price)" runat="server"/></h3>
    </div>
 </asp:Content>
