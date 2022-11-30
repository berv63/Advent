using System.Linq;
using AdventShared;
using NUnit.Framework;

namespace Advent2021.Tests
{
    [TestFixture]
    public class Advent13TransparentOrigamiTests
    {
        [Test]
        public void OrigamiDotsPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent13\Practice.txt");

            var dots = rows.Where(x => x.Contains(",")).Select(x => x.Split(',').ToList()).ToList();
            var folds = rows.Where(x => x.Contains("=")).Select(x => x.Split(' ')[2].Split('=').ToList()).ToList();
            
            var paper = TransparentOrigami.CreateTransparentPaper(dots, folds);

            var dotCount = TransparentOrigami.FoldDotsCount(paper, folds);
            Assert.AreEqual(17, dotCount);
        }
        
        [Test]
        public void OrigamiDots()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent13\Actual.txt");

            var dots = rows.Where(x => x.Contains(",")).Select(x => x.Split(',').ToList()).ToList();
            var folds = rows.Where(x => x.Contains("=")).Select(x => x.Split(' ')[2].Split('=').ToList()).ToList();
            
            var paper = TransparentOrigami.CreateTransparentPaper(dots, folds);

            var dotCount = TransparentOrigami.FoldDotsCount(paper, folds);
            Assert.AreNotEqual(594, dotCount); //too high
            Assert.AreNotEqual(722, dotCount); //too high, i/j flipped on fold left
            Assert.AreEqual(592, dotCount);
        }
        
        [Test]
        public void OrigamiFinishPractice()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent13\Practice.txt");

            var dots = rows.Where(x => x.Contains(",")).Select(x => x.Split(',').ToList()).ToList();
            var folds = rows.Where(x => x.Contains("=")).Select(x => x.Split(' ')[2].Split('=').ToList()).ToList();

            var paper = TransparentOrigami.CreateTransparentPaper(dots, folds);
            
            var dotCount = TransparentOrigami.FoldDotsFinish(paper, folds);
            Assert.AreEqual(16, dotCount);
        }
        
        [Test]
        public void OrigamiFinish()
        {
            var rows = FileExtensions.ReadFile(@"..\..\..\Files\Advent13\Actual.txt");

            var dots = rows.Where(x => x.Contains(",")).Select(x => x.Split(',').ToList()).ToList();
            var folds = rows.Where(x => x.Contains("=")).Select(x => x.Split(' ')[2].Split('=').ToList()).ToList();
            
            var paper = TransparentOrigami.CreateTransparentPaper(dots, folds);

            var dotCount = TransparentOrigami.FoldDotsFinish(paper, folds);
            Assert.AreEqual(94, dotCount);
        }
    }
}