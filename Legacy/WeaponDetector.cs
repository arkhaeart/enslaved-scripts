using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Units.Modules
{
    public class WeaponDetector : MonoBehaviour
    {
        private Mesh mesh;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Unit unit = collision.transform.GetComponent<Unit>();
            if(unit!=null)
            {
                Debug.Log("Weapon landed a hit");
            }
        }
    }
    
}