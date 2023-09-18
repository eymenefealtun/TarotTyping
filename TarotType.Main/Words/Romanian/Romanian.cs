namespace TarotType.Main.Utilities.Words.Romanian
{
    public class Romanian : Language
    {

        string _path = @"Words\Romanian\Romanian.txt";
        
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
