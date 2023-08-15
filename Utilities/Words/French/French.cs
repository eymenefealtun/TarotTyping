namespace Utilities.Words.French
{
    public class French : Language      
    {
        public string _path = @"Words\French\French-336.528.txt";           
        public string _flowDirection = "left";
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
