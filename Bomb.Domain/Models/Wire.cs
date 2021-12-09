using System;

namespace Bomb.Domain.Models
{
    public abstract class Wire
    {
        public WireColorEnum Color { get; set; }
        public Rules Rules { get; set; }
    }
}
