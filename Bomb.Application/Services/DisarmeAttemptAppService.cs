using Bomb.Application.Exceptions;
using Bomb.Domain.Factories;
using Bomb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb.Application.Interfaces
{
    public class DisarmeAttemptAppService : IDisarmeAttemptAppService
    {
        public void TryDisarm(string wires)
        {
            var wireList = GetWireListFromString(wires);
            
            CutWires(wireList);
        }


        private static void CutWires(List<Wire> wires)
        {
            var rules = new Rules();

            foreach (var wire in wires)
            {
                if (CheckIfBombExploded(wire.Color, rules))
                    throw new BombExplodedException();

                rules = wire.Rules;
            }
        }

        private static bool CheckIfBombExploded(WireColorEnum color, Rules rules)
        {
            return rules.WiresColorsShouldCut.Any() && 
                   !rules.WiresColorsShouldCut.Contains(color) ||
                   rules.WiresColorsCantCut.Any() &&
                   rules.WiresColorsCantCut.Contains(color);
        }

        private static List<Wire> GetWireListFromString(string wiresText)
        {
            var wires = wiresText.Split(',');
            var wireList = new List<Wire>();

            foreach (var wire in wires)
            {                
                WireColorEnum wireColor = wire.Trim().ToLower() switch
                {
                    "branco" => WireColorEnum.White,
                    "preto" => WireColorEnum.Black,
                    "vermelho" => WireColorEnum.Red,
                    "verde" => WireColorEnum.Green,
                    "laranja" => WireColorEnum.Orange,
                    "roxo" => WireColorEnum.Purple,
                    _ => throw new ArgumentException("Informe um input válido", wiresText),
                };

                wireList.Add(WireFactory.CreateWire(wireColor));
            }

            return wireList;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
