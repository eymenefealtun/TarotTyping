namespace TarotType.Main.Utilities.Words.Hebrew
{
    public class Hebrew : Language
    {
        string _path = @"Words\Hebrew\Hebrew";
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