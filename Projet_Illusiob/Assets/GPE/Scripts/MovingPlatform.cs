using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] CurveType curveType = CurveType.Sine;
    [SerializeField] EaseType easeType = EaseType.EaseIn;

    [SerializeField] bool useDebugs = false;
    [SerializeField] bool canMove = true;

    [SerializeField] float duration = 5f;
    [SerializeField] float easedT = 0f;

    Vector3 startPos = Vector3.zero;
    [SerializeField] Vector3 finalPos = Vector3.zero;

    [SerializeField] float timer = 0f;

   


    void Start()
    {
        startPos = transform.position; 
    }


    void Update()
    {
        IncreaseTimer();
        Move();
    }

    private void IncreaseTimer()
    {
        timer += Time.deltaTime;
    }

    void Move()
    {
        if (!canMove) return;

        float _t = timer / duration;
        _t = Mathf.Clamp01(_t);

        easedT = CurveManager.ApplyCurve(curveType, easeType, _t);
        easedT = Mathf.Max(0, easedT);

        transform.position = Vector3.Lerp(startPos, finalPos, easedT);

        if (_t >= 1f || easedT >= 0.999f)
        {
            easedT = 1f;
            timer = 0f;
            Vector3 _temp = startPos;
            startPos = finalPos;
            finalPos = _temp;
        }

    }

    private void OnDrawGizmos()
    {
        if (!useDebugs) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(startPos, 1f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(finalPos, 1f);
    }
}
