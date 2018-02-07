using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRemoteControl
{
    public class Responses
    {
        public List<Response> Parameters { get; set; }

        //public List<ResponsePing> Ping { get; set; }
    }

    public class Response
    {
        public string ImageName { get; set; }
        public string PID { get; set; }
        public string SessionName { get; set; }
        public string SessionNumber { get; set; }
        public string MemUsage { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public string CPUtime { get; set; }
    }



    public class Parameter
    {
        public string imagename { get; set; }
        public string pid { get; set; }
        public string sessionname { get; set; }
        public string sessionnumber { get; set; }
        public string memusage { get; set; }
        public string status { get; set; }
        public string username { get; set; }
        public string cputime { get; set; }
    }
}
