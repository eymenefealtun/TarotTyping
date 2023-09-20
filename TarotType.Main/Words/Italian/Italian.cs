namespace TarotType.Main.Utilities.Words.Italian
{
    public class Italian : Language
    {
        string _path = @"Words\Italian\Italian.txt";
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
