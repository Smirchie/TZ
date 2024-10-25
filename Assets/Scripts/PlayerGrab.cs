using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform hand;
    [SerializeField] private float pickUpRange = 1.5f;
    private GameObject pickedItem;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (pickedItem != null)
            {
                DropItem();
            }
            else
            {
                FindItemToPickUp();
            }
        }
    }

    private void DropItem()
    {
        pickedItem.transform.SetParent(null);
        pickedItem.GetComponent<BoxCollider>().enabled = true;
        pickedItem.GetComponent<Rigidbody>().isKinematic = false;
        pickedItem = null;
    }

    private void FindItemToPickUp()
    {
        var ray = playerCamera.ViewportPointToRay(Vector3.one * 0.5f);
        if (Physics.Raycast(ray, out RaycastHit hit, pickUpRange))
        {
            var item = hit.transform.gameObject;
            if (item.CompareTag("PickableItem"))
            {
                PickUpItem(item);
            }
        }
    }

    private void PickUpItem(GameObject item)
    {
        pickedItem = item;
        pickedItem.GetComponent<Rigidbody>().isKinematic = true;
        pickedItem.GetComponent<BoxCollider>().enabled = false;
        pickedItem.transform.SetParent(hand);
        pickedItem.transform.position = hand.position;
    }
}