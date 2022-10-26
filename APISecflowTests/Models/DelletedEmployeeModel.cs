using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISecflowTests.Models
{
    internal class DelletedEmployeeModel
    {
        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("data")]
        public string data { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
