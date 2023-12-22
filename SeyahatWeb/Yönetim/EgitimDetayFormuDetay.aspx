<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="EgitimDetayFormuDetay.aspx.cs" Inherits="SeyahatWeb.Yönetim.EgitimDetayFormuDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <div class="accordion-group" style="text-align: center;">
        <div class="accordion-heading accordion-heading-header" style="background-color: #fcf8e3">
            <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
              <strong>EĞİTİM DETAY FORMU
                </strong></span>
        </div>
    </div>
   
     <div class="contanier">
       
        <div class="row">
              <div class="col-lg-2 col-sm-1  align-self-center"><b> Oluşturulma Tarihi:</b></div>
            <div class="col-lg-10 col-sm-2 ">
                <asp:Label runat="server" ID="lblOlusturulmaTarihi" ClientIDMode="Static"  Font-Bold="false"/>
            </div>

           </div>
        <div class="row">  
              <div class="col-lg-2 col-sm-1  align-self-center"><b> Oluşturan Kişi:</b></div>
            <div class="col-lg-10 col-sm-2 ">
                <asp:Label runat="server" ID="lblOlusturanKullanici" ClientIDMode="Static"  Font-Bold="false"/>
            </div>
           
        </div>    
        <div class="row">
            <div class="col-lg-2 col-sm-1  align-self-center"><b>Merkez Adı:</b></div>
            <div class="col-lg-10 col-sm-2 " >
                 <asp:Label runat="server" ID="lblBirim" ClientIDMode="Static" Font-Bold="false" />
            </div>
          </div>
        </div>
    <br />

    
    
   <%-- <p>--%>
         <div class="table-responsive">
        <asp:Literal ID="litTable" runat="server"   />
             </div>
        <br />
        <br />
        <asp:Button Text="Kaydet" ID="btnKaydet"  CssClass="btn btn-primary" runat="server" Width="180" Height="40" OnClick="btnKaydet_Click" />
   <%-- </p>--%>



   
</asp:Content>
