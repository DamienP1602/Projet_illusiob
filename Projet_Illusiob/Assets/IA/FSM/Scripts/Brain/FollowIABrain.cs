using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIABrain : Brain
{
    protected override State StartingState => new IdleState();
    [SerializeField] IA_MovementComponent movement = null;
    [SerializeField] IA_SightComponent sight = null;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void Init()
    {
        fsm.InitFSM(this, StartingState);

        movement = GetComponent<IA_MovementComponent>();
        sight = GetComponent<IA_SightComponent>();

        sight.OnTargetDetected += movement.SetTarget;
    }
}
