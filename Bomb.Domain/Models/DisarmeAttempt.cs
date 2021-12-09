using System;
using System.Collections.Generic;

namespace Bomb.Domain.Models
{
    public class DisarmeAttempt
    {
        public Guid Id { get; set; }
        public IEnumerable<Wire> Wires { get; set; }
        public DateTime Date { get; set; }
        public bool Result { get; set; }
    }
}
