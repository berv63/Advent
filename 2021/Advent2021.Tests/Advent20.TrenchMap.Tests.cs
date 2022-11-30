using System.Collections.Generic;
using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent20TrenchMapTests
    {
        private void OutputImage(List<string> image)
        {
            var output = image.Select(x => string.Join("", x.Select(y => y == '1' ? '#' : '.')));
            
            FileExtensions.WriteFile(@"..\..\..\Files\Advent20\result.txt", output);
        }
        
        [Test]
        public void EnhancePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent20\Practice.txt");
            var enhancementString = rows[0];
            var enhancementSet = new Dictionary<string, char>();
            for (var i = 0; i < enhancementString.Length; i++)
            {
                enhancementSet.Add(i.ToBinary(9), enhancementString[i] == '.' ? '0' : '1');
            }

            var image = new List<string>();
            for(var i = 2; i < rows.Count; i++)
            {
                image.Add(string.Join("", rows[i].Select(x => x == '.' ? '0' : '1')));
            }

            for (var i = 0; i < 2; i++)
            {
                var isOnePadding = enhancementSet.First().Value == '1' && i%2 == 1;
                image = TrenchMap.Expand(image, isOnePadding);
                image = TrenchMap.Enhance(enhancementSet, image).ToList();
            }
            
            OutputImage(image);

            var count = image.SelectMany(x => x.Select(y => int.Parse(y.ToString()))).Sum();
            Assert.AreEqual(35, count);
        }
        
        [Test]
        public void Enhance()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent20\Actual.txt");
            var enhancementString = rows[0];
            var enhancementSet = new Dictionary<string, char>();
            for (var i = 0; i < enhancementString.Length; i++)
            {
                enhancementSet.Add(i.ToBinary(9), enhancementString[i] == '.' ? '0' : '1');
            }

            var image = new List<string>();
            for(var i = 2; i < rows.Count; i++)
            {
                image.Add(string.Join("", rows[i].Select(x => x == '.' ? '0' : '1')));
            }

            for (var i = 0; i < 2; i++)
            {
                var isOnePadding = enhancementSet.First().Value == '1' && i%2 == 1;
                image = TrenchMap.Expand(image, isOnePadding);
                image = TrenchMap.Enhance(enhancementSet, image).ToList();
                OutputImage(image);
            }

            var count = image.SelectMany(x => x.Select(y => int.Parse(y.ToString()))).Sum();
            Assert.AreNotEqual(5431, count); //forgot to account for all the 0's if the 000000000 = 1 and 11111111 = 0 then they flip after 2 runs.
            Assert.AreEqual(5347, count);
        }
        
        [Test]
        public void EnhanceMorePractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent20\Practice.txt");
            var enhancementString = rows[0];
            var enhancementSet = new Dictionary<string, char>();
            for (var i = 0; i < enhancementString.Length; i++)
            {
                enhancementSet.Add(i.ToBinary(9), enhancementString[i] == '.' ? '0' : '1');
            }

            var image = new List<string>();
            for(var i = 2; i < rows.Count; i++)
            {
                image.Add(string.Join("", rows[i].Select(x => x == '.' ? '0' : '1')));
            }

            for (var i = 0; i < 50; i++)
            {
                var isOnePadding = enhancementSet.First().Value == '1' && i%2 == 1;
                image = TrenchMap.Expand(image, isOnePadding);
                image = TrenchMap.Enhance(enhancementSet, image).ToList();
            }
            
            OutputImage(image);

            var count = image.SelectMany(x => x.Select(y => int.Parse(y.ToString()))).Sum();
            Assert.AreEqual(3351, count);
        }
        
        [Test]
        public void EnhanceMore()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent20\Actual.txt");
            var enhancementString = rows[0];
            var enhancementSet = new Dictionary<string, char>();
            for (var i = 0; i < enhancementString.Length; i++)
            {
                enhancementSet.Add(i.ToBinary(9), enhancementString[i] == '.' ? '0' : '1');
            }

            var image = new List<string>();
            for(var i = 2; i < rows.Count; i++)
            {
                image.Add(string.Join("", rows[i].Select(x => x == '.' ? '0' : '1')));
            }

            for (var i = 0; i < 50; i++)
            {
                var isOnePadding = enhancementSet.First().Value == '1' && i%2 == 1;
                image = TrenchMap.Expand(image, isOnePadding);
                image = TrenchMap.Enhance(enhancementSet, image).ToList();
                OutputImage(image);
            }
            
            var count = image.SelectMany(x => x.Select(y => int.Parse(y.ToString()))).Sum();
            Assert.AreNotEqual(5431, count); //forgot to account for all the 0's if the 000000000 = 1 and 11111111 = 0 then they flip after 2 runs.
            Assert.AreEqual(17172, count);
        }
    }
}