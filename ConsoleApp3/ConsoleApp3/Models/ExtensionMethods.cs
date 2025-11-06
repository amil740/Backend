using ConsoleApp3.Services;
using ConsoleApp3.Transactions;
using System;

namespace ConsoleApp3.Models
{
    public static class ExtensionMethods
    {
        public static string MaskCardNumber(this Card card)
        {
            if (string.IsNullOrEmpty(card.CardNumber) || card.CardNumber.Length != 16)
                return card.CardNumber ?? string.Empty;

            return $"{card.CardNumber.Substring(0, 4)} **** **** {card.CardNumber.Substring(12, 4)}";
        }

        public static bool ExpenseAndGetBonus(this Card card, double amount, TransactionService? transactionService = null)
        {
            if (amount <= 0)
                return false;

            if (!card.WithDraw(amount))
                return false;

            double bonusPercentage = card.Bank switch
            {
                Bank.ABB => 0.02,
                Bank.Leo => 0.04, 
                Bank.Kapital => 0.05,
                _ => 0.0
            };

            card.Bonus += amount * bonusPercentage;

            if (transactionService != null)
            {
                var transaction = new Transaction
                {
                    CardNumber = card.CardNumber,
                    Amount = amount,
                    Date = DateTime.Now
                };

                try
                {
                    transactionService.AddTransaction(transaction);
                }
                catch
                {
                    card.Balance += amount;
                    card.Bonus -= amount * bonusPercentage;
                    return false;
                }
            }

            return true;
        }
    }
}