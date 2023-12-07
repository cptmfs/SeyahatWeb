<%@ Page Title="" Language="C#" MasterPageFile="~/Yönetim/Admin.Master" AutoEventWireup="true" CodeBehind="BlogDuzenleSil.aspx.cs" Inherits="SeyehatWeb.Yönetim.BlogDuzenleSil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="page-title">Blog Düzenleme / Silme Sayfası</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" SelectCommand="SELECT * FROM [tblBlog]" DeleteCommand="DELETE FROM [tblBlog] WHERE [Id] = @Id" InsertCommand="INSERT INTO [tblBlog] ([Baslik], [Ozet], [KategoriId], [Resim], [Detay], [Tarih]) VALUES (@Baslik, @Ozet, @KategoriId, @Resim, @Detay, @Tarih)" UpdateCommand="UPDATE [tblBlog] SET [Baslik] = @Baslik, [Ozet] = @Ozet, [KategoriId] = @KategoriId, [Resim] = @Resim, [Detay] = @Detay, [Tarih] = @Tarih WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Baslik" Type="String"></asp:Parameter>
            <asp:Parameter Name="Ozet" Type="String"></asp:Parameter>
            <asp:Parameter Name="KategoriId" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Resim" Type="String"></asp:Parameter>
            <asp:Parameter Name="Detay" Type="String"></asp:Parameter>
            <asp:Parameter Name="Tarih" Type="DateTime"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Baslik" Type="String"></asp:Parameter>
            <asp:Parameter Name="Ozet" Type="String"></asp:Parameter>
            <asp:Parameter Name="KategoriId" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Resim" Type="String"></asp:Parameter>
            <asp:Parameter Name="Detay" Type="String"></asp:Parameter>
            <asp:Parameter Name="Tarih" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" CssClass="table table-striped" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#Eval("id","BlogDuzenleSecilen.aspx?id={0}") %>' runat="server">Duzenle</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="False"></asp:CommandField>
        </Columns>
    </asp:GridView>--%>
    <div class="accordion-group">
        <div class="accordion-heading accordion-heading-header">
            <span class="accordion-toggle" style="position: relative; left: -9px; cursor: default">
                <i class="splashy-document_letter" style="position: relative; top: 1px;"></i>&nbsp;<b> Blog Listesi </b></span>
        </div>
    </div>
    <div class="btn-group">
        <a data-bs-toggle="modal" id="A4" data-bs-backdrop="static" class="btn btn-primary" href="#BlogModal"
            onclick="PrepareModalPopup('yeniKayit')">Yeni Kayıt</a>
    </div>


    <div class="table-responsive">
        <asp:GridView ID="gridBlog" runat="server" Width="100%" CssClass="table table-bordered table-condensed table-striped"
            Font-Names="Calibri" AutoGenerateColumns="False" PageSize="20" DataKeyNames="Id" AllowPaging="True" OnPageIndexChanging="gridBlog_PageIndexChanging">
            <Columns>

                <asp:BoundField DataField="Id" HeaderText="Id No" SortExpression="Id"
                    NullDisplayText="-">
                    <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>

                <asp:BoundField DataField="Baslik" HeaderText="Başlık" SortExpression="Baslik"
                    NullDisplayText="-">
                    <ItemStyle Width="10%" HorizontalAlign="left" VerticalAlign="Middle" />
                </asp:BoundField>

                <asp:BoundField DataField="Ozet" HeaderText="Özet" SortExpression="Ozet"
                    NullDisplayText="-">
                    <ItemStyle Width="10%" HorizontalAlign="left" VerticalAlign="Middle" />
                </asp:BoundField>

                <asp:BoundField DataField="KategoriId" HeaderText="Kategori Id" SortExpression="KategoriId"
                    NullDisplayText="-">
                    <ItemStyle Width="8%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Detay" SortExpression="Detay">
                    <ItemTemplate>
                        <%# Eval("Detay").ToString().Length > 100 ? Eval("Detay").ToString().Substring(0, 100) + "..." : Eval("Detay") %>
                    </ItemTemplate>
                    <ItemStyle Width="8%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:BoundField DataField="Tarih" HeaderText="Tarih" SortExpression="Tarih"
                    NullDisplayText="-">
                    <ItemStyle Width="8%" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>


                <%--      <asp:BoundField DataField="Aciklama" HeaderText="Açıklama" SortExpression="Aciklama"
                    NullDisplayText="-">
                    <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>--%>



                <asp:TemplateField HeaderText="İşlemler" ShowHeader="False">
                    <ItemTemplate>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A1" title="Detayı Görüntüle" data-id='<%# Eval("Id") %>' onclick="Blog(this);"
                            href="#BlogModal" style="padding-right: 8px;" data-islemtipi="kayitDetay">
                            <img src="/images/gCons/addressbook.png" alt="Detay" /></a>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A2" runat="server" title="Güncelle" data-id='<%# Eval("Id") %>' onclick="Blog(this);"
                            href="#BlogModal" style="padding-left: 8px;" data-islemtipi="kayitGuncelle">
                            <img src="/images/gCons/edit.png" alt="Güncelle" /></a>
                        <a data-bs-toggle="modal" data-bs-backdrop="static"
                            id="A3" runat="server" title="Sil" data-id='<%# Eval("Id") %>' onclick="Blog(this);"
                            href="#BlogModal" style="padding-left: 8px;" data-islemtipi="kayitSil">
                            <img src="/images/gCons/recycle-full.png" alt="Sil" /></a>

                    </ItemTemplate>
                    <ItemStyle Width="20%" VerticalAlign="Middle" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="GridPager" />
            <SelectedRowStyle Font-Bold="True" ForeColor="#3993BA" />

        </asp:GridView>
    </div>




    <asp:HiddenField ID="hiddenSecilenBlogId" runat="server" Value="" EnableViewState="False" />

    <div class="modal fade" id="BlogModal">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <h3>

                        <span class="yeniKayit">
                            <img src="../../images/gCons/add-item.png" alt="" />Yeni Kayıt</span>
                        <span class="kayitDetay">
                            <img src="../../images/gCons/addressbook.png" alt="" />Blog Detayı</span>
                        <span class="kayitGuncelle">
                            <img src="../../images/gCons/edit.png" alt="" />Blog Güncelle</span><span class="kayitSil">
                                <img src="../../images/gCons/recycle-full.png" alt="" />Bina Sil</span>
                    </h3>
                    <button class="close" data-bs-dismiss="modal" id="BlogModalCloseButton">
                        x</button>
                </div>
                <div class="modal-body ">
                    <div id="popupEkranı">
                        <table class="table table-bordered table-condensed table-striped dTableR" id="tblBlog">
                            <thead>
                                <tr>
                                    <th colspan="4">Blog Bilgileri
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="tdWidth" style="text-align: right; vertical-align: middle">Başlık :
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtBaslik" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBaslik" runat="server" Text="*" ControlToValidate="txtBaslik"
                                            ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdWidth" style="text-align: right; vertical-align: middle">Özet :
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtOzet" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOzet" runat="server" Text="*" ControlToValidate="txtOzet"
                                            ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdWidth" style="text-align: right; vertical-align: middle">Kategori :
                                    </td>
                                    <td>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="drpBlogKategori" AppendDataBoundItems="True">
                                            <asp:ListItem Text="Seçiniz..." Value="-1" />
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredBlogKategori" runat="server" Text="*" ControlToValidate="drpBlogKategori"
                                            ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" InitialValue="-1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdWidth" style="text-align: right; vertical-align: middle">Resim :
                                    </td>
                                    <td>
                                        <asp:Image ID="imgResim" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="txtDetay"
                                            ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                                    </td>
                                    <tr>
                                        <td class="tdWidth" style="text-align: right; vertical-align: middle">Detay :
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtDetay" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDetay" runat="server" Text="*" ControlToValidate="txtDetay"
                                                ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                                        </td>
                                    </tr>
                                <tr>
                                    <td class="tdWidth" style="text-align: right; vertical-align: middle">Tarih :
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtTarih" />
                                        <asp:RequiredFieldValidator ID="requiredTarih" runat="server" Text="*" ControlToValidate="txtTarih"
                                            ValidationGroup="Islem" SetFocusOnError="True" ForeColor="Red" />
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="modal-footer">

                    <span class="yeniKayit">
                        <asp:Button ID="btnKaydet" Text="Kaydet" CssClass="btn btn-primary" runat="server" Width="100"
                            ValidationGroup="Islem" ClientIDMode="Static" OnClick="btnKaydet_Click" /></span>
                    <span class="kayitGuncelle">
                        <asp:Button ID="btnGuncelle" ClientIDMode="Static" Text="Güncelle" CssClass="btn btn-primary" runat="server" Width="100"
                            ValidationGroup="Islem" OnClick="btnGuncelle_Click" /></span>
                    <span class="kayitSil">
                        <asp:Button ID="btnSil" Text="Sil" ClientIDMode="Static" CssClass="btn btn-primary" runat="server" Width="100"
                            ValidationGroup="Islemyok" OnClick="btnSil_Click" /></span>
                    <span class="kayitDetay"></span>
                </div>
            </div>
        </div>
    </div>    

    <script type="text/javascript">
        var txtBaslik = $("#<%= txtBaslik.ClientID %>");
        var txtOzet = $("#<%= txtOzet.ClientID %>");
        var drpKategori = $("#<%= drpBlogKategori.ClientID %>");
        var imgResim = $("#<%= imgResim.ClientID %>");
        var txtDetay = $("#<%= txtDetay.ClientID %>");
        var txtTarih = $("#<%= txtTarih.ClientID %>");

        var hiddenSecilenBlogId = $("#<%= hiddenSecilenBlogId.ClientID %>");

        // MODAL

        function Blog(element) {            
            var BlogId = $(element).attr("data-id");
            console.log("deneme");
            var islemTipi = $(element).attr("data-islemtipi");

            if (BlogId == null || BlogId == 'undefined') {
                $("#modalAlertHeader").html("Blog Bilgisi Getirilemiyor");
                $("#modalAlertBody").html("İşlem yapmak istediğiniz <b>Blog bilgisi</b> getirilemedi. Lütfen daha sonra tekrar deneyiniz.");
                var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                return;
            }

            // AJAX }

            $.ajax({
                type: "POST",
                url: "BlogDuzenleSil.aspx/BlogGetirAjax",
                data: "{'BlogId':" + BlogId + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) { 
                    var BlogDetay= eval(data.d);
                    hiddenSecilenBlogId.val(BlogDetay.Id.toString());
                    console.log(BlogDetay);

                    if (BlogDetay.Baslik != null) txtBaslik.val(BlogDetay.Baslik);
                    if (BlogDetay.Ozet != null) txtOzet.val(BlogDetay.Ozet);
                    if (BlogDetay.KategoriAciklama != null) drpKategori.val(BlogDetay.KategoriAciklama.toString());
                    if (BlogDetay.Resim != null) imgResim.val(BlogDetay.Resim);
                    if (BlogDetay.Detay != null) txtDetay.val(BlogDetay.Detay);
                    if (BlogDetay.Tarih != null) txtTarih.val(BlogDetay.Tarih);
                },
                error: function (err) {
                    $("#modalAlertHeader").html("İşlem Yapılamıyor");
                    $("#modalAlertBody").html("İşleminiz şu anda gerçekleştirilemiyor. Lütfen daha sonra tekrar deneyiniz ya da <br /><b>BİLGİ İŞLEM</b> ile irtibata geçiniz.");
                    var myModal1 = new bootstrap.Modal(document.getElementById("modalAlert"), {}); myModal1.show();
                    return;
                }
            });
            console.log("gir");

            PrepareModalPopup(islemTipi);
            console.log("cik");

        }
        function Temizle() {

            // $("#AramaGrid").find("input:text").val('');

            $("#BlogModal div").scrollTop(0);

            $("#BlogModal input")
                .not(":input[type=submit], :input[type=button], :input[type=checkbox]")
                .val("");

            $("#BlogModal textarea").each(function () {
                $(this).val("");
            });
            //$("#BinaModal span").html("");
            $("#BlogModal select").each(function () {
                $(this)[0].selectedIndex = 0;

            });

            $("#BlogModal :checked").each(function () {
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

        $("#BlogModalCloseButton").click(function () {Temizle();});
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

                    $("#LimanModal").ready();
                    $("span.kayitDetay").css("display", "");
                    $("span.kayitSil").css("display", "none");
                    EnableInputElements(false);
                    break;


            }
        }

        function EnableInputElements(enableElements) {
            if (enableElements) {
                $("#BinaModal *")
                    .not(":input[type=submit]")
                    .not("button")
                    .removeAttr("disabled");
            }
            else
                $("#BinaModal *")
                    .not(":input[type=submit]")
                    .not("button")
                    .prop("disabled", "disabled");
        } 




        //$("#txtTarih").
        //    datepicker({
        //        dateFormat: "dd.mm.yy",
        //        monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
        //        dayNamesMin: ["Pzr", "Pts", "Sal", "Çrş", "Prş", "Cm", "Cts"],
        //        setDate: new Date(),
        //        maxDate: new Date(),
        //        firstDay: 1,
        //        required: true,
        //        changeYear: true,
        //        changeMonth: true,
        //        monthNamesShort: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"]
        //    });

    </script>
</asp:Content>
