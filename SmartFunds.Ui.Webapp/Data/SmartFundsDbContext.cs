using Microsoft.EntityFrameworkCore;
using SmartFunds.Ui.Webapp.Models;

namespace SmartFunds.Ui.Webapp.Data
{
    public class SmartFundsDbContext: DbContext
    {
        public SmartFundsDbContext(DbContextOptions<SmartFundsDbContext> options): base(options)
        {

        }

        public DbSet<Organization> Organizations => Set<Organization>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        public void Seed()
        {
            Organizations.AddRange(            
                new()
                {
                    Name = "Vives",
                    Type = "School",
                    CompanyNumber = "123-456-789",
                    Transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Owner = "Bavo",
                            Amount = 100,
                            TimeStamp = DateTime.UtcNow,
                            Remarks = "Student invoice"
                        }
                    }
                },
                new()
                {
                    Name = "Club Brugge",
                    Type = "Soccer Club",
                    CompanyNumber = "123-456-780",
                    Transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Owner = "John",
                            Amount = 1000,
                            TimeStamp = DateTime.UtcNow,
                            Remarks = "Sponsorship"
                        },
                        new Transaction
                        {
                            Owner = "Bavo",
                            Amount = -100,
                            TimeStamp = DateTime.UtcNow,
                            Remarks = "Bar supplies"
                        },
                        new Transaction
                        {
                            Owner = "Bavo",
                            Amount = 0,
                            TimeStamp = DateTime.UtcNow,
                            Remarks = "Diner with sales"
                        },
                        new Transaction
                        {
                            Owner = "Bavo",
                            Amount = -50,
                            TimeStamp = DateTime.UtcNow,
                            Remarks = "Repair light fixtures"
                        }
                    }
                },
                new()
                {
                    Name = "Badmintonclub Kortrijk",
                    Type = "Badminton",
                    CompanyNumber = "123-456-788"
                },
                new()
                {
                    Name = "De Lustige Darters",
                    Type = "Zwemclub",
                    CompanyNumber = "123-456-782"
                }
            );

            SaveChanges();
        }
    }
}
