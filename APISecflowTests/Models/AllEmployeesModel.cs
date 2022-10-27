using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISecflowTests.Models
{
    public class AllEmployeesModel
    {
        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("data")]
        public List<DataEmployeeModel> data { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
