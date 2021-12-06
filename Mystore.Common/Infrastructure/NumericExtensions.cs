using Mystore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public static class NumericExtensions
    {
        public static double RoundUpToOneSymbol(this double number)
        {
            return Math.Round(number, NumericConstants.One);
        }

        public static double RoundUpToTwoSymbols(this double number)
        {
            return Math.Round(number, NumericConstants.Two);
        }
    }
}
