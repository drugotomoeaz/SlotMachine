using NUnit.Framework;
using SlotMachine.Symbols;
using System.Collections.Generic;

namespace SlotMachine.UnitTests
{
    public class ProfitCalculatorUnitTests
    {
        private IProfitCalculator _profitCalculator; 

        [SetUp]
        public void Setup()
        {
            _profitCalculator = ProfitCalculator.CreateInstance();
        }

        [Test]
        [TestCase(Symbols.Symbols.Apple, 1.2)]
        [TestCase(Symbols.Symbols.Banana, 1.8)]
        [TestCase(Symbols.Symbols.Pineapple, 2.4)]
        public void GetProfit_MatchingSymbols_Profit(Symbols.Symbols symbolType, decimal expectedResult)
        {
            var testsymbols = new List<ISymbol> 
            {
                Symbol.Create(symbolType),
                Symbol.Create(symbolType),
                Symbol.Create(symbolType)
            };

            var result = _profitCalculator.GetProfit(testsymbols, 1);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(Symbols.Symbols.Apple, Symbols.Symbols.Wildcard, Symbols.Symbols.Apple, 0.8)]
        [TestCase(Symbols.Symbols.Wildcard, Symbols.Symbols.Banana, Symbols.Symbols.Banana, 1.2)]
        [TestCase(Symbols.Symbols.Pineapple,Symbols.Symbols.Pineapple, Symbols.Symbols.Wildcard, 1.6)]
        [TestCase(Symbols.Symbols.Pineapple, Symbols.Symbols.Wildcard, Symbols.Symbols.Wildcard, 0.8)]
        public void GetProfit_MatchingSymbolsWithWildcard_Profit(
            Symbols.Symbols firstSymbolType,
            Symbols.Symbols secondSymbolType,
            Symbols.Symbols thirdSymbolType, 
            decimal expectedResult)
        {
            var testsymbols = new List<ISymbol>
            {
                Symbol.Create(firstSymbolType),
                Symbol.Create(secondSymbolType),
                Symbol.Create(thirdSymbolType)
            };

            var result = _profitCalculator.GetProfit(testsymbols, 1);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(Symbols.Symbols.Pineapple, Symbols.Symbols.Wildcard, Symbols.Symbols.Apple)]
        [TestCase(Symbols.Symbols.Wildcard, Symbols.Symbols.Banana, Symbols.Symbols.Apple)]
        [TestCase(Symbols.Symbols.Pineapple, Symbols.Symbols.Banana, Symbols.Symbols.Wildcard)]
        [TestCase(Symbols.Symbols.Wildcard, Symbols.Symbols.Wildcard, Symbols.Symbols.Wildcard)]
        public void GetProfit_MatchingSymbolsWithWildcard_NoProfit(
             Symbols.Symbols firstSymbolType,
             Symbols.Symbols secondSymbolType,
             Symbols.Symbols thirdSymbolType)
        {
            var testsymbols = new List<ISymbol>
            {
                Symbol.Create(firstSymbolType),
                Symbol.Create(secondSymbolType),
                Symbol.Create(thirdSymbolType)
            };

            var result = _profitCalculator.GetProfit(testsymbols, 1);

            Assert.AreEqual(0.0m, result);
        }
    }
}