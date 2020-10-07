using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoomWithOAuth.Models.ZoomModels;

namespace ZoomWithOAuth.Models.ApiResponse
{
    public class EventResponse
    {
        public List<EventRoot> events_list { get; set; }

        public bool status { get; set; }

        public string message { get; set; }

    }
}