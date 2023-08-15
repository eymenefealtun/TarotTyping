namespace Utilities.Words.Turkish
{
    public class Turkish : Language
    {
        public string _path = @"Words\Turkish\Turkish-60.451.txt";
        public string _flowDirection = "left";

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