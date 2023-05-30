using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Pathfinding
{
    public class Path
    {
        Vector3[] waypoints;
        public Path(Vector3[] points)
        {
            waypoints = points;
        }

        public Vector3 this[int i]
        {
            get
            {
               
                    return waypoints[i];
                
            }
        }
        public bool Exists
        {
            get
            {
                if (waypoints.Length > 0)
                    return true;
                else return false;
            }
        }
        public Vector3 Last
        {
            get
            {

                return waypoints.Last();
            }
        }
    }
    [System.Serializable]
    public class Node:IHeap<Node>
    {
        public bool walkable;
        /// <summary>
        /// cost to get there
        /// </summary>
        public float gCost;
        /// <summary>
        /// cost to target
        /// </summary>
        public float hCost;
        public float fCost { get { return gCost + hCost; } }
        int heapIndex;
        public int HeapIndex { get => heapIndex; set => heapIndex=value; }

        public Vector3 position;
        public int X, Y;
        public Node parent;
        public Node(Vector3 pos, int _X, int _Y,bool _walkable)
        {
            position = pos;
            X = _X;
            Y = _Y;
            walkable = _walkable;
        }

        public int CompareTo(Node node)
        {
            int compare = fCost.CompareTo(node.fCost);
            if (compare == 0)
                compare = hCost.CompareTo(node.hCost);
            return -compare;
        }
    }

}
