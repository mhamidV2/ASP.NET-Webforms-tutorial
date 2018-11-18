<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataBindingExample.aspx.cs" Inherits="MyWebApplication.DataBindingExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Data Binding Example</h1>
    <h4>
        <asp:Literal ID="ltError" runat="server"/>
    </h4>
    
    <asp:GridView ID="gvColors" CssClass="table table-striped color-table" AutoGenerateColumns="false" 
        OnRowDeleting="gvColors_OnRowDeleting" 
        OnRowEditing="gvColors_OnRowEditing" 
        OnRowUpdating="gvColors_OnRowUpdating" 
        OnRowCancelingEdit="gvColors_OnRowCancelingEdit"
        GridLines="None"
        runat="server"
    >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hdnColorId" Value='<%#DataBinder.Eval(Container.DataItem, "id") %>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="display_name" HeaderText="Name"/>
            <asp:BoundField DataField="hex_code" HeaderText="Hex"/>
            <asp:TemplateField HeaderText="Color Swatch">
                <ItemTemplate>
                    <div class="color-swatch">
                        <div class="color-swatch" style='padding:16px;width:100%;<%# "background-color:" + Eval("hex_code") + ";" %>'></div>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True"/>
            <asp:CommandField ShowDeleteButton="True"/>
        </Columns>
    </asp:GridView>
    <div class="row color-table">
        <asp:Button ID="btnAddRow" Text="Add New Row" CssClass="btn btn-primary" OnClick="btnAddRow_OnClick" runat="server"/>
    </div>
</asp:Content>
