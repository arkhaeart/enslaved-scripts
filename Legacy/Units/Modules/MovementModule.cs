using System.Collections;
using UnityEngine;
using Pathfinding;
namespace Units.Modules
{
    public class MovementModule : BehaviourModule
    {
        public ModifiableParameter speed;
        protected Rigidbody2D rgbd;
        protected IPathFinder pathFinder;
        MyCour<Vector3> proceeding;
        MyCour<Vector3[]> followingPath;
        public MovementModule(Agent mono, Rigidbody2D rgbd,IPathFinder pathFinder) : base(mono)
        {
            this.pathFinder = pathFinder;
            this.rgbd = rgbd;
            proceeding = new MyCour<Vector3>(base.mono, new System.Func<Vector3, IEnumerator>(ProceedingToPoint));
            followingPath = new MyCour<Vector3[]>(base.mono, new System.Func<Vector3[], IEnumerator>(FollowingPath));
            speed = new ModifiableParameter(10);
        }
        public void CheckCurrentPath()
        {
            if (followingPath.IsActive)
                followingPath.Stop();
        }
        public bool Moving
        {
            get => followingPath.IsActive;
        }
        public void Move(Vector2 direction)
        {
            if (!CheckWalkable(direction))
            {
                Debug.Log("Non-walkable, aborting movement");
                followingPath.Stop();
                proceeding.Stop();
                return;

            }
            Vector3 newPos = Vector3.MoveTowards(transform.position, (Vector2)transform.position + direction, 0.0032f * speed.Get);
            
            rgbd.MovePosition(newPos);
        }
        bool CheckWalkable(Vector3 dir)
        {
            if (Physics2D.Raycast(transform.position, dir, 0.1f, LayerMask.GetMask("Solid")))
                return false;

            return true;
        }
        public void RequestPath(Vector3 target)
        {
            pathFinder.RequestPath(
                new PathFinder.PathRequest(transform.position, target,
                new System.Action<Vector3[]>(PathFound),
                new PathFinder.PathFailedCallback(new System.Action(PathFailed))));
        }


        protected void PathFound(Vector3[] path)
        {
            followingPath.Run(path);
        }
        protected IEnumerator FollowingPath(Vector3[] path)
        {
            Debug.Log("Following path started");
            int currentWayPoint = 0;
            while (currentWayPoint + 1 < path.Length)
            {
                if (proceeding.IsActive)
                {
                    Debug.Log(proceeding.IsActive);
                    yield return null;
                    continue;
                }
                currentWayPoint++;
                ProceedToPoint(path[currentWayPoint]);
                yield return null;
            }
            Debug.Log($"{mono.name} arrived!");
        }
        protected virtual void PathFailed()
        {
            Debug.Log($"{mono.name} failed to find path");
            proceeding.Stop();
            followingPath.Stop();
        }
        protected void ProceedToPoint(Vector3 pos)
        {
            proceeding.Run(pos);
        }
        protected IEnumerator ProceedingToPoint(Vector3 pos)
        {
            float e = 0.005f;
            while (Vector3.Distance(transform.position, pos) > e)
            {

                Move(pos - transform.position);
                yield return null;
            }
            Debug.Log(proceeding.IsActive);
            //yield return null;
            //proceeding.Stop();
        }


    }
}