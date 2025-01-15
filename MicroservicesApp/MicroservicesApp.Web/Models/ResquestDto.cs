﻿using MicroservicesApp.Web.Utility;
using System.Net.Mime;
using System.Security.AccessControl;
using static MicroservicesApp.Web.Utility.Constants;

namespace MicroservicesApp.Web.Models
{
    public class ResquestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
        //public ContentType ContentType { get; set; } = ContentType.Json;
    }
}
