<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="BlogDuzenleSil.aspx.cs" Inherits="SeyehatWeb.Yönetim.BlogDuzenleSil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Blog Düzenleme / Silme Sayfası</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" SelectCommand="SELECT * FROM [tblBlog]" DeleteCommand="DELETE FROM [tblBlog] WHERE [Id] = @Id" InsertCommand="INSERT INTO [tblBlog] ([Baslik], [Ozet], [KategoriId], [Resim], [Detay], [Tarih]) VALUES (@Baslik, @Ozet, @KategoriId, @Resim, @Detay, @Tarih)" UpdateCommand="UPDATE [tblBlog] SET [Baslik] = @Baslik, [Ozet] = @Ozet, [KategoriId] = @KategoriId, [Resim] = @Resim, [Detay] = @Detay, [Tarih] = @Tarih WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Baslik" Type="String"></asp:Parameter>
            <asp:Parameter Name="Ozet" Type="String"></asp:Parameter>
            <asp:Parameter Name="KategoriId" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Resim" Type="String"></asp:Parameter>
            <asp:Parameter Name="Detay" Type="String"></asp:Parameter>
            <asp:Parameter Name="Tarih" Type="DateTime"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Baslik" Type="String"></asp:Parameter>
            <asp:Parameter Name="Ozet" Type="String"></asp:Parameter>
            <asp:Parameter Name="KategoriId" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Resim" Type="String"></asp:Parameter>
            <asp:Parameter Name="Detay" Type="String"></asp:Parameter>
            <asp:Parameter Name="Tarih" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" CssClass="table table-striped" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#Eval("id","BlogDuzenleSecilen.aspx?id={0}") %>' runat="server">Duzenle</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="False"></asp:CommandField>
        </Columns>
    </asp:GridView>
</asp:Content>
