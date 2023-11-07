<%@ Page Title="" Language="C#" MasterPageFile="~/Altsayfa.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="SeyehatWeb.Iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Bize Ulaşın</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="d-none d-sm-block mb-5 pb-4">
            <div id="map" style="height: 480px; position: relative; overflow: hidden;">
                <div style="height: 100%; width: 100%; position: absolute; top: 0px; left: 0px; background-color: rgb(229, 227, 223);">
<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d48280.01183042491!2d29.299844109777517!3d40.86088398578716!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cad916057f4263%3A0xe0be153bd2ad89a8!2zQXlkxLFubMSxLCAzNDk1MyBUdXpsYS_EsHN0YW5idWw!5e0!3m2!1str!2str!4v1699346689838!5m2!1str!2str" width="1200" height="600" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <h2 class="contact-title">Bize Ulaşın</h2>
            </div>
            <div class="col-lg-8">
                <form class="form-contact contact_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
                    <div class="row">
                        <div class="col-12">
                            <div class="form-group">
                                <input class="form-control" name="subject" id="subject" type="text" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Konu'" placeholder="Konu">
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <input class="form-control valid" name="name" id="name" type="text" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Ad Soyad'" placeholder="Ad Soyad">
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <input class="form-control valid" name="email" id="email" type="email" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Email Adresi'" placeholder="Email Adresi">
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <textarea class="form-control w-100" name="message" id="message" cols="30" rows="9" onfocus="this.placeholder = ''" onblur="this.placeholder = 'Mesaj'" placeholder=" Mesaj"></textarea>
                            </div>
                        </div>


                    </div>
                    <div class="form-group mt-3">
                        <button type="submit" class="button button-contactForm boxed-btn">Gönder</button>
                    </div>
                </form>
            </div>
            <div class="col-lg-3 offset-lg-1">
                <div class="media contact-info">
                    <span class="contact-info__icon"><i class="ti-home"></i></span>
                    <div class="media-body">
                        <h3>Istanbul/Turkey</h3>
                        <p>Tuzla , AY 34899</p>
                    </div>
                </div>
                <div class="media contact-info">
                    <span class="contact-info__icon"><i class="ti-tablet"></i></span>
                    <div class="media-body">
                        <h3>+90 543 987 65 43</h3>
                        <p>Pazartesi - Cuma 8.30 am - 5 pm</p>
                    </div>
                </div>
                <div class="media contact-info">
                    <span class="contact-info__icon"><i class="ti-email"></i></span>
                    <div class="media-body">
                        <h3>destek@tatilburada.com</h3>
                        <p>Sormak istedikleriniz için iletişime geçin!</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
