namespace KukaPositionParser.Core;

public class E6Axis : Position
{

    public E6Axis(string fileName,string line) : base(fileName, line) { }
    public double A1 { get; set; }
    public double A2 { get; set; }
    public double A3 { get; set; }
    public double A4 { get; set; }
    public double A5 { get; set; }
    public double A6 { get; set; }

}
