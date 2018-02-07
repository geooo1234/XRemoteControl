using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRemoteControl
{
    public class Responses1
    {

        public Response1 Pings { get; set; }

    }


    public class Response1
    {
        public string Ip { get; set; }
        public string Sent { get; set; }
        public string Received { get; set; }
        public string Lost { get; set; }
        public string Minimum { get; set; }
        public string Maximum { get; set; }
        public string Average { get; set; }

    }
    public class Param
    {
        public string ip { get; set; }
        public string sent { get; set; }
        public string received { get; set; }
        public string lost { get; set; }
        public string minimum { get; set; }
        public string maximum { get; set; }
        public string average { get; set; }
    }
}
