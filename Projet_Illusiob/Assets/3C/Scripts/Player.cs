using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent),typeof(MovementComponent))]
public class Player : MonoBehaviour
{
    InputComponent inputs = null;
    MovementComponent movement = null;

    void Start()
    {
        inputs = GetComponent<InputComponent>();
        movement = GetComponent<MovementComponent>();
    }

    void Update()
    {

    }
}
