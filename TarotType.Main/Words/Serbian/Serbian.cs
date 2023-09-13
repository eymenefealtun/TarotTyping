using TarotType.Main.Utilities;
using TarotType.Main.Utilities.Words;

namespace TarotType.Main.Words.Serbian
{
    internal class Serbian : Language
    {
        string _path = @"Words\Serbian\Serbian.txt";
        SourceManager.flowDirections _flowDirection = SourceManager.flowDirections.left;
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
