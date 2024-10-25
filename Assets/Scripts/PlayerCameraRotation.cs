using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRotation : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float cameraSensitivity = 35f;
    [SerializeField] private float xRotationLimit =90f;
    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        xRotation -= Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -xRotationLimit, xRotationLimit);
        cameraTransform.eulerAngles = new Vector3(xRotation, yRotation, 0f);
    }
}