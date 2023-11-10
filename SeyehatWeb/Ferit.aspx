<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/IsGuvenligiEgitimi/IsGuvenligiEgitimi.master" AutoEventWireup="true" CodeBehind="MF_OrtamEtkenleriTanim.aspx.cs" Inherits="THSSBS.Web.Modules.IsGuvenligiEgitimi.MF_OrtamEtkenleriTanim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="IsGuvenligiEgitimiHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="IsGuvenligiEgitimiBody" runat="server">

    <div class="accordion-group accordion-heading-header">
        <div class="accordion-heading">
            <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                <i class="splashy-zoom" style="position: relative; top: 1px;"></i>&nbsp;<b>Ortam Etkeni
                Araması</b></span>
        </div>
    </div>


    <div class="container">
        <div class="row">
            <div class="col-lg-2 col-sm-3 align-self-center">
                <b>Ortam Etkeni Adı :</b>
            </div>
            <div class="col-lg-3 col-sm-6">
                <asp:TextBox runat="server" ID="txtOrtamEtkenleriArama" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="col-lg-2 col-sm-2">
                <asp:Button runat="server" value="Ara" ID="btnAra"
                    CssClass="btn btn-primary" Text="Ara" OnClick="btnAra_Click" />
            </div>
        </div>
    </div>

    <div class="accordion-group">
        <div class="accordion-heading accordion-heading-header">
            <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                <i class="splashy-document_letter" style="position: relative; top: 1px;"></i>&nbsp;<b>Ortam Etkenleri Listesi</b></span>
        </div>
    </div>

    <div class="btn-group">
        <a data-bs-toggle="modal" id="A4" data-bs-backdrop="static" class="btn btn-primary"
            href="#MF_OrtamEtkenleriModal" onclick="PrepareModalPopup('yeniKayit')">Yeni Kayıt</a>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gridOrtamEtkenleri" runat="server" Width="100%" CssClass="table table-bordered table-condensed table-striped"
            Font-Names="Calibri" AutoGenerateColumns="False" PageSize="10" DataKeyNames="Id" AllowPaging="True"
            OnPageIndexChanging="gridOrtamEtkenleri_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="EtkenAciklama" HeaderText="Etken Açıklama" SortExpression="EtkenAciklama"
                    NullDisplayText="-">
                    <ItemStyle Width="15%" HorizontalAlign="left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="OlcumTarihi" HeaderText="Ölçüm Tarihi" SortExpression="OlcumTarihi"
                    DataFormatString="{0:dd.MM.yyyy}" NullDisplayText="-">
                    <ItemStyle Width="15%" HorizontalAlign="left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="OlcumSonucu" HeaderText="Ölçüm Sonucu" SortExpression="OlcumSonucu"
                    NullDisplayText="-">
                    <ItemStyle Width="15%" HorizontalAlign="left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="İşlemler" ShowHeader="False">
                    <ItemTemplate>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A1" title="Detayı Görüntüle" data-id='<%# Eval("Id") %>' onclick="OrtamEtkenleri(this);"
                            href="#MF_OrtamEtkenleriModal" style="padding-right: 8px;" data-islemtipi="kayitDetay">
                            <img src="/img/gCons/addressbook.png" alt="Detay" /></a>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A2" runat="server" title="Güncelle" data-id='<%# Eval("Id") %>' onclick="OrtamEtkenleri(this);"
                            href="#MF_OrtamEtkenleriModal" style="padding-left: 8px;" data-islemtipi="kayitGuncelle">
                            <img src="/img/gCons/edit.png" alt="Güncelle" /></a>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A3" runat="server" title="Sil" data-id='<%# Eval("Id") %>' onclick="OrtamEtkenleri(this);"
                            href="#MF_OrtamEtkenleriModal" style="padding-left: 8px;" data-islemtipi="kayitSil">
                            <img src="/img/gCons/recycle-full.png" alt="Sil" /></a>

                    </ItemTemplate>
                    <ItemStyle Width="20%" VerticalAlign="Middle" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="GridPager" />
            <SelectedRowStyle Font-Bold="True" ForeColor="#3993BA" />

        </asp:GridView>
    </div>

    <asp:HiddenField ID="hiddenSecilenOrtamEtkenleriId" runat="server" Value="" EnableViewState="False" />
    <div class="modal fade" id="MF_OrtamEtkenleriModal">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h3>
                        <span class="yeniKayit">
                            <img src="../../img/gCons/add-item.png" alt="" />Yeni Kayıt</span>
                        <span class="kayitDetay">
                            <img src="../../img/gCons/addressbook.png" alt="" />Ortam Etkenleri Detayı</span>
                        <span class="kayitGuncelle">
                            <img src="../../img/gCons/edit.png" alt="" />Ortam Etkenleri Güncelle</span>
                        <span class="kayitSil">
                            <img src="../../img/gCons/recycle-full.png" alt="" />Ortam Etkenleri Sil</span>
                    </h3>
                    <button data-bs-dismiss="modal" id="MF_OrtamEtkenleriModalCloseButton">x</button>
                </div>
                <div class="modal-body">
                    <div id="popupEkrani">
                        <table class="table table-bordered table-condensed table-striped dTableR" id="tblMF_OrtamEtkenleri">
                            <thead>
                                <tr>
                                    <th colspan="4">MF Ortam Etkenleri
                                    </th>
                                </tr>
                            </thead>
                            <tbody>

                                <tr>
                                    <td class="tdWidth" style="text-align: right; vertical-align: middle">Ortam Etkeni :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="drpOrtamEtkenleri" ClientIDMode="Static" CssClass="form-control" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seçiniz" Value="Seçiniz" />
                                            <asp:ListItem Text="Gürültü" Value="Gürültü" />
                                            <asp:ListItem Text="Termal Konfor" Value="Termal Konfor" />
                                            <asp:ListItem Text="Gürültü" Value="Gürültü" />

                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredOrtamEtkeni" runat="server" Text="*" ControlToValidate="drpOrtamEtkenleri"
                                            ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" InitialValue="Seçiniz" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdWidth" style="text-align: right; vertical-align: middle">Ölçüm Tarihi :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOlcumTarihi" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredTarih" runat="server" Text="*" ControlToValidate="txtOlcumTarihi"
                                            ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />

                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdWidth" style="text-align: right; vertical-align: middle">Ölçüm Sonucu :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOlcumSonucu" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredOlcumSonucu" runat="server" Text="*" ControlToValidate="txtOlcumSonucu"
                                            ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="modal-footer">
                    <span class="yeniKayit">
                        <asp:Button ID="btnKaydet" Text="Kaydet" CssClass="btn btn-primary" runat="server"
                            ValidationGroup="Islem" ClientIDMode="Static" OnClick="btnKaydet_Click" /></span>
                    <span class="kayitGuncelle">
                        <asp:Button ID="btnGuncelle" ClientIDMode="Static" Text="Güncelle" CssClass="btn btn-primary" runat="server"
                            ValidationGroup="Islem" OnClick="btnGuncelle_Click" /></span>
                    <span class="kayitSil">
                        <asp:Button ID="btnSil" Text="Sil" ClientIDMode="Static" CssClass="btn btn-primary" runat="server"
                            ValidationGroup="Islemyok" OnClick="btnSil_Click" /></span>
                    <span class="kayitDetay"></span>
                </div>
            </div>
        </div>

    </div>
    <script type="text/javascript">
        var hiddenSecilenOrtamEtkenleriId = $("#<%= hiddenSecilenOrtamEtkenleriId.ClientID %>");


        var drpOrtamEtkenleri = $("#<%= drpOrtamEtkenleri.ClientID %>");
        var txtOlcumTarihi = $("#<%= txtOlcumTarihi.ClientID %>");
        var txtOlcumSonucu = $("#<%= txtOlcumSonucu.ClientID %>");




        function OrtamEtkenleri(element) {
            var ortamEtkenId = $(element).attr("data-id");
            var islemTipi = $(element).attr("data-islemtipi");

            if (ortamEtkenId == null || ortamEtkenId == 'undefined') {
                $("#modalAlertHeader").html("Ortam Etkenleri Bilgilerini Getirelemiyor");
                $("#modalAlertBody").html("İşlem yapmak istediğiniz <b>Ortam Etkeni Bilgisi</b> getirilemedi. Lütfen daha sonra tekrar deneyiniz.");
                var myModal = new bootstrap.Modal(document.getElementById("modalAlert"), {});
                myModal.show();
                return;
            }

            $.ajax({
                type: "POST",
                url: "MF_OrtamEtkenleriTanim.aspx/OrtamEtkenleriGetir",
                data: "{'OrtamEtkenleriId':" + OrtamEtkenleriId + "}",
                contentType: "application/json; charset=utf-8",
                dataType="json",
                success: function (data) {
                    var OrtamEtkenDetay = eval(data.d);
                    hiddenSecilenOrtamEtkenleriId.val(OrtamEtkenDetay.Id.toString());

                    if (OrtamEtkenDetay.OlcumTarihi != null) txtOlcumTarihi.val(ConvertDate(OrtamEtkenDetay.OlcumTarihi));

                    if (OrtamEtkenDetay.OlcumSonucu != null) txtOlcumSonucu.val(OrtamEtkenDetay.OlcumSonucu);
                    if (OrtamEtkenDetay.EtkenAciklama != null) drpOrtamEtkeni.val(OrtamEtkenDetay.EtkenAciklama);

                },

                error: function (err) {
                    $("#modalAlertHeader").html("İşlem Yapılamıyor");
                    $("#modalAlertBody").html("İşleminiz şu anda gerçekleştirilemiyor. Lütfen daha sonra tekrar deneyiniz ya da <br /><b>BİLGİ İŞLEM</b> ile irtibata geçiniz.");
                    var myModal = new bootstrap.Modal(document.getElementById("modalAlert"), {});
                    myModal.show();
                    return;
                }

            });
            PrepareModalPopup(islemTipi);
        }



        function Temizle() {
            $("MF_OrtamEtkenleriModal div").scrollTop(0);

            $("MF_OrtamEtkenleriModal input")
                .not(":input[type=submit], :input[type=button], :input[type=checkbox]")
                .val("");
            $("MF_OrtamEtkenleriModal textarea").each(function () {
                $(this).val("");
            });

            $("#IsKazasiSoruModal select").each(function () {
                $(this)[0].selectedIndex = 0;
            });

            $("#IsKazasiSoruModal :checked").each(function () {
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

        $("#MF_OrtamEtkenleriModalCloseButton")
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

                $("#MF_OrtamEtkenleriModal *")
                    .not(":input[type=submit]")
                    .not("button")
                    .removeAttr("disabled");

            }
            else {
                $("#MF_OrtamEtkenleriModal *")
                    .not(":input[type=submit]")
                    .not("button")
                    .prop("disabled", "disabled");
            }
        }


        function GetDateString() {
            var date = new Date();
            var day = date.getDate();
            var month = date.getMonth() + 1;
            var year = date.getFullYear();
            var dateString = ((day < 10) ? ("0" + day) : day) + "." + ((month < 10) ? ("0" + month) : month) + "." + year;

            return dateString;
        }
        $("#<%= txtOlcumTarihi.ClientID %>").datepicker({
            dateFormat: "dd.mm.yy",
            monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
            dayNamesMin: ["Pzr", "Pts", "Sal", "Çrş", "Prş", "Cm", "Cts"],
            setDate: new Date(),
            //maxDate: new Date(),
        });

    </script>


</asp:Content>