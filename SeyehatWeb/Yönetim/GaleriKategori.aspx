<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="GaleriKategori.aspx.cs" Inherits="SeyehatWeb.Yönetim.GaleriKategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Galeri Kategori İşlemleri Sayfası</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="col-12 grid-margin stretch-card">

        <div class="card">
            <div class="card-body">
                <div class="form-group">
                    <label for="exampleInputName1">Kategori Adı</label>
                    <asp:TextBox ID="txtAd" CssClass="form-control" placeholder="Kategori Adı" runat="server"></asp:TextBox>
                </div>   
                <asp:Button ID="btnKaydet" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Kategori Ekle" OnClick="btnKaydet_Click" />
            </div>
        </div>
    </div>
</asp:Content>
