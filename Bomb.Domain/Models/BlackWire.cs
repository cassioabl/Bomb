using System.Collections.Generic;

namespace Bomb.Domain.Models
{
    public class BlackWire : Wire
    {
        public BlackWire()
        {
            Color = WireColorEnum.Black;
            Rules = new Rules()
            {
                WiresColorsCantCut = new List<WireColorEnum>() 
                { 
                    WireColorEnum.White,
                    WireColorEnum.Green,
                    WireColorEnum.Orange
                },
                WiresColorsShouldCut = new List<WireColorEnum>() { }
            };
        }
    }
}
