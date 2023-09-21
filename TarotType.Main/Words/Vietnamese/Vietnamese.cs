using TarotType.Main.Utilities;
using TarotType.Main.Utilities.Words;

namespace TarotType.Main.Words.Vietnamese
{
    internal class Vietnamese : Language
    {
        string _path = @"Words\Vietnamese\Vietnamese.txt";

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
