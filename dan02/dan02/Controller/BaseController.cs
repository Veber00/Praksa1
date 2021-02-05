using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dan02.Controller
{
    public class BaseController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
    }
}
