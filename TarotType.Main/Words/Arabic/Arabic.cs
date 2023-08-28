namespace TarotType.Main.Utilities.Words.Arabic
{
    public class Arabic : Language
    {
        string _path = @"Words\Arabic\Arabic-5.691.498.txt";
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