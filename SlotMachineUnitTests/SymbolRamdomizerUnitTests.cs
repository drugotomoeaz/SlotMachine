using NUnit.Framework;
using SlotMachine.Symbols;
using System.Collections.Generic;

namespace SlotMachine.UnitTests
{
    public class SymbolRamdomizerUnitTests
    {
        private ISymbolRandomizer _symbolRandomizer;

        [SetUp]
        public void Setup()
        {
            var population = new List<ISymbol>
            {
                Symbol.Create(Symbols.Symbols.Apple),
                Symbol.Create(Symbols.Symbols.Banana),
                Symbol.Create(Symbols.Symbols.Pineapple),
                Symbol.Create(Symbols.Symbols.Wildcard)
            };

            _symbolRandomizer = new SymbolRandomizer(population);
        }

        [Test]
        [TestCase(2)]
        [TestCase(9)]
        [TestCase(20)]
        public void GetSample_DifferentSizes_Sample(int size)
        {
            var result = _symbolRandomizer.GetSample(size);

            Assert.IsNotNull(result);
            Assert.AreEqual(size, result.Count);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void GetSample_DifferentSizes_EmptyCollection(int size)
        {
            var result = _symbolRandomizer.GetSample(size);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
