<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="BlogEkle.aspx.cs" Inherits="Seyehat.Yönetim.BlogEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Yeni Blog Ekleme Sayfası</h3>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="col-12 grid-margin stretch-card">
        <div class="card">
            <div class="card-body">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" SelectCommand="SELECT * FROM [tblBlogKategori]"></asp:SqlDataSource>
                <div class="form-group">
                    <label for="exampleInputName1">Başlık</label>
                    <asp:TextBox ID="txtBaslik" CssClass="form-control" placeholder="Başlık" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail3">Özet</label>
                    <asp:TextBox ID="txtOzet" CssClass="form-control" TextMode="MultiLine" placeholder="Özet" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword4">Kategori</label>
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Ad" DataValueField="Id"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>Blog Resim</label>
                    <input type="file" name="img[]" class="file-upload-default">
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control file-upload-info" runat="server" />
                    <asp:Button ID="Button1" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Resim Yükle" OnClick="Button1_Click" />

                </div>
                 <div class="form-group">
     <asp:Label ID="lblResim" Text="" runat="server"></asp:Label>
 </div>
                <div class="form-group">
                    <label for="exampleTextarea1">Blog Detay</label>
                    <asp:TextBox ID="txtBlogDetay" CssClass="form-control" TextMode="MultiLine" Height="100px" placeholder="Blog Detay" runat="server"></asp:TextBox>
                    <asp:Label ID="lblTarih" runat="server" Text="Label"></asp:Label>
                </div>
                <asp:Button ID="btnKaydet" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Kaydet"  OnClick="btnKaydet_Click"
                    />
            </div>
        </div>
    </div>

</asp:Content>
