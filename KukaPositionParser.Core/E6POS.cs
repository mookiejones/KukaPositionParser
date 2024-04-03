using System.Text.RegularExpressions;

namespace KukaPositionParser.Core;

public class E6POS:Position
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public E6POS(string fileName,string line,Match match):base(fileName,line)
    {

        var groups = match.Groups.OfType<Group>().ToArray();

        Name = groups[3].Value;

        // Now parse the value
        var text     = groups[4].Value;

        // Split the groups by ,
        var split = Regex.Split(text, ",");




        var items = split.ToDictionary(line=>line.Split(' ')[0], line => double.Parse(line.Split(' ')[1]));

        foreach(var item in items)
        {
            var prop = GetType().GetProperty(item.Key);

            prop?.SetValue(this,item.Value);
        }

         
    }
}
