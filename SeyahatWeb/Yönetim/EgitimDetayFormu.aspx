<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="EgitimDetayFormu.aspx.cs" Inherits="SeyahatWeb.Yönetim.EgitimDetayFormu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<%--          <div class="alert alert-danger py-2">
               <b> Sorumluluk sahanızda görülen ve halk sağlığı riski taşıyan olay/vaka bildirimlerinde, doldurulması gereken OLAY BİLGİ FORMU (OBF)  için ekte bulunan kılavuzlardan destek alınız.                   
                    <br />
                    Konu ile ilgili sorularınız için Genel Müdürlüğümüz Erken Uyarı ve Cevap Birimini arayabilirsiniz. Dahili Tel No: 377-138   
                   <br />
                   </b>  
    
                   <a target="_blank" href="../HudutGozlem/OBFKilavuz/OBF Doldurma Klavuzu LİMANLAR.docx">  Deniz Limanları OBF kılavuzu için tıklayınız. </a>  <br />
                    <a target="_blank" href="../HudutGozlem/OBFKilavuz/OBF Doldurma Klavuzu HAVALİMANLARI.docx">   Havalimanları OBF kılavuzu için tıklayınız. </a>  <br />
                     <a target="_blank" href="../HudutGozlem/OBFKilavuz/OBF Doldurma Klavuzu KARA HUDUT KAPILARI.docx">  Kara Hudut Kapıları OBF kılavuzu için tıklayınız. </a>
                    
                                  
  <br />
               
            </div>--%>
   

      <div class="accordion-group">
        <div class="accordion-heading accordion-heading-header">
            <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                <i class="splashy-information" style="position: relative; top: 1px;"></i>&nbsp;<b> Merkez Bilgileri </b></span>
        </div>
    </div>


     <div class="contanier mt-2">
        <div class="row">
            <div class="col-lg-1 col-sm-1  align-self-center"><b>Merkez Adı:</b></div>
            <div class="col-lg-4 col-sm-3">
                 <asp:Label runat="server" ID="lblBirim" ClientIDMode="Static" />
            </div>
          
        </div>
          </div>

      <br />

    <div class="accordion-group mt-2">
        <div class="accordion-heading accordion-heading-header">
            <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                <i class="splashy-document_letter" style="position: relative; top: 1px;"></i>&nbsp;<b> Eğitim Detay Formu Listesi </b></span>
        </div>
    </div>
     <div class="btn-group mt-2">
        <a data-bs-toggle="modal" id="A4" data-bs-backdrop="static" class="btn btn-primary" href="#EgitimDetayFormuModal" runat="server"
            onclick="PrepareModalPopup('yeniKayit')">Yeni Kayıt</a>
    </div>

        <div class="table-responsive"><asp:GridView ID="gridEgitimDetayFormu" runat="server" Width="100%" CssClass="table table-bordered table-condensed table-striped" Font-Size="Small"
            Font-Names="Calibri" AutoGenerateColumns="False" PageSize="30" DataKeyNames="Id" AllowPaging="True" OnPageIndexChanging="gridEgitimDetayFormu_PageIndexChanging" OnRowDataBound="gridEgitimDetayFormu_RowDataBound" >
            <Columns>
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <img alt="" title="Güncellemeler" style="cursor: pointer" src="../../images/details_open.png" class="openImage" data-id='<%# Eval("Id") %>' />
                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        </asp:Panel>
                    </ItemTemplate>
                    <ItemStyle Width="1%" VerticalAlign="Middle" HorizontalAlign="Center" />
                </asp:TemplateField>

                  <asp:BoundField DataField="SiraNo" HeaderText="Sıra No" SortExpression="SiraNo"
                    NullDisplayText="-">
                    <ItemStyle Width="5%" HorizontalAlign="center" VerticalAlign="Middle" />
                </asp:BoundField>
                  <asp:BoundField DataField="TurAciklama" HeaderText="OBF Giriş Seçeneği" SortExpression="TurAciklama"
                    NullDisplayText="-">
                    <ItemStyle Width="10%" HorizontalAlign="center" VerticalAlign="Middle" />
                </asp:BoundField>
                   <asp:BoundField DataField="OlusturanKullaniciTanim" HeaderText="Oluşturan Kullanıcı" SortExpression="OlusturanKullaniciTanim"
                    NullDisplayText="-" >
                    <ItemStyle Width="15%" HorizontalAlign="center" VerticalAlign="Middle" />
                </asp:BoundField> 
                <asp:BoundField DataField="OlusturulmaTarihi" HeaderText="Oluşturulma Tarihi" SortExpression="OlusturulmaTarihi"
                    NullDisplayText="-" DataFormatString="{0: dd.MM.yyyy HH:mm:ss}">
                    <ItemStyle Width="15%" HorizontalAlign="center" VerticalAlign="Middle" />
                </asp:BoundField>               


                  <asp:BoundField DataField="AktifAciklama" HeaderText="Durum" SortExpression="AktifAciklama"
                    NullDisplayText="-">
                    <ItemStyle Width="15%" HorizontalAlign="center" VerticalAlign="Middle" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="İşlemler" ShowHeader="False">
                    <ItemTemplate>
                         <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A2" runat="server" title="Süreci Sonlandır/Tekrar Başlat"
                            data-id='<%# Eval("Id") %>'  data-kapatTarih='<%# Eval("KapatmaTarihi") %>'  data-kapatan='<%# Eval("KapatanKullaniciAciklama") %>'  
                            data-acmaTarih='<%# Eval("AcmaTarihi") %>'  data-acan='<%# Eval("AcanKullaniciAciklama") %>' onclick="EgitimDetayFormu(this);"
                            href="#EgitimDetayFormuModal" style="padding-left: 8px;" data-islemtipi="kayitDetay2">
                            <img src="../../images/gCons/lock.png" alt="Süreci Sonlandır/Tekrar Başlat" runat="server" id="acKapatIkon" /></a>
                                               
                         <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A1" runat="server" title="Süreç Sonu Değerlendirme Raporu Ekle"
                            href="#EgitimDetayFormuGuncellemeModal" style="padding-left: 8px;" data-formid='<%# Eval("Id") %>' onclick="EgitimDetayFormuGuncelleme(this)" data-islemtipi="yeniKayit2">
                            <img src="../../images/gCons/add-item.png" alt="Süreç Sonu Değerlendirme Raporu Ekle" /></a>
                        
                        <a id="A4" title="Eğitim Detay Formu Detayı"
                                        href='<%# String.Format("EgitimDetayFormuDetay.aspx?olayBilgiFormuId={0}", Eval("Id"))%>'
                                        style="padding-left: 8px;">
                                        <img src="../../images/gCons/processing.png" alt="Eğitim Detay Formu Detayı" /></a>

                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A3" runat="server" title="Sil" data-id='<%# Eval("Id") %>'  data-kapatTarih='<%# Eval("KapatmaTarihi") %>'  data-kapatan='<%# Eval("KapatanKullaniciAciklama") %>'  
                            data-acmaTarih='<%# Eval("AcmaTarihi") %>'  data-acan='<%# Eval("AcanKullaniciAciklama") %>' 
                             onclick="EgitimDetayFormu(this);"
                            href="#EgitimDetayFormuModal" style="padding-left: 8px;" data-islemtipi="kayitSil">
                            <img src="../../images/gCons/recycle-full.png" alt="Sil" /></a>
                                               
                    

                    </ItemTemplate>
                    <ItemStyle Width="20%" VerticalAlign="Middle" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
             <PagerStyle CssClass="GridPager" /> <SelectedRowStyle Font-Bold="True" ForeColor="#3993BA" />

        </asp:GridView>
    </div>

     <asp:HiddenField ID="hiddenSecilenEgitimDetayFormuId" runat="server" Value="" EnableViewState="False" />

    <div class="modal fade" id="EgitimDetayFormuModal">
        <div class="modal-dialog modal-dialog-scrollable" ><div class="modal-content"> 
        <div class="modal-header">
            
            <h3>
                <span class="yeniKayit">
                    <img src="../../images/gCons/add-item.png" alt="" />Yeni Kayıt</span>
                 <span class="kayitDetay2">
                    <img src="../../images/gCons/addressbook.png" alt="" />Kayıt Detayı</span>
                <span class="kayitSil">
                        <img src="../../images/gCons/recycle-full.png" alt="" />Kayıt Sil</span>
            </h3>
            <button class="close" data-bs-dismiss="modal" id="EgitimDetayFormuModalCloseButton">
                ×</button>
        </div>
         <div class="modal-body">
            <div id="popupEkranı">
                <table class="table table-bordered table-condensed table-striped dTableR" id="tblForm">
                    <thead>
                        <tr>
                            <th colspan="4">Eğitim Detay Formu Bilgileri
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                           
                         <tr>
                            <td class="tdWidth" style="text-align: right; vertical-align: middle">Merkez:
                            </td>
                            <td >                                
                                <asp:DropDownList runat="server" ID="drpMerkez" ClientIDMode="Static"  AppendDataBoundItems="True" CssClass="form-control" Enabled="false">
                                    <asp:ListItem Text="Seçiniz" Value="-1" />                                  
                                </asp:DropDownList>                              
                                
                            </td>
                          
                        </tr>
                         <tr>
                            <td class="tdWidth" style="text-align: right; vertical-align: middle">Eğitim Detay Formu Giriş Seçenekleri:
                            </td>
                            <td >                                
                                <asp:DropDownList runat="server" ID="drpTur" ClientIDMode="Static"  AppendDataBoundItems="True" CssClass="form-control" Enabled="false">
                                    <asp:ListItem Text="Seçiniz" Value="-1" />      
                                     <asp:ListItem Text="Havalimanı OBF" Value="1" />
                                     <asp:ListItem Text="Deniz Limanı OBF" Value="2" />
                                     <asp:ListItem Text="Kara Hudut Kapıları OBF" Value="3" />
                                </asp:DropDownList>   
                                    <asp:RequiredFieldValidator ID="requiredTur" runat="server" Text="*" ControlToValidate="drpTur"
                                    ValidationGroup="Islem" SetFocusOnError="True" InitialValue="-1" ForeColor="Red" />
                               
                            </td>
                          
                        </tr>
                     
                         <tr class="gizle">
                            <td class="tdWidth" style="text-align: right; vertical-align: middle">Sonlandırılma Tarihi :
                            </td>
                            <td>

                               <asp:Label runat="server" ID="lblKapatmaTarihi" ClientIDMode="Static" />

                            </td>
                        </tr>
                        <tr class="gizle">
                            <td class="tdWidth" style="text-align: right; vertical-align: middle">Sonlandıran Kişi:
                            </td>
                            <td>

                               <asp:Label runat="server" ID="lblKapatanKisi" ClientIDMode="Static" />

                            </td>
                        </tr>
                       <tr class="gizle">
                            <td class="tdWidth" style="text-align: right; vertical-align: middle">Tekrar Açılma Tarihi :
                            </td>
                            <td>

                               <asp:Label runat="server" ID="lblAcmaTarihi" ClientIDMode="Static" />

                            </td>
                        </tr>
                       <tr class="gizle">
                            <td class="tdWidth" style="text-align: right; vertical-align: middle">Tekrar Açan Kişi :
                            </td>
                            <td>

                               <asp:Label runat="server" ID="lblAcanKisi" ClientIDMode="Static"  />

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
           <span class="kayitDetay2"> <asp:Button ID="btnFormAcKapat" Text="Kaydet"  CssClass="btn btn-primary" runat="server" Width="120"
                    ValidationGroup="IslemYok" ClientIDMode="Static" OnClick="btnFormAcKapat_Click" />

           </span>
            <span class="kayitSil">
                <asp:Button ID="btnSil" Text="Sil" ClientIDMode="Static"  CssClass="btn btn-primary" runat="server" Width="100"
                    ValidationGroup="Islemyok" OnClick="btnSil_Click" /></span>
           
        </div>
    </div>
              </div>
    </div>

      <asp:HiddenField ID="hiddenSecilenEgitimDetayFormuGuncellemeId" runat="server" Value="" EnableViewState="False" />

    <div class="modal fade" id="EgitimDetayFormuGuncellemeModal">
        <div class="modal-dialog modal-dialog-scrollable" ><div class="modal-content">
        <div class="modal-header">
            
            <h3>
                <span class="yeniKayit2">
                    <img src="../../img/gCons/add-item.png" alt="" />Yeni Kayıt</span>
                   <span class="kayitDetay">
                    <img src="../../img/gCons/addressbook.png" alt="" />Kayıt Detayı</span>
               <span class="kayitGuncelle">
                    <img src="../../img/gCons/edit.png" alt="" />Kayıt Güncelle</span>

                <span class="kayitSil2">
                        <img src="../../img/gCons/recycle-full.png" alt="" />Kayıt Sil</span>
            </h3>
            <button class="close" data-bs-dismiss="modal" id="EgitimDetayFormuGuncellemeModalCloseButton">
                ×</button>
        </div>
         <div class="modal-body">
            <div id="popupEkranı2">
                <table class="table table-bordered table-condensed table-striped dTableR" id="tblGuncelleme">
                    <thead>
                        <tr>
                            <th colspan="4">Süreç Sonu Değerlendirme Raporu
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                           
                         <tr>
                            <td class="tdWidth" style="text-align: right; vertical-align: top">Açıklama:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAciklama" TextMode="MultiLine" Rows="6" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="requiredAciklama" runat="server" Text="*" ControlToValidate="txtAciklama"
                                    ValidationGroup="Islem2" SetFocusOnError="True" ForeColor="Red" />
                            </td>
                        </tr>                     
                                                 
                        
                    </tbody>
                </table>
            </div>
        </div>
        <div class="modal-footer">
            <span class="yeniKayit2">
                <asp:Button ID="btnGuncellemeKaydet" Text="Kaydet"  CssClass="btn btn-primary" runat="server" Width="100"
                    ValidationGroup="Islem2" ClientIDMode="Static" OnClick="btnGuncellemeKaydet_Click" /></span>
            <span class="kayitGuncelle">
                <asp:Button ID="btnGuncelle" Text="Güncelle"  CssClass="btn btn-primary" runat="server" Width="100"
                    ValidationGroup="Islem2" ClientIDMode="Static" OnClick="btnGuncelle_Click" /></span>
             <span class="kayitDetay"></span>

            <span class="kayitSil2">
                <asp:Button ID="btnGuncellemeSil" Text="Sil" ClientIDMode="Static"  CssClass="btn btn-primary" runat="server" Width="100"
                    ValidationGroup="Islemyok" OnClick="btnGuncellemeSil_Click" /></span>
           
        </div>
    </div>
             </div>
    </div>

     <script type="text/javascript">
        var hiddenSecilenEgitimDetayFormuId = $("#<%= hiddenSecilenEgitimDetayFormuId.ClientID %>");
        var hiddenSecilenEgitimDetayFormuGuncellemeId = $("#<%= hiddenSecilenEgitimDetayFormuGuncellemeId.ClientID %>");
         var drpMerkez = $("#<%= drpMerkez.ClientID %>");
         var txtAciklama = $("#<%= txtAciklama.ClientID %>");
         var lblAcanKisi = $("#<%= lblAcanKisi.ClientID %>");
         var lblAcmaTarihi = $("#<%= lblAcmaTarihi.ClientID %>");
         var lblKapatanKisi = $("#<%= lblKapatanKisi.ClientID %>");
         var lblKapatmaTarihi = $("#<%= lblKapatmaTarihi.ClientID %>");
         var drpTur = $("#<%= drpTur.ClientID %>");

         function EgitimDetayFormu(element) {

             var EgitimDetayFormuId = $(element).attr("data-id");
             var islemTipi = $(element).attr("data-islemtipi");

             lblAcanKisi.text($(element).attr("data-acan"));
             lblAcmaTarihi.text ( $(element).attr("data-acmaTarih"));
             lblKapatanKisi.text ($(element).attr("data-kapatan"));
             lblKapatmaTarihi.text ($(element).attr("data-kapatTarih"));

             if (EgitimDetayFormuId == null || EgitimDetayFormuId == 'undefined') {
                 $("#modalAlertHeader").html("İş Kazası Formu Bilgisi Getirilemiyor");
                 $("#modalAlertBody").html("İşlem yapmak istediğiniz <b>Ramak kala Türü bilgisi</b> getirilemedi. Lütfen daha sonra tekrar deneyiniz.");
                  var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                 return;
             }

             //Temizle();

             $.ajax({
                 type: "POST",
                 url: "EgitimDetayFormu.aspx/EgitimDetayFormuGetir",
                 data: "{'EgitimDetayFormuId':" + EgitimDetayFormuId + "}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (data) {
                     var EgitimDetayFormuDetay = eval(data.d);

                     hiddenSecilenEgitimDetayFormuId.val(EgitimDetayFormuDetay.Id.toString());
                   
                     if (EgitimDetayFormuDetay.MerkezId != null) drpMerkez.val(EgitimDetayFormuDetay.MerkezId.toString());
                     if (EgitimDetayFormuDetay.Tur != null) drpTur.val(EgitimDetayFormuDetay.Tur.toString());

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

             $("#EgitimDetayFormuModal div").scrollTop(0);

             $("#EgitimDetayFormuModal input")
                 .not(":input[type=submit], :input[type=button], :input[type=checkbox]")
                 .val("");

             $("#EgitimDetayFormuModal textarea").each(function () {
                 $(this).val("");
             });
             //$("#IsKazasiFormuModal span").html("");
           
             $("#EgitimDetayFormuModal :checked").each(function () {
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

         $("#EgitimDetayFormuModalCloseButton")
         .click(function () {
             Temizle();
         });

          function PrepareModalPopup(islemTipi) {
            //Temizle();

            switch (islemTipi) {

                case "yeniKayit":

                    $("span.yeniKayit").css("display", "");
                    $("span.kayitSil").css("display", "none");
                    $("span.kayitDetay2").css("display", "none");
                    EnableInputElements(true);
                    $(".gizle").hide(10);
                    break;

                case "kayitDetay2":

                    $("span.kayitSil").css("display", "none");
                    $("span.yeniKayit").css("display", "none");
                    $("span.kayitDetay2").css("display", "");
                    EnableInputElements(false);
                    $(".gizle").show(10);
                    break;

                case "kayitSil":
                    $("span.yeniKayit").css("display", "none");
                    $("span.kayitDetay2").css("display", "none");
                    $("span.kayitSil").css("display", "");
                    EnableInputElements(false);
                    $(".gizle").show(10);
                    break;
                
                  // Diger Popup

                case "kayitGuncelle":

                    $("span.kayitGuncelle").css("display", "");
                    $("span.kayitDetay").css("display", "none");
                    $("span.kayitSil2").css("display", "none");
                    $("span.yeniKayit2").css("display", "none");
                    EnableInputElements(true);
                    break;

                case "kayitSil2":

                    $("span.kayitGuncelle").css("display", "none");
                    $("span.kayitDetay").css("display", "none");
                    $("span.kayitSil2").css("display", "");
                    $("span.yeniKayit2").css("display", "none");
                    EnableInputElements(false);
                    break;

                case "kayitDetay":

                    $("span.kayitGuncelle").css("display", "none");
                    $("span.kayitDetay").css("display", "");
                    $("span.kayitSil2").css("display", "none");
                    $("span.yeniKayit2").css("display", "none");
                    $("span.yeniKayit").css("display", "none");
                    EnableInputElements(false);
                    $(".gizle").show(10);
                    break;

                case "yeniKayit2":

                    $("span.kayitGuncelle").css("display", "none");
                    $("span.kayitDetay").css("display", "none");
                    $("span.kayitSil2").css("display", "none");
                    $("span.yeniKayit2").css("display", "");
                    EnableInputElements(true);
                    break;
            }
        }

        function EnableInputElements(enableElements) {
            if (enableElements) {
                $("#EgitimDetayFormuModal *,#EgitimDetayFormuGuncellemeModal *")
                .not(":input[type=submit]")
                .not("button")
                .removeAttr("disabled");
            }
            else
                $("#EgitimDetayFormuModal *,#EgitimDetayFormuGuncellemeModal *")
                .not(":input[type=submit]")
                .not("button")
                .prop("disabled", "disabled");

            drpMerkez.prop("disabled", "disabled");
        }

         // Güncelleme

        function EgitimDetayFormuGuncelleme(element) {


            var EgitimDetayFormuGuncellemeId = $(element).attr("data-id");          
            var islemTipi = $(element).attr("data-islemtipi");

            if (islemTipi == 'yeniKayit2') {
                var EgitimDetayFormuId = $(element).attr("data-formid");
                hiddenSecilenEgitimDetayFormuId.val(EgitimDetayFormuId.toString());
                PrepareModalPopup(islemTipi);
                return;
            }


            if (EgitimDetayFormuGuncellemeId == null || EgitimDetayFormuGuncellemeId == 'undefined') {
                $("#modalAlertHeader").html("İş Kazası Formu Bilgisi Getirilemiyor");
                $("#modalAlertBody").html("İşlem yapmak istediğiniz <b>EgitimDetayFormuGuncelleme bilgisi</b> getirilemedi. Lütfen daha sonra tekrar deneyiniz.");
                 var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                return;
            }

            //Temizle();

            $.ajax({
                type: "POST",
                url: "EgitimDetayFormu.aspx/EgitimDetayFormuGuncellemeGetir",
                data: "{'EgitimDetayFormuGuncellemeId':" + EgitimDetayFormuGuncellemeId + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var EgitimDetayFormuGuncellemeDetay = eval(data.d);

                    hiddenSecilenEgitimDetayFormuGuncellemeId.val(EgitimDetayFormuGuncellemeDetay.Id.toString());

                    if (EgitimDetayFormuGuncellemeDetay.Aciklama != null) txtAciklama.val(EgitimDetayFormuGuncellemeDetay.Aciklama);

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
        function Temizle2() {

            // $("#AramaGrid").find("input:text").val('');

            $("#EgitimDetayFormuGuncellemeModal div").scrollTop(0);

            $("#EgitimDetayFormuGuncellemeModal input")
                .not(":input[type=submit], :input[type=button], :input[type=checkbox]")
                .val("");

            $("#EgitimDetayFormuGuncellemeModal textarea").each(function () {
                $(this).val("");
            });
            //$("#IsKazasiFormuModal span").html("");
            $("#EgitimDetayFormuGuncellemeModal select").each(function () {
                $(this)[0].selectedIndex = 0;

            });

            $("#EgitimDetayFormuGuncellemeModal :checked").each(function () {
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


        $("#EgitimDetayFormuGuncellemeModalCloseButton")
       .click(function () {
           Temizle2();
       });

     
        //Grid üzerinde talimat geçmişi butonunu açılır kapanır yapmak için kullandık
        $(document).on("click", "img.openImage", function () {

            var formId = $(this).attr("data-id");

            $('img.closeImage').each(function () {
                $(this).attr("src", "/img/details_open.png");
                $(this).attr("class", "openImage");
                $(this).closest("tr").next().remove();
            });
            //$(this).closest("tr").after("<tr><td></td><td colspan = '999'></td></tr>");
            $(this).attr("src", "/img/details_close.png");
            $(this).attr("class", "closeImage");

            GuncellemeGoruntule(this, formId);
        });

        $(document).on("click", "img.closeImage", function () {
            $(this).attr("src", "/img/details_open.png");
            $(this).closest("tr").next().remove();
            $(this).attr("class", "openImage");
        });

        function GuncellemeGoruntule(element, formId) {

            $(element).closest("tr").after("<tr ><td></td><td style='background-color:#e0e0e0' colspan = '999'><table  class='table table-bordered table-condensed table-striped dTableR' id='tblGuncellemeler'></table></td></tr>");

            $.ajax({
                type: "POST",
                url: "EgitimDetayFormu.aspx/EgitimDetayFormuGuncellemeListele",
                data: "{'formId':" + formId + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    var guncellemeListesi = eval(data.d);
                    var tblGuncellemeler = $('#tblGuncellemeler');
                    tblGuncellemeler.empty();
                    tblGuncellemeler.append("<tr>" +
                            "<th style='text-align: center'>Açıklama</th>" +
                             "<th style='text-align: center'>Oluşturan Kullanıcı</th>" +
                              "<th style='text-align: center'>İşlem Tarihi</th>" +
                            "<th style='text-align: center'>İşlemler</th>")

                    $.each(guncellemeListesi, function (index, value) {

                        tblGuncellemeler.append("<tr>" +
                            "<td style='width: 50%; text-align: left;  vertical-align:middle;'>" + ((value.Aciklama == null) ? '-' : (value.Aciklama)) +
                               "<td style='width: 25%; text-align: left;  vertical-align:middle;'>" + ((value.OlusturanKullaniciTanim == null) ? '-' : (value.OlusturanKullaniciTanim)) +
                            "</td><td style='width: 10%; text-align: center; vertical-align:middle;'>" + ((value.OlusturulmaTarihi == null) ? '-' : ConvertDateWithTime(value.OlusturulmaTarihi)) +
                            "</td><td style=' text-align: center'> <a data-bs-toggle='modal' data-bs-backdrop='static' title='Güncelle' data-id='" + value.Id + "' onclick='EgitimDetayFormuGuncelleme(this);' href='#EgitimDetayFormuGuncellemeModal' style='padding-left: 8px; text-decoration:none;' data-islemtipi='kayitGuncelle'> <img src='../../img/gCons/edit.png' /></a>" +
                            "<a data-bs-toggle='modal' data-bs-backdrop='static' title='Detay' data-id='" + value.Id + "'   onclick='EgitimDetayFormuGuncelleme(this);' href='#EgitimDetayFormuGuncellemeModal' style='padding-left: 8px; text-decoration:none;' data-islemtipi='kayitDetay'> <img src='../../img/gCons/addressbook.png' /></a>" +
                            "<a data-bs-toggle='modal' data-bs-backdrop='static' title='Sil' data-id='" + value.Id + "'   onclick='EgitimDetayFormuGuncelleme(this);' href='#EgitimDetayFormuGuncellemeModal' style='padding-left: 8px; text-decoration:none;' data-islemtipi='kayitSil2'> <img src='../../img/gCons/recycle-full.png' /></a>"
                            + "</td></tr>");
                    });
                    //Footerda talimata ait yapılacak butonlar oluşturulur, en son talimata göre bu butonlar oluşturulur.
                    //Uyarı

                    tblGuncellemeler.addClass("table table-bordered table-condensed table-striped dTableR");
                    tblGuncellemeler.paginate({
                        'elemsPerPage': 10
                    });
                },
                error: function (err) {
                    $("#modalAlertHeader").html("İşlem Yapılamıyor");
                    $("#modalAlertBody").html("İşleminiz şu anda gerçekleştirilemiyor. Lütfen daha sonra tekrar deneyiniz ya da <br /><b>BİLGİ İŞLEM</b> ile irtibata geçiniz.");
                     var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                    return;
                }
            });

                    }

      

        function ConvertDateWithTimeEski(jsonDate) {
          
           

            return (jsDate.getDate() < 10 ? ("0" + jsDate.getDate()) : jsDate.getDate()) + "."
                + (jsDate.getMonth() < 9 ? ("0" + (jsDate.getMonth() + 1)) : (jsDate.getMonth() + 1)) + "."
                + jsDate.getFullYear() + " "
                + (jsDate.getHours() < 10 ? ("0" + jsDate.getHours()) : jsDate.getHours()) + ":"
                + (jsDate.getMinutes() < 10 ? ("0" + jsDate.getMinutes()) : jsDate.getMinutes());
        }

     </script>

</asp:Content>
