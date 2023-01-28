using System.Text.Json.Serialization;

namespace Task_webAPI.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Employee>? Employees { get; set; }

    }
}
