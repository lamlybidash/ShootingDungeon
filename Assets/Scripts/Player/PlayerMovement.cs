using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystickMove;
    [SerializeField] private FixedJoystick _joystickShoot;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rb;


    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_joystickMove.Horizontal * _moveSpeed, _joystickMove.Vertical * _moveSpeed);
        //Flip
        if(_joystickShoot.Direction.magnitude > 0.1f)   //Có input shoot
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
            if(_joystickMove.Direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (_joystickMove.Direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
