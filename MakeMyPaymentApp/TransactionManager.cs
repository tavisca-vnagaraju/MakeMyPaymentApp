using System.Collections.Generic;

namespace MakeMyPaymentApp
{
    public class TransactionManager
    {
        private Dictionary<PaymentSource, int> _totalTransactionDetails = new Dictionary<PaymentSource, int>();
        public void makeTransaction(PaymentSource paymentSource, int amount)
        {
            if (_totalTransactionDetails.ContainsKey(paymentSource))
            {
                _totalTransactionDetails[paymentSource] += amount;
            }
            else
            {
                _totalTransactionDetails[paymentSource] = amount;
            }
        }
        public int GetTransactionAmountOfPaymentSource(PaymentSource paymentSource)
        {
            if (_totalTransactionDetails.ContainsKey(paymentSource))
            {
                return _totalTransactionDetails[paymentSource];
            }
            return 0;
        }
    }
}
