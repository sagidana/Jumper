﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumper.WebServer
{
    public class WebResource
    {
        public string Path { get; set; }

        public string Method { get; set; }

        public RequestHandler Handler { get; set; }
    }
}
