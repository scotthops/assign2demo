using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DonationLibrary;

public class DonationDbContext : DbContext {
    public DbSet<Donation> Donations => Set<Donation>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<TransactionType> TransactionTypes => Set<TransactionType>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();

  public DonationDbContext(DbContextOptions<DonationDbContext> options)
    : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    base.OnModelCreating(modelBuilder);
    // Seed Accounts
    modelBuilder.Entity<Account>().HasData(GetAccounts());
    // Seed TransactionTypes
    modelBuilder.Entity<TransactionType>().HasData(GetTransactionTypes());
    // Seed PaymentMethods
    modelBuilder.Entity<PaymentMethod>().HasData(GetPaymentMethods());

    // Seed Donations (make sure the foreign keys exist in related entities)
    modelBuilder.Entity<Donation>().HasData(GetDonations());
  }
// working but weird
//   private static IEnumerable<Account> GetAccounts()
// {
//     string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "accounts.csv" };
//     var csvFilePath = Path.Combine(p);

//     var config = new CsvConfiguration(CultureInfo.InvariantCulture)
//     {
//         PrepareHeaderForMatch = args => args.Header.ToLower(),
//     };

//     var data = new List<Account>().AsEnumerable();
//     using (var reader = new StreamReader(csvFilePath)) {
//       using (var csvReader = new CsvReader(reader, config))  {
//         // Read the header
//         csvReader.Read();
//         csvReader.ReadHeader();

//         // Print the headers
//         var headers = csvReader.HeaderRecord;
//         if(headers is null) throw new Exception("Headers are null");
//         Console.WriteLine($"Headers read from CSV: {string.Join(", ", headers)}");

//         // Read the records
//         data = csvReader.GetRecords<Account>().ToList();
//     }
//     }
//     return data;
// }
  private static IEnumerable<Account> GetAccounts()
{
    string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "accounts.csv" };
    var csvFilePath = Path.Combine(p);

    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        PrepareHeaderForMatch = args => args.Header.ToLower(),
    };

    var data = new List<Account>().AsEnumerable();
    using (var reader = new StreamReader(csvFilePath)) {
      using (var csvReader = new CsvReader(reader, config)) {
        data = csvReader.GetRecords<Account>().ToList();
      }
    }
    return data;
}

  private static IEnumerable<TransactionType> GetTransactionTypes()
{
    string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "transactiontypes.csv" };
    var csvFilePath = Path.Combine(p);

    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        PrepareHeaderForMatch = args => args.Header.ToLower(),
    };

    var data = new List<TransactionType>().AsEnumerable();
    using (var reader = new StreamReader(csvFilePath)) {
      using (var csvReader = new CsvReader(reader, config)) {
        data = csvReader.GetRecords<TransactionType>().ToList();
      }
    }
    return data;
}

  private static IEnumerable<PaymentMethod> GetPaymentMethods()
{
    string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "paymentmethods.csv" };
    var csvFilePath = Path.Combine(p);

    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        PrepareHeaderForMatch = args => args.Header.ToLower(),
    };

    var data = new List<PaymentMethod>().AsEnumerable();
    using (var reader = new StreamReader(csvFilePath)) {
      using (var csvReader = new CsvReader(reader, config)) {
        data = csvReader.GetRecords<PaymentMethod>().ToList();
      }
    }
    return data;
}
  
  private static IEnumerable<Donation> GetDonations() {
    string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "donations.csv" };
    var csvFilePath = Path.Combine(p);

    var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
      PrepareHeaderForMatch = args => args.Header.ToLower(),
    };

    var data = new List<Donation>().AsEnumerable();
    using (var reader = new StreamReader(csvFilePath)) {
      using (var csvReader = new CsvReader(reader, config)) {
                // Read the header
        csvReader.Read();
        csvReader.ReadHeader();

        // Print the headers
        var headers = csvReader.HeaderRecord;
        if(headers is null) throw new Exception("Headers are null");
        Console.WriteLine($"Headers read from CSV: {string.Join(", ", headers)}");

        // Read the records
        data = csvReader.GetRecords<Donation>().ToList();

      }
    }
    return data;
  }
}

// public class AccountMap : ClassMap<Account>
// {
//     public AccountMap()
//     {
//         Map(x => x.AccountNo).Name("AccountNo");
//         Map(x => x.FirstName).Name("FirstName");
//         Map(x => x.LastName).Name("LastName");
//         Map(x => x.Email).Name("Email");
//         Map(x => x.Street).Name("Street");
//         Map(x => x.City).Name("City");
//         Map(x => x.PostalCode).Name("PostalCode");
//         Map(x => x.Country).Name("Country");
//         Map(x => x.Created).Name("Created");
//         Map(x => x.Modified).Name("Modified");
//         Map(x => x.CreatedBy).Name("CreatedBy");
//         Map(x => x.ModifiedBy).Name("ModifiedBy");
//     }
// }
// using System.Globalization;
// using CsvHelper;
// using CsvHelper.Configuration;
// using Microsoft.EntityFrameworkCore;

// namespace DonationLibrary;

// public class DonationDbContext : DbContext {
//     public DbSet<Donation> Donations => Set<Donation>();
//     public DbSet<Account> Accounts => Set<Account>();
//     public DbSet<TransactionType> TransactionTypes => Set<TransactionType>();
//     public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();

//   public DonationDbContext(DbContextOptions<DonationDbContext> options)
//     : base(options) { }

//   protected override void OnModelCreating(ModelBuilder modelBuilder) {
//     base.OnModelCreating(modelBuilder);
//     modelBuilder.Entity<Donation>().HasData(GetDonations());
//   }
  
//   private static IEnumerable<Donation> GetDonations() {
//     string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "donations.csv" };
//     var csvFilePath = Path.Combine(p);

//     var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
//       PrepareHeaderForMatch = args => args.Header.ToLower(),
//     };

//     var data = new List<Donation>().AsEnumerable();
//     using (var reader = new StreamReader(csvFilePath)) {
//       using (var csvReader = new CsvReader(reader, config)) {
//         data = csvReader.GetRecords<Donation>().ToList();
//       }
//     }
//     return data;
//   }
// }
