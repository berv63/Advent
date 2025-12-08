using Advent2025.Advent07;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent07;

public class Advent07_LaboratoriesTests
{
    private Laboratories SUT = new();
    
    [Fact]
    public void TachyonSplitCount_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TachyonSplitCount(fileData);
        Assert.That(result, Is.EqualTo(21));
    }
    
    [Fact]
    public void TachyonSplitCount_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TachyonSplitCount(fileData);
        Assert.That(result, Is.GreaterThan(1119)); //didnt retain unsplit lines
        Assert.That(result, Is.LessThan(1727)); //didnt distinct the combination of split and unsplit lines
        Assert.That(result, Is.EqualTo(1651));
    }
    
    [Fact]
    public void TachyonTimelineCount_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TachyonTimelineCount(fileData);
        Assert.That(result, Is.EqualTo(40));
    }
    
    [Fact]
    public void TachyonTimelineCount_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TachyonTimelineCount(fileData);
        Assert.That(result, Is.EqualTo(108924003331749));
    }
}