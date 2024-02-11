using P.F.M.Model;

namespace P.F.M.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public  Settings? Settings { get; set; }
        public List<PFMTransaction>? PFMTransactions { get; set; } = null!;
        public List<BankAccount>? BankAccounts { get; set; } = null!;

    }
}
