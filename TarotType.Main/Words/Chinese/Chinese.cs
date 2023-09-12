namespace TarotType.Main.Utilities.Words.Chinese
{
    public class Chinese : Language
    {

        string _path = @"Words\Chinese\Chinese.txt";
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
