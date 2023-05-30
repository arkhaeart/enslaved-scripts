using UnityEngine;
using System;

namespace Pathfinding
{
    public partial class PathFinder 
    {
        public class PathSuccessCallback : IPathCallback
        {
            public PathSuccessCallback(Action<Vector3[]>callback,Vector3[]waypoints)
            {
                this.callback = callback;
                path = waypoints;
            }
            public void Call()
            {
                callback(path);
            }
            Vector3[] path;
            Action<Vector3[]> callback;
        }
    }
}