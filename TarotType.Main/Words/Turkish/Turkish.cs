namespace Utilities.Words.Turkish
{
    public class Turkish : Language
    {
        string _path = @"Words\Turkish\Turkish-60.451.txt";
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