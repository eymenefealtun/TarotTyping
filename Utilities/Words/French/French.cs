namespace Utilities.Words.French
{
    public class French : Language
    {
        string _path = @"Words\French\French-336.528.txt";
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
