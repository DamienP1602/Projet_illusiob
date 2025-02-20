using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_VerticalMoveComponent : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        float _y = Time.deltaTime * moveSpeed * Mathf.Sin(Time.time);
        Vector3 _newPos = new Vector3(transform.position.x, transform.position.y + _y, transform.position.z);
        transform.position = _newPos;
    }
}
