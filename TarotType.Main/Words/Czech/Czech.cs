namespace TarotType.Main.Utilities.Words.Czech
{
    public class Czech : Language
    {

        string _path = @"Words\Czech\Czech.txt";
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
