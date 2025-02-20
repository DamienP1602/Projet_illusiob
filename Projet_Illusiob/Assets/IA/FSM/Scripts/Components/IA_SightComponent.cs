using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_SightComponent : MonoBehaviour
{
    public Action<GameObject> OnTargetDetected = null;
    public Action OnTargetLost = null;

    [SerializeField] int sightRange = 10;
    [SerializeField, Range(1,90)] int sightAngle = 30;

    [SerializeField] LayerMask playerLayer = 0;
    [SerializeField] LayerMask obstacleLayer = 0;

    public Vector3 SightOrigin => transform.position + transform.up;

    GameObject target = null;


    private void Update()
    {
        Detect();   
    }

    public void Detect()
    {
        bool _hasDetectedPlayer = false;
        for (int _i = -sightAngle; _i < sightAngle; _i++)
        {
            Vector3 _sightLine = Quaternion.AngleAxis(_i,transform.forward) * transform.right;

            bool _raycastPlayer = Physics.Raycast(SightOrigin, _sightLine, out RaycastHit _hitPlayer, sightRange, playerLayer);
            bool _raycastObstacle = Physics.Raycast(SightOrigin, _sightLine, out RaycastHit _hitObstacle, sightRange, obstacleLayer);

            if (_raycastObstacle && _raycastPlayer)
            {
                if (_hitPlayer.distance > _hitObstacle.distance)
                    _raycastPlayer = false;
                else
                    _raycastObstacle = false;
            }
            if (_raycastPlayer)
            {
                OnTargetDetected?.Invoke(_hitPlayer.collider.gameObject);
                target = _hitPlayer.collider.gameObject;
                _hasDetectedPlayer = true;
                Debug.DrawRay(SightOrigin,_sightLine * (_hitPlayer.distance), Color.red,0.1f);//
            }
            else if (_raycastObstacle)
            {
                Debug.DrawRay(SightOrigin, _sightLine * (_hitObstacle.distance), Color.blue, 0.1f);
            }
            else
                Debug.DrawRay(SightOrigin, _sightLine* sightRange, Color.green, 0.1f);
        }
        if (!_hasDetectedPlayer && target)
        {
            target = null;
            OnTargetLost?.Invoke();
        }    
    }
}
