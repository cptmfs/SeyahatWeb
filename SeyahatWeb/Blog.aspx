<%@ Page Title="" Language="C#" MasterPageFile="~/Altsayfa.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="SeyehatWeb.Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Blog</h2>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="row">
        <div class="col-lg-8 mb-5 mb-lg-0">
            <div class="blog_left_sidebar">

                <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" SelectCommand="SELECT * FROM [tblBlog] inner join tblBlogKategori on tblBlogKategori.Id=tblBlog.KategoriId "></asp:SqlDataSource>--%>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2" DataKeyField="Id">
                    <ItemTemplate>
                    <%--    Id:
                        <asp:Label Text='<%# Eval("Id") %>' runat="server" ID="IdLabel" /><br />
                        Baslik:
                        <asp:Label Text='<%# Eval("Baslik") %>' runat="server" ID="BaslikLabel" /><br />
                        Ozet:
                        <asp:Label Text='<%# Eval("Ozet") %>' runat="server" ID="OzetLabel" /><br />
                        KategoriId:
                        <asp:Label Text='<%# Eval("KategoriId") %>' runat="server" ID="KategoriIdLabel" /><br />
                        Resim:
                        <asp:Label Text='<%# Eval("Resim") %>' runat="server" ID="ResimLabel" /><br />
                        Detay:
                        <asp:Label Text='<%# Eval("Detay") %>' runat="server" ID="DetayLabel" /><br />
                        Tarih:
                        <asp:Label Text='<%# Eval("Tarih") %>' runat="server" ID="TarihLabel" /><br />
                        <br />--%>
                                   <article class="blog_item">
    <div class="blog_item_img">
        <img class="card-img rounded-0" src='images/blog/<%# Eval("Resim") %>' alt="">
        <a href='<%# Eval ("Id","BlogDetay.aspx?Id={0}") %>' class="blog_item_date">
            <h3>'<%# Eval("Tarih") %>'</h3>
        </a>
    </div>

    <div class="blog_details">
        <a class="d-inline-block" href='<%# Eval ("Id","BlogDetay.aspx?Id={0}") %>'>
            <h2>'<%# Eval("Baslik") %>'</h2>
        </a>
        <p>
           '<%# Eval("Ozet") %>'
        </p>
        <ul class="blog-info-link">
            <li><a href='<%# Eval ("Id","BlogDetay.aspx?Id={0}") %>'><i class="fa fa-user"></i>'<%# Eval("Ad") %>'</a></li>
            <li><a href='<%# Eval ("Id","BlogDetay.aspx?Id={0}") %>'><i class="fa fa-comments"></i>03 Comments</a></li>
        </ul>
    </div>
</article>
                    </ItemTemplate>
                </asp:DataList>


              
                    <asp:HiddenField ID="hiddenSecilenBlogId" runat="server" Value="" EnableViewState="False" />



                <nav class="blog-pagination justify-content-center d-flex">
                    <ul class="pagination">
                        <li class="page-item">
                            <a href="#" class="page-link" aria-label="Previous">
                                <i class="ti-angle-left"></i>
                            </a>
                        </li>
                        <li class="page-item">
                            <a href="#" class="page-link">1</a>
                        </li>
                        <li class="page-item active">
                            <a href="#" class="page-link">2</a>
                        </li>
                        <li class="page-item">
                            <a href="#" class="page-link" aria-label="Next">
                                <i class="ti-angle-right"></i>
                            </a>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>
        <div class="col-lg-4">
            <div class="blog_right_sidebar">
                <aside class="single_sidebar_widget search_widget">
                    <form action="#">
                        <div class="form-group">
                            <div class="input-group mb-3">
                                <input type="text" class="form-control" placeholder='Search Keyword'
                                    onfocus="this.placeholder = ''"
                                    onblur="this.placeholder = 'Search Keyword'">
                                <div class="input-group-append">
                                    <button class="btns" type="button"><i class="ti-search"></i></button>
                                </div>
                            </div>
                        </div>
                        <button class="button rounded-0 primary-bg text-white w-100 btn_1 boxed-btn"
                            type="submit">
                            Search</button>
                    </form>
                </aside>

                <aside class="single_sidebar_widget post_category_widget">
                    <h4 class="widget_title">Kategoriler</h4>
                    <ul class="list cat-list">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" SelectCommand="SELECT * FROM [tblBlogKategori]"></asp:SqlDataSource>
                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                            <ItemTemplate>
                                <li>
                                    <a href="#" class="d-flex">
                                        <p><%#Eval ("Ad") %></p>
                                        <p>(37)</p>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    
                    </ul>
                </aside>

                <aside class="single_sidebar_widget popular_post_widget">
                    <h3 class="widget_title">Recent Post</h3>
                    <div class="media post_item">
                        <img src="assets/img/post/post_1.png" alt="post">
                        <div class="media-body">
                            <a href="single-blog.html">
                                <h3>From life was you fish...</h3>
                            </a>
                            <p>January 12, 2019</p>
                        </div>
                    </div>
                    <div class="media post_item">
                        <img src="assets/img/post/post_2.png" alt="post">
                        <div class="media-body">
                            <a href="single-blog.html">
                                <h3>The Amazing Hubble</h3>
                            </a>
                            <p>02 Hours ago</p>
                        </div>
                    </div>
                    <div class="media post_item">
                        <img src="assets/img/post/post_3.png" alt="post">
                        <div class="media-body">
                            <a href="single-blog.html">
                                <h3>Astronomy Or Astrology</h3>
                            </a>
                            <p>03 Hours ago</p>
                        </div>
                    </div>
                    <div class="media post_item">
                        <img src="assets/img/post/post_4.png" alt="post">
                        <div class="media-body">
                            <a href="single-blog.html">
                                <h3>Asteroids telescope</h3>
                            </a>
                            <p>01 Hours ago</p>
                        </div>
                    </div>
                </aside>
                <aside class="single_sidebar_widget tag_cloud_widget">
                    <h4 class="widget_title">Tag Clouds</h4>
                    <ul class="list">
                        <li>
                            <a href="#">project</a>
                        </li>
                        <li>
                            <a href="#">love</a>
                        </li>
                        <li>
                            <a href="#">technology</a>
                        </li>
                        <li>
                            <a href="#">travel</a>
                        </li>
                        <li>
                            <a href="#">restaurant</a>
                        </li>
                        <li>
                            <a href="#">life style</a>
                        </li>
                        <li>
                            <a href="#">design</a>
                        </li>
                        <li>
                            <a href="#">illustration</a>
                        </li>
                    </ul>
                </aside>


                <aside class="single_sidebar_widget instagram_feeds">
                    <h4 class="widget_title">Instagram Feeds</h4>
                    <ul class="instagram_row flex-wrap">
                        <li>
                            <a href="#">
                                <img class="img-fluid" src="assets/img/post/post_5.png" alt="">
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <img class="img-fluid" src="assets/img/post/post_6.png" alt="">
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <img class="img-fluid" src="assets/img/post/post_7.png" alt="">
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <img class="img-fluid" src="assets/img/post/post_8.png" alt="">
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <img class="img-fluid" src="assets/img/post/post_9.png" alt="">
                            </a>
                        </li>
                        <li>
                            <a href="#">
                                <img class="img-fluid" src="assets/img/post/post_10.png" alt="">
                            </a>
                        </li>
                    </ul>
                </aside>


                <aside class="single_sidebar_widget newsletter_widget">
                    <h4 class="widget_title">Newsletter</h4>

                    <form action="#">
                        <div class="form-group">
                            <input type="email" class="form-control" onfocus="this.placeholder = ''"
                                onblur="this.placeholder = 'Enter email'" placeholder='Enter email' required>
                        </div>
                        <button class="button rounded-0 primary-bg text-white w-100 btn_1 boxed-btn"
                            type="submit">
                            Subscribe</button>
                    </form>
                </aside>
            </div>
        </div>
    </div>
</asp:Content>
