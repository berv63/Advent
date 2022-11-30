 using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Models
{
    public class NumericDisplayModel
    {
        private static readonly List<int> _uniqueResultLengths = new List<int> {2, 3, 4, 7};

        private static readonly string _options = "abcdefg";
        public List<string> JumbledOutputs { get; set; }
        public List<string> JumbledResults { get; set; }
        
        public string DigitOutputs { get; set; }
        
        public string Positions { get; set; }
        
        public NumericDisplayModel(List<string> jumbledOutputs, List<string> jumbledResults)
        {
            JumbledOutputs = jumbledOutputs;
            JumbledResults = jumbledResults;
        }

        public int GetResultInt()
        {
            return int.Parse(DigitOutputs);
        }

        public void DetermineResult()
        {
            foreach (var digit in JumbledResults)
            {
                var digitLength = GetDigitLength(digit);

                if (DoesDigitContainPositions(digit, "012456"))
                    DigitOutputs += "0";
                else if (digitLength == 2)
                    DigitOutputs += "1";
                else if (DoesDigitContainPositions(digit, "02346"))
                    DigitOutputs += "2";
                else if (DoesDigitContainPositions(digit, "02356"))
                    DigitOutputs += "3";
                else if (digitLength == 4)
                    DigitOutputs += "4";
                else if (DoesDigitContainPositions(digit, "01356"))
                    DigitOutputs += "5";
                else if (DoesDigitContainPositions(digit, "013456"))
                    DigitOutputs += "6";
                else if (digitLength == 3)
                    DigitOutputs += "7";
                else if (digitLength == 7)
                    DigitOutputs += "8";
                else if (DoesDigitContainPositions(digit, "012356"))
                    DigitOutputs += "9";
            }
        }

        private bool DoesDigitContainPositions(string digit, string positions)
        {
            if (digit.Length != positions.Length)
            {
                return false;
            }
            
            var positionCharacters = "";
            foreach (var position in positions)
            {
                positionCharacters += Positions[int.Parse(position.ToString())];
            }

            var result = true;
            foreach (var character in positionCharacters)
            {
                result = result && digit.Contains(character);
            }

            return result;
        }
        
        private int GetDigitLength(string digit)
        {
            return digit.Length;
        }

        public void DeterminePositions()
        {
            var one = JumbledOutputs.First(x => x.Length == 2);
            var four = JumbledOutputs.First(x => x.Length == 4);
            var seven = JumbledOutputs.First(x => x.Length == 3);
            
            var position2or5 = GetIntersection(seven, one);
            var position1or3 = GetDifferences(four, one);
            
            var position0 = GetDifferences(seven, one)[0];
            var position1 = GetItemWithAppearanceCount(position1or3, 6);
            var position2 = GetItemWithAppearanceCount(position2or5, 8);
            var position3 = GetItemWithAppearanceCount(position1or3, 7);
            var position5 = GetItemWithAppearanceCount(position2or5, 9);

            var taken = position0.ToString() + position1 + position2 + position3 + position5;
            var position4or6 = GetDifferences(_options, taken);
            
            var position4 = GetItemWithAppearanceCount(position4or6, 4);
            var position6 = GetItemWithAppearanceCount(position4or6, 7);
            
            Positions = position0.ToString() + position1 + position2 + position3 + position4 + position5 + position6;
        }

        private string GetDifferences(string a, string b)
        {
            var result = "";
            foreach (var character in a)
            {
                if (!b.Contains(character))
                    result += character;
            }

            return result;
        }

        private string GetIntersection(string a, string b)
        {
            var result = "";
            foreach (var character in a)
            {
                if (b.Contains(character))
                    result += character;
            }

            return result;
        }

        private char GetItemWithAppearanceCount(string a, int count)
        {
            return a.FirstOrDefault(character => JumbledOutputs.Count(x => x.Contains(character)) == count);
        }
    }
}