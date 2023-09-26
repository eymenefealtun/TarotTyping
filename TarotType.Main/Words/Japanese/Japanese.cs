namespace TarotType.Main.Utilities.Words.Japanese
{
    public class Japanese : Language
    {
        string _path = @"Words\Japanese\Japanese.txt";
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
