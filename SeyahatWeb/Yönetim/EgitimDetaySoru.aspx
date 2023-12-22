<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="EgitimDetaySoru.aspx.cs" Inherits="SeyahatWeb.Yönetim.EgitimDetaySoru" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
         <div class="accordion-group">
       <div class="accordion-heading accordion-heading-header">
           <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
               <i class="splashy-zoom" style="position: relative; top: 1px;"></i>&nbsp;<b>Eğitim Detay Formu Soru
               Arama</b></span>
       </div>
   </div>


    <div class="contanier">
       <div class="row mt-5">
           <div class="col-lg-1 col-sm-1  align-self-center"><b>Soru Başlığı:</b></div>
           <div class="col-lg-2 col-sm-3">
            <asp:DropDownList CssClass="form-control" runat="server" ID="drpSoruTuruArama" AppendDataBoundItems="true" ClientIDMode="Static" >
                                   <asp:ListItem Text="Seçiniz" Value="-1" />

                               </asp:DropDownList>
           </div>
            <div class="col-lg-1 col-sm-3  align-self-center">
               <asp:Button Text="Ara" ID="btnAra" CssClass="btn btn-primary" runat="server"
                   OnClick="btnAra_Click" />
           </div>
         
       </div>
         </div>



   <div class="accordion-group mt-5">
       <div class="accordion-heading accordion-heading-header">
           <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
               <i class="splashy-document_letter" style="position: relative; top: 1px;"></i>&nbsp;<b> Eğitim Detay Formu Soru Listesi </b></span>
       </div>
   </div>

   <div class="btn-group mt-3">
       <a data-bs-toggle="modal" id="A4" data-bs-backdrop="static" class="btn btn-primary" href="#EgitimDetayFormuSoruModal"
           onclick="PrepareModalPopup('yeniKayit')">Yeni Kayıt</a>
   </div>


    <div class="table-responsive"><asp:GridView ID="gridEgitimDetayFormuSoru" runat="server" Width="100%" CssClass="table table-bordered table-condensed table-striped"
           Font-Names="Calibri" AutoGenerateColumns="False" PageSize="30" DataKeyNames="Id" AllowPaging="True" OnPageIndexChanging="gridEgitimDetayFormuSoru_PageIndexChanging">
             <Columns>
                  <asp:BoundField DataField="Sira" HeaderText="Sıra" SortExpression="Sira"
                   NullDisplayText="-">
                   <ItemStyle Width="15%" HorizontalAlign="center" VerticalAlign="Middle" />
               </asp:BoundField>
               <asp:BoundField DataField="Tanim" HeaderText="Tanım" SortExpression="Tanim"
                   NullDisplayText="-">
                   <ItemStyle Width="15%" HorizontalAlign="center" VerticalAlign="Middle" />
               </asp:BoundField>
               <asp:BoundField DataField="EgitimDetayFormuSoruBaslikTanim" HeaderText="Başlığı" SortExpression="EgitimDetayFormuSoruBaslikTanim"
                   NullDisplayText="-">
                   <ItemStyle Width="15%" HorizontalAlign="center" VerticalAlign="Middle" />
               </asp:BoundField>
                   <asp:BoundField DataField="CevapTuruAciklama" HeaderText="Cevap Türü" SortExpression="CevapTuruAciklama"
                   NullDisplayText="-">
                   <ItemStyle Width="15%" HorizontalAlign="center" VerticalAlign="Middle" />
               </asp:BoundField>
                  
                 
               <asp:TemplateField HeaderText="İşlemler" ShowHeader="False">
                   <ItemTemplate>
                       <a data-bs-toggle="modal" data-bs-backdrop="static"
                           id="A1" title="Detayı Görüntüle" data-id='<%# Eval("Id") %>' onclick="EgitimDetayFormuSoru(this);"
                           href="#EgitimDetayFormuSoruModal" style="padding-right: 8px;" data-islemtipi="kayitDetay">
                           <img src="../../images/gCons/addressbook.png" alt="Detay" /></a>
                       <a data-bs-toggle="modal" data-bs-backdrop="static"
                           id="A2" runat="server" title="Güncelle" data-id='<%# Eval("Id") %>' onclick="EgitimDetayFormuSoru(this);"
                           href="#EgitimDetayFormuSoruModal" style="padding-left: 8px;" data-islemtipi="kayitGuncelle">
                           <img src="../../images/gCons/edit.png" alt="Güncelle" /></a>
                       <a data-bs-toggle="modal" data-bs-backdrop="static"
                           id="A3" runat="server" title="Sil" data-id='<%# Eval("Id") %>' onclick="EgitimDetayFormuSoru(this);"
                           href="#EgitimDetayFormuSoruModal" style="padding-left: 8px;" data-islemtipi="kayitSil">
                           <img src="../../images/gCons/recycle-full.png" alt="Sil" /></a>
                   </ItemTemplate>
                   <ItemStyle Width="20%" VerticalAlign="Middle" HorizontalAlign="Center" />
               </asp:TemplateField>
           </Columns>
            <PagerStyle CssClass="GridPager" /> <SelectedRowStyle Font-Bold="True" ForeColor="#3993BA" />

       </asp:GridView>
   </div>

   <asp:HiddenField ID="hiddenSecilenEgitimDetayFormuSoruId" runat="server" Value="" EnableViewState="False" />

   
   <div class="modal fade"  id="EgitimDetayFormuSoruModal">
 <div class="modal-dialog modal-dialog-scrollable" ><div class="modal-content"> <div class="modal-header">
          <h3>
               <span class="yeniKayit">
                   <img src="../../images/gCons/add-item.png" alt="" />Yeni Kayıt</span>
               <span class="kayitDetay">
                   <img src="../../images/gCons/addressbook.png" alt="" />Kayıt Detayı</span>
               <span class="kayitGuncelle">
                   <img src="../../images/gCons/edit.png" alt="" />Kayıt Güncelle</span>
               <span class="kayitSil">
                   <img src="../../images/gCons/recycle-full.png" alt="" />Kayıt Sil</span>
           </h3><button class="close" data-bs-dismiss="modal" id="EgitimDetayFormuSoruModalCloseButton">
x</button>
       </div>

        <div class="modal-body" >
           <div id="popupEkranı">
               <table class="table table-bordered table-condensed table-striped dTableR" id="tblEgitimDetaySoru">
                   <thead>
                       <tr>
                           <th colspan="4">Eğitim Detay Formu Soru
                           </th>
                       </tr>
                   </thead>
                   <tbody>

                       <tr>
                           <td class="tdWidth" style="text-align: right; vertical-align: middle">Tanım :
                           </td>
                           <td>
                               <asp:TextBox runat="server" ID="txtTanim" CssClass="form-control"/>
                               <asp:RequiredFieldValidator ID="requiredTanim" runat="server" Text="*" ControlToValidate="txtTanim"
                                   ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                           </td>
                       </tr>
                         <tr>
                           <td class="tdWidth" style="text-align: right; vertical-align: middle">Sıra :
                           </td>
                           <td>
                               <asp:TextBox runat="server" ID="txtSira" CssClass="form-control"/>
                               <asp:RequiredFieldValidator ID="RequiredFieldtxtSira" runat="server" Text="*" ControlToValidate="txtSira"
                                   ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                           </td>
                       </tr>
                       <tr>
                           <td class="tdWidth" style="text-align: right; vertical-align: middle">Soru Başlığı :
                           </td>
                           <td>
                               <asp:DropDownList CssClass="form-control" runat="server" ID="drpSoruTuru" ClientIDMode="Static" AppendDataBoundItems="true" >
                                   <asp:ListItem Text="Seçiniz" Value="-1" />                                  
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="requiredSoruTuru" runat="server" Text="*" ControlToValidate="drpSoruTuru" InitialValue="-1"
                                   ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                           </td>
                       </tr>
                       <tr>
                           <td class="tdWidth" style="text-align: right; vertical-align: middle">Cevap Türü :
                           </td>
                           <td>
                               <asp:DropDownList CssClass="form-control" runat="server" ID="drpCevapTuru" ClientIDMode="Static">
                                   <asp:ListItem Text="Seçiniz" Value="" />
                                   <asp:ListItem Text="Uzun Metin" Value="1" />
                                     <asp:ListItem Text="Kısa Metin" Value="4" />
                                   <asp:ListItem Text="Var/Yok/Bilinmiyor" Value="2" />
                                     <asp:ListItem Text="Çoktan Seçim" Value="3" />
                                    <asp:ListItem Text="Tarih" Value="5" /> 
                                   <asp:ListItem Text="Tarih & Saat" Value="6" />
                                   <asp:ListItem Text="Rakam" Value="7" /> 
                                   <asp:ListItem Text="Resim" Value="8" /> 
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="requiredCevapTuru" runat="server" Text="*" ControlToValidate="drpCevapTuru"
                                   ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                           </td>
                       </tr>
                        <tr>
                           <td class="tdWidth" style="text-align: right; vertical-align: middle">Satır Sayısı :
                           </td>
                           <td>
                               <asp:TextBox runat="server" ID="txtSatirSayisi" CssClass="form-control" onkeypress="return isNumber(event)" ClientIDMode="Static" />
                              
                           </td>
                       </tr>
                      

                   </tbody>
               </table>
           </div>
       </div>

           <div class="modal-footer">
           <span class="yeniKayit">
               <asp:Button ID="btnKaydet" Text="Kaydet"  CssClass="btn btn-primary" runat="server" Width="100"
                   ValidationGroup="Islem" ClientIDMode="Static" OnClick="btnKaydet_Click" /></span>
           <span class="kayitGuncelle">
               <asp:Button ID="btnGuncelle" ClientIDMode="Static" Text="Güncelle"  CssClass="btn btn-primary" runat="server" Width="100"
                   ValidationGroup="Islem" OnClick="btnGuncelle_Click" /></span>
           <span class="kayitSil">
               <asp:Button ID="btnSil" Text="Sil" ClientIDMode="Static"  CssClass="btn btn-primary" runat="server" Width="100"
                   ValidationGroup="Islemyok" OnClick="btnSil_Click" /></span>
           <span class="kayitDetay"></span></div></div></div></div>

    <script type="text/javascript">
       var hiddenSecilenEgitimDetayFormuSoruId = $("#<%= hiddenSecilenEgitimDetayFormuSoruId.ClientID %>");

       var txtTanim = $("#<%= txtTanim.ClientID %>");
        var drpSoruTuru = $("#<%= drpSoruTuru.ClientID %>");
        var drpCevapTuru= $("#<%= drpCevapTuru.ClientID %>");
        var txtSatirSayisi = $("#<%= txtSatirSayisi.ClientID %>");        
        var txtSira = $("#<%= txtSira.ClientID %>");

        function EgitimDetayFormuSoru(element) {

            var EgitimDetayFormuSoruId = $(element).attr("data-id");
            var islemTipi = $(element).attr("data-islemtipi");

            if (EgitimDetayFormuSoruId == null || EgitimDetayFormuSoruId == 'undefined') {
                $("#modalAlertHeader").html("Oryantasyon Formu Soru Bilgisi Getirilemiyor");
                $("#modalAlertBody").html("İşlem yapmak istediğiniz <b>Oryantasyon Formu Soru bilgisi</b> getirilemedi. Lütfen daha sonra tekrar deneyiniz.");
                 var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                return;
            }
       

            $.ajax({
                type: "POST",
                url: "EgitimDetaySoru.aspx/EgitimDetayFormuSoruGetir",
                data: "{'EgitimDetayFormuSoruId':" + EgitimDetayFormuSoruId + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var EgitimDetayFormuSoruDetay = eval(data.d);
                    hiddenSecilenEgitimDetayFormuSoruId.val(EgitimDetayFormuSoruDetay.Id.toString());
                   
                    if (EgitimDetayFormuSoruDetay.Tanim != null) txtTanim.val(EgitimDetayFormuSoruDetay.Tanim);
                    if (EgitimDetayFormuSoruDetay.EgitimDetayFormuSoruBaslikId != null) drpSoruTuru.val(EgitimDetayFormuSoruDetay.EgitimDetayFormuSoruBaslikId);
                    if (EgitimDetayFormuSoruDetay.CevapTuru != null) drpCevapTuru.val(EgitimDetayFormuSoruDetay.CevapTuru);
                    if (EgitimDetayFormuSoruDetay.TxtSatirSayisi != null) txtSatirSayisi.val(EgitimDetayFormuSoruDetay.TxtSatirSayisi);
                    if (EgitimDetayFormuSoruDetay.Sira != null) txtSira.val(EgitimDetayFormuSoruDetay.Sira);
                },
                error: function (err) {
                    $("#modalAlertHeader").html("İşlem Yapılamıyor");
                    $("#modalAlertBody").html("İşleminiz şu anda gerçekleştirilemiyor. Lütfen daha sonra tekrar deneyiniz ya da <br /><b>BİLGİ İŞLEM</b> ile irtibata geçiniz.");
                     var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                    return;
                }
            });

            PrepareModalPopup(islemTipi);

        }

        function Temizle() {

            // $("#AramaGrid").find("input:text").val('');

            $("#EgitimDetayFormuSoruModal div").scrollTop(0);

            $("#EgitimDetayFormuSoruModal input")
                .not(":input[type=submit], :input[type=button], :input[type=checkbox]")
                .val("");

            $("#EgitimDetayFormuSoruModal textarea").each(function () {
                $(this).val("");
            });
            //$("#PeriyodikMuayeneSoruModal span").html("");
            $("#EgitimDetayFormuSoruModal select").each(function () {
                $(this)[0].selectedIndex = 0;

            });

            $("#EgitimDetayFormuSoruModal :checked").each(function () {
                $(this).removeAttr("checked");
            });

            // Validation Kontrollerini temizlemek
            if (typeof (window.Page_Validators) != "undefined") {
                for (var i = 0; i < window.Page_Validators.length; i++) {
                    var validator = window.Page_Validators[i];
                    validator.isvalid = true;
                    window.ValidatorUpdateDisplay(validator);
                }
            }
        }

        $("#EgitimDetayFormuSoruModalCloseButton")
        .click(function () {
            Temizle();
        });


          function PrepareModalPopup(islemTipi) {
           //Temizle();

           switch (islemTipi) {

               case "yeniKayit":

                   $("span.yeniKayit").css("display", "");
                   $("span.kayitGuncelle").css("display", "none");
                   $("span.kayitSil").css("display", "none");

                   $("span.kayitDetay").css("display", "none");
                   EnableInputElements(true);
                   break;

               case "kayitGuncelle":
                   $("span.yeniKayit").css("display", "none");

                   $("span.kayitDetay").css("display", "none");
                   $("span.kayitSil").css("display", "none");
                   $("span.kayitGuncelle").css("display", "");
                   EnableInputElements(true);
                   break;
               case "kayitSil":
                   $("span.yeniKayit").css("display", "none");
                   $("span.kayitGuncelle").css("display", "none");

                   $("span.kayitDetay").css("display", "none");
                   $("span.kayitSil").css("display", "");
                   EnableInputElements(false);
                   break;

               case "kayitDetay":
                   $("span.yeniKayit").css("display", "none");
                   $("span.kayitGuncelle").css("display", "none");

                   $("span.kayitDetay").css("display", "");
                   $("span.kayitSil").css("display", "none");
                   EnableInputElements(false);
                   break;
           }
       }

       function EnableInputElements(enableElements) {
           if (enableElements) {
               $("#EgitimDetayFormuSoruModal *")
               .not(":input[type=submit]")
               .not("button")
               .removeAttr("disabled");
           }
           else
               $("#EgitimDetayFormuSoruModal *")
               .not(":input[type=submit]")
               .not("button")
               .prop("disabled", "disabled");
       }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
           var charCode = (evt.which) ? evt.which : evt.keyCode;
           if (charCode > 31 && (charCode < 48 || charCode > 57)) {
               return false;
           }
           return true;
       }


    </script>
</asp:Content>
