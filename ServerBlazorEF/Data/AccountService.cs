namespace ServerBlazorEF;

public class AccountService
{
    private DonationDbContext _context;

    public AccountService(DonationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Account>> GetAccountsAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account?> GetAccountByIdAsync(int id)
    {
        return await _context.Accounts.FindAsync(id) ?? null;
    }

    public async Task<Account?> InsertAccountAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return account;
    }

    public async Task<Account> UpdateAccountAsync(int id, Account updatedAccount)
    {
        var account = await _context.Accounts!.FindAsync(id);

        if (account == null)
            return null!;

        // Update properties of the account
        account.FirstName = updatedAccount.FirstName;
        account.LastName = updatedAccount.LastName;
        account.Email = updatedAccount.Email;
        account.Street = updatedAccount.Street;
        account.City = updatedAccount.City;
        account.PostalCode = updatedAccount.PostalCode;
        account.Country = updatedAccount.Country;
        account.Modified = updatedAccount.Modified;
        account.ModifiedBy = updatedAccount.ModifiedBy;

        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();

        return account!;
    }

    public async Task<Account> DeleteAccountAsync(int id)
    {
        var account = await _context.Accounts!.FindAsync(id);

        if (account == null)
            return null!;

        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();

        return account!;
    }

    private bool AccountExists(int id)
    {
        return _context.Accounts!.Any(e => e.AccountNo == id);
    }
}
