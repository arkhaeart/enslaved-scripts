using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Items;

public static class ItemsExtensionMethods
{
    public static T FindByName<T>(this List<T> list,string name) where T:Item
    {
        T item=list.Find((n) => n.name == name);
        return item;
    }
    public static Vector3 RandomPointNearby(this Vector3 pos, float radius)
    {
        int degree = Random.Range(0, 360);
        Quaternion quat=Quaternion.AngleAxis(degree, Vector3.forward);
        Vector3 newPos = quat * pos;
        return Vector3.Lerp(pos, newPos, radius);
    }
}
