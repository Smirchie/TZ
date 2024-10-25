using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6.0F;
    [SerializeField] private float groundedY = 0f;
    [SerializeField] private Transform cameraTransform;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
        if (transform.position.y > groundedY || transform.position.y < groundedY)
        {
            transform.position = new Vector3(transform.position.x, groundedY, transform.position.z);
        }
    }
}