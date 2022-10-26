using Newtonsoft.Json;

namespace APISecflowTests.Models
{
    internal class SingleEmployeeModel
    {
        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("data")]
        public DataEmployeeModel data { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
