using Newtonsoft.Json;

namespace APISecflowTests.Models
{
    public class SingleEmployeeModel
    {
        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("data")]
        public DataEmployeeModel data { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
