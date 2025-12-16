using Advent2025.Advent12;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent12;

public class Advent12_TreeFarmTests
{
    private TreeFarm SUT = new();
    
    [Fact]
    public void TotalPathsOut_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.ValidPresentConfigurations(fileData);
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Fact]
    public void TotalPathsOut_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.ValidPresentConfigurations(fileData);
        Assert.That(result, Is.EqualTo(2));
    }
}