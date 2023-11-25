namespace ServerBlazorEF
{
    public class TransTypeService
    {
        private DonationDbContext _context;

        public TransTypeService(DonationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionType>> GetTransactionTypesAsync()
        {
            return await _context.TransactionTypes.ToListAsync();
        }

        public async Task<TransactionType?> GetTransactionTypeByIdAsync(int id)
        {
            return await _context.TransactionTypes.FindAsync(id) ?? null;
        }

        public async Task<TransactionType?> InsertTransactionTypeAsync(TransactionType transType)
        {
            _context.TransactionTypes.Add(transType);
            await _context.SaveChangesAsync();

            return transType;
        }

        public async Task<TransactionType> UpdateTransactionTypeAsync(int id, TransactionType updatedTransType)
        {
            var transType = await _context.TransactionTypes!.FindAsync(id);

            if (transType == null)
                return null!;

            // Update properties of the transaction type
            transType.Name = updatedTransType.Name;
            transType.Description = updatedTransType.Description;
            transType.Modified = updatedTransType.Modified;
            transType.ModifiedBy = updatedTransType.ModifiedBy;

            _context.TransactionTypes.Update(transType);
            await _context.SaveChangesAsync();

            return transType!;
        }

        public async Task<TransactionType> DeleteTransactionTypeAsync(int id)
        {
            var transType = await _context.TransactionTypes!.FindAsync(id);

            if (transType == null)
                return null!;

            _context.TransactionTypes.Remove(transType);
            await _context.SaveChangesAsync();

            return transType!;
        }

        public async Task<Dictionary<int, string>> GetTransNamesMappingAsync()
        {
            var transTypes = await _context.TransactionTypes.ToListAsync();

            // Use ToDictionary to create a mapping of PaymentMethodIds to PaymentMethod names
            var mapping = transTypes.ToDictionary(method => method.TransactionTypeId, method => method.Name ?? string.Empty);

            return mapping;
        }

        private bool TransactionTypeExists(int id)
        {
            return _context.TransactionTypes!.Any(e => e.TransactionTypeId == id);
        }
    }
}
