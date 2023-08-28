namespace Utilities.Words.Turkish
{
    public class English : Language
    {
        string _path = @"Words\English\English-300.000.txt";
        SourceManager.flowDirections _flowDirection = SourceManager.flowDirections.left;
        public override SourceManager.flowDirections FlowDirection()
        {
            return _flowDirection;
        }

        public override string Path()
        {
            return _path;
        }
    }
}