using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    IA_MovementComponent mov = null;
    IA_SightComponent sight = null;

    bool changeState = false;

    public override string StateName => "ChaseState";

    public override void Enter(Brain owner)
    {
        mov = owner.GetComponent<IA_MovementComponent>();
        sight = owner.GetComponent<IA_SightComponent>();
        sight.OnTargetLost += LostPlayer;


        transitions.Add(new Transition(CanChangeState, new IdleState()));
        isEnter = true;
    }

    public override void Exit(Brain owner)
    {
        if (sight)
            sight.OnTargetLost -= LostPlayer;
    }

    public override void Update(Brain owner)
    {
        mov.MoveTo();
    }

    void LostPlayer()
    {
        changeState = true;
    }

    bool CanChangeState() => changeState;
}
