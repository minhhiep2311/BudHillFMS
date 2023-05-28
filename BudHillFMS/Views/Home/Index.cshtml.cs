namespace BudHillFMS.Views.Home;

public class HomePageModel
{
    public decimal Outcome { get; set; } = new();
    public int FarmsNumber { get; set; }
    public int SeedsNumber { get; set; }
    public int EmployeeNumber { get; set; }
    public List<Tuple<int?, string, decimal[], string>> OutcomeList { get; set; } = new();
}