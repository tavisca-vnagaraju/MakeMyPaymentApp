namespace MakeMyPaymentApp
{
    public class OfferEligibilityManager
    {
        private IStorage _storage;
        public OfferEligibilityManager(IStorage storage)
        {
            _storage = storage;
        }
        public int GetMaxmimumTrasactionAmountEligibleForOffer(PaymentSource paymentSource)
        {
            return _storage.GetMaxmimumTrasactionAmountEligibleForOffer(paymentSource);
        }
        public void SetMaxmimumTrasactionAmountEligibleForOffer(PaymentSource paymentSource, int amount)
        {
            _storage.SetMaxmimumTrasactionAmountEligibleForOffer(paymentSource, amount);
        }
    }
}
