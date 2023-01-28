using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Task_webAPI.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int? Dept_ID { get; set; }
        [JsonIgnore]
        public virtual Department? Department { get; set; }

    }
}
