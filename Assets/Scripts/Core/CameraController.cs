using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target")]
    public Transform target; // Player

    [Header("Settings")]
    public float smoothSpeed = 0.125f; // tốc độ mượt (0.1 -> 0.2 là đẹp)
    public Vector3 offset;             // khoảng cách lệch giữa camera và player

    [Header("Clamp (Optional)")]
    public bool useLimits = false;
    public Vector2 minPosition; // Giới hạn trái dưới
    public Vector2 maxPosition; // Giới hạn phải trên

    private void LateUpdate()
    {
        if (target == null) return;

        // Vị trí mong muốn
        Vector3 desiredPosition = target.position + offset;

        // Làm mượt bằng Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Giới hạn camera trong map (nếu bật useLimits)
        if (useLimits)
        {
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minPosition.x, maxPosition.x);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minPosition.y, maxPosition.y);
        }

        // Cập nhật camera
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
