using System.Text.RegularExpressions;

namespace KukaPositionParser.Core;
 
public class PositionParser
{
    public static IEnumerable<Position> ParsePositions(string path)
    {
        // Find out if path is a file or a directory
        var fileInfo = new FileInfo(path);

        var isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory);

        return isDirectory
                        ?ParseDirectory(path)
                        :ParseFile(path);
    }
    private const string E6PATTERN = "(DECL)?\\s+(E6(?:POS|AXIS))\\s+(\\D[^\\s=]+)\\s*=\\s*\\{([^\\}]+)\\}";
    private static IEnumerable<Position> ParseFile(string file)
    {
        // Get Name for File
        var filename = Path.GetFileNameWithoutExtension(Path.GetFileName(file));

        // Get Positional Lines
        var lines = File.ReadAllLines(file)
                        .Where(IsValidLine)
                        .Select(line => CreatePosition(filename, line));

        return lines;


    }

    private static Position CreatePosition(string filename, string line)
        
    {
       

        var matches = Regex.Matches(line, E6PATTERN,RegexOptions.IgnoreCase)
            .First<Match>();
        var result = new E6POS(filename, line,matches);

        return result;
    }

    private static bool IsValidLine(string line)
    {

        // Find out if is E6POS line
        var isE6AXIS = Regex.IsMatch(line, E6PATTERN,RegexOptions.IgnoreCase);

        return isE6AXIS;
    }

    private static IEnumerable<Position> ParseDirectory(string path)
    {
        var files = Directory.EnumerateFiles(path, "*.dat", SearchOption.AllDirectories);

        var results = files.SelectMany(ParseFile);

        return results;
    }

    public static string FormatFilename(string filename)
    {
        // Get Name for File
        var result = Path.GetFileNameWithoutExtension(Path.GetFileName(filename));

        return result;
    }
}