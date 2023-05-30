//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class MyTuple: System.Tuple<int,int>
//{
//    public MyTuple(int item1, int item2) : base(item1, item2)
//    {
        
//    }

//    public override bool Equals(object obj)
//    {
//        return this == obj as MyTuple;
//    }

//    public override int GetHashCode()
//    {
//        return base.GetHashCode();
//    }

//    public static bool operator ==(MyTuple left, MyTuple right)
//    {
//        if (left.Item1 == right.Item1 && left.Item1 == right.Item2)
//            return true;
//        else return false;
//    }
//    public static bool operator !=(MyTuple left, MyTuple right)
//    {
//        if (left == right)
//            return true;
//        else return false;
//    }
//}
