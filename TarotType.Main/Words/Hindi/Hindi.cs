using TarotType.Main.Utilities;
using TarotType.Main.Utilities.Words;

namespace TarotType.Main.Words.Hindi
{
    public class Hindi : Language
    {
        SourceManager.flowDirections _flowDirection = SourceManager.flowDirections.left;
        string _path = @"Words\Hindi\Hindi.txt";
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
