using KukaPositionParser.Core;

namespace KukaPositionParser.Test;

public class PositionParserTest:TestsBase
{
    


    private string[] GetFiles()=> Directory.GetFiles(TestDirectory, "*.dat", SearchOption.AllDirectories);

    [Fact]
    public void FindFilesTest()
    {
        var files = GetFiles();

        Assert.True(files.Any());

    }


    [Fact]
    public void TestFilename()
    {
        var file = GetFiles().First();

        var result = PositionParser.FormatFilename(file);

        Assert.True(result.Length>0);
    }

    [Fact]
    public void TestParsePositions()
    {

        var results = PositionParser.ParsePositions(TestDirectory);
        var count = results.Count();
        Assert.NotEqual(0, count);
        Assert.True(results.Any());
    }
}