using Advent2025.Advent05;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent05;

public class Advent05_CafeteriaTests
{
    private Cafeteria SUT = new();
    
    [Fact]
    public void FreshItemCount_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.GetFreshItemCount(fileData);
        Assert.That(result, Is.EqualTo(3));
    }
    
    [Fact]
    public void FreshItemCount_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.GetFreshItemCount(fileData);
        Assert.That(result, Is.EqualTo(505));
    }
    
    [Fact]
    public void FreshItemIdCount_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.GetFreshItemIdCount(fileData);
        Assert.That(result, Is.EqualTo(14));
    }
    
    [Fact]
    public void FreshItemIdCount_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.GetFreshItemIdCount(fileData);
        Assert.That(result, Is.LessThan(367041619727250));
        Assert.That(result, Is.EqualTo(344423158480189));
    }
}