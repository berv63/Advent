using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Advent2021.Models;
using AdventShared;

namespace Advent2021
{
    public static class ExtendedPolymerization
    {
        #region TreeBuilder
        public static void BuildPolymerizationTrees(List<PolymerizationTreeModel> models)
        {
            foreach (var model in models) //loop thru all in case there are some buried without parents
            {
                AddChildren(model, models);
            }
        }
        
        private static void AddChildren(PolymerizationTreeModel model, List<PolymerizationTreeModel> models)
        {
            if (model.Visited) return;
            
            model.Visited = true;
            AddChild(model, models, model.Rule[0] + model.Insertion);
            AddChild(model, models, model.Insertion + model.Rule[1]);
        }

        private static void AddChild(PolymerizationTreeModel model, List<PolymerizationTreeModel> models, string rule)
        {
            var child = models.FirstOrDefault(x => x.Rule == rule);
            if (child != null)
            {
                model.Children.Add(child);
                AddChildren(child, models);
            }
        }
        #endregion

        public static long GetMostLestCommonDifference(string startingValue, List<PolymerizationTreeModel> treeRoots, int steps)
        {
            var charCount = new Dictionary<char, long>();
            for (var i = 0; i < startingValue.Length - 1; i++)
            {
                var root = treeRoots.FirstOrDefault(x => x.Rule == startingValue[i] + startingValue[i + 1].ToString());
                if (root != null)
                    GetCharacterCounts(root, charCount, steps);
                else
                    AddCharCount(charCount, startingValue[i]);
            }
            
            AddCharCount(charCount, startingValue.Last());

            var (max, min) = GetMostLeastCommonCharCounts(charCount);
            return max - min;
        }
        
        private static (long, long) GetMostLeastCommonCharCounts(Dictionary<char, long> charCount)
        {
            var sorted = charCount.OrderByDescending(x => x.Value).ToList();
            return (sorted.First().Value, sorted.Last().Value);
        }

        private static void GetCharacterCounts(PolymerizationTreeModel model, Dictionary<char, long> charCountMain, int steps)
        {
            if (steps == 0)
            {
                AddCharCount(charCountMain, model.Rule[0]);
                return;
            };

            if (model.CharCounts.ContainsKey(steps))
            {
                MergeCharCounts(charCountMain, model.CharCounts[steps]);
                return;
            }

            var newSteps = steps - 1;

            var charCount = new Dictionary<char, long>();
            foreach (var child in model.Children)
            {
                GetCharacterCounts(child, charCount, newSteps);
            }
            
            model.AddCharCounts(steps, charCount);
            MergeCharCounts(charCountMain, charCount);
        }
        
        private static void MergeCharCounts(IDictionary<char, long> charCount1, IReadOnlyDictionary<char, long> charCount2)
        {
            var result = new Dictionary<char, long>();
            
            foreach (var character in charCount1.Where(character => !charCount2.ContainsKey(character.Key)))
            {
                result[character.Key] = charCount1[character.Key];
            }
            
            foreach (var character in charCount1.Where(character => charCount2.ContainsKey(character.Key)))
            {
                result[character.Key] = charCount1[character.Key] + charCount2[character.Key];
            }

            foreach (var character in charCount2.Where(character => !charCount1.ContainsKey(character.Key)))
            {
                result[character.Key] = character.Value;
            }

            foreach (var item in result)
            {
                charCount1[item.Key] = item.Value;
            }
        }

        private static void AddCharCount(IDictionary<char, long> charCount, char character)
        {
            if (charCount.ContainsKey(character))
                charCount[character]++;
            else
                charCount.Add(character, 1);
        }
        
        #region Part1
        public static long GetMoreString(string initialString, Dictionary<string, string> rules, int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                initialString = ApplyMoreRules(initialString, rules);
            }

            var (max, min) = GetMostLeastCommonCounts(initialString);
            return max - min;
        }
        
        private static string ApplyMoreRules(string initialString, Dictionary<string, string> rules)
        {
            var result = "";
            return result; 
            //todo option 1 recurrsion? and each time i repeat a pattern look back at what happened before?
            //todo option 2 Linked list? where CH points to CBH...and when i get back to CH loop it back?
        }
        
        public static long GetFinalString(string initialString, Dictionary<string, string> rules, int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                initialString = ApplyRules(initialString, rules);
            }

            var (max, min) = GetMostLeastCommonCounts(initialString);
            return max - min;
        }

        private static (long, long) GetMostLeastCommonCounts(string finalString)
        {
            var characterGrouping = finalString.GroupBy(x => x).ToList();
            return (characterGrouping.Max(x => x.Count()), characterGrouping.Min(x => x.Count()));
        }

        private static string ApplyRules(string initialString, Dictionary<string, string> rules)
        {
            var result = initialString[0].ToString();
            for (var i = 0; i < initialString.Length - 1; i++)
            {
                var hasRule = rules.ContainsKey(initialString[i].ToString() + initialString[i + 1]);
                if(i < initialString.Length - 1 && hasRule)
                    result += rules[initialString[i].ToString() + initialString[i + 1]];
                
                result += initialString[i+1];
            }

            return result;
        }
        #endregion
    }
}
/*                                                                                      => BN done
CH => CBH => CB => CHB => HB => HCB => HC => HBC => BC => BBC => BB => BNB => BN => BBN => BB done
                       => CH done   => CB done   => HB done   => BC done   => NB => NBB => NB done
          => BH => BHH => BH done                                                       => BB done
                       => HH => HNH => HN => HCN => HC done
                                                 => CN => CCN => CC => CNC => NC => NBC => NB done
                                                               => CN done   => CN => done => BC done
                                    => NH => NCH => NC done
                                                 => CH done       
                                    
NN => NCN => NC done
          => CN done
*/