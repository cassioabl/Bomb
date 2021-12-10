using System;

namespace Bomb.Domain.Models
{
    public class CuttedWire : Entity
    {
        public WireColorEnum ColorEnum { get; set; }
        public Guid DisarmAttemptId { get; set; }
        
        public DisarmAttempt DisarmAttempt { get; set; }
    }
}
