using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
// using UnityEngine.InputSystem;

public class FreeLookCamera : MonoBehaviour
{
    public float Pitch { get; private set; }
    public float Yaw { get; private set; }
    public float mouseSensitivity = 1f;

    public void UpdateRotation()
    {
        Yaw += Input.GetAxis("Mouse X") * mouseSensitivity * 0.2f;
        Pitch += Input.GetAxis("Mouse Y") * mouseSensitivity * 0.2f;
        Pitch = Mathf.Clamp(value: Pitch, min: 20, max: 70);

        transform.rotation = Quaternion.Euler(x: Pitch, y: Yaw, z: 0);
    }
    private void Update()
    {
        UpdateRotation();
    }
}