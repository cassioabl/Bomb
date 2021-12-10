using System.Collections.Generic;

namespace Bomb.Domain.Models
{
    public class Rules
    {
        public List<WireColorEnum> WiresColorsShouldCut { get; set; } = new List<WireColorEnum>() { };
        public List<WireColorEnum> WiresColorsCantCut { get; set; } = new List<WireColorEnum>() { };
    }
}
