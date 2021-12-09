using System.Collections.Generic;

namespace Bomb.Domain.Models
{
    public class RedWire : Wire
    {
        public RedWire()
        {
            Color = WireColorEnum.Red;
            Rules = new Rules()
            {
                WiresColorsCantCut = new List<WireColorEnum>() { },
                WiresColorsShouldCut = new List<WireColorEnum>() 
                {
                    WireColorEnum.Green
                }
            };
        }
    }
}
