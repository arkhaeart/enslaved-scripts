using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class TypeStringDropDownAttribute:PropertyAttribute
{
    public string namespaceName;
}
