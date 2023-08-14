
namespace Utilities.Words.Turkish
{
    public class English : Language
    {
        public int _languageIndex = 1;
        public string _path = @"Words\English\English-300.000.txt";
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