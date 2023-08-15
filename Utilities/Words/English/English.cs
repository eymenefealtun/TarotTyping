namespace Utilities.Words.Turkish
{
    public class English : Language
    {
        string _path = @"Words\English\English-300.000.txt";
        string _flowDirection = "left";
        public override string FlowDirection()
        {
            return _flowDirection;
        }

        public override string Path()
        {
            return _path;
        }
    }
}