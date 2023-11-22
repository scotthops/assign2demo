namespace ServerBlazorEF;

public class DonationService {
  private DonationDbContext _context;
  
  public DonationService(DonationDbContext context) {
    _context = context;
  }

  public async Task<List<Donation>> GetDonationsAsync() {
   return await  _context.Donations.ToListAsync();
  }

  public async Task<Donation?> GetDonationsIdAsync(int id) {
    return await _context.Donations.FindAsync(id) ?? null;
  }

  public async Task<Donation?> InsertDonationsAsync(Donation donation) {
    _context.Donations.Add(donation);
    await _context!.SaveChangesAsync();

    return donation;
  }

  public async Task<Donation> UpdateDonationsAsync(int id, Donation s) {
    var donation = await _context.Donations!.FindAsync(id);

    if (donation == null)
      return null!;

    donation.Date = s.Date;
    donation.AccountNo = s.AccountNo;
    donation.TransactionTypeId = s.TransactionTypeId;
    donation.Amount = s.Amount;
    donation.PaymentMethodId = s.PaymentMethodId;
    donation.Notes = s.Notes;
    donation.Created = s.Created;
    donation.Modified = s.Modified;
    donation.CreatedBy = s.CreatedBy;
    donation.ModifiedBy = s.ModifiedBy;

    _context.Donations.Update(donation);
    await _context.SaveChangesAsync();

    return donation!;
  }

  public async Task<Donation> DeleteDonationsAsync(int id) {
    var donation = await _context.Donations!.FindAsync(id);

    if (donation == null)
      return null!;

    _context.Donations.Remove(donation);
    await _context.SaveChangesAsync();

    return donation!;
  }

  private bool StudentExists(int id) {
    return _context.Donations!.Any(e => e.TransId == id);
  }
}
