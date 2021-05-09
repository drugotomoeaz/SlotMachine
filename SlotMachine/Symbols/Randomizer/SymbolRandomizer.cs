using SlotMachine.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;

using Proababilities = System.Collections.Generic.Dictionary<SlotMachine.Symbols.ISymbol, (decimal, decimal)>;

namespace SlotMachine
{
    public class SymbolRandomizer : ISymbolRandomizer
    {
        private static readonly Random _random = new Random();

        private readonly Proababilities _seqProbabilities;

        public SymbolRandomizer(ICollection<ISymbol> population)
        {
            _seqProbabilities = CalculateSeqProbabilities(population);
        }

        public ICollection<ISymbol> GetSample(int size) 
        {
            var sample = new List<ISymbol>();

            while (sample.Count < size)
            {
                try
                {
                    var seed = (decimal)_random.NextDouble();
                    
                    sample.Add(_seqProbabilities
                                    .Single(p => seed >= p.Value.Item1 &&
                                                seed < p.Value.Item2).Key);
                }
                catch
                {
                    throw new IndexOutOfRangeException("Something went wrong. Sorry. Please try again. Problem with the sample generation.");
                }
            }

            return sample;
        }

        private static Proababilities CalculateSeqProbabilities(IEnumerable<ISymbol> population)
        {
            var cumulativeProbability = 0.0m;
            var correctionCoeficient = population.Sum(p => p.Probability) != 1.0m
                                            ? 1.0m / population.Sum(p => p.Probability)
                                            : 1.0m;

            var seqProbabilities = new Proababilities();
            foreach (var entity in population)
            {
                var adjustedProabability = entity.Probability * correctionCoeficient;
                seqProbabilities.Add(entity, (cumulativeProbability, cumulativeProbability + adjustedProabability));
                cumulativeProbability += adjustedProabability;
            }

            if (cumulativeProbability != 1.0m)
                throw new Exception("Symbols probabilities sum must be exactly 100%.");

            return seqProbabilities;
        }
    }
}
