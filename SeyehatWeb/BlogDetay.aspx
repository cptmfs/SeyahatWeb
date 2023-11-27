<%@ Page Title="" Language="C#" MasterPageFile="~/Altsayfa.Master" AutoEventWireup="true" CodeBehind="BlogDetay.aspx.cs" Inherits="SeyehatWeb.BlogDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="col-lg-8 posts-list">

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" SelectCommand="SELECT * FROM [tblBlog]  inner join tblBlogKategori on tblBlogKategori.Id=tblBlog.KategoriId WHERE tblBlog.Id=@Id">
            <SelectParameters>
                <asp:QueryStringParameter QueryStringField="Id" Name="Id" Type="Int32"></asp:QueryStringParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource2" DataKeyField="Id">
            <ItemTemplate>
                <div class="single-post">
                    <div class="feature-img">
                        <img class="img-fluid" src='images/blog/<%# Eval("Resim") %>' alt="">
                    </div>
                    <div class="blog_details">
                        <h2>'<%# Eval("Baslik") %>'
                        </h2>
                        <ul class="blog-info-link mt-3 mb-4">
                            <li><a href="#"><i class="fa fa-user"></i>'<%# Eval("Ad") %>'</a></li>
                            <li><a href="#"><i class="fa fa-comments"></i>03 Comments</a></li>
                        </ul>
                        <p class="excert">
                            '<%# Eval("Detay") %>'
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>

        <div class="navigation-top">
            <div class="d-sm-flex justify-content-between text-center">
                <p class="like-info">
                    <span class="align-middle"><i class="fa fa-heart"></i></span>Lily and 4
                        people like this
                </p>
                <div class="col-sm-4 text-center my-2 my-sm-0">
                    <!-- <p class="comment-count"><span class="align-middle"><i class="fa fa-comment"></i></span> 06 Comments</p> -->
                </div>
                <ul class="social-icons">
                    <li><a href="#"><i class="fab fa-facebook-f"></i></a></li>
                    <li><a href="#"><i class="fab fa-twitter"></i></a></li>
                    <li><a href="#"><i class="fab fa-dribbble"></i></a></li>
                    <li><a href="#"><i class="fab fa-behance"></i></a></li>
                </ul>
            </div>

        </div>
        <div class="blog-author">
            <div class="media align-items-center">
                <img src="assets/img/blog/author.png" alt="">
                <div class="media-body">
                    <a href="#">
                        <h4>Harvard milan</h4>
                    </a>
                    <p>
                        Second divided from form fish beast made. Every of seas all gathered use saying you're, he
                           our dominion twon Second divided from
                    </p>
                </div>
            </div>
        </div>
        <div class="comments-area">
            <h4>05 Comments</h4>
            <div class="comment-list">
                <div class="single-comment justify-content-between d-flex">
                    <div class="user justify-content-between d-flex">
                        <div class="thumb">
                            <img src="assets/img/comment/comment_1.png" alt="">
                        </div>
                        <div class="desc">
                            <p class="comment">
                                Multiply sea night grass fourth day sea lesser rule open subdue female fill which them
                                 Blessed, give fill lesser bearing multiply sea night grass fourth day sea lesser
                            </p>
                            <div class="d-flex justify-content-between">
                                <div class="d-flex align-items-center">
                                    <h5>
                                        <a href="#">Emilly Blunt</a>
                                    </h5>
                                    <p class="date">December 4, 2017 at 3:12 pm </p>
                                </div>
                                <div class="reply-btn">
                                    <a href="#" class="btn-reply text-uppercase">reply</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="comment-list">
                <div class="single-comment justify-content-between d-flex">
                    <div class="user justify-content-between d-flex">
                        <div class="thumb">
                            <img src="assets/img/comment/comment_2.png" alt="">
                        </div>
                        <div class="desc">
                            <p class="comment">
                                Multiply sea night grass fourth day sea lesser rule open subdue female fill which them
                                 Blessed, give fill lesser bearing multiply sea night grass fourth day sea lesser
                            </p>
                            <div class="d-flex justify-content-between">
                                <div class="d-flex align-items-center">
                                    <h5>
                                        <a href="#">Emilly Blunt</a>
                                    </h5>
                                    <p class="date">December 4, 2017 at 3:12 pm </p>
                                </div>
                                <div class="reply-btn">
                                    <a href="#" class="btn-reply text-uppercase">reply</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="comment-list">
                <div class="single-comment justify-content-between d-flex">
                    <div class="user justify-content-between d-flex">
                        <div class="thumb">
                            <img src="assets/img/comment/comment_3.png" alt="">
                        </div>
                        <div class="desc">
                            <p class="comment">
                                Multiply sea night grass fourth day sea lesser rule open subdue female fill which them
                                 Blessed, give fill lesser bearing multiply sea night grass fourth day sea lesser
                            </p>
                            <div class="d-flex justify-content-between">
                                <div class="d-flex align-items-center">
                                    <h5>
                                        <a href="#">Emilly Blunt</a>
                                    </h5>
                                    <p class="date">December 4, 2017 at 3:12 pm </p>
                                </div>
                                <div class="reply-btn">
                                    <a href="#" class="btn-reply text-uppercase">reply</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="comment-form">
            <h4>Leave a Reply</h4>
            <form class="form-contact comment_form" action="#" id="commentForm">
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <textarea class="form-control w-100" name="comment" id="comment" cols="30" rows="9"
                                placeholder="Write Comment"></textarea>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <input class="form-control" name="name" id="name" type="text" placeholder="Name">
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <input class="form-control" name="email" id="email" type="email" placeholder="Email">
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="form-group">
                            <input class="form-control" name="website" id="website" type="text" placeholder="Website">
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <button type="submit" class="button button-contactForm btn_1 boxed-btn">Send Message</button>
                </div>
            </form>
        </div>
    </div>









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

</asp:Content>
