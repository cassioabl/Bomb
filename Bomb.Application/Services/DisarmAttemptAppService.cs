using Bomb.Application.Exceptions;
using Bomb.Domain.Factories;
using Bomb.Domain.Interfaces;
using Bomb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb.Application.Interfaces
{
    public class DisarmAttemptAppService : IDisarmAttemptAppService
    {
        private readonly IDisarmAttemptRepository _disarmAttemptRepository;
        public DisarmAttemptAppService(IDisarmAttemptRepository disarmAttemptRepository)
        {
            _disarmAttemptRepository = disarmAttemptRepository;
        }

        public void TryDisarm(string wires)
        {
            var wireList = GetWireListFromString(wires);
            bool success = true;

            try
            {
                CutWires(wireList);
            }
            catch (BombExplodedException)
            {
                success = false;
                throw;
            }
            finally
            {
                SaveAttempt(wireList, success);
            }
        }

        public List<string> GetDisarmAttempts()
        {
            var result = new List<string>();
            var attempts = _disarmAttemptRepository.GetDisarmAttempt().Result;

            foreach (var attempt in attempts)
            {
                result.Add($"{attempt.Created} - "
                           + string.Join(", ", attempt.CuttedWires.Select(p => p.ColorEnum))
                           + (attempt.Success ? " - Bomba desarmada" : " - Bomba explodiu"));
            }

            return result;
        }

        public void SaveAttempt(List<Wire> wireList, bool success)
        {
            var attempt = new DisarmAttempt()
            {
                Success = success
            };

            foreach (var wire in wireList)
            {
                attempt.CuttedWires.Add(new CuttedWire()
                {
                    ColorEnum = wire.Color,
                });
            }

            _disarmAttemptRepository.Add(attempt);
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
