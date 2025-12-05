using System.Collections.Generic;
using System.Linq;

namespace AdventShared
{
    public static class IntExtensions
    {
        public static List<int> GetFactors(this int value)
        {
            var result = new List<int>();
            for (var i = 1; i <= value / 2; i++)
            {
                if (value % i != 0) continue;

                result.Add(i);
                result.Add(value / i);
            }

            result.Sort();
            return result.Distinct().ToList();
        }

        public static void GetPrimeFactors(this int value, ref List<int> primeFactors)
        {
            if (value.IsPrime())
            {
                if(!primeFactors.Contains(value))
                    primeFactors.Add(value);

                return;
            }

            var factors = value.GetFactors().Where(x => x != value && x != 1);
            foreach (var factor in factors)
            {
                GetPrimeFactors(factor, ref primeFactors);
            }

        }

        private static bool IsPrime(this int value)
        {
            if (value is 1 or 2)
            {
                return true;
            }

            for (var i = 2; i <= value / 2; i++)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }
        
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
    }
}
