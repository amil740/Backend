using System;

namespace ConsoleApp3.Transactions
{
    public class Transaction
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction()
        {
        }

        public Transaction(int id, string cardNumber, double amount, DateTime date)
        {
            Id = id;
            CardNumber = cardNumber;
            Amount = amount;
            Date = date;
        }

        public override string ToString()
        {
            return $"Id: {Id}, CardNumber: {CardNumber}, Amount: {Amount}, Date: {Date}";
        }
    }
}