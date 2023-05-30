// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Tilemaps;
// using Pathfinding;
// namespace GameSystems {
//     public class GridManager
//     {
//         public int NodeCount { get => Xlenght * Ylenght; }
//         Vector3 chunkCenter;
//         Vector3 corner00;
//         Vector3 cornerXY;
//         int Xlenght, Ylenght;
//         Node[,] nodeGrid;
//         float sliceRatio;
//         LayerMask nonWalkableMask;
//         public GridManager()
//         {
//
//         }
//         void SetCenterAndBounds(Tilemap tilemap)
//         {
//             Bounds bounds = tilemap.localBounds;
//             chunkCenter = bounds.center;
//             float Xextent = bounds.extents.x;
//             float Yextent = bounds.extents.y;
//             corner00 = new Vector3(chunkCenter.x - Xextent, chunkCenter.y - Yextent, 0);
//             cornerXY = new Vector3(chunkCenter.x + Xextent, chunkCenter.y + Yextent, 0);
//             Xlenght = Mathf.RoundToInt(2 * Xextent / sliceRatio);
//             Ylenght = Mathf.RoundToInt(2 * Yextent / sliceRatio);
//             nodeGrid = new Node[Xlenght, Ylenght];
//         }
//         public void CreateGrid(Tilemap tilemap)
//         {
//             SetCenterAndBounds(tilemap);
//
//             for (int x = 0; x < Xlenght; x++)
//                 for (int y = 0; y < Ylenght; y++)
//                 {
//                     Vector3 pos = new Vector3(corner00.x + x * sliceRatio, corner00.y + y * sliceRatio);
//                     Collider2D col=Physics2D.OverlapCircle(pos, 0.01f, nonWalkableMask);
//                     bool walkable = col == null;
//                     Node current = new Node(pos, x, y, walkable);
//                     nodeGrid[x, y] = current;
//                     Debug.Log(current.walkable);
//                 }
//         }
//         public Node GetNodeFromPos(Vector3 pos)
//         {
//             int x = Mathf.RoundToInt((pos.x - corner00.x) / sliceRatio);
//             int y = Mathf.RoundToInt((pos.y - corner00.y) / sliceRatio);
//             if (x >= Xlenght || y >= Ylenght||x<0||y<00)
//             {
//                 return null;
//             }
//             return nodeGrid[x, y];
//         }
//         public List<Node> GetNeighbours(Node node)
//         {
//             List<Node> neighbours = new List<Node>();
//             for (int i = -1; i <= 1; i++)
//                 for (int z = -1; z <= 1; z++)
//                 {
//                     if (i == 0 && z == 0)
//                         continue;
//                     int x = node.X + i;
//                     int y = node.Y + z;
//                     if (x < 0 || y < 0 || x >= Xlenght || y >= Ylenght)
//                         continue;
//                     neighbours.Add(nodeGrid[x, y]);
//                 }
//             return neighbours;
//         }
//         private void OnDrawGizmos()
//         {
//             if (nodeGrid != null)
//             {
//                 foreach (var node in nodeGrid)
//                 {
//
//                     if (node.walkable)
//                         Gizmos.color = Color.green;
//                     else
//                         Gizmos.color = Color.red;
//                     Gizmos.DrawSphere(node.position, 0.008f);
//                 }
//             }
//         }
//         //private void OnDrawGizmos()
//         //{
//         //    if (nodeGrid != null)
//         //    {
//         //        foreach (var node in nodeGrid)
//         //        {
//         //            Gizmos.color = Color.white;
//         //            Gizmos.DrawLine(node.position, node.position + Vector3.forward);
//         //        }
//         //    }
//         //}
//     }
// }