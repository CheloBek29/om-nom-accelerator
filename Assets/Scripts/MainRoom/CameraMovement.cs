using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float m_sensivityX = 1f;
    [SerializeField] private float m_sensivityY = 1f;

    private Transform _cameraTransform;

    private void Awake()
    {
        _cameraTransform = gameObject.GetComponent<Transform>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        _cameraTransform.Rotate(Vector3.up * mouseX * m_sensivityX + Vector3.left * mouseY * m_sensivityY);
        Vector3 currEulerAngles = _cameraTransform.eulerAngles;
        currEulerAngles.z = 0f;
        _cameraTransform.eulerAngles = currEulerAngles;
    }
}
