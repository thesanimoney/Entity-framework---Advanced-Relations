// P01_BillsPaymentSystem.Data.Models/BankAccount.cs
namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public decimal Balance { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }

        // Navigation Property
        public PaymentMethod PaymentMethod { get; set; }

        public void ProcessTransaction(decimal amount, Action<decimal> transactionAction)
        {
            if (transactionAction != null)
            {
                transactionAction(amount);
            }
        }
    }
}

// P01_BillsPaymentSystem.Data.Models/CreditCard.cs
namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Limit { get; set; }
        public decimal MoneyOwed { get; set; }
        public decimal LimitLeft => Limit - MoneyOwed;

        // Navigation Property
        public PaymentMethod PaymentMethod { get; set; }

        public void ProcessPayment(decimal amount)
        {
            if (LimitLeft >= amount)
            {
                MoneyOwed += amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }
    }
}

// P01_BillsPaymentSystem.Data.Models/PaymentMethod.cs
namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public PaymentMethodType Type { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int? BankAccountId { get; set; }
        public int? CreditCardId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public BankAccount BankAccount { get; set; }
        public CreditCard CreditCard { get; set; }

        public void PayBill(decimal amount)
        {
            if (Type == PaymentMethodType.BankAccount)
            {
                BankAccount?.ProcessTransaction(amount, BankAccount.Withdraw);
            }
            else if (Type == PaymentMethodType.CreditCard)
            {
                CreditCard?.ProcessPayment(amount);
            }
        }
    }
}


// P01_BillsPaymentSystem.Data.Models/PaymentMethod.cs
namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public PaymentMethodType Type { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int? BankAccountId { get; set; }
        public int? CreditCardId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public BankAccount BankAccount { get; set; }
        public CreditCard CreditCard { get; set; }

        public void PayBill(decimal amount)
        {
            if (Type == PaymentMethodType.BankAccount)
            {
                BankAccount?.ProcessTransaction(amount, BankAccount.Withdraw);
            }
            else if (Type == PaymentMethodType.CreditCard)
            {
                CreditCard?.ProcessPayment(amount);
            }
        }
    }
}

// P01_BillsPaymentSystem.Data.Models/User.cs
namespace P01_BillsPaymentSystem.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation Property
        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}


