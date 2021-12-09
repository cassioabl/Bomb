using Bomb.Domain.Models;

namespace Bomb.Domain.Factories
{
    public class WireFactory
    {
        public static Wire CreateWire(WireColorEnum color)
        {
            return color switch
            {
                WireColorEnum.White => new WhiteWire(),
                WireColorEnum.Black => new BlackWire(),
                WireColorEnum.Red => new RedWire(),
                WireColorEnum.Orange => new OrangeWire(),
                WireColorEnum.Green => new GreenWire(),
                WireColorEnum.Purple => new PurpleWire(),
                _ => null,
            };
        }
    }
}
