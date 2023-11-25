namespace ServerBlazorEF
{
    public class PaymentService
    {
        private DonationDbContext _context;

        public PaymentService(DonationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentMethod>> GetPaymentMethodsAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod?> GetPaymentMethodByIdAsync(int id)
        {
            return await _context.PaymentMethods.FindAsync(id) ?? null;
        }

        public async Task<PaymentMethod?> InsertPaymentMethodAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Add(paymentMethod);
            await _context.SaveChangesAsync();

            return paymentMethod;
        }

        public async Task<PaymentMethod> UpdatePaymentMethodAsync(int id, PaymentMethod updatedPaymentMethod)
        {
            var paymentMethod = await _context.PaymentMethods!.FindAsync(id);

            if (paymentMethod == null)
                return null!;

            // Update properties of the payment method
            paymentMethod.Name = updatedPaymentMethod.Name;
            paymentMethod.Modified = updatedPaymentMethod.Modified;
            paymentMethod.ModifiedBy = updatedPaymentMethod.ModifiedBy;

            _context.PaymentMethods.Update(paymentMethod);
            await _context.SaveChangesAsync();

            return paymentMethod!;
        }

        public async Task<PaymentMethod> DeletePaymentMethodAsync(int id)
        {
            var paymentMethod = await _context.PaymentMethods!.FindAsync(id);

            if (paymentMethod == null)
                return null!;

            _context.PaymentMethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();

            return paymentMethod!;
        }
        public async Task<Dictionary<int, string>> GetPaymentMethodNamesMappingAsync()
        {
            var paymentMethods = await _context.PaymentMethods.ToListAsync();

            // Use ToDictionary to create a mapping of PaymentMethodIds to PaymentMethod names
            var mapping = paymentMethods.ToDictionary(method => method.PaymentMethodId, method => method.Name ?? string.Empty);

            return mapping;
        }

        private bool PaymentMethodExists(int id)
        {
            return _context.PaymentMethods!.Any(e => e.PaymentMethodId == id);
        }
    }
}
