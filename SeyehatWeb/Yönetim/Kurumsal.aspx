<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="Kurumsal.aspx.cs" Inherits="SeyehatWeb.Yönetim.Kurumsal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Kurumsal İşlemleri Sayfası</h3>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="col-12 grid-margin stretch-card">
        <div class="card">
            <div class="card-body">
                <div class="forms-sample">
                    <div class="form-group">
                        <label for="exampleInputName1">Başlık</label>
                        <asp:TextBox ID="txtBaslik" CssClass="form-control" placeholder="Başlık" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblId" runat="server" Text="*"></asp:Label>

                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail3">Özet</label>
                        <asp:TextBox ID="txtOzet" CssClass="form-control" placeholder="Özet" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword4">Detay</label>
                        <asp:TextBox ID="txtDetay" CssClass="form-control" TextMode="MultiLine" Height="100px" placeholder="Detay" runat="server"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnKaydet" CssClass="btn btn-gradient-primary mr-2" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
                    <asp:Button ID="btnYukle" CssClass="btn btn-gradient-danger mr-2" runat="server" Text="Yükle" OnClick="btnYukle_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
