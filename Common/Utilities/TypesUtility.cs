using System;
using UnityEngine;

namespace Common.Utilities
{
    public static class TypesUtility
    {
        public static T Create<T>(string typeName) where T:class
        {
            try
            {
                Type type = Type.GetType(typeName);
                var obj = Activator.CreateInstance(type);
                return  obj as T;
            }
            catch (Exception e)
            {
                Debug.LogError($"Could not create type from string {typeName}. Exception:{e}");
                return default;
            }
        }
        
    }
}