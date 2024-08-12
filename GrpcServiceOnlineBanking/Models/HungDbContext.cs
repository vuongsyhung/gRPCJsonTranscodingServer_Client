using Microsoft.EntityFrameworkCore;


namespace GrpcServiceOnlineBanking.Models
{
    public class HungDbContext : DbContext
    {
        public HungDbContext(DbContextOptions<HungDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccountCustomer> AccountCustomers { get; set; }
        public DbSet<Accounts> Accountss { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<BankingTransactions> BankingTransactions { get; set; }
        public DbSet<BranchEmployee> BranchEmployees { get; set; }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<CreditCardTransactions> CreditCardTransactionss { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
