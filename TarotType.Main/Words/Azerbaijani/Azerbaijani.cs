namespace Utilities.Words.Azerbaijani
{
    public class Azerbaijani : Language
    {
        
        string _path = @"Words\Azerbaijani\Azerbaijani-38.503.txt";
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
