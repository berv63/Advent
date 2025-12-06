using Advent2025.Advent04;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent04;

public class Advent04_Printing
{
    private Printing SUT = new();
    
    [Fact]
    public void AvailableRows_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalAvailableRolls(fileData);
        Assert.That(result, Is.EqualTo(13));
    }
    
    [Fact]
    public void AvailableRows_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TotalAvailableRolls(fileData);
        Assert.That(result, Is.EqualTo(1560));
    }
    
    [Fact]
    public void AvailableTotal_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.OngoingAvailableRolls(fileData);
        Assert.That(result, Is.EqualTo(43));
    }
    
    [Fact]
    public void AvailableTotal_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.OngoingAvailableRolls(fileData);
        Assert.That(result, Is.EqualTo(9609));
    }
}