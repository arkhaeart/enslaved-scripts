#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using UnityEditor;

public static class NamespaceClassesUtility 
{
    
    public static Type[] GetTypes(string assemblyName,string namespaceName)
    {


        var assembly = GetAssemblyFromAsmdef(assemblyName);
        var types= assembly.GetTypes()
            .Where(t => string.Equals(t.Namespace, namespaceName, StringComparison.Ordinal))
            .ToArray();

        return types;
          
    }
    public static Type[] GetTypesByInterface<T>()
    {


        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // Loop through each assembly and get all types that implement IMyInterface
        var types = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => typeof(T).IsAssignableFrom(t)).ToArray();

        return types;
          
    }
    public static string[] GetTypesStringByInterface<T>()
    {


        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // Loop through each assembly and get all types that implement IMyInterface
        var types = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => typeof(T).IsAssignableFrom(t)).Select(t=>t.AssemblyQualifiedName).ToArray();

        return types;
          
    }
    public static Type[] GetTypesWithAttribute<T>()where T:Attribute
    {


        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // Loop through each assembly and get all types that implement IMyInterface
        var types = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => t.GetCustomAttribute<T>() != null).ToArray();

        return types;
          
    }
    public static List<string> GetTypeNamesWithAttribute<T>()where T:Attribute
    {


        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // Loop through each assembly and get all types that implement IMyInterface
        var types = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => t.GetCustomAttribute<T>() != null).Select(a=>a.AssemblyQualifiedName).ToList();

        return types;
          
    }
    public static Assembly GetAssemblyFromAsmdef(string asmdefPath)
    {
        // Load the contents of the .asmdef file into a string
        string asmdefText = AssetDatabase.LoadAssetAtPath<TextAsset>(asmdefPath).text;

        // Parse the JSON data in the .asmdef file to get the name of the assembly
        var asmdefJson = JsonUtility.FromJson<AsmdefJson>(asmdefText);
        string assemblyName = asmdefJson.name;

        // Load the assembly using System.Reflection.Assembly
        Assembly assembly = Assembly.Load(assemblyName);

        return assembly;
    }

    [Serializable]
    private class AsmdefJson
    {
        public string name;
    }
    

}

#endif