using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent18SnailfishTests
    {
        [Test]
        public void BuildPractice1()
        {
            var stringToBuild = "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]";
            var result = Snailfish.BuildSnailfishNumber(stringToBuild); 
            Assert.AreEqual(stringToBuild, result.PrintNumbers()); //confirm build
        }
        
        [Test]
        public void SingleExplodePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\SingleExplodePractice.txt");
            var rowSplits = rows.Select(x => x.Split('|'));

            foreach (var rowSplit in rowSplits)
            {
                var result = Snailfish.BuildSnailfishNumber(rowSplit[0]); 
                Assert.AreEqual(rowSplit[0], result.PrintNumbers()); //confirm build
                
                result.ExplodeOnce(); 
                Assert.AreEqual(rowSplit[1], result.PrintNumbers()); //confirm condense
            }
        }
        
        [Test]
        public void SimplePractice1()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\SimplePractice1.txt");
            var numbers = rows.Select(Snailfish.BuildSnailfishNumber).ToList();

            var resultNumber = numbers[0];
            for (var i = 1; i < numbers.Count; i++)
            {
                resultNumber = Snailfish.AddSnailfishNumbers(resultNumber, numbers[i]);
                resultNumber.Condense();
            }
            
            Assert.AreEqual("[[[[1,1],[2,2]],[3,3]],[4,4]]", resultNumber.PrintNumbers());
        }
        
        [Test]
        public void SimplePractice2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\SimplePractice2.txt");
            var numbers = rows.Select(Snailfish.BuildSnailfishNumber).ToList();

            var resultNumber = numbers[0];
            for (var i = 1; i < numbers.Count; i++)
            {
                resultNumber = Snailfish.AddSnailfishNumbers(resultNumber, numbers[i]);
                resultNumber.Condense();
            }
            
            Assert.AreEqual("[[[[3,0],[5,3]],[4,4]],[5,5]]", resultNumber.PrintNumbers());
        }
        
        [Test]
        public void SimplePractice3()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\SimplePractice3.txt");
            var numbers = rows.Select(Snailfish.BuildSnailfishNumber).ToList();

            var resultNumber = numbers[0];
            for (var i = 1; i < numbers.Count; i++)
            {
                resultNumber = Snailfish.AddSnailfishNumbers(resultNumber, numbers[i]);
                resultNumber.Condense();
            }
            
            Assert.AreEqual("[[[[5,0],[7,4]],[5,5]],[6,6]]", resultNumber.PrintNumbers());
        }
        
        [Test]
        public void Practice_PrintNumbers()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\Practice.txt");
            var numbers = rows.Select(Snailfish.BuildSnailfishNumber).ToList();

            var resultNumber = numbers[0];
            for (var i = 1; i < numbers.Count; i++)
            {
                resultNumber = Snailfish.AddSnailfishNumbers(resultNumber, numbers[i]);
                resultNumber.Condense();
                
                if(i == 1)
                    Assert.AreEqual("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", resultNumber.PrintNumbers());
            }
        }
        
        [Test]
        public void Practice_PrintNumbers2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\Practice2.txt");
            var numbers = rows.Select(Snailfish.BuildSnailfishNumber).ToList();

            var resultNumber = numbers[0];
            for (var i = 1; i < numbers.Count; i++)
            {
                resultNumber = Snailfish.AddSnailfishNumbers(resultNumber, numbers[i]);
                resultNumber.Condense();

                switch (i)
                {
                    case 1:
                        Assert.AreEqual("[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]", resultNumber.PrintNumbers());
                        break;
                    case 2:
                        Assert.AreEqual("[[[[6,7],[6,7]],[[7,7],[0,7]]],[[[8,7],[7,7]],[[8,8],[8,0]]]]", resultNumber.PrintNumbers());
                        break;
                    case 3:
                        Assert.AreEqual("[[[[7,0],[7,7]],[[7,7],[7,8]]],[[[7,7],[8,8]],[[7,7],[8,7]]]]", resultNumber.PrintNumbers());
                        break;
                }
            }
        }
        
        [Test]
        public void MagnitudePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\MagnitudePractice.txt");
            var rowSplits = rows.Select(x => x.Split('|'));

            foreach (var rowSplit in rowSplits)
            {
                var result = Snailfish.BuildSnailfishNumber(rowSplit[0]); 
                Assert.AreEqual(rowSplit[0], result.PrintNumbers()); //confirm build
                
                var magnitude = result.GetMagnitude(); 
                Assert.AreEqual(int.Parse(rowSplit[1]), magnitude);
            }
        }
        
        [Test]
        public void MagnitudePractice2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\MagnitudePractice2.txt");
            var numbers = rows.Select(Snailfish.BuildSnailfishNumber).ToList();

            var resultNumber = numbers[0];
            for (var i = 1; i < numbers.Count; i++)
            {
                resultNumber = Snailfish.AddSnailfishNumbers(resultNumber, numbers[i]);
                resultNumber.Condense();
            }
            
            Assert.AreEqual(4140, resultNumber.GetMagnitude());
        }
        
        [Test]
        public void Magnitude()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\Actual.txt");
            var numbers = rows.Select(Snailfish.BuildSnailfishNumber).ToList();

            var resultNumber = numbers[0];
            for (var i = 1; i < numbers.Count; i++)
            {
                resultNumber = Snailfish.AddSnailfishNumbers(resultNumber, numbers[i]);
                resultNumber.Condense();
            }
            
            Assert.AreEqual(2541, resultNumber.GetMagnitude());
        }
        
        [Test]
        public void LargestMagnitudePractice2()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\MagnitudePractice2.txt");

            long maxMagnitude = 0;
            for (var i = 0; i < rows.Count; i++)
            {
                for (var j = 0; j < rows.Count; j++)
                {
                    if (i == j) continue;

                    var number1 = Snailfish.BuildSnailfishNumber(rows[i]);
                    var number2 = Snailfish.BuildSnailfishNumber(rows[j]);
                    var resultNumber = Snailfish.AddSnailfishNumbers(number1, number2);
                    resultNumber.Condense();
                    
                    if(i == 8 && j == 0)
                        Assert.AreEqual("[[[[7,8],[6,6]],[[6,0],[7,7]]],[[[7,8],[8,8]],[[7,9],[0,6]]]]", resultNumber.PrintNumbers());
                    
                    var magnitude = resultNumber.GetMagnitude();
                    if (magnitude > maxMagnitude)
                        maxMagnitude = magnitude;
                }
            }
            
            Assert.AreEqual(3993, maxMagnitude);
        }
        
        [Test]
        public void LargestMagnitude()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent18\Actual.txt");
            long maxMagnitude = 0;
            for (var i = 0; i < rows.Count; i++)
            {
                for (var j = 0; j < rows.Count; j++)
                {
                    if (i == j) continue;

                    var number1 = Snailfish.BuildSnailfishNumber(rows[i]);
                    var number2 = Snailfish.BuildSnailfishNumber(rows[j]);
                    var resultNumber = Snailfish.AddSnailfishNumbers(number1, number2);
                    resultNumber.Condense();
                    
                    var magnitude = resultNumber.GetMagnitude();
                    if (magnitude > maxMagnitude)
                        maxMagnitude = magnitude;
                }
            }
            
            Assert.AreNotEqual(4585, maxMagnitude); //due to recursiveness and reference. the row changes everytime you condense. had to rebuild the numbers each time from row
            Assert.AreEqual(4647, maxMagnitude);
        }
    }
}