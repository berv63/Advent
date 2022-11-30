using System;

namespace Advent2021.Models
{
    public class SnailfishNumberModel
    {
        public int? Number1 { get; set; }
        public int? Number2 { get; set; }
        
        public SnailfishNumberModel SubNumbers1 { get; set; }
        public SnailfishNumberModel SubNumbers2 { get; set; }

        public string RemainingDefinition { get; set; }
        
        public SnailfishNumberModel(string definition)
        {
            if (definition[1] == '[')
            {
                SubNumbers1 = new SnailfishNumberModel(definition.Substring(1));
                if (SubNumbers1.RemainingDefinition[1] == '[')
                {
                    SubNumbers2 = new SnailfishNumberModel(SubNumbers1.RemainingDefinition.Substring(1));
                    RemainingDefinition = SubNumbers2.RemainingDefinition.Substring(1);
                }
                else if (int.TryParse(SubNumbers1.RemainingDefinition[1].ToString(), out var number2))
                {
                    Number2 = number2;
                    RemainingDefinition = SubNumbers1.RemainingDefinition.Substring(3);
                }
            }
            else if (int.TryParse(definition[1].ToString(), out var number1))
            {
                Number1 = number1;

                if (definition[3] == '[')
                {
                    SubNumbers2 = new SnailfishNumberModel(definition.Substring(3));
                    RemainingDefinition = SubNumbers2.RemainingDefinition.Substring(1);
                }
                else if (int.TryParse(definition[3].ToString(), out var number2))
                {
                    Number2 = number2;
                    RemainingDefinition = definition.Substring(5);
                }
            }
        }
        
        public SnailfishNumberModel(SnailfishNumberModel number1, SnailfishNumberModel number2)
        {
            SubNumbers1 = number1;
            SubNumbers2 = number2;
        }
        
        private SnailfishNumberModel(int number1, int number2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public long GetMagnitude()
        {
            long pairMagnitude = 0;
            if (Number1.HasValue)
                pairMagnitude += 3 * Number1.Value;
            else
                pairMagnitude += 3 * SubNumbers1.GetMagnitude();
            
            if (Number2.HasValue)
                pairMagnitude += 2 * Number2.Value;
            else
                pairMagnitude += 2 * SubNumbers2.GetMagnitude();
            
            return pairMagnitude;
        }

        public string PrintNumbers()
        {
            var result = $"[{PrintNumber(Number1, SubNumbers1)},{PrintNumber(Number2, SubNumbers2)}]";
            return result;   
        }

        private string PrintNumber(int? number, SnailfishNumberModel subNumber)
        {
            var result = "";
            
            if (number.HasValue)
                result += number.Value.ToString();
            else
                result += subNumber.PrintNumbers();
            
            return result;
        }
        
        public void Condense()
        {
            bool exploded;
            bool split;

            do
            {
                exploded = false;
                split = false;

                var explodeTuple = (0, 0);
                Explode(0, ref explodeTuple, ref exploded);
                if(exploded)
                    continue;

                Split(ref split);
            } while (exploded || split);
        }

        private void Split(ref bool split)
        {
            if (split) return;

            if (Number1.HasValue && Number1 >= 10)
            {
                GenerateSplitLeft();
                split = true;
            }
            else if(SubNumbers1 != null)
                SubNumbers1.Split(ref split);

            if (split) return;
            
            if (Number2.HasValue && Number2 >= 10)
            {
                GenerateSplitRight();
                split = true;
            }
            else if(SubNumbers2 != null)
                SubNumbers2.Split(ref split);
        }

        private void GenerateSplitLeft()
        {
            var half = Number1.Value / 2m;
            Number1 = null;
            SubNumbers1 = BuildNewSnailfishNumbers(half);
        }
        
        private void GenerateSplitRight()
        {
            var half = Number2.Value / 2m;
            Number2 = null;
            SubNumbers2 = BuildNewSnailfishNumbers(half);
        }

        private SnailfishNumberModel BuildNewSnailfishNumbers(decimal half)
        {
            return new SnailfishNumberModel((int)Math.Truncate(half), (int)Math.Round(half, MidpointRounding.AwayFromZero));
        }
        
        public void ExplodeOnce()
        {
            bool exploded;
            bool split;

            do
            {
                exploded = false;
                split = false;

                var explodeTuple = (0, 0);
                Explode(0, ref explodeTuple, ref exploded);
                if(exploded)
                    continue;
            } while (!exploded && !split);
        }
        
        private void Explode(int depth, ref (int, int) leftRight, ref bool exploded)
        {
            if (!exploded)
            {
                if (depth == 4)
                {
                    exploded = true;
                    leftRight.Item1 = Number1 ?? 0;
                    leftRight.Item2 = Number2 ?? 0;
                }
                else
                {
                    SubNumbers1?.Explode(depth + 1, ref leftRight, ref exploded);
                    if (exploded)
                    {
                        if (depth == 3)
                        {
                            Number1 = 0;
                            SubNumbers1 = null;
                        }

                        if (leftRight.Item2 != 0)
                        {
                            if (Number2.HasValue)
                            {
                                Number2 += leftRight.Item2;
                                leftRight.Item2 = 0;
                            }
                            else
                                SubNumbers2?.UpdateLeftMost(ref leftRight);
                        }
                    }

                    if (!exploded)
                    {
                        SubNumbers2?.Explode(depth + 1, ref leftRight, ref exploded);
                        if (exploded)
                        {
                            if (depth == 3)
                            {
                                Number2 = 0;
                                SubNumbers2 = null;
                            }

                            if (leftRight.Item1 != 0)
                            {
                                if (Number1.HasValue)
                                {
                                    Number1 += leftRight.Item1;
                                    leftRight.Item1 = 0;
                                }
                                else
                                    SubNumbers1?.UpdateRightMost(ref leftRight);
                            }
                        }
                    }
                }
            }
        }

        private void UpdateValueItem1(ref (int, int) leftRight, int? value)
        {
            value += leftRight.Item1;
            leftRight.Item1 = 0;
        }
        
        private void UpdateValueItem2(ref (int, int) leftRight, int? value)
        {
            value += leftRight.Item2;
            leftRight.Item2 = 0;
        }

        private void UpdateRightMost(ref (int, int) leftRight)
        {
            if (Number2.HasValue)
            {
                Number2 += leftRight.Item1;
                leftRight.Item1 = 0;
            }
            else
                SubNumbers2.UpdateRightMost(ref leftRight);
        }

        private void UpdateLeftMost(ref (int, int) leftRight)
        {
            if (Number1.HasValue)
            {
                Number1 += leftRight.Item2;
                leftRight.Item2 = 0;
            }
            else
                SubNumbers1.UpdateLeftMost(ref leftRight);
        }
    }
}