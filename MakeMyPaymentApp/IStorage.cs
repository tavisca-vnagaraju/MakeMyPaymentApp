namespace MakeMyPaymentApp
{
    public interface IStorage
    {
        void SetMaxmimumTrasactionAmountEligibleForOffer(PaymentSource paymentSource, int amount);
        int GetMaxmimumTrasactionAmountEligibleForOffer(PaymentSource paymentSource);
    }
}
