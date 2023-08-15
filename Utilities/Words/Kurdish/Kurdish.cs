namespace Utilities.Words.Kurdish
{
    public class Kurdish : Language
    {
        string _path = @"Words\Kurdish\Kurdish-959.txt";
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
