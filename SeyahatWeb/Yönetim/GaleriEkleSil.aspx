<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="GaleriEkleSil.aspx.cs" Inherits="SeyahatWeb.Yönetim.GaleriEkleSil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Resim Galerisi İşlemleri Sayfası</h3>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="col-12 grid-margin stretch-card">

        <div class="card">
            <div class="card-body">
                <div class="form-group">
                    <label for="exampleInputName1">Kategori Adı</label>
                    <asp:TextBox ID="txtAd" CssClass="form-control" placeholder="Kategori Adı" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnKaydet" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Kategori Ekle" />
                <br />
                <br />
                <br />
                <hr />
                <h3>Galeri Resim Yükleme Alanı</h3>
                <br />
                <div class="form-group">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" SelectCommand="SELECT * FROM [tblGaleriKategori]"></asp:SqlDataSource>
                    <label for="exampleInputName1">Kategori Adı</label>
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataTextField="Adi" DataValueField="Id" DataSourceID="SqlDataSource1"></asp:DropDownList>

                </div>
                <div class="form-group">
                    <label>Galeri Resim</label>
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control file-upload-info" runat="server" />
                    <asp:Button ID="btnResimYukle" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Resim Yükle" OnClick="btnResimYukle_Click" />
                </div>
                                    <div class="form-group">
                        <asp:Label ID="lblResim" Text="" runat="server"></asp:Label>
                    </div>
                <div class="form-group">
                    <asp:Button ID="btnKaydet2" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Kaydet" OnClick="btnKaydet2_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
