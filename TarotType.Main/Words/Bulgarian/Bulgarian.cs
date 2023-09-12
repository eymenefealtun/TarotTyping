namespace TarotType.Main.Utilities.Words.Bulgarian
{
    public class Bulgarian : Language
    {

        string _path = @"Words\Bulgarian\Bulgarian.txt";
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
