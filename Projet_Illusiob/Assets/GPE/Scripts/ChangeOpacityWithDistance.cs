using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ChangeOpacityWithDistance : MonoBehaviour
{

    [SerializeField] Transform player = null;
    [SerializeField] float maxDistance = 2f;
    [SerializeField] float minDistance = 1f;
    [SerializeField] Renderer renderer;
    [SerializeField] Material material;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    void Update()
    {
        float _distance = Vector3.Distance(player.position, transform.position);
        //Debug.Log(_distance);
        float _opacity = Mathf.InverseLerp(minDistance, maxDistance, _distance);


        Color _color = material.color;
        _color.a = _opacity;
        material.color = _color;
    }
}
