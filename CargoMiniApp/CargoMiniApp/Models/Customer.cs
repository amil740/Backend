using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CargoMiniApp.Models
{
    internal class Customer
    {
        private static int _nextId = 0;

        public int Id { get; }
        public string Name { get; set; }
        public string City  { get; set; }
        public Customer(string Name, string City)
        {
            Id = Interlocked.Increment(ref _nextId);
            Name = Name ?? throw new ArgumentNullException(nameof(Name));
            City = City ?? throw new ArgumentNullException(nameof(City));
        }

    }
}
