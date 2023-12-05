// P01_BillsPaymentSystem.App/Program.cs
namespace P01_BillsPaymentSystem.App
{
	class Program
	{
		static void Main()
		{
			using (var context = new BillsPaymentSystemContext())
			{
				// ... existing code

				if (user != null)
				{
					Console.WriteLine($"User: {user.FirstName} {user.LastName}");
					Console.WriteLine("Bank Accounts:");

					foreach (var bankAccount in user.PaymentMethods
						.Where(pm => pm.Type == PaymentMethodType.BankAccount)
						.Select(pm => pm.BankAccount))
					{
						Console.WriteLine($"- ID: {bankAccount.BankAccountId}");
						Console.WriteLine($"  Balance: {bankAccount.Balance:C}");
						Console.WriteLine($"  Bank: {bankAccount.BankName}");
						Console.WriteLine($"  SWIFT: {bankAccount.SwiftCode}");
					}

					Console.WriteLine("Credit Cards:");

					foreach (var creditCard in user.PaymentMethods
						.Where(pm => pm.Type == PaymentMethodType.CreditCard)
						.Select(pm => pm.CreditCard))
					{
						Console.WriteLine($"- ID: {creditCard.CreditCardId}");
						Console.WriteLine($"  Limit: {creditCard.Limit:C}");
						Console.WriteLine($"  Money Owed: {creditCard.MoneyOwed:C}");
						Console.WriteLine($"  Limit Left: {creditCard.LimitLeft:C}");
						Console.WriteLine($"  Expiration Date: {creditCard.ExpirationDate:yyyy/MM}");
					}
				}
				else
				{
					Console.WriteLine($"User with ID {userIdToRetrieve} not found!");
				}
			}
		}
	}
}
