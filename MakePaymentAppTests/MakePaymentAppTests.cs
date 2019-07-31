using MakeMyPaymentApp;
using System;
using Xunit;

namespace MakePaymentAppTests
{
    public class MakePaymentAppTests
    {
        [Fact]
        public void TestGetMaxmimumTrasactionAmountEligibleForOffer()
        {
            var upi = new UPI();
            var netBanking = new NetBanking();

            OfferEligibilityManager offerEligibilityManager = new OfferEligibilityManager(new InMemoryStorage());
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(upi, 1000);
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(netBanking, 2000);

            Assert.Equal(1000, offerEligibilityManager.GetMaxmimumTrasactionAmountEligibleForOffer(upi));
        }
        [Fact]
        public void TestTotalTransaction()
        {
            var upi = new UPI();
            var netBanking = new NetBanking();

            OfferEligibilityManager offerEligibilityManager = new OfferEligibilityManager(new InMemoryStorage());
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(upi, 1000);
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(netBanking, 2000);

            TransactionManager transactionManager = new TransactionManager();
            transactionManager.makeTransaction(upi, 500);
            transactionManager.makeTransaction(upi, 600);

            Assert.Equal(1100, transactionManager.GetTransactionAmountOfPaymentSource(upi));
        }
        [Fact]
        public void TestIsUserEligibleForOfferTrue()
        {
            var upi = new UPI();
            var netBanking = new NetBanking();

            OfferEligibilityManager offerEligibilityManager = new OfferEligibilityManager(new InMemoryStorage());
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(upi, 1000);
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(netBanking, 2000);

            TransactionManager transactionManager = new TransactionManager();
            transactionManager.makeTransaction(upi, 500);
            transactionManager.makeTransaction(upi, 600);

            TransactionAmountTracker transactionAmountTracker = new TransactionAmountTracker(transactionManager,offerEligibilityManager);
            transactionAmountTracker.IsUserEligibleForOffer(upi);

            Assert.Equal(true, transactionAmountTracker.IsUserEligibleForOffer(upi));
        }
        [Fact]
        public void TestIsUserEligibleForOfferFalse()
        {
            var upi = new UPI();
            var netBanking = new NetBanking();

            OfferEligibilityManager offerEligibilityManager = new OfferEligibilityManager(new InMemoryStorage());
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(upi, 1000);
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(netBanking, 2000);

            TransactionManager transactionManager = new TransactionManager();
            transactionManager.makeTransaction(upi, 500);
            transactionManager.makeTransaction(netBanking, 2500);

            TransactionAmountTracker transactionAmountTracker = new TransactionAmountTracker(transactionManager, offerEligibilityManager);
            Assert.Equal(true, transactionAmountTracker.IsUserEligibleForOffer(netBanking));
        }
        [Fact]
        public void TestNoTransactionEligibleForOffer()
        {
            var upi = new UPI();
            var netBanking = new NetBanking();

            OfferEligibilityManager offerEligibilityManager = new OfferEligibilityManager(new InMemoryStorage());
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(upi, 1000);
            offerEligibilityManager.SetMaxmimumTrasactionAmountEligibleForOffer(netBanking, 2000);

            TransactionManager transactionManager = new TransactionManager();
            transactionManager.makeTransaction(upi, 500);

            TransactionAmountTracker transactionAmountTracker = new TransactionAmountTracker(transactionManager, offerEligibilityManager);
            Assert.Equal(false, transactionAmountTracker.IsUserEligibleForOffer(netBanking));
        }
    }
}
