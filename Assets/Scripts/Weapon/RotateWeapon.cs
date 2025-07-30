using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    public FixedJoystick joystick; // Gán joystick từ Inspector
    public float angleOffset = 0f; // Nếu mũi tên ban đầu không trỏ lên

    void Update()
    {
        Vector2 direction = joystick.Direction;

        // Nếu joystick có input
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (direction.magnitude > 0.1f)
        {
            int flipY = 0;
            if(joystick.Direction.x > 0)
            {
                flipY = 0;
            }
            if (joystick.Direction.x < 0)
            {
                flipY = 180;
                angle = 180 - angle;
            }
            transform.rotation = Quaternion.Euler(0, flipY, angle + angleOffset);
        }
    }
}
