namespace Utilities.Words.Greek
{
    public class Greek : Language
    {
        string _path = @"Words\Greek\Greek-35.279.txt";
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
