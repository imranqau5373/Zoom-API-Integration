using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZoomWithOAuth.Models;

namespace ZoomWithOAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult RedirectPage()
        {
            ViewBag.Message = "Your page is rediect.";

            return View();
        }

        public ActionResult Authroize()
        {
            ViewBag.Message = "Authorize your page from Zoom.";
            ViewBag.AuthroizeUrl = $"{ZoomModel.AuthorizeUrl}&client_id={ZoomModel.ClientId}&redirect_uri={ZoomModel.RedirectUrl}";

            return View();
        }


        [Route("/")]
        public ActionResult GetUserInfomration(string accessToken)
        {
            var client = new RestClient("https://api.zoom.us/v2/users/me");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer "+ AccessToken.GetAccessTokenValue);
            request.AddHeader("Cookie", "_zm_currency=USD; _zm_mtk_guid=6821d57c93a645dfb1dc074fbfdfc3bc; _zm_ssid=aw1_c_3Q9Q8s6ySYi7VloTotTC0Q; _zm_csp_script_nonce=GAZlqQFYQzi7EjzsVhXHkQ; _zm_o2nd=e87626a5a6c8f3d23888323f7f3af8cf; _zm_page_auth=aw1_c_jURnI_f6T5mG9iv86L0tjg; cred=B5FC1CD871004E5CC02F5582F8E064CA");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            ViewBag.UserData = response.Content.ToString();
            return View();
        }


        public ActionResult AfterRedirectPage(string code)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ViewBag.Message = "Your page is redirected after the authorization.";
            var client = new RestClient("https://zoom.us/oauth/token?grant_type=authorization_code&code="+code+"&redirect_uri="+ ZoomModel.RedirectUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            var encodedToken = Base64Url.Encode(ZoomModel.ClientId + ":" + ZoomModel.ClientSecret);
            request.AddHeader("Authorization", "Basic "+encodedToken);
            IRestResponse response = client.Execute(request);
            var objResponseData = response.Content;
            GetAccessModel myDeserializedClass = JsonConvert.DeserializeObject<GetAccessModel>(response.Content);
            AccessToken.GetAccessTokenValue = myDeserializedClass.access_token;
            Console.WriteLine(response.Content);
            return View();
        }
    }
}