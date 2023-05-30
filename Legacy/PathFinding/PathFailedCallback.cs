using System;

namespace Pathfinding
{
    public partial class PathFinder 
    {
        public class PathFailedCallback : IPathCallback
        {
            Action callback;
            public PathFailedCallback(Action callback)
            {
                this.callback = callback;
            }
            public void Call()
            {
                callback();
            }
        }
    }
}