using Advent2025.Advent06;
using AdventShared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Advent2025.Tests.Advent06;

public class Advent06_TrashTests
{
    private Trash SUT = new();
    
    [Fact]
    public void MathGrandTotal_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.MathGrandTotal(fileData);
        Assert.That(result, Is.EqualTo(4277556));
    }
    
    [Fact]
    public void MathGrandTotal_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.MathGrandTotal(fileData);
        Assert.That(result, Is.Not.EqualTo(51217905673));
        Assert.That(result, Is.EqualTo(6957525317641));
    }
    
    [Fact]
    public void VertMathGrandTotal_Practice()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.VertMathGrandTotal(fileData);
        Assert.That(result, Is.EqualTo(3263827));
    }
    
    [Fact]
    public void VertMathGrandTotal_Actual()
    {
        //Act
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        //Assert
        var result = SUT.VertMathGrandTotal(fileData);
        Assert.That(result, Is.EqualTo(13215665360076));
    }
}