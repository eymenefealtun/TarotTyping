namespace Utilities.Words.Spanish
{
    public class Spanish : Language     
    {
        public int _languageIndex = 4;
        public string _path = @"Words\Spanish\Spanish-636.598.txt";
        public string _flowDirection = "left";

        public override string FlowDirection()
        {
            return _flowDirection;              
        }

        public override string Path()
        {
            return _path;
        }
        public override int Index()
        {
            return _languageIndex;
        }
    }
}