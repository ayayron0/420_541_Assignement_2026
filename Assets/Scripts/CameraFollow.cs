using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset = new Vector3(0f, 1.5f, 0f);
    public float distance = 5f;
    public float sensitivityX = 3f;
    private float currentYaw;
    public float sensitivityY = 3f;
    public float minPitch = -20f;
    public float maxPitch = 80f;
    private float currentPitch;
    public float smoothTime = 0.1f;
    private Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        currentYaw = transform.eulerAngles.y;
        currentPitch = transform.eulerAngles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void LateUpdate()
    {
        if (target == null){ 
            return;
        }

        currentYaw += Input.GetAxis("Mouse X") * sensitivityX;
        currentPitch -= Input.GetAxis("Mouse Y") * sensitivityY;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        Quaternion targetRotation = Quaternion.Euler(currentPitch, currentYaw, 0f);

        Vector3 focusPoint = target.position + targetOffset;

        Vector3 desiredPosition = focusPoint - (targetRotation * Vector3.forward * distance);

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);

        transform.LookAt(focusPoint);
    }
}
