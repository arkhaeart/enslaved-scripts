using UnityEngine;
using System;

namespace Pathfinding
{
    public partial class PathFinder 
    {
        public struct PathRequest
        {
            public Vector3 start;
            public Vector3 end;
            public Action<Vector3[]> success;
            public IPathCallback fail;

            public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[]> success, IPathCallback fail)
            {
                start = _start;
                end = _end;
                this.success = success;
                this.fail = fail;
            }
        }
    }
}