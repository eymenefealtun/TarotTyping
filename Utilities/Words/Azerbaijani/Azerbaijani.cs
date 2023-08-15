namespace Utilities.Words.Azerbaijani
{
    public class Azerbaijani : Language
    {
        string _flowDirection = "left";
        string _path = @"Words\Azerbaijani\Azerbaijani-38.503.txt";

        public override string FlowDirection()
        {
            return _flowDirection;
        }
        public override string Path()
        {
            return _path;
        }
    }
}
