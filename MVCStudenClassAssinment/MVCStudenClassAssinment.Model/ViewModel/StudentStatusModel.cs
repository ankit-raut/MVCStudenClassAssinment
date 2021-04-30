using Newtonsoft.Json;

namespace MVCStudenClassAssinment.Model.ViewModel
{
    public class StudentStatusModel
    {
        [JsonProperty("studentid")]
        public string Studentid { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
