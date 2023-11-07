<%@ Page Title="" Language="C#" MasterPageFile="~/Altsayfa.Master" AutoEventWireup="true" CodeBehind="Galeri.aspx.cs" Inherits="SeyehatWeb.Galeri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <h2>Galeri</h2>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="row gallery-item">
					<div class="col-md-4">
						<a href="assets/img/elements/g1.jpg" class="img-pop-up">
							<div class="single-gallery-image" style="background: url(assets/img/elements/g1.jpg);"></div>
						</a>
					</div>
					<div class="col-md-4">
						<a href="assets/img/elements/g2.jpg" class="img-pop-up">
							<div class="single-gallery-image" style="background: url(assets/img/elements/g2.jpg);"></div>
						</a>
					</div>
					
				</div>
</asp:Content>
