using Microsoft.EntityFrameworkCore;
using P.F.M.Models;
using P.F.M.Data;
using P.F.M.Model;
using P.F.M.Control;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;



namespace P.F.M
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PFMContext ConnectDb() => new ApplicationContextFactory().CreateDbContext();
            using (PFMContext db = ConnectDb())
            {
                #region add data
                //List<User> users = new List<User>() {
                //new User{Name="Alex"},
                //new User{Name="Bob"},
                //new User { Name = "Merry"},
                //};
                //List<Settings> settings = new List<Settings>() {
                //new Settings{About="About",login="Alex",Pass="Very secret string",User=users[0]},
                //new Settings{About="About",login="Bob",Pass="Very secret string",User=users[1]},
                //new Settings{About="About",login="Marry",Pass="Very secret string",User=users[2]},
                //};
                //db.AddRange(settings);
                //db.SaveChanges();
                //List<BankAccount> bankAccounts = new List<BankAccount>()
                //{
                //    new BankAccount{AccountNumber="252525",MoneyAccount=25000,Users=db.Users.FirstOrDefault(e=>e.Id==1)},
                //    new BankAccount{AccountNumber="2622626",MoneyAccount=23000,Users=db.Users.FirstOrDefault(e=>e.Id==2)},
                //    new BankAccount{AccountNumber="333626",MoneyAccount=5000,Users=db.Users.FirstOrDefault(e=>e.Id==3)}
                //    };

                //db.AddRange(bankAccounts);
                //db.SaveChanges();

                //var user= db.Users.FirstOrDefault(e => e.Id == 1);
                //PFMTransaction pFMTransaction = new PFMTransaction {Users=user,Money=20,
                //UOperation=new UserOperation {Description="Расход"}};
                //db.Add(pFMTransaction);
                //db.SaveChanges();
                #endregion
                ManagementPFM managementPFM = new ManagementPFM(db);

                managementPFM.Expenditure(75, 1, "252525");
                managementPFM.Earnings(20, 1, "252525");
                managementPFM.GetTransactionsBySumDateType(1, 20, "Доход", "2024-02-10");
                managementPFM.GetTransactionsSumByDate(1, "2024-02-10", "2024-02-11");
                managementPFM.GetReport(1, "Доход");
            }

        }
    }
}
