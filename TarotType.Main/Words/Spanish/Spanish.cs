namespace TarotType.Main.Utilities.Words.Spanish
{
    public class Spanish : Language
    {
        string _path = @"Words\Spanish\Spanish.txt";
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