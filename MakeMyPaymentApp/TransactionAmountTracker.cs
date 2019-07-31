using System;

namespace MakeMyPaymentApp
{
    public class TransactionAmountTracker
    {
        private TransactionManager _transactionManager;
        private OfferEligibilityManager _offerEligibilityManager;
        public TransactionAmountTracker(TransactionManager transactionManager,OfferEligibilityManager offerEligibilityManager)
        {
            _transactionManager = transactionManager;
            _offerEligibilityManager = offerEligibilityManager;
        }
        public Boolean IsUserEligibleForOffer(PaymentSource paymentSource)
        {
            var maximumAmountForOffer = _offerEligibilityManager.GetMaxmimumTrasactionAmountEligibleForOffer(paymentSource);
            var totalTransactionAmount = _transactionManager.GetTransactionAmountOfPaymentSource(paymentSource);
            if(totalTransactionAmount > maximumAmountForOffer)
            {
                return true;
            }
            return false;
        }
    }
}
