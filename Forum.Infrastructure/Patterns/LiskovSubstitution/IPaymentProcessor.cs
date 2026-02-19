using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Patterns.LiskovSubstitution
{
    public interface IPayment
    {
        decimal Amount { get; }
        string Currency { get; }
    }
    public interface IPaymentProcessor
    {
        public void ProcessPayment(IPayment payment);
    }

    public interface ICreditCardPayment:IPayment
    {
        string CardNumber { get; }
        string CardHolder { get; }
        DateTime ExpirationDate { get; }
    }
    public interface ICryptoPayment : IPayment
    {
        string WalletAddress { get; }
    }
    public interface IPaypalPayment : IPayment
    {
        string PaypalAccount { get; }
    }

    public class CreditCardPayment : ICreditCardPayment
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "USD";
        public string CardNumber { get; init; } = string.Empty;
        public string CardHolder { get; init; } = string.Empty;
        public DateTime ExpirationDate { get; init; }
    }

    public class CryptoPayment : ICryptoPayment
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "BTC";
        public string WalletAddress { get; init; } = string.Empty;
    }

    public class PaypalPayment : IPaypalPayment
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "USD";
        public string PaypalAccount { get; init; } = string.Empty;
    }
}
