namespace Utilities.Words.Greek
{
    public class Greek : Language
    {
        string _path = @"Words\Greek\Greek-35.279.txt";
        string _flowDirection = "left";
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
