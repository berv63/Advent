using Advent2025.Advent03;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent03;

public class Advent03_LobbyTests
{
    private Lobby SUT = new();
    
    [Fact]
    public void SumJoltage_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalSumJoltage(fileData);
        Assert.That(result, Is.EqualTo(357));
    }
    
    [Fact]
    public void SumJoltage_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalSumJoltage(fileData);
        Assert.That(result, Is.EqualTo(17158));
    }
    
    [Fact]
    public void SumNewJoltage_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalSumNewJoltage(fileData);
        Assert.That(result, Is.EqualTo(3121910778619));
    }
    
    [Fact]
    public void SumNewJoltage_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalSumNewJoltage(fileData);
        Assert.That(result, Is.EqualTo(170449335646486));
    }
}