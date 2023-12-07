<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="PaketDuzenleSil.aspx.cs" Inherits="Seyehat.Yönetim.PaketDuzenleSil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Tur Paketi Düzenle/Sil Sayfası</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" SelectCommand="SELECT * FROM [tblTurPaket]" DeleteCommand="DELETE FROM [tblTurPaket] WHERE [Id] = @Id" InsertCommand="INSERT INTO [tblTurPaket] ([Id], [Adi], [Fiyat], [Sure], [Lokasyon], [Resim], [Detay]) VALUES (@Id, @Adi, @Fiyat, @Sure, @Lokasyon, @Resim, @Detay)" UpdateCommand="UPDATE [tblTurPaket] SET [Adi] = @Adi, [Fiyat] = @Fiyat, [Sure] = @Sure, [Lokasyon] = @Lokasyon, [Resim] = @Resim, [Detay] = @Detay WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Adi" Type="String"></asp:Parameter>
                <asp:Parameter Name="Fiyat" Type="String"></asp:Parameter>
                <asp:Parameter Name="Sure" Type="String"></asp:Parameter>
                <asp:Parameter Name="Lokasyon" Type="String"></asp:Parameter>
                <asp:Parameter Name="Resim" Type="String"></asp:Parameter>
                <asp:Parameter Name="Detay" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Adi" Type="String"></asp:Parameter>
                <asp:Parameter Name="Fiyat" Type="String"></asp:Parameter>
                <asp:Parameter Name="Sure" Type="String"></asp:Parameter>
                <asp:Parameter Name="Lokasyon" Type="String"></asp:Parameter>
                <asp:Parameter Name="Resim" Type="String"></asp:Parameter>
                <asp:Parameter Name="Detay" Type="String"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
                <asp:BoundField DataField="Adi" HeaderText="Adi" SortExpression="Adi"></asp:BoundField>
                <asp:BoundField DataField="Fiyat" HeaderText="Fiyat" SortExpression="Fiyat"></asp:BoundField>
                <asp:BoundField DataField="Sure" HeaderText="Sure" SortExpression="Sure"></asp:BoundField>
                <asp:BoundField DataField="Lokasyon" HeaderText="Lokasyon" SortExpression="Lokasyon"></asp:BoundField>
                <asp:BoundField DataField="Resim" HeaderText="Resim" SortExpression="Resim"></asp:BoundField>
                <asp:BoundField DataField="Detay" HeaderText="Detay" SortExpression="Detay"></asp:BoundField>
            </Columns>
        </asp:GridView>
</asp:Content>
