using P.F.M.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.F.M.Model
{
    internal class BankAccount
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public Decimal? MoneyAccount { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; } = null!;
    }
}
