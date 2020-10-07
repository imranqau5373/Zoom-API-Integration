using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using ZoomWithOAuth.Models.ApiResponse;
using ZoomWithOAuth.Models.ZoomModels;

namespace ZoomWithOAuth.Controllers
{
    public class ZoomApiController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetEventNotification(EventRoot event_root)
        {
            if(event_root.payload != null)
            {
                var currentDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                string fileName = event_root.payload.@object.id;
                string path = Path.Combine(currentDirectory, @"EventData\", fileName+".txt");
                var eventData = new JavaScriptSerializer().Serialize(event_root);
                File.WriteAllText(path, eventData);
            }
            return Ok();
        }

        [HttpGet]
        public EventResponse GetEventNotification()
        {
            EventResponse event_response = new EventResponse();
            var currentDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            string path = Path.Combine(currentDirectory, @"EventData\");
            var txtFiles = Directory.EnumerateFiles(path, "*.txt");
            event_response.events_list = new List<EventRoot>();
            foreach (string currentFile in txtFiles)
            {
                var text_file_data = File.ReadAllText(currentFile);
                var eventData = new JavaScriptSerializer().Deserialize<EventRoot>(text_file_data);
                event_response.events_list.Add(eventData);
                File.Delete(currentFile);
            }
            return event_response;

        }

    }
}
