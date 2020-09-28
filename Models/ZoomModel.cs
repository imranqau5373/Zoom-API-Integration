using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoomWithOAuth.Models
{
    public static class ZoomModel
    {
        public static string ClientId { get; set; }

        public static string ClientSecret { get; set; }

        public static string AuthorizeUrl { get; set; }

        public static string RedirectUrl { get; set; }


    }
}