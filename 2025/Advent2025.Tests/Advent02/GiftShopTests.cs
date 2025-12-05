using Advent2025.Advent01;
using Advent2025.Advent02;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent02;

public class Advent02_GiftShopTests
{
    private GiftShop SUT = new();
    
    [Fact]
    public void SumInvalid_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.SumInvalid(fileData);
        Assert.That(result, Is.EqualTo(1227775554));
    }
    
    [Fact]
    public void SumInvalid_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.SumInvalid(fileData);
        Assert.That(result, Is.EqualTo(30608905813));
    }
    
    [Fact]
    public void SumRepeatingInvalid_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.SumRepeatingInvalid(fileData);
        Assert.That(result, Is.EqualTo(4174379265));
    }
    
    [Fact]
    public void SumRepeatingInvalid_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.SumRepeatingInvalid(fileData);
        Assert.That(result, Is.EqualTo(31898925685));
    }
}