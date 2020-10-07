using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoomWithOAuth.Models.ApiResponse
{
    public class ResponseObject
    {

        public int Status { get; set; }
        public int CustomerId { get; set; }
        public string[] Warnings { get; set; }
        public string[] Errors { get; set; }

        public string Message { get; set; }
    }
}