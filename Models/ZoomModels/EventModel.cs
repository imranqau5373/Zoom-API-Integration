using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoomWithOAuth.Models.ZoomModels;

namespace ZoomWithOAuth.Models.ZoomModels
{
    public class EventModel
    {
        public int duration { get; set; }
        public DateTime start_time { get; set; }
        public string timezone { get; set; }
        public DateTime end_time { get; set; }
        public string topic { get; set; }
        public string id { get; set; }
        public int type { get; set; }
        public string uuid { get; set; }
        public string host_id { get; set; }
    }

    public class EventData
    {
        public string account_id { get; set; }
        public EventModel @object { get; set; }
    }

    public class EventRoot
    {
        public string @event { get; set; }
        public EventData payload { get; set; }
    }
}