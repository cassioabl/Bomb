using System.Collections.Generic;

namespace Bomb.Domain.Models
{
    public class OrangeWire : Wire
    {
        public OrangeWire()
        {
            Color = WireColorEnum.Orange;
            Rules = new Rules()
            {
                WiresColorsCantCut = new List<WireColorEnum>() { },
                WiresColorsShouldCut = new List<WireColorEnum>()
                { 
                    WireColorEnum.Red,
                    WireColorEnum.Black 
                },
            };
        }
    }
}
