using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamages : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] LayerMask layerToSetDamages;
    [SerializeField] Vector3 positionForRespawn = Vector3.zero;
    [SerializeField] bool useDebugs = false;
    [SerializeField] Color colorDebug = Color.white;

    private void OnCollisionEnter(Collision collision)
    {
        //TODO En attente de romanito
        //if (collision.gameObject.layer == layerToSetDamages)
            
    }

    private void OnDrawGizmos()
    {
        if (!useDebugs)
            return;
        Gizmos.color = colorDebug;
        Gizmos.DrawWireSphere(positionForRespawn, 1f);
    }
}
