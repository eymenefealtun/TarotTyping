namespace TarotType.Main.Utilities.Words.Portuguese
{
    public class Portuguese : Language
    {
        string _path = @"Words\Portuguese\Portuguese.txt";
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
