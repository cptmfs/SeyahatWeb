<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="PaketEkle.aspx.cs" Inherits="SeyehatWeb.Yönetim.PaketEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Yeni Tur Paketi Ekleme Sayfası</h3>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="col-12 grid-margin stretch-card">
        <div class="card">
            <div class="card-body">

                <form class="forms-sample" runat="server">
                    <div class="form-group">
                        <label for="exampleInputName1">Tur Adı</label>
                        <asp:TextBox ID="txtTurAd" CssClass="form-control" placeholder="Tur Adı" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail3">Tur Fiyatı</label>
                        <asp:TextBox ID="txtTurFiyat" CssClass="form-control" placeholder="Tur Fiyat" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword4">Tur Süresi</label>
                        <asp:TextBox ID="txtTurSure" CssClass="form-control" placeholder="Tur Süresi" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleSelectGender">Konum</label>
                        <asp:TextBox ID="txtTurKonum" CssClass="form-control" placeholder="Tur Konumu" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Tur Resim</label>
                        <input type="file" name="img[]" class="file-upload-default">
                        <asp:FileUpload ID="FileUpload1" CssClass="form-control file-upload-info" runat="server" />

                    </div>
                    <div class="form-group">
                        <label for="exampleTextarea1">Detay</label>
                        <asp:TextBox ID="txtTurDetay" CssClass="form-control" TextMode="MultiLine" Height="100px" placeholder="Tur Detay" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnKaydet" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Kaydet" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
