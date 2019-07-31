using System.Collections.Generic;

namespace MakeMyPaymentApp
{
    public class InMemoryStorage : IStorage
    {
        private Dictionary<PaymentSource, int> _paymentSourceOffers = new Dictionary<PaymentSource, int>();
        public int GetMaxmimumTrasactionAmountEligibleForOffer(PaymentSource paymentSource)
        {
            if (_paymentSourceOffers.ContainsKey(paymentSource))
            {
                return _paymentSourceOffers[paymentSource];
            }
            throw new OfferNotFoundException();
        }

        public void SetMaxmimumTrasactionAmountEligibleForOffer(PaymentSource paymentSource, int amount)
        {
            if (_paymentSourceOffers.ContainsKey(paymentSource))
            {
                _paymentSourceOffers[paymentSource] = amount;
            }
            else
            {
                _paymentSourceOffers.Add(paymentSource, amount);
            }
        }
    }
}
