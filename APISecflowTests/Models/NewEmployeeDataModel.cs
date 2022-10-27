using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISecflowTests.Models
{
    public class NewEmployeeDataModel
    {
        [JsonProperty("employee_name")]
        public string name { get; set; }

        [JsonProperty("employee_salary")]
        public string salary { get; set; }

        [JsonProperty("employee_age")]
        public string age { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
