using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ZoomWithOAuth.Models
{
    public static class Base64Url
    {
        public static string Encode(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).TrimEnd('=').Replace('+', '-')
                .Replace('/', '_');
        }
    }
}