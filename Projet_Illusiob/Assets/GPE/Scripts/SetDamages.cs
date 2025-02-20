using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamages : MonoBehaviour
{

    [SerializeField] Vector3 positionForRespawn = Vector3.zero;
    [SerializeField] bool useDebugs = false;
    [SerializeField] Color colorDebug = Color.white;

    public Vector3 PositionForRespawn => positionForRespawn;


    private void OnDrawGizmos()
    {
        if (!useDebugs)
            return;
        Gizmos.color = colorDebug;
        Gizmos.DrawWireSphere(positionForRespawn, 1f);
    }
}
