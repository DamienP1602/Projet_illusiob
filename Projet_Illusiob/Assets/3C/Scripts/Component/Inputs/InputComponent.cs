using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    IA_Player controls = null;

    InputAction moveAction = null;
    InputAction jumpAction = null;
    InputAction sprintAction = null;
    
    public InputAction MoveAction => moveAction;
    public InputAction JumpAction => jumpAction;
    public InputAction SprintAction => sprintAction;

    private void Awake()
    {
        controls = new IA_Player();
    }

    private void OnEnable()
    {
        moveAction = controls.Player.Move;
        moveAction.Enable();
        jumpAction = controls.Player.Jump;
        jumpAction.Enable();
        sprintAction = controls.Player.Sprint;
        sprintAction.Enable();
    }
}
