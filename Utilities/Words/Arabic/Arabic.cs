
namespace Utilities.Words.Turkish
{
    public class Arabic : Language              
    {
        public int _languageIndex = 0;          
        public string _path = @"Words\Arabic\Arabic-5.691.498.txt";
        public string _flowDirection = "right";

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