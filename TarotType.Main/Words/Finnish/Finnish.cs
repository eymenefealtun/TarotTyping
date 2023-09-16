namespace TarotType.Main.Utilities.Words.Finnish
{
    public class Finnish : Language
    {
        string _path = @"Words\Finnish\Finnish.txt";
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