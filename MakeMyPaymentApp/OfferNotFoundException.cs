using System;

namespace MakeMyPaymentApp
{
    internal class OfferNotFoundException : Exception
    {
        public OfferNotFoundException()
        {
        }

        public OfferNotFoundException(string message) : base(message)
        {
        }

        public OfferNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}