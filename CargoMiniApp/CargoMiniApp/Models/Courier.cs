using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CargoMiniApp.Models
{
    internal class Courier
    {
        private static int _nextId = 0;

        public int Id { get; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public Courier(string adi, bool isAvailable = true)
        {
            Id = Interlocked.Increment(ref _nextId);
            Name = Name ?? throw new ArgumentNullException(nameof(Name));
            IsAvailable = isAvailable;
        }
    }
}
