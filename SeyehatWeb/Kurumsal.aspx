<%@ Page Title="" Language="C#" MasterPageFile="~/Altsayfa.Master" AutoEventWireup="true" CodeBehind="Kurumsal.aspx.cs" Inherits="SeyehatWeb.Kurumsal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Kurumsal</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="col-12 grid-margin stretch-card">
        <div class="card">
            <div class="card-body">
                <form runat="server">
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
                </form>
            </div>
        </div>
    </div>
</asp:Content>
