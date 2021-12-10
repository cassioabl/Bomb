using System.Collections.Generic;

namespace Bomb.Domain.Models
{
    public class PurpleWire : Wire
    {
        public PurpleWire()
        {
            Color = WireColorEnum.Purple;
            Rules = new Rules()
            {
                WiresColorsCantCut = new List<WireColorEnum>() 
                {
                    WireColorEnum.Purple,
                    WireColorEnum.Green,
                    WireColorEnum.Orange,
                    WireColorEnum.White
                },
                WiresColorsShouldCut = new List<WireColorEnum>() { },
            };
        }
    }
}
