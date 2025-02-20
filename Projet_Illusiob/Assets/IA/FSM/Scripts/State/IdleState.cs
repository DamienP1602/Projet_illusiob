using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    IA_SightComponent sight = null;
    bool changeState = false;

    public override string StateName => "IdleState";

    public override void Enter(Brain owner)
    {
        sight = owner.GetComponent<IA_SightComponent>();
        transitions.Add(new Transition(CanChangeState, new ChaseState()));
        sight.OnTargetDetected += PlayerIsInSight;
        isEnter = true;
    }

    public override void Exit(Brain owner)
    {
        if (sight)
            sight.OnTargetDetected -= PlayerIsInSight;
    }

    public override void Update(Brain owner)
    {
        
    }

    void PlayerIsInSight(GameObject _target)
    {
        changeState = true;
    }

    bool CanChangeState() => changeState;
}
