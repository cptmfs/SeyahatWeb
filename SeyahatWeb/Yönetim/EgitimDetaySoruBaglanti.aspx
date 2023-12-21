<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="EgitimDetaySoruBaglanti.aspx.cs" Inherits="SeyahatWeb.Yönetim.EgitimDetaySoruBaglanti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="accordion-group">
        <div class="accordion-heading accordion-heading-header">
            <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                <i class="splashy-document_letter" style="position: relative; top: 1px;"></i>&nbsp;<b> Eğitim Detay Formu Soru Bağlantı Listesi </b></span>
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gridEgitimDetayFormuSoruBaglanti" runat="server" Width="100%" CssClass="table table-bordered table-condensed table-striped"
            Font-Names="Calibri" AutoGenerateColumns="False" PageSize="20" DataKeyNames="Id" AllowPaging="True" OnPageIndexChanging="gridEgitimDetayFormuSoruBaglanti_PageIndexChanging">
            <Columns>


                <asp:BoundField DataField="Aciklama" HeaderText="Giriş Seçenekleri" SortExpression="Aciklama"
                    NullDisplayText="-">
                    <ItemStyle Width="25%" HorizontalAlign="center" VerticalAlign="Middle" />
                </asp:BoundField>



                <asp:TemplateField HeaderText="İşlemler" ShowHeader="False">
                    <ItemTemplate>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A4" title="Soru Ekle/Çıkar" data-turid='<%# Eval("Id") %>' onclick="SoruEkle(this);"
                            href="#anchorSoruListesiModal" style="padding-right: 8px;" data-islemtipi="soruEkle">
                            <img src="../../images/gCons/add-item.png" alt="Soru Ekle/Çıkar" /></a>
                    </ItemTemplate>
                    <ItemStyle Width="20%" VerticalAlign="Middle" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="GridPager" />
            <SelectedRowStyle Font-Bold="True" ForeColor="#3993BA" />

        </asp:GridView>
    </div>

    <asp:HiddenField ID="hiddenSecilenEgitimDetayFormuSoruBaglantiId" runat="server" Value="" EnableViewState="False" />


    <div id="soruList">
        <%--KonuListesi Modal----%>
        <%--  <a data-bs-toggle="modal" data-bs-backdrop="static" id="anchorKonuListesiModal"
    href="#konuListesiModal" style="visibility: hidden"></a>--%>
        <div class="modal fade" id="anchorSoruListesiModal">
            <div class="modal-dialog modal-xl modal-dialog-scrollable">
                <div class="modal-content">
                    <div class="modal-header">

                        <h3>
                            <span>
                                <img src="doc/img/gCons/search.png" alt="" style="position: relative; top: -3px" />Soru Listesi</span>
                        </h3>
                        <button data-bs-dismiss="modal" id="soruListesiModalCloseButton">
                            ×</button>
                    </div>
                    <div class="modal-body">
                        <div class="accordion-group" style="width: 523px; position: relative; margin-bottom: 10px; display: inline-block; float: left">
                            <div class="accordion-heading" style="text-align: center">
                                <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                                    <i style="position: relative; top: 1px"></i><span>&nbsp;<b>Soru Listesi</b> </span></span>
                            </div>
                        </div>
                        <div class="accordion-group" style="width: 520px; position: relative; margin-bottom: 10px; display: inline-block; float: right">
                            <div class="accordion-heading" style="text-align: center">
                                <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                                    <i style="position: relative; top: 1px"></i><span>&nbsp;<b>Seçilen Sorular</b> </span></span>
                            </div>
                        </div>
                        <select id="konuListesi" multiple="multiple"></select>
                    </div>
                    <div class="modal-footer">
                        <span class="kayitSoruListesiOlustur">
                            <input type="button" id="btnSoruListesi" class="btn btn-primary" style="width: 100px" value="Seç" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        var hiddenSecilenEgitimDetayFormuSoruBaglantiId = $("#<%= hiddenSecilenEgitimDetayFormuSoruBaglantiId.ClientID %>");




        function Temizle() {

            // $("#AramaGrid").find("input:text").val('');

            $("#anchorSoruListesiModal div").scrollTop(0);

            $("#anchorSoruListesiModal input")
                .not(":input[type=submit], :input[type=button], :input[type=checkbox]")
                .val("");

            $("#anchorSoruListesiModal textarea").each(function () {
                $(this).val("");
            });
            //$("#PeriyodikMuayeneSoruModal span").html("");
            $("#anchorSoruListesiModal select").each(function () {
                $(this)[0].selectedIndex = 0;

            });

            $("#anchorSoruListesiModal :checked").each(function () {
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

        $("#anchorSoruListesiModalCloseButton")
            .click(function () {
                Temizle();
            });


        function PrepareModalPopup(islemTipi) {
            //Temizle();

            switch (islemTipi) {


                case "soruEkle":

                    $("span.soruEkle").css("display", "");

                    EnableInputElements(true);
                    break;
            }
        }

        function EnableInputElements(enableElements) {
            if (enableElements) {
                $("#anchorSoruListesiModal *")
                    .not(":input[type=submit]")
                    .not("button")
                    .removeAttr("disabled");
            }
            else
                $("#anchorSoruListesiModal *")
                    .not(":input[type=submit]")
                    .not("button")
                    .prop("disabled", "disabled");
        }

        var soruListesi = new Array();
        var turId = 0;

        function SoruEkle(element) {

            var TurId = $(element).attr("data-turId");
            var islemTipianchorKonuListesi = $(element).attr("data-islemtipi");

            hiddenSecilenEgitimDetayFormuSoruBaglantiId.val(TurId);
            turId = hiddenSecilenEgitimDetayFormuSoruBaglantiId.val();


            //var TurId = $(element).attr("data-TurId");

            if (TurId == null || TurId == 'undefined') {
                $("#modalAlertHeader").html("Tür Bilgisi Getirilemiyor");
                $("#modalAlertBody").html("İşlem yapmak istediğiniz <b>Tür bilgisi</b> getirilemedi. Lütfen daha sonra tekrar deneyiniz.");
                var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                return;
            }


            $.ajax({
                type: "POST",
                url: "EgitimDetaySoruBaglanti.aspx/SoruGetir",
                data: "{'TurId':" + TurId + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var anchorKonuListesiDetay = eval(data.d);
                    // hiddenSecilenIsGuvenligiTurId.val(anchorKonuListesiDetay.Id.toString());
                    console.log(anchorKonuListesiDetay);
                    //if (anchorKonuListesiDetay.KonuId != null) drpBirim.val(anchorKonuListesiDetay.KonuId.toString());
                    $.each(anchorKonuListesiDetay, function (index, value) {
                        soruListesi.push(value.EgitimDetayFormuSoruId);
                    });
                    KategorileriListele();

                    //var myModal = new bootstrap.Modal(document.getElementById("anchorKonuListesiModal"), {});
                    //myModal.show();
                },
                error: function (err) {
                    $("#modalAlertHeader").html("İşlem Yapılamıyor");
                    $("#modalAlertBody").html("İşleminiz şu anda gerçekleştirilemiyor. Lütfen daha sonra tekrar deneyiniz ya da <br /><b>BİLGİ İŞLEM</b> ile irtibata geçiniz.");
                    var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                    return;
                }
            });

            //hiddenSecilenHedefElemanlariId.val(HedefElemaniId.toString());
            PrepareModalPopup(islemTipianchorKonuListesi);
        }

        $("#soruListesiModalCloseButton").click(function () {

            $("#soruList input")
                .not(":input[type=submit], :input[type=button], :input[type=checkbox]")
                .val("");
            $('.tree-multiselect').children().remove();
            $('.tree-multiselect').remove();
            $('select#konuListesi').html('');
            soruListesi = [];
            var myModal = new bootstrap.Modal(document.getElementById("anchorSoruListesiModal"), {});
            myModal.hide();
        });

        function KategorileriListele() {

            var d = new jQuery.Deferred();
            $.ajax({
                type: "POST",
                url: "EgitimDetaySoruBaglanti.aspx/SoruListele",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (data) {

                    var konuListesi = $('select#konuListesi');
                    var ullist = $('#header ul');
                    var kategoriler = eval(data.d);
                    console.log(kategoriler);
                    $.each(kategoriler, function (index) {

                        var datasection = kategoriler[index].EgitimDetayFormuSoruBaslikTanim;

                        konuListesi.append("<option value='" + kategoriler[index].Id + "'data-section='" + datasection + "' >" + " - " + kategoriler[index].Tanim + "</option>");

                    });


                    $.each(soruListesi, function (index, value) {

                        $('select#konuListesi option[value="' + value + '"]').attr('selected', '');

                    });


                    $('select#konuListesi').treeMultiselect({
                        sortable: true,
                        startCollapsed: true,
                        showSectionOnSelected: false,
                        singleSelection: true,
                        allowBatchSelection: false,
                        searchable: true

                    });
                },

                error: function (xhr, status, error) {
                    $("#modalAlertHeader").html("İşlem Yapılamıyor");
                    $("#modalAlertBody").html("İşleminiz şu anda gerçekleştirilemiyor. Lütfen daha sonra tekrar deneyiniz ya da <br /><b>BİLGİ İŞLEM</b> ile irtibata geçiniz.");
                    var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                    return;
                }
            });
        }

        $("#btnSoruListesi").click(function () {
            var secilenler = $('select#konuListesi').val();
            var secilenler = secilenler.map(Number);

            if (secilenler != null) {
                $.ajax({
                    type: "POST",
                    url: "EgitimDetaySoruBaglanti.aspx/SorulariGonder",
                    data: "{'secilenler':" + JSON.stringify(secilenler) + ", 'turId': " + turId + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        console.log("Selected values was send.");

                        $('#konuListesiModalCloseButton').click();
                        window.location.reload();
                    },
                    error: function (err) {
                        $("#modalAlertHeader").html("İşlem Yapılamıyor");
                        $("#modalAlertBody").html("İşleminiz şu anda gerçekleştirilemiyor. Lütfen daha sonra tekrar deneyiniz ya da <br /><b>BİLGİ İŞLEM</b> ile irtibata geçiniz.");
                        var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                        return;
                    }
                });
            }

        })
    </script>

</asp:Content>
