<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="Ayarlar.aspx.cs" Inherits="Seyehat.Yönetim.Ayarlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Site Ayarları Sayfası</h3>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="col-12 grid-margin stretch-card">
        <div class="card">
            <div class="card-body">

                    <div class="form-group">
                        <label for="exampleInputName1">E-Mail</label>
                        <asp:TextBox ID="txtMail" CssClass="form-control" placeholder="E-Mail" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail3">Telefon</label>
                        <asp:TextBox ID="txtTelefon" CssClass="form-control" placeholder="Telefon" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword4">Adres</label>
                        <asp:TextBox ID="txtAdress" CssClass="form-control" TextMode="MultiLine" Height="100px" placeholder="Adres" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail3">Youtube</label>
                        <asp:TextBox ID="txtYoutube" CssClass="form-control" placeholder="Youtube" runat="server"></asp:TextBox>
                    </div>
                                        <div class="form-group">
                        <label for="exampleInputEmail3">Instagram</label>
                        <asp:TextBox ID="txtInstagram" CssClass="form-control" placeholder="Instagram" runat="server"></asp:TextBox>
                    </div>
                                                            <div class="form-group">
                        <label for="exampleInputEmail3">Facebook</label>
                        <asp:TextBox ID="txtFacebook" CssClass="form-control" placeholder="Facebook" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Logo</label>
                        <input type="file" name="img[]" class="file-upload-default">
                        <asp:FileUpload ID="FileUpload1" CssClass="form-control file-upload-info" runat="server" />
                                            <asp:Button ID="btnResimYukle" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Yükle" OnClick="btnResimYukle_Click" />

                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblLogo" runat="server" Text=""></asp:Label>

                    </div>
                                                    <div class="form-group">
                                        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>

                    </div>
                    <div class="form-group">
                        <label for="exampleTextarea1">Site Açıklama</label>
                        <asp:TextBox ID="txtBlogDetay" CssClass="form-control" TextMode="MultiLine" Height="100px" placeholder="Site Açıklama" runat="server"></asp:TextBox>
                        <asp:Label ID="lblTarih" runat="server" Text="Label"></asp:Label>
                    </div>
                    <asp:Button ID="btnKaydet" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Kaydet" OnClick="btnKaydet_Click"/>
                    <asp:Button ID="btnYukle" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Yükle" OnClick="btnYukle_Click" />
            </div>
        </div>
    </div>
</asp:Content>
