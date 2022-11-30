using System.Collections.Generic;
using System.Linq;

namespace Advent2021
{
    public static class SyntaxScoring
    {
        private static readonly Dictionary<char, char> openingChunks = new Dictionary<char, char> 
        { 
            {'(', ')'},
            {'[', ']'},
            {'{', '}'},
            {'<', '>'}
        };
        
        private static readonly Dictionary<char, char> closingChunks = new Dictionary<char, char> 
        { 
            {')', '('},
            {']', '['},
            {'}', '{'},
            {'>', '<'}
        };
        
        private static readonly Dictionary<char, int> characterScore = new Dictionary<char, int> 
        {
            {')', 3},
            {']', 57}, 
            {'}', 1197},
            {'>', 25137}
        };
        
        private static readonly Dictionary<char, int> characterAutoCompleteScore = new Dictionary<char, int> 
        {
            {')', 1},
            {']', 2}, 
            {'}', 3},
            {'>', 4}
        };

        public static long GetAutoCompleteScore(List<string> rows)
        {
            var rowScores = new List<long>();
            foreach (var row in rows)
            {
                var characters = GetCharacters(row, true);
                if (!characters.Any())
                    continue;
                
                var autoCompleteChars = GetAutoCompleteMapping(characters);
                var rowScore = GetAutoCompleteCharacterScore(autoCompleteChars);
                rowScores.Add(rowScore);
            }

            return GetMiddleScore(rowScores);
        }

        private static long GetMiddleScore(List<long> rowScores)
        {
            var sortedScores = rowScores.OrderBy(x => x).ToList();
            var middleIndex = rowScores.Count / 2;
            return sortedScores[middleIndex];
        }

        private static long GetAutoCompleteCharacterScore(IEnumerable<char> characters)
        {
            long score = 0;
            foreach (var character in characters)
            {
                score = (score * 5) + characterAutoCompleteScore[character];
            }

            return score;
        }

        private static List<char> GetAutoCompleteMapping(IEnumerable<char> characters)
        {
            return characters.Select(x => openingChunks[x]).Reverse().ToList();
        }

        public static int GetSyntaxScore(List<string> rows)
        {
            var fileScore = 0;
            foreach (var row in rows)
            {
                var characters = GetCharacters(row);
                var rowScore = GetRowScore(characters);
                fileScore += rowScore;
            }

            return fileScore;
        }

        private static int GetRowScore(IEnumerable<char> characters)
        {
            return characters.Sum(x => characterScore[x]);
        }

        private static List<char> GetCharacters(string row, bool getRemainingCharacters = false)
        {
            var invalidCharacters = new List<char>();
            
            var index = 0;
            do
            {
                if (index == row.Length)
                    break;
                if (closingChunks.Keys.Contains(row[index]))
                {
                    if (index == 0)
                    {
                        invalidCharacters.Add(row[index]);
                        row = row.Substring(1);
                    }
                    else if (row[index - 1] == closingChunks[row[index]])
                    {
                        if (index == row.Length - 1)
                        {
                            row = row.Substring(0, index - 1);
                            break;
                        }
                        else
                        {
                            row = GetRemainingCharacters(row, index);
                        }
                    }
                    else
                    {
                        invalidCharacters.Add(row[index]);
                        row = GetRemainingCharacters(row, index);
                    }
                    
                    index = 0;
                }
                else
                {
                    index++;
                }
            } while (row.Length > 0);

            switch (getRemainingCharacters)
            {
                case true when !invalidCharacters.Any():
                    return row.Select(x => x).ToList();
                case true when invalidCharacters.Any():
                    return new List<char>();
                default:
                    return invalidCharacters.ToList();
            }
        }

        private static string GetRemainingCharacters(string row, int index)
        {
            return  row.Substring(0, index - 1) + row.Substring(index + 1, row.Length - 1 - index);
        }
    }
}
