namespace Utilities.Words.Turkish
{
    public class Armenian : Language
    {
        string _path = @"Words\Armenian\Armenian-981.txt";
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