namespace TarotType.Main.Utilities.Words.Swedish
{
    public class Swedish : Language
    {
        string _path = @"Words\Swedish\Swedish.txt";
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