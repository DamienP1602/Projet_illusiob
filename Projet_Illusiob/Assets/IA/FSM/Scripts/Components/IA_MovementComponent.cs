using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_MovementComponent : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] GameObject target = null;

    public bool IsAtDestination => Vector3.Distance(target.transform.position, transform.position) < 1.0f;
    public Vector3 Destination => target.transform.position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTo()
    {
        if (IsAtDestination) return;
        Vector3 _newDestination = new Vector3(Destination.x, transform.position.y, 0.0f);
        Debug.Log(_newDestination);
        transform.position = Vector3.MoveTowards(transform.position, _newDestination, moveSpeed * Time.deltaTime);
    }

    public void SetTarget(GameObject _target) => target = _target;
}
