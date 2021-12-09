using System.Collections.Generic;

namespace Bomb.Domain.Models
{
    public class WhiteWire : Wire
    {
        public WhiteWire()
        {
            Color = WireColorEnum.White;
            Rules = new Rules()
            {
                WiresColorsCantCut = new List<WireColorEnum>() 
                { 
                    WireColorEnum.White,
                    WireColorEnum.Black 
                },
                WiresColorsShouldCut = new List<WireColorEnum>() { }
            };
        }
    }
}
