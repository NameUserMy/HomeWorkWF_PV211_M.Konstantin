using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using P.F.M.Data;
using P.F.M.Model;
using P.F.M.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P.F.M.Control
{
    internal class ManagementPFM
    {
        private readonly PFMContext _db;

        public void Expenditure(decimal money, int userId, string accountNumber)
        {
            var param1 = new SqlParameter("@accountNumber", accountNumber);
            var param2 = new SqlParameter("@amountTransfer", money);
            var user = _db.Users.Include(e => e.BankAccounts).FirstOrDefault(e => e.Id == userId);
            _db.Database.ExecuteSqlRaw("dbo.sp_Spend @accountNumber, @amountTransfer", param1, param2);
            PFMTransaction pFMTransaction = new PFMTransaction
            {
                Users = user,
                Money = money,
                UOperation = new UserOperation { Description = "Расход" }

            };
            _db.Add(pFMTransaction);
            _db.SaveChanges();


        }//spend money
        public void Earnings(decimal money, int userId, string accountNumber)
        {
            var user = _db.Users.Include(e => e.BankAccounts).FirstOrDefault(e => e.Id == userId);

            var param1 = new SqlParameter("@accountNumber", accountNumber);
            var param2 = new SqlParameter("@amountTransfer", money);

            _db.Database.ExecuteSqlRaw("dbo.sp_Earnings @accountNumber, @amountTransfer", param1, param2);

            PFMTransaction pFMTransaction = new PFMTransaction
            {
                Users = user,
                Money = money,
                UOperation = new UserOperation { Description = "Доход" }

            };
            _db.Add(pFMTransaction);
            _db.SaveChanges();
        }//add money
        public void GetTransactionsBySumDateType(int userId, decimal sum, string type, string date) {

            var AllTransactions = _db.PFMTransactions.Where(e => EF.Functions.Like(e.UOperation.Description, type))
                    .Where(e => EF.Functions.Like(e.DateTransaction.ToString(), date + "%")).
                    Where(e => e.Money == sum).
                    Where(e => e.UserId == userId);

            foreach (var item in AllTransactions)
            {
                Console.WriteLine($"{item.DateTransaction} {item.Money}");
            }
        }
        public void GetTransactionsSumByDate(int userId, string startDate,string endDate)
        {

            string sql = $"""
                 
                SELECT * FROM PFMTransactions 
                WHERE PFMTransactions.DateTransaction LIKE '{startDate} %' 
                or PFMTransactions.DateTransaction LIKE '{endDate} %' 
                """;

                 var spend = _db.PFMTransactions.FromSqlRaw(sql)
                .Where(e => e.UOperation.Description == "Расход")
                 .Where(e => e.UserId == userId);
                var incomming = _db.PFMTransactions.FromSqlRaw(sql)
                .Where(e => e.UOperation.Description == "Доход")
                 .Where(e => e.UserId == userId);
            Console.WriteLine($"Расход {spend.Sum(e => e.Money)}");
            Console.WriteLine($"Доход {incomming.Sum(e => e.Money)}");
        }

        public void GetTransactionsSumByDateAndType(int userId, string startDate, string endDate,string type )
        {
            string sql = $"""
                 
                SELECT * FROM PFMTransactions 
                WHERE PFMTransactions.DateTransaction LIKE '{startDate} %' 
                or PFMTransactions.DateTransaction LIKE '{endDate} %' 
                """;

            var spend = _db.PFMTransactions.FromSqlRaw(sql)
           .Where(e => e.UOperation.Description == type)
            .Where(e => e.UserId == userId);
            Console.WriteLine($"{type} : {spend.Sum(e => e.Money)}");
        }

        public void GetReport(int userId,string type)
        {

            var incomming=_db.PFMTransactions.Where(e=>EF.Functions.Like(e.UOperation.Description,"Доход"))
                .Where(e=>e.UserId== userId).Sum(e=>e.Money);
            var spend = _db.PFMTransactions.Where(e => EF.Functions.Like(e.UOperation.Description, "Расход"))
                .Where(e => e.UserId == userId).Sum(e => e.Money);
            var balance = _db.BankAccounts.Where(e => e.UserId == userId).Sum(e => e.MoneyAccount);
            Console.WriteLine($"Общий баланс {balance}\nОбщий Доход {incomming}\nОбщий Расход {spend}\n");

            var transactions = _db.PFMTransactions.Where(e => EF.Functions.Like(e.UOperation.Description,type))
                .Where(e => e.UserId == userId);

            foreach (var item in transactions)
            {

                Console.WriteLine($"{item.DateTransaction} {item.Money} {type}");
            }



        }
        public ManagementPFM (PFMContext db)=>_db=db;
    }
}
