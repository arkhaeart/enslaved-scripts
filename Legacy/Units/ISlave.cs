using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units.Modules;

public interface ISlave
{
    SlaveModule SModule { get; }
}
public interface IInventoryUser
{
    InventoryModule IModule { get; }
}
// public interface IEqupmentUser
// {
//     EquipmentModule EModule { get; }
// }
