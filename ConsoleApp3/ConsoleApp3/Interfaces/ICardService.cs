using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Interfaces
{
    public interface ICardService
    {
        List<Card> GetAll();
        void AddCard(Card card);
        Card? this[string cardNumber] { get; }
    }
}