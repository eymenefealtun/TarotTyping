namespace TarotType.Main.Utilities.Words.Greek
{
    public class Georgian : Language
    {
        string _path = @"Words\Georgian\Georgian.txt";
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
