using TarotType.Main.Utilities;
using TarotType.Main.Utilities.Words;

namespace TarotType.Main.Words.Urdu
{
    public class Urdu : Language
    {
        SourceManager.flowDirections _flowDirection = SourceManager.flowDirections.right;
        string _path = @"Words\Urdu\Urdu.txt";
        public override SourceManager.flowDirections FlowDirection()
        {
            return _flowDirection;
        }

        public override string Path()
        {
            return _path;
        }
    }
}
