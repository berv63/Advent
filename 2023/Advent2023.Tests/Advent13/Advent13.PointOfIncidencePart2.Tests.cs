using Advent2023.Advent13;
using AdventShared;

namespace Advent2023.Tests.Advent13;

public class Advent13_PointOfIncidenceTests_Part2
{
    private PointOfIncidence SUT;

    [Fact]
    public void GetSmudgyMirrorSummary_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PointOfIncidence(fileData);
        Assert.Equal(400, SUT.GetSmudgyMirrorSummary());
    }

    [Fact]
    public void GetSmudgyMirrorSummary_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PointOfIncidence(fileData);
        var result = SUT.GetSmudgyMirrorSummary();
        Assert.Equal(37617, result);
    }
}
