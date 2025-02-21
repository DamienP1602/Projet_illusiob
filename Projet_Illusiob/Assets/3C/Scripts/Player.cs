using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent),typeof(MovementComponent), typeof(StatComponent))]
public class Player : MonoBehaviour
{
    InputComponent inputs = null;
    MovementComponent movement = null;
    StatComponent stats = null;

    [SerializeField] ValueBar staminaBar = null;
    [SerializeField] HealthPanel healthPanel = null;

    void Start()
    {
        Init();
    }

    void Update()
    {

    }

    void Init()
    {
        inputs = GetComponent<InputComponent>();
        movement = GetComponent<MovementComponent>();
        stats = GetComponent<StatComponent>();

        stats.OnLoseHealth += healthPanel.RemoveHeart;
        movement.OnStaminaChanged += staminaBar.UpdateValue;
    }
}
