<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="BlogDuzenleSil.aspx.cs" Inherits="SeyehatWeb.Yönetim.BlogDuzenleSil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Blog Düzenleme / Silme Sayfası</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" ProviderName="<%$ ConnectionStrings:dbGoTripConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [tblBlog]"></asp:SqlDataSource>
</asp:Content>
