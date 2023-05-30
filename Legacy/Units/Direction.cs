using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Direction 
{
    public int degree=0;
    public int xScale=1;
    public static Direction Get(Vector2 dir)
    {
        if (dir.x >= Mathf.Abs(dir.y))
        {
            return new EastDirection();
        }
        else if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
        {
            return new WestDirection();
        }
        else if (dir.y > 0)
            return new NorthDirection();
        else return new SouthDirection();
        
    }
}
public class SouthDirection:Direction
{
    public SouthDirection()
    {
        degree = 90;
    }
}
public class NorthDirection:Direction
{
    public NorthDirection()
    {
        degree = -90;
    }
}
public class EastDirection : Direction
{
    public EastDirection()
    {
        
    }
}
public class WestDirection : Direction
{
    public WestDirection()
    {
        degree = 0;
        xScale = -1;
    }
}