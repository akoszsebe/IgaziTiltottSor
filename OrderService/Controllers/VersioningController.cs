using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/versioning")]
    public class Versioningv1Controller : Controller
    {
        // GET api/versioning?api-version=1.0
        [HttpGet]
        public string Get()
        {
            return "Hello from version v1_1 1.0";
        }
    }

    [ApiVersion("2.0")]
    [Route("api/versioning")]
    public class Versioningv1_2Controller : Controller
    {
        // GET api/versioning?api-version=2.0
        [HttpGet]
        public string Get()
        {
            return "Hello from version v1_2 2.0";
        }
    }

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/versioning")]
    public class Versioningv2_1Controller : Controller
    {
        // GET /api/v1.0/versioning
        [HttpGet]
        public string Get()
        {
            return "Hello from version v2_1 1.0";
        }
    }

    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/versioning")]
    public class Versioningv2_2Controller : Controller
    {
        // GET api/v2.0/versioning
        [HttpGet]
        public string Get()
        {
            return "Hello from version v2_2 2.0";
        }
    }
}