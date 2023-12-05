using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityTypeConfigurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            // Primary Key
            builder.HasKey(b => b.BankAccountId);

            // Properties
            builder.Property(b => b.Balance)
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.BankName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(b => b.SwiftCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            // Relationships
            builder.HasOne(b => b.PaymentMethod)
                .WithOne(pm => pm.BankAccount)
                .HasForeignKey<BankAccount>(b => b.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


namespace P01_BillsPaymentSystem.Data.EntityTypeConfigurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            // Primary Key
            builder.HasKey(c => c.CreditCardId);

            // Properties
            builder.Property(c => c.ExpirationDate)
                .HasColumnType("date");

            builder.Property(c => c.Limit)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.MoneyOwed)
                .HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasOne(c => c.PaymentMethod)
                .WithOne(pm => pm.CreditCard)
                .HasForeignKey<CreditCard>(c => c.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


namespace P01_BillsPaymentSystem.Data.EntityTypeConfigurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            // Primary Key
            builder.HasKey(pm => pm.PaymentMethodId);

            // Enum conversion
            builder.Property(pm => pm.Type)
                .HasConversion<string>();

            // Relationships
            builder.HasOne(pm => pm.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pm => pm.BankAccount)
                .WithOne(b => b.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pm => pm.CreditCard)
                .WithOne(c => c.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


namespace P01_BillsPaymentSystem.Data.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(u => u.UserId);

            // Properties
            builder.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(u => u.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(u => u.Password)
                .HasMaxLength(25)
                .IsUnicode(false);
        }
    }
}
