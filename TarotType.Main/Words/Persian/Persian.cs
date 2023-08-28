namespace Utilities.Words.Persian
{
    public class Persian : Language
    {
        string _path = @"Words\Persian\Persian-900.357.txt";
        SourceManager.flowDirections _flowDirection = SourceManager.flowDirections.right;
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
