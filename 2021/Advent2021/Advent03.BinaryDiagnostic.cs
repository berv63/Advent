using System.Collections.Generic;
using System.Linq;
using AdventShared;

namespace Advent2021
{
    public static class BinaryDiagnostic
    {
        public static int GetLifeSupportRating(List<string> diags)
        {
            var (oxygen, co2) = GetOxygenCo2(diags);
            return oxygen * co2;
        }
        
        private static (int, int) GetOxygenCo2(List<string> diags)
        {
            var oxygen = GetOValues(diags, true);
            var co2 = GetOValues(diags, false);

            return (oxygen.ToDecimal(), co2.ToDecimal());
        }

        public static IEnumerable<int> GetOValues(List<string> diags, bool mostCommon)
        {
            var result = new List<int>();

            var index = 0;
            do
            {
                var commonValue = GetValue(diags, index, mostCommon);
                result.Add(commonValue);
                diags = diags.Where(x => int.Parse(x[index].ToString()) == commonValue).ToList();

                if (diags.Count == 1)
                {
                    result = diags[0].Select(x => int.Parse(x.ToString())).ToList();
                    break;
                }
                
                index++;
            } while (index < diags[0].Length);

            return result;
        }
        
        public static int GetPowerConsumption(List<string> diags)
        {
            var (gamma, epsilon) = GetGammaEpsilonRates(diags);
            return gamma * epsilon;
        }
        
        private static (int, int) GetGammaEpsilonRates(IReadOnlyList<string> diags)
        {
            var gammaRateBinary = GetGammaRate(diags);
            var epsilonRateBinary = gammaRateBinary.InvertBinary();;

            return (gammaRateBinary.ToDecimal(), epsilonRateBinary.ToDecimal());
        }
        
        private static List<int> GetGammaRate(IReadOnlyList<string> diags)
        {
            var result = new List<int>();

            for (var i = 0; i < diags[0].Length; i++)
            {
                result.Add(GetValue(diags, i));
            }

            return result;
        }

        private static int GetValue(IReadOnlyCollection<string> diags, int index, bool mostCommon = true)
        {
            var sum = diags.Select(x => int.Parse(x[index].ToString())).Sum();
            var sumGreaterThanHalf = sum >= (diags.Count / 2m);
            
            return mostCommon ?
                sumGreaterThanHalf ? 1 : 0 :
                sumGreaterThanHalf ? 0 : 1;
        }
    }
}