using Advent2025.Advent09;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent09;

public class Advent09_MovieTheaterTests
{
    private MovieTheater SUT = new();
    
    [Fact]
    public void LargestRectangleArea_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.LargestRectangleArea(fileData);
        Assert.That(result, Is.EqualTo(50));
    }
    
    [Fact]
    public void LargestRectangleArea_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.LargestRectangleArea(fileData);
        Assert.That(result, Is.GreaterThan(2147366520)); //cast as long
        Assert.That(result, Is.EqualTo(4759930955));
    }
    
    [Fact]
    public void LargestEnclosedRectangleArea_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.LargestEnclosedRectangleArea(fileData);
        Assert.That(result, Is.EqualTo(24));
    }
    
    [Fact]
    public void LargestEnclosedRectangleArea_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.LargestEnclosedRectangleArea(fileData);
        Assert.That(result, Is.EqualTo(1525241870));
    }
}