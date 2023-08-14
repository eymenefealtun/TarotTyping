
namespace Utilities.Words.Turkish
{
    public class Turkish : Language
    {
        public int _languageIndex = 2;
        public string _path = @"Words\Turkish\Turkish-60.451.txt";
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