namespace Utilities.Words.Persian
{
    public class Persian : Language
    {
        string _path = @"Words\Persian\Persian-900.357.txt";
        string _flowDirection = "right";
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
