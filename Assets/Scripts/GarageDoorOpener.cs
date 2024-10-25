using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoorOpener : MonoBehaviour
{
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;
    [SerializeField] private float openSpeed;
    [SerializeField] private float openAngle=90f;

    private void Update()
    {
        Vector3 rotationVector = new (0f, openSpeed * Time.deltaTime);
        if(leftDoor.rotation.eulerAngles.y<=openAngle)
        {
            leftDoor.Rotate(rotationVector);
            rightDoor.Rotate(-rotationVector);
        }
    }
}
