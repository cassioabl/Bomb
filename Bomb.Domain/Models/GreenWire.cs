using System.Collections.Generic;

namespace Bomb.Domain.Models
{
    public class GreenWire : Wire
    {
        public GreenWire()
        {
            Color = WireColorEnum.Green;
            Rules = new Rules()
            {
                WiresColorsCantCut = new List<WireColorEnum>() { },
                WiresColorsShouldCut = new List<WireColorEnum>()
                {
                    WireColorEnum.Orange,
                    WireColorEnum.White
                },
            };
        }
    }
}
