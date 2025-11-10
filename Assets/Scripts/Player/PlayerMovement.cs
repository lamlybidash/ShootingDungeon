using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystickMove;
    [SerializeField] private FixedJoystick _joystickShoot;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rb;

    private Animator _animator;


    private bool old_status;
    private bool new_status;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        old_status = !new_status;
    }

    private void FixedUpdate()
    {
        MoveF();
    }

    private void MoveF()
    {
        _rb.velocity = new Vector2(_joystickMove.Horizontal * _moveSpeed, _joystickMove.Vertical * _moveSpeed);
        SetAnimationF();
        FlipF();
    }

    private void FlipF()
    {
        if (_joystickShoot.Direction.magnitude > 0.1f)   //Có input shoot
        {
            if (_joystickShoot.Direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            if (_joystickShoot.Direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            if (_joystickMove.Direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (_joystickMove.Direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void SetAnimationF()
    {
        if (_joystickMove.Direction.magnitude >= 0.01f)
        {
            new_status = true;
        }
        else
        {
            new_status = false;
        }

        if (old_status != new_status)
        {
            old_status = new_status;
            _animator.SetBool("Run", new_status);
        }
    } 
}
