using System;
using System.Collections.Generic;

namespace Bomb.Domain.Models
{
    public class DisarmAttempt : Entity
    {
        public DisarmAttempt()
        {
            CuttedWires = new List<CuttedWire>();
        }

        public IList<CuttedWire> CuttedWires { get; set; }
        public bool Success { get; set; }
    }
}
