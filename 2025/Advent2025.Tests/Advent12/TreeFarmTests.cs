using Advent2025.Advent11;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent11;

public class Advent11_ReactorTests
{
    private Reactor SUT = new();
    
    [Fact]
    public void TotalPathsOut_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalPathsOut(fileData);
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Fact]
    public void TotalPathsOut_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalPathsOut(fileData);
        Assert.That(result, Is.EqualTo(764));
    }
    
    [Fact]
    public void TotalPathsOutThroughDacFft_Practice2()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalPathsOutThroughDacFft(fileData);
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Fact]
    public void TotalPathsOutThroughDacFft_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalPathsOutThroughDacFft(fileData);
        Assert.That(result, Is.EqualTo(462444153119850));
    }
}