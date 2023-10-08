using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    private Vector3 deltaXY;
    private float deltaZ;

    private bool isMoving;
    private bool isScrolling;

    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float zoomSpeed = 50f;
    public void OnLook(InputAction.CallbackContext context)
    {
        deltaXY = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        isMoving = context.started || context.performed;
    }

    public void OnScroll(InputAction.CallbackContext context)
    {
        isScrolling = context.started || context.performed;
        deltaZ = context.ReadValue<float>();
       // Debug.Log(deltaZ);
    }

    private void LateUpdate()
    {
        if (isMoving)
        {
            var position = transform.right * (deltaXY.x * -movementSpeed);
            position += transform.up * (deltaXY.y * -movementSpeed);
            transform.position += position * Time.deltaTime;
        }

        if (isScrolling)
        {
            if (deltaZ > 0)
                Camera.main.orthographicSize -= zoomSpeed * Time.deltaTime;
            else if (deltaZ < 0)
                Camera.main.orthographicSize += zoomSpeed * Time.deltaTime;
        }
    }
}
