
namespace Utilities.Words.Kurdish
{
    public class Kurdish : Language
    {
        public int _languageIndex = 3;
        public string _path = @"Words\Kurdish\Kurdish-959.txt";
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
