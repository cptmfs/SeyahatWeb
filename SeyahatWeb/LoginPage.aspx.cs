using DTO.Modules.SeyehatWeb;
using Infrastructure.Helper;
using Presenter.Modules.SeyehatWeb.Interface;
using Presenter.Modules.SeyehatWeb.Presenter;
using System;
using System.Collections.Generic;

namespace SeyehatWeb
{
    public partial class LoginPage : System.Web.UI.Page,IKullaniciView
    {
        //string congBaglanti = WebConfigurationManager.ConnectionStrings["GoTripEntities"].ConnectionString;

        private KullaniciPresenter _presenter;

        protected KullaniciPresenter Presenter
        {
            get { return _presenter ?? (_presenter = new KullaniciPresenter(this)); }
        }
        string guid = Guid.NewGuid().ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cookies.Add(new HttpCookie("AuthToken", guid));

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var sonuc = Presenter.KullaniciKontrol(UserName, Password);
            //Session["AuthToken"] = guid;
            if (sonuc.Item2 == true)
            {
                Session["Kullanici"] = UserName.ToString();
                SessionHelper.KullaniciId = sonuc.Item1;

                Response.Redirect("~/Yönetim/Default.aspx");
            }
            else
            {
                lblHatalıGiris.Text = "Kullanıcı adı veya şifre hatalıdır.!!";
            }


            //SqlConnection baglanti = new SqlConnection(congBaglanti);
            //baglanti.Open();
            //SqlCommand cmd = new SqlCommand("Select * from tblKullanici where UserName=@UserName and Password=@Password", baglanti);
            //cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.ToString());
            //cmd.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    Session["Kullanici"] = reader["UserName"].ToString();
            //    Response.Redirect("~/Yönetim/Default.aspx");
            //}
            //else
            //{
            //    lblHatalıGiris.Text = "Kullanıcı adı veya şifre hatalıdır.!!";
            //}
            //reader.Close();
            //baglanti.Close();
            //baglanti.Dispose();

        }
        public string KullaniciAra => throw new NotImplementedException();

        public int SecilenKullaniciId => throw new NotImplementedException();

        public string UserName
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtUserName.Text) ? null : (txtUserName.Text.Trim());
            }
        }

        public string Password
        {
            get
            {
                return String.IsNullOrWhiteSpace(txtPassword.Text) ? null : (txtPassword.Text.Trim());
            }
        }

        public string Name => throw new NotImplementedException();

        public string Surname => throw new NotImplementedException();

        public string EMail => throw new NotImplementedException();

        public List<KullaniciDTO> KullaniciListe { set => throw new NotImplementedException(); }

        
    }
}