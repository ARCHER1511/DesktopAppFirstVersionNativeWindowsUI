namespace ERPAppDomain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
