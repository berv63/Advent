using Advent2025.Advent01;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent01;

public class Advent01_SecretEntranceTests
{
    private SecretEntrance SUT = new();
    
    [Fact]
    public void CountZero_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TimesZero(fileData);
        Assert.That(result, Is.EqualTo(3));
    }
    
    [Fact]
    public void CountZero_Actual1()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.TimesZero(fileData);
        Assert.That(result, Is.EqualTo(1139));
    }
    
    [Fact]
    public void ClicksZero_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.ClicksZero(fileData);
        Assert.That(result, Is.EqualTo(6));
    }
    
    [Fact]
    public void ClicksZero_Actual1()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.ClicksZero(fileData);
        Assert.That(result, Is.GreaterThan(6416));
        Assert.That(result, Is.EqualTo(6684));
    }
}