namespace Utilities.Words.Turkish
{
    public class Turkish : Language
    {
        string _path = @"Words\Turkish\Turkish-60.451.txt";
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