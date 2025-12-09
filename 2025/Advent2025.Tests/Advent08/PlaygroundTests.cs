using Advent2025.Advent08;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent08;

public class Advent08_PlaygroundTests
{
    private Playground SUT = new();
    
    [Fact]
    public void CircuitSizes_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.CircuitSizes(fileData, 10);
        Assert.That(result, Is.EqualTo(40));
    }
    
    [Fact]
    public void CircuitSizes_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.CircuitSizes(fileData, 1000);
        Assert.That(result, Is.EqualTo(42840));
    }
    
    [Fact]
    public void FinalCircuitDistance_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.FinalCircuitDistance(fileData);
        Assert.That(result, Is.EqualTo(25272));
    }
    
    [Fact]
    public void FinalCircuitDistance_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.FinalCircuitDistance(fileData);
        Assert.That(result, Is.EqualTo(170629052));
    }
}