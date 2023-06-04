namespace BudHillFMS.Models
{
    public class EmployeeHistory
    {
        public int Id { get; set; }
        public string? FarmWorked { get; set; }
        public string? PositionWorked { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
    }
}
