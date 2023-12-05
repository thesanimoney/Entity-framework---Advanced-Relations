// P01_BillsPaymentSystem.Data/BillsPaymentSystemContextSeeder.cs
namespace P01_BillsPaymentSystem.Data
{
    public static class BillsPaymentSystemContextSeeder
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            // ... existing code

            var paymentMethod1 = new PaymentMethod
            {
                Type = PaymentMethodType.BankAccount,
                User = user1,
                BankAccount = bankAccount1
            };

            var paymentMethod2 = new PaymentMethod
            {
                Type = PaymentMethodType.BankAccount,
                User = user1,
                BankAccount = bankAccount2
            };

            var paymentMethod3 = new PaymentMethod
            {
                Type = PaymentMethodType.CreditCard,
                User = user1,
                CreditCard = creditCard1
            };

            context.PaymentMethods.AddRange(paymentMethod1, paymentMethod2, paymentMethod3);

            context.SaveChanges();
        }
    }
}
