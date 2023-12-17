using Advent2023.Advent13;
using AdventShared;

namespace Advent2023.Tests.Advent13;

public class Advent13_PointOfIncidenceTests_Part1
{
    private PointOfIncidence SUT;

    [Fact]
    public void GetMirrorSummary_Practice()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PointOfIncidence(fileData);
        Assert.Equal(405, SUT.GetMirrorSummary());
    }

    [Fact]
    public void GetMirrorSummary_Actual()
    {
        var fileData = FileExtensions.ReadFile($@"..\..\..\..\{FileExtensions.GetFileLocation(this.GetType().Name[..8])}");

        SUT = new PointOfIncidence(fileData);
        var result = SUT.GetMirrorSummary();
        Assert.Equal(31956, result);
    }
}
