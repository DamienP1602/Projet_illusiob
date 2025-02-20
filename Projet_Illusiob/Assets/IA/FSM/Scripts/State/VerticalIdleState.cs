using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalIdleState : State
{
    IA_VerticalMoveComponent move = null;
    public override string StateName => "VerticalMoveState";

    public override void Enter(Brain owner)
    {
        move = owner.GetComponent<IA_VerticalMoveComponent>();
        isEnter = true;
    }

    public override void Exit(Brain owner)
    {
    }

    public override void Update(Brain owner)
    {
        move.Move();
    }
}
