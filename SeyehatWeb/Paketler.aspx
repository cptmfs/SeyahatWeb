<%@ Page Title="" Language="C#" MasterPageFile="~/Altsayfa.Master" AutoEventWireup="true" CodeBehind="Paketler.aspx.cs" Inherits="SeyehatWeb.Paketler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Paketlerimiz</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     <div class="row">
     <div class="col-lg-12">
         <div class="section-tittle text-center">
             <span>Özel Tur Paketleri</span>
             <h2>Favori Yerler</h2>
         </div>
     </div>
 </div>
 <div class="row">
     <div class="col-xl-4 col-lg-4 col-md-6">
         <div class="single-place mb-30">
             <div class="place-img">
                 <img src="assets/img/service/services1.jpg" alt="">
             </div>
             <div class="place-cap">
                 <div class="place-cap-top">
                     <span><i class="fas fa-star"></i><span>8.0 </span></span>
                     <h3><a href="#">Petasos Chic Hotel</a></h3>
                     <p class="dolor">$1870 <span>/ Per Person</span></p>
                 </div>
                 <div class="place-cap-bottom">
                     <ul>
                         <li><i class="far fa-clock"></i>3 Days</li>
                         <li><i class="fas fa-map-marker-alt"></i>Mikonos , Yunanistan</li>
                     </ul>
                 </div>
             </div>
         </div>
     </div>
     </div>
</asp:Content>
