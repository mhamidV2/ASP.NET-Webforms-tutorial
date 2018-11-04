<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyWebApplication.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
    <div>
        <label>Name</label>
        <asp:TextBox ID="txtName" CssClass="text-box" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" ControlToValidate="txtName" ErrorMessage="*" runat="server"/>
    </div>
    <div>
        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revEmail" ControlToValidate="txtEmail" ErrorMessage="Required." Display="Dynamic" ValidationExpression="^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" runat="server"/>
        <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" ErrorMessage="Required." Display="Dynamic"  runat="server"/>

    </div>
    <div>
        <label>Age</label>
        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
    </div>
    <div>
        <label>Your Favorite Color</label>
        <asp:DropDownList ID="ddlColor" runat="server">
            <asp:ListItem Text="Please Chose a color" Value=""/>
            <asp:ListItem Text="Blue" Value="Blue"/>
            <asp:ListItem Text="Red" Value="Red"/>
            <asp:ListItem Text="Green" Value="Green"/>
            <asp:ListItem Text="Yellow" Value="Yellow"/>
            <asp:ListItem Text="Orange" Value="Orange"/>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvColor" ControlToValidate="ddlColor" ErrorMessage="Color Required." Display="Dynamic"  runat="server"/>

    </div>
    
    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Info" OnClick="btnSubmit_OnClick"/>
    </div>
    <div class="">
        <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
    </div>
        
</asp:Content>
