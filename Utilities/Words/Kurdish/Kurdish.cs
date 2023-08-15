﻿namespace Utilities.Words.Kurdish
{
    public class Kurdish : Language
    {
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
    }
}
