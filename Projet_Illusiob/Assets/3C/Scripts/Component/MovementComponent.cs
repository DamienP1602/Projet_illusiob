using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class MovementComponent : MonoBehaviour
{
    public event Action<float, float> OnStaminaChanged = null;
    InputComponent inputs = null;
    Player player = null;
    [SerializeField] float moveSpeed = 0.0f, maxMoveSpeed = 5.0f, speedFactor = 2.0f, zeroSpeed = 0.0f, maxMoveSpeedSprinting = 7.5f;
    [SerializeField] float currentStamina = 100.0f, maxStamina = 100.0f, minStamina = 0.0f, staminaSpeed = 2.0f;
    [SerializeField] bool canMove = true, isSprinting = false;
    [SerializeField] bool onGround = true;
    Rigidbody rb = null;
    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<InputComponent>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        inputs.JumpAction.performed += Jump;
        inputs.SprintAction.started += UpdateSprintValue;
        inputs.SprintAction.canceled += UpdateSprintValue;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!canMove) return;
        float _dir = inputs.MoveAction.ReadValue<float>();
        float _maxMoveSpeedTemp = isSprinting ? maxMoveSpeedSprinting : maxMoveSpeed; // spriting lead to change the current max speed 
        currentStamina = StaminaSystem(_dir, currentStamina, maxStamina, minStamina); //manage the stamina loss and gain system
        OnStaminaChanged?.Invoke(currentStamina,maxStamina);
        if (_dir == zeroSpeed) // if no movement
        {
            moveSpeed -= Time.deltaTime * speedFactor * _maxMoveSpeedTemp; //lose speed by time elapsed
            moveSpeed = Clamp(moveSpeed, _maxMoveSpeedTemp, zeroSpeed); //clamp the moveSpeed value
            return;
        }
        moveSpeed += Time.deltaTime * speedFactor; //occure a smooth transition for walking
        moveSpeed = Clamp(moveSpeed, _maxMoveSpeedTemp, zeroSpeed); //clamp the moveSpeed value
        transform.position += new Vector3(_dir, zeroSpeed, zeroSpeed) * moveSpeed * Time.deltaTime;
    }

    void Jump(InputAction.CallbackContext _context)
    {
        if (!onGround) return;
        rb.AddForce(new Vector3(0.0f, 350.0f, 0.0f));
    }

    void UpdateSprintValue(InputAction.CallbackContext _context)
    {
        isSprinting = _context.ReadValueAsButton();
    }

    //method that clamp a value between a max and min value
    float Clamp(float _toClamp, float _max, float _min) => _toClamp = _toClamp > _max ? _max : _toClamp < _min ? _min : _toClamp;

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        transform.parent = collision.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
        transform.parent = null;
    }

    float StaminaSystem(float _dir, float _toClamp, float _max, float _min)
    {
        if (isSprinting)
        {
            if (_dir == zeroSpeed)
            {
                //if the player is sprinting without movement he gain stamina
                _toClamp += Time.deltaTime * staminaSpeed;
                return Clamp(_toClamp, _max, _min);
            }
                //if the player is sprinting with movement he lose stamina
                _toClamp -= Time.deltaTime * staminaSpeed;
            return Clamp(_toClamp, _max, _min);
        }
        else
        {
            if (_dir != zeroSpeed)
            {
                //if the player is not sprinting with movement he gain stamina
                _toClamp += Time.deltaTime * staminaSpeed;
                return Clamp(_toClamp, _max, _min);
            }
                //if the player is not sprinting without movement he gain stamina
            _toClamp += Time.deltaTime * staminaSpeed;
            return Clamp(_toClamp, _max, _min);
        }

    }
}
