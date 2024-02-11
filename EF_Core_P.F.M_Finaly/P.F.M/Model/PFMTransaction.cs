using P.F.M.Models;

namespace P.F.M.Model
{
    internal class PFMTransaction
    {
        public int Id { get; set; }
        public DateTime DateTransaction { get; set; }
        public Decimal Money { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; } = null!;
        public UserOperation? UOperation { get; set; } = null!;
    }
}
