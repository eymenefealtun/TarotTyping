namespace Utilities.Words.Turkish
{
    public class Armenian : Language
    {
        string _path = @"Words\Armenian\Armenian-981.txt";
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