<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="EgitimTuruTanim.aspx.cs" Inherits="SeyahatWeb.Yönetim.EgitimTuruTanim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <h2>Eğitim Türü Listesi</h2>
    <div class="accordion-group accordion-heading-header">
        <div class="accordion-heading">
            <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                <i class="splashy-group_blue" style="position: relative; top: -1px;"></i>&nbsp;<b>Eğitim Türü Arama</b>
            </span>
        </div>
    </div>

    <div class="contanier">
        <div class="row">
            <div class="col-lg-2 col-sm-1  align-self-center"><b>Eğitim Türü Adı:</b></div>
            <div class="col-lg-2 col-sm-3">
                 <asp:TextBox ID="txtAdAra" runat="server"  CssClass="form-control" />
            </div>

              <div class="col-lg-1 col-sm-3  align-self-center">
                <asp:Button Text="Ara" ID="btnAra"  CssClass="btn btn-primary" runat="server" 
                                OnClick="btnAra_Click" />
            </div>

           
           

        </div>
    </div>


   
    <div class="accordion-group accordion-heading-header">
        <div class="accordion-heading">
            <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                <i class="splashy-zoom_in" style="position: relative; top: 1px;"></i>&nbsp;<b>Arama
                Sonuçları</b> </span>
        </div>
    </div>

      <div class="btn-group">
        <a data-bs-toggle="modal" id="A4" data-bs-backdrop="static" class="btn btn-primary" href="#EgitimTuruModal"
            onclick="PrepareModalPopup('yeniKayit')">Yeni Kayıt</a>
    </div>
     <div class="table-responsive"><asp:GridView ID="gridEgitimTuruListesi" runat="server" Width="100%" CssClass="table table-bordered table-condensed table-striped"
            Font-Names="Calibri" AutoGenerateColumns="False" PageSize="10" DataKeyNames="Id" AllowPaging="True" OnPageIndexChanging="gridEgitimTuruListesi_PageIndexChanging">
            <Columns>              
                <asp:BoundField DataField="Tanim" HeaderText="Adı" SortExpression="Tanim">
                    <ItemStyle Width="45%" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="İşlemler" ShowHeader="False">
                    <ItemTemplate>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A1" title="Detayı Görüntüle" data-id='<%# Eval("Id") %>' onclick="EgitimTuru(this);"
                            href="#EgitimTuruModal" style="padding-right: 8px;" data-islemtipi="kayitDetay">
                            <img src="../../images/gCons/addressbook.png" alt="Detay" /></a>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A2" runat="server" title="Güncelle" data-id='<%# Eval("Id") %>' onclick="EgitimTuru(this);"
                            href="#EgitimTuruModal" style="padding-left: 8px;" data-islemtipi="kayitGuncelle">
                            <img src="../../images/gCons/edit.png" alt="Güncelle" /></a>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A3" runat="server" title="Sil" data-id='<%# Eval("Id") %>' onclick="EgitimTuru(this);"
                            href="#EgitimTuruModal" style="padding-left: 8px;" data-islemtipi="kayitSil">
                            <img src="../../images/gCons/recycle-full.png" alt="Sil" /></a>

                    </ItemTemplate>
                    <ItemStyle Width="20%" VerticalAlign="Middle" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
             <PagerStyle CssClass="GridPager" /> <SelectedRowStyle Font-Bold="True" ForeColor="#3993BA" />
            <EmptyDataTemplate>
                <b>Belirtilen kriterlere ait herhangi bir kayıt bulunamadı.</b>
                <br />
                Yukarıdaki arama kriterlerini belirterek <b>Eğitim Türü arama</b> işlemini yapabilirsiniz.
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
  
    <asp:HiddenField ID="hiddenSecilenEgitimTuruId" runat="server" Value="" EnableViewState="False" />

    <div class="modal fade"  id="EgitimTuruModal">
  <div class="modal-dialog modal-dialog-scrollable" ><div class="modal-content"> <div class="modal-header">
           <h3>
                <span class="kayitDetay">
                    <img src="../../images/gCons/addressbook.png" alt="" />Eğitim Türü Detayı</span>
                <span class="yeniKayit">
                    <img src="../../images/gCons/add-item.png" alt="" />Yeni Kayıt</span>  <span class="kayitGuncelle">
                        <img src="../../images/gCons/edit.png" alt="" />Kayıt Güncelle</span><span class="kayitSil">
                            <img src="../../images/gCons/recycle-full.png" alt="" />Kayıt Sil</span>

            </h3><button class="close" data-bs-dismiss="modal" id="EgitimTuruModalCloseButton">
 x</button>
        </div>
        <div class="modal-body" >
            <div id="popupEkranı">
                <table class="table table-bordered table-condensed table-striped dTableR" id="tblEgitimTuruPopup">
                    <thead>
                        <tr>
                            <th colspan="4">Eğitim Türü Bilgileri
                            </th>
                        </tr>
                    </thead>
                    <tbody>                        
                        <tr>
                            <td class="tdWidth" style="text-align: right; vertical-align: middle">Eğitim Türü Adı :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAd" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="requiredAd" runat="server" Text="*" ControlToValidate="txtAd"
                                    ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                            </td>
                        </tr>                      
                    </tbody>
                </table>
            </div>
        </div>
        <div class="modal-footer">
            <span class="yeniKayit">
                <asp:Button ID="btnKaydet" Text="Kaydet"  CssClass="btn btn-primary" runat="server" Width="100"
                    ValidationGroup="Islem" ClientIDMode="Static"  OnClick="btnKaydet_Click" /></span>
            <span class="kayitGuncelle">
                <asp:Button ID="btnGuncelle" Text="Güncelle"  CssClass="btn btn-primary" runat="server" Width="100"
                    ValidationGroup="Islem" ClientIDMode="Static"  OnClick="btnGuncelle_Click" /></span>
            <span class="kayitSil">
                <asp:Button ID="btnSil" Text="Sil"  CssClass="btn btn-primary" runat="server" Width="100"
                    ValidationGroup="Islemyok" ClientIDMode="Static"  OnClick="btnSil_Click" /></span>
            <span class="kayitDetay"></span></div></div></div></div>
    <script type="text/javascript">
        var hiddenSecilenEgitimTuruId = $("#<%= hiddenSecilenEgitimTuruId.ClientID %>");

        var txtAd = $("#<%= txtAd.ClientID %>");



        function EgitimTuru(element) {

            var EgitimTuruId = $(element).attr("data-id");
            var islemTipi = $(element).attr("data-islemtipi");

            if (EgitimTuruId == null || EgitimTuruId == 'undefined') {
                $("#modalAlertHeader").html("DigerAlan Bilgisi Getirilemiyor");
                $("#modalAlertBody").html("İşlem yapmak istediğiniz <b>havayolu şirketi bilgisi</b> getirilemedi. Lütfen daha sonra tekrar deneyiniz.");
                 var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                return;
            }

            //Temizle();

            $.ajax({
                type: "POST",
                url: "EgitimTuruTanim.aspx/EgitimTuruGetir",
                data: "{'EgitimTuruId':" + EgitimTuruId + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var EgitimTuruDetay = eval(data.d);
                    hiddenSecilenEgitimTuruId.val(EgitimTuruDetay.Id.toString());

                    if (EgitimTuruDetay.Tanim) txtAd.val(EgitimTuruDetay.Tanim);

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

            $("#EgitimTuruModal div").scrollTop(0);

            $("#EgitimTuruModal input")
                .not(":input[type=submit], :input[type=button], :input[type=checkbox]")
                .val("");

            $("#EgitimTuruModal textarea").each(function () {
                $(this).val("");
            });
            //$("#EgitimTuruModal span").html("");
            $("#EgitimTuruModal select").each(function () {
                $(this)[0].selectedIndex = 0;

            });

            $("#EgitimTuruModal :checked").each(function () {
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

        $("#EgitimTuruModalCloseButton")
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
                $("#EgitimTuruModal *")
                .not(":input[type=submit]")
                .not("button")
                .removeAttr("disabled");
            }
            else
                $("#EgitimTuruModal *")
                .not(":input[type=submit]")
                .not("button")
                .prop("disabled", "disabled");
        }


    </script>
</asp:Content>
