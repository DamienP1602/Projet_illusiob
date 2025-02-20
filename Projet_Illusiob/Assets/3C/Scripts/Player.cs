using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent),typeof(MovementComponent), typeof(StatComponent))]
public class Player : MonoBehaviour
{
    InputComponent inputs = null;
    MovementComponent movement = null;
    StatComponent stats = null;
    void Start()
    {
        inputs = GetComponent<InputComponent>();
        movement = GetComponent<MovementComponent>();
        stats = GetComponent<StatComponent>();
    }

    void Update()
    {

    }
}
