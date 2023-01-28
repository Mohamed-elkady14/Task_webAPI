namespace Task_webAPI.Dto
{
    public class Departmentlist
    {
        public Departmentlist()
        {
            emps = new List<emp>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<emp> emps { get; set; }
    }
    public class emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

